using MessengerRandomizerMappingGenerator.RandomizerGeneration.Constants;
using System.Collections.Generic;
using System.Text;


namespace MessengerRandomizerMappingGenerator.RandomizerGeneration.RO
{
    public struct SeedRO
    {
        //seed number
        public int Seed { get; }

        // Type of seed so we know what logic to run against it.
        public SeedType SeedType { get; }

        // Settings
        public Dictionary<SettingType, SettingValue> Settings { get; }

        /*
        //Collected Items this seed
        public List<RandoItemRO> CollectedItems { set; get; }
        */

        /*
        public SeedRO(int fileSlot, SeedType seedType, int seed, Dictionary<SettingType, SettingValue> settings, List<RandoItemRO> collectedItems)
        {
            FileSlot = fileSlot;
            SeedType = seedType;
            Seed = seed;

            if (settings == null)
            {
                settings = new Dictionary<SettingType, SettingValue>();
            }
            Settings = settings;

            CollectedItems = collectedItems == null ? new List<RandoItemRO>() : collectedItems;
        }
        */

        public SeedRO(int seed, SeedType seedType, Dictionary<SettingType, SettingValue> settings)
        {
            Seed = seed;
            SeedType = seedType;

            if (settings == null)
            {
                //Handle wierd cases where settings are created right
                settings = new Dictionary<SettingType, SettingValue>();
            }

            Settings = settings;
        }

        public override string ToString()
        {
            //Set up settings string
            StringBuilder settingsSB = new StringBuilder();
            settingsSB.Append("Settings:'");
            foreach (SettingType key in Settings.Keys)
            {
                settingsSB.Append($"{key}={Settings[key]}");
                settingsSB.Append("&");
            }
            settingsSB.Append("'");

            //Set up collected items string
            StringBuilder collectedItemsSB = new StringBuilder();
            collectedItemsSB.Append("CollectedItems:'");
            settingsSB.Append("'");

            return $"{Seed}|{SeedType}|{settingsSB.ToString()}";
        }

        public override bool Equals(object obj)
        {
            return obj is SeedRO rO &&
                   SeedType == rO.SeedType &&
                   Seed == rO.Seed &&
                   EqualityComparer<Dictionary<SettingType, SettingValue>>.Default.Equals(Settings, rO.Settings);
        }

        public override int GetHashCode()
        {
            var hashCode = -514544316;
            hashCode = hashCode * -1521134295 + SeedType.GetHashCode();
            hashCode = hashCode * -1521134295 + Seed.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<Dictionary<SettingType, SettingValue>>.Default.GetHashCode(Settings);
            return hashCode;
        }
    }
}
