﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Config
{
    public class ConfigElement
    {
        string value;
        public ConfigElement(string value)
        {
            this.value = value;
        }
        public string Value => value;
    }
}
