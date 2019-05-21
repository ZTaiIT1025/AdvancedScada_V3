using AdvancedScada.DriverBase.Devices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdvancedScada.DriverBase.Client
{
    public class TagCollectionClient
    {
        public static Dictionary<string, Tag> Tags { get; set; } = new Dictionary<string, Tag>();
    }
    
}
