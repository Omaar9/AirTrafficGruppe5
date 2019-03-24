using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ATMClasses.Decoding;

namespace ATMClasses
{
    public class Filter : IFilter
    {

            public Dictionary<string, IUpdate> _dictionaryUpdate { get; }
            public Dictionary<string, ITrack> _dictionaryTrack { get; set; }
            public event EventHandler<TrackEvent> TrackEdited;
            public List<IUpdate> _uTracks { get; set; }
        //public object updateDic { get; set; }


        //Skal subscribe på event i constructor

        public Filter(IDecoding decoding)
            {
             _dictionaryTrack = new Dictionary<string, ITrack>();
             _dictionaryUpdate = new Dictionary<string, IUpdate>();
             decoding._updateCreated += OnUpdateCreated;
             _uTracks = new List<IUpdate>();
            }
        //Event som skal kaldes, når der laves nyt UpdateObjekt
        public void OnUpdateCreated(object sender, UpdateEvent uTrack)
        {
            _uTracks = uTrack.updatetracks;
            foreach (IUpdate updateTrack in _uTracks)
            {
                // Dummy kode, bruges bare til at være sikker på at event virker
                //Console.WriteLine("Event raised - updatetrack recieved: " + updateTrack.Tag);

                if (_dictionaryUpdate.ContainsKey(updateTrack._tag))
                {
                    if (updateTrack.InAirspace)
                    {
                        CreateTrack(updateTrack);
                    }
                    else
                    {
                        if (_dictionaryUpdate[updateTrack._tag].InAirspace)
                        {
                            RemoveTrack(updateTrack._tag);
                        }
                        else
                        {
                            _dictionaryUpdate[updateTrack._tag] = updateTrack;
                        }
                    }
                }
                else
                {
                    _dictionaryUpdate.Add(updateTrack._tag, updateTrack);
                }

            }
        }
       

            public void RemoveTrack(string tag)
            {
                _dictionaryUpdate.Remove(tag);
                _dictionaryTrack.Remove(tag);

                onTrackEdited(_dictionaryTrack);
            }


            public void CreateTrack(IUpdate updateTrack)
            {
                if (_dictionaryTrack.ContainsKey(updateTrack._tag))
                {
                    _dictionaryTrack[updateTrack._tag] = new Track(_dictionaryUpdate[updateTrack._tag], updateTrack);
                }
                else
                {
                    _dictionaryTrack.Add(updateTrack._tag, new Track(_dictionaryUpdate[updateTrack._tag], updateTrack));
                }
                _dictionaryUpdate[updateTrack._tag] = updateTrack;

                onTrackEdited(_dictionaryTrack);

            }

            protected virtual void onTrackEdited(Dictionary<String, ITrack> t)
            {
                TrackEdited?.Invoke(this, new TrackEvent() { tracks = t });
            }
    }

        public class TrackEvent : EventArgs
        {
            public Dictionary<String, ITrack> tracks { get; set; }
        }
    
}

