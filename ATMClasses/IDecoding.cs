﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMClasses
{
    public interface IDecoding
    {
        event EventHandler<UpdateEvent> _updateTrackCreated;

        void Seperater(string track);
    }
}
