using MessengerRandomizerMappingGenerator.RandomizerGeneration.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerRandomizerMappingGenerator.RandomizerGeneration.RO
{
    public class MappingJsonRO
    {
        public Dictionary<string, string>? Mappings { get; set; }
        public Dictionary<SettingType, SettingValue>? Settings { get; set; }
        public SeedType SeedType { get; set; }

    }
}
