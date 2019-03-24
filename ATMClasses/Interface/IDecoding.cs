using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ATMClasses.Decoding;

namespace ATMClasses
{
    public interface IDecoding
    {
        event EventHandler<UpdateEvent> _updateCreated;

        object _dictionaryUpdate { get; set; }
        //object TrackDic { get; set; }

        void Separater(string track);
    }
}
