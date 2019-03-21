using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ATMClasses.Decoding;

namespace ATMClasses
{
    public interface IFilter
    {
        event EventHandler<TrackEvent> TrackEdited;
        List<IUpdate> _uTracks { get; set; }
        Dictionary<string, ITrack> _dictionaryTrack { get; }
        Dictionary<string, IUpdate> _dictionaryUpdate { get; }
        void CreateTrack(IUpdate _updateTrack);
        void onUpdateCreated(object source, UpdateEvent uTrack);
        void RemoveTrack(string tag);

   

    }
}
