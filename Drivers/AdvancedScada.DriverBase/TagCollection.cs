using AdvancedScada.DriverBase.Devices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedScada.DriverBase
{
    public static class TagCollection
    {
        private static Dictionary<string, Tag> _Tags = new Dictionary<string, Tag>();

        public static Dictionary<string, Tag> Tags
        {
            get { return _Tags; }
            set { _Tags = value; }
        }
    }
}
