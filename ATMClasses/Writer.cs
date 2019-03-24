using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;


namespace ATMClasses
{
    public class Writer : IWriter
    {

        private List<ConditionDetecter> conditionTracks;
        public event EventHandler<SplitEvent> SplitCreation;
        public event EventHandler<SplitEvent> SplitCreated;

        public Dictionary<String, ITrack> tracks { get; set; }

        public Writer(IFilter trackfilter, List<ConditionDetecter> conditionTracks)
        {
            trackfilter.TrackEdited += onTrackEdited;
            //conditionTracks.SplitCreated += onSplitCreated;
           
        }

        public void onTrackEdited(object source, TrackEvent trackEvent)
        {
            tracks = trackEvent.tracks;
            conditionTracks = new List<ConditionDetecter>();

            List<ITrack> flight = new List<ITrack>();

            foreach (var track in trackEvent.tracks)
            {
                flight.Add(track.Value);
            }

            for (int i = 0; i < flight.Count; i++)
            {
                for (int j = i + 1; j < flight.Count; j++)
                {
                    if (Distance(flight[i], flight[j]) < 5000)
                    {
                        if (Math.Abs(flight[i]._altitude - flight[j]._altitude) < 300)
                        {
                            List<ITrack> condition = new List<ITrack>();
                            condition.Add(flight[i]);
                            condition.Add(flight[j]);
                            conditionTracks.Add(new ConditionDetecter(condition));
                        }
                    }
                }
            }

            if (conditionTracks.Count > 0)
            {
                onSplitCreated(conditionTracks);
            }
        }
        
        public double Distance(ITrack track1, ITrack track2)
        {
            double hyp1 = Math.Sqrt(Math.Pow((track1._xcoordinate - track2._xcoordinate), 2) + Math.Pow((track1._ycoordinate - track2._ycoordinate), 2));
            return Math.Abs(hyp1);
        }
        protected virtual void onSplitCreated(List<ConditionDetecter> condtiontracks)
        {
            SplitCreated?.Invoke(this, new SplitEvent() {ConditionDetecters = condtiontracks});
        }
        public class SplitEvent : EventArgs
        {
            public List<ConditionDetecter> ConditionDetecters { get; set; }
        }
        public void onSplitCreated(object source, SplitEvent condition)
        {
            Console.Clear();

            String[] l = new string[condition.ConditionDetecters.Count];

            for (int i = 0; i < condition.ConditionDetecters.Count; i++)
            {
                l[i] = "Flight are in DANGER";

                for (int j = 0; j < condition.ConditionDetecters[i]._detectingFligts.Count; j++)
                {
                    l[i] += condition.ConditionDetecters[i]._detectingFligts[j]._tag + ", ";
                }

                l[i] += condition.ConditionDetecters[i]._detectTime + ":" +
                        condition.ConditionDetecters[i]._detectTime.Millisecond;
            }

            for (int i = 0; i < l.Length; i++)
            {
                Console.WriteLine(l[i]);
            }
        
        }

        public void Write(Track track)
        {
            throw new NotImplementedException();
        }

        public void write()
        {
            throw new NotImplementedException();
        }
    }
}
