using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClasses
{
    public interface IFilter
    {
        event EventHandler<TrackEvent> _trackFiltered;

        List<IUpdate> _fTrack { get; set; }

        Dictionary<string, ITrack> _dictionaryTrack { get; }
        Dictionary<string, IUpdate> _dictionaryUpdate { get; }
        void TrackCreate(IUpdate _updateTrack);
        void onUpdateCreated(object source, UpdateEvent _fTrack);
        void TrackRemove(string tag);
    }
}
