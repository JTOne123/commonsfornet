﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commons.Messaging
{
    public interface IMessageConfig
    {
        IMessageConfig BindTo(string address);
    }
}
