using AdvancedScada.DriverBase.Devices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedScada.DriverBase
{
    public static class TagCollection
    {
        public static Dictionary<string, Tag> Tags { get; set; } = new Dictionary<string, Tag>();
    }
}
