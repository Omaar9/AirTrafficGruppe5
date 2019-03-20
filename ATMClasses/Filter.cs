using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClasses
{
    public class Filter : IFilter
    {
        public Dictionary<string, ITrack> _dictionaryTrack { get; set; }
        public Dictionary<string, IUpdate> _dictionaryUpdates { get; set; }

        public event EventHandler<TrackEvent> _trackFiltered;

        public List<IUpdate> _fTrack { get; set; }

        //Skal subscribe på event i constructor

        public Filter(IDecoding decoding)
        {
            _dictionaryTrack = new Dictionary<string, ITrack>();
            _dictionaryUpdates = new Dictionary<string, IUpdate>();
            _decoding._updateTrackCreated += onUpdateCreated;
            _fTrack = new List<IUpdate>();
        }


        //Event som skal kaldes, når der laves nyt pseudoObjekt
        public void onUpdateCreated(object source, UpdateEvent fTrack)
        {
            _fTrack = fTrack.updatetracks;
            foreach (IUpdate _updateTrack in _fTrack)
            {
                // Dummy kode, bruges bare til at være sikker på at event virker
                //Console.WriteLine("Event raised - pseudotrack recieved: " + pseudoTrack.Tag);

                if (_dictionaryUpdates.ContainsKey(_updateTrack._tag))
                {
                    if (_updateTrack._airspace)
                    {
                        TrackCreate(_updateTrack);
                    }
                    else
                    {
                        if (_dictionaryUpdates[_updateTrack._tag]._airspace)
                        {
                            TrackRemove(_updateTrack._tag);
                        }
                        else
                        {
                            _dictionaryUpdates[_updateTrack._tag] = _updateTrack;
                        }
                    }
                }
                else
                {
                    _dictionaryUpdates.Add(_updateTrack._tag, _updateTrack);
                }

            }

        }

        public void TrackRemove(string tag)
        {
            _dictionaryUpdates.Remove(tag);
            _dictionaryTrack.Remove(tag);

            onUpdateCreated(_dictionaryTrack);
        }


        public void TrackCreate(IUpdate _updatetrack)
        {
            if (_dictionaryTrack.ContainsKey(_updatetrack._tag))
            {
                _dictionaryTrack[_updatetrack._tag] = new Track(_dictionaryUpdates[_updatetrack._tag], _updatetrack);
            }
            else
            {
                _dictionaryTrack.Add(_updatetrack._tag, new Track(_dictionaryUpdates[_updatetrack._tag], _updatetrack));
            }
            _dictionaryUpdates[_updatetrack._tag] = _updatetrack;

            onTrackFiltered(_dictionaryTrack);

        }

        protected virtual void onTrackFiltered(Dictionary<String, ITrack> tracks)
        {
            _trackFiltered?.Invoke(this, new TrackEvent() { tracks = t});
        }

        public class TrackEvent : EventArgs
        {
            public Dictionary<String, ITrack> tracks { get; set; }
        }
    }
}
