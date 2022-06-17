using System.Collections.Generic;
using MessengerRandomizerMappingGenerator.RandomizerGeneration.RO;

namespace MessengerRandomizerMappingGenerator.RandomizerGeneration.Constants
{
    class RandomizerConstants
    {

        public static List<string> GetNotesList()
        {
            List<string> notes = new List<string>();

            notes.Add("Key_Of_Hope");
            notes.Add("Key_Of_Chaos");
            notes.Add("Key_Of_Courage");
            notes.Add("Key_Of_Love");
            notes.Add("Key_Of_Strength");
            notes.Add("Key_Of_Symbiosis");

            return notes;
        }


        public static List<string> GetRandoItemList()
        {
            List<string> randomizedItems = new List<string>();

            randomizedItems.Add("Windmill_Shuriken");
            randomizedItems.Add("Wingsuit");
            randomizedItems.Add("Rope_Dart");
            randomizedItems.Add("Ninja_Tabis");
            randomizedItems.Add("Candle");
            randomizedItems.Add("Seashell");
            randomizedItems.Add("Power_Thistle");
            randomizedItems.Add("Demon_King_Crown");
            randomizedItems.Add("Ruxxtin_Amulet");
            randomizedItems.Add("Fairy_Bottle");
            randomizedItems.Add("Sun_Crest");
            randomizedItems.Add("Moon_Crest");
            randomizedItems.Add("Necro");
            randomizedItems.Add("Pyro");
            randomizedItems.Add("Claustro");
            randomizedItems.Add("Acro");

            return randomizedItems;
        }
        
        /*
        public static List<RandoItemRO> GetAdvancedRandoItemList()
        {
            List<RandoItemRO> randomizedItems = new List<RandoItemRO>();

            randomizedItems.Add("Money_Wrench");

            randomizedItems.Add(new RandoItemRO("Timeshard_1", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_2", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_3", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_4", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_5", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_6", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_7", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_8", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_9", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_10", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_11", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_12", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_13", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_14", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_15", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_16", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_17", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_18", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_19", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_20", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_21", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_22", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_23", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_24", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_25", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_26", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_27", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_28", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_29", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_30", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_31", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_32", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_33", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_34", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_35", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_36", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_37", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_38", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_39", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_40", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_41", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_42", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_43", EItems.TIME_SHARD));
            randomizedItems.Add(new RandoItemRO("Timeshard_44", EItems.TIME_SHARD));

            return randomizedItems;
        }
        */

        public static List<LocationRO> GetRandoLocationList()
        {
            //Create a LocationRO for every check and put it in a list
            List<LocationRO> randomizedLocations = new List<LocationRO>();
            //Phase 1 section, no key items required
            randomizedLocations.Add(new LocationRO("Seashell"));
            randomizedLocations.Add(new LocationRO("Ninja_Tabis"));
            randomizedLocations.Add(new LocationRO("Rope_Dart"));
            randomizedLocations.Add(new LocationRO("Wingsuit"));
            randomizedLocations.Add(new LocationRO("Key_Of_Love", "Key_Of_Love", new string[] { "Sun_Crest", "Moon_Crest" }, false, false, false));
            randomizedLocations.Add(new LocationRO("Key_Of_Courage", "Key_Of_Courage", new string[] { "Demon_King_Crown", "Fairy_Bottle" }, false, false, false));
            //Tabi locked section
            randomizedLocations.Add(new LocationRO("Key_Of_Chaos", "Key_Of_Chaos", new string[] {}, false, false, true));
            randomizedLocations.Add(new LocationRO("Sun_Crest", "Sun_Crest", new string[] {}, false, false, true));
            randomizedLocations.Add(new LocationRO("Moon_Crest", "Moon_Crest", new string[] {}, false, false, true));
            randomizedLocations.Add(new LocationRO("Pyro", "Pyro", new string[] {}, false, false, true));
            //Wingsuit locked section
            randomizedLocations.Add(new LocationRO("Acro", "Acro", new string[] {"Ruxxtin_Amulet"}, true, false, false));
            randomizedLocations.Add(new LocationRO("Necro", "Necro", new string[] {}, true, false, false));
            randomizedLocations.Add(new LocationRO("Ruxxtin_Amulet", "Ruxxtin_Amulet", new string[] {}, true, false, false));
            randomizedLocations.Add(new LocationRO("Candle", "Candle", new string[] {}, true, false, false));
            randomizedLocations.Add(new LocationRO("Claustro", "Claustro", new string[] {}, true, false, false));
            randomizedLocations.Add(new LocationRO("Climbing_Claws", "Climbing_Claws", new string[] {}, true, false, false));
            randomizedLocations.Add(new LocationRO("Demon_King_Crown", "Demon_King_Crown", new string[] { "Necro", "Claustro", "Pyro", "Acro" }, true, false, false, false));
            //Rope Dart locked section
            randomizedLocations.Add(new LocationRO("Key_Of_Symbiosis", "Key_Of_Symbiosis", new string[] { "Fairy_Bottle" }, false, true, false));
            //This section needs either the Wingsuit OR the Ropedart (plus other items). If you have one you are good.
            randomizedLocations.Add(new LocationRO("Key_Of_Strength", "Key_Of_Strength", new string[] { "Power_Thistle" }, false, false, false, true));
            randomizedLocations.Add(new LocationRO("Power_Thistle", "Power_Thistle", new string[] {}, false, false, false, true));
            randomizedLocations.Add(new LocationRO("Fairy_Bottle", "Fairy_Bottle", new string[] {}, false, false, false, true));
            //Wingsuit AND Ropedart locked
            randomizedLocations.Add(new LocationRO("Key_Of_Hope", "Key_Of_Hope", new string[] {}, true, true, false));

            return randomizedLocations;
        }

        public static List<LocationRO> GetAdvancedRandoLocationList()
        {
            //Create a LocationRO for every check and put it in a list
            List<LocationRO> advancedRandomizedLocations = new List<LocationRO>();

            //Adding seal locations

            //Ninja Village
            advancedRandomizedLocations.Add(new LocationRO("-436-404-44-28", "Ninja Village Seal - Tree House", new string[] {}, true, true, false)); //Tree House
            //Autumn Hills
            advancedRandomizedLocations.Add(new LocationRO("-52-20-60-44", "Autumn Hills Seal - Trip Saws", new string[] {}, true, false, false)); //Trip Saws
            advancedRandomizedLocations.Add(new LocationRO("556588-44-28", "Autumn Hills Seal - Double Swing Saws", new string[] {}, true, false, false)); //Double Swing Saws
            advancedRandomizedLocations.Add(new LocationRO("748780-76-60", "Autumn Hills Seal - Spike Ball Swing", new string[] {}, true, false, false)); //Spike Ball Swing
            advancedRandomizedLocations.Add(new LocationRO("748780-108-76", "Autumn Hills Seal - Spike Ball Darts", new string[] {}, true, false, false)); //Spike Ball Darts - also requires Acrobatic Warrior upgrade
            //Catacombs
            advancedRandomizedLocations.Add(new LocationRO("236268-44-28", "Catacombs Seal - Triple Spike Crushers", new string[] {}, true, false, false)); //Triple Spike Crushers
            advancedRandomizedLocations.Add(new LocationRO("492524-44-28", "Catacombs Seal - Crusher Gauntlet", new string[] {}, true, false, false)); //Crusher Gauntlet
            advancedRandomizedLocations.Add(new LocationRO("556588-60-44", "Catacombs Seal - Dirty Pond", new string[] {}, true, false, false)); //Dirty Pond
            //Bamboo Creek
            advancedRandomizedLocations.Add(new LocationRO("-84-52-28-12", "Bamboo Creek Seal - Spike crushers and Doors", new string[] {}, true, false, false)); //Spike crushers and Doors
            advancedRandomizedLocations.Add(new LocationRO("172236-44-28", "Bamboo Creek Seal - Spike ball pits", new string[] {}, true, false, false)); //Spike ball pits
            advancedRandomizedLocations.Add(new LocationRO("300332-1236", "Bamboo Creek Seal - Spike crushers and Doors v2", new string[] {}, true, false, false)); //Spike crushers and doors v2
            //Howling Grotto
            advancedRandomizedLocations.Add(new LocationRO("108140-28-12", "Howling Grotto Seal - Windy Saws and Balls", new string[] {}, false, false, false)); //Windy Saws and Balls
            advancedRandomizedLocations.Add(new LocationRO("300332-92-76", "Howling Grotto Seal - Crushing Pits", new string[] {}, false, false, false)); //Crushing Pits
            advancedRandomizedLocations.Add(new LocationRO("460492-172-156", "Howling Grotto Seal - Breezy Crushers", new string[] {}, false, false, false)); //Breezy Crushers
            //Quillshroom Marsh
            advancedRandomizedLocations.Add(new LocationRO("204236-28-12", "Quillshroom Marsh Seal - Spikey Window", new string[] {}, false, false, false)); //Spikey Window
            advancedRandomizedLocations.Add(new LocationRO("652684-60-28", "Quillshroom Marsh Seal - Sand Trap", new string[] {}, false, false, false)); //Sand Trap
            advancedRandomizedLocations.Add(new LocationRO("940972-28-12", "Quillshroom Marsh Seal - Do the Spike Wave", new string[] {}, false, false, false)); //Do the Spike Wave
            //Searing Crags
            advancedRandomizedLocations.Add(new LocationRO("761085268", "Searing Crags Seal - Triple Ball Spinner", new string[] {}, false, false, false, true)); //Triple Ball Spinner
            advancedRandomizedLocations.Add(new LocationRO("300332196212", "Searing Crags Seal - Raining Rocks", new string[] {}, false, false, false, true)); //Raining Rocks
            advancedRandomizedLocations.Add(new LocationRO("364396292308", "Searing Crags Seal - Rythym Rocks", new string[] {}, false, false, false, true)); //Rythym Rocks
            //Glacial Peak
            advancedRandomizedLocations.Add(new LocationRO("140172-492-476", "Glacial Peak Seal - Ice Climbers", new string[] {}, false, true, false)); //Ice Climbers
            advancedRandomizedLocations.Add(new LocationRO("236268-396-380", "Glacial Peak Seal - Projectile Spike Pit", new string[] {}, false, false, false, true)); //Projectile Spike Pit
            advancedRandomizedLocations.Add(new LocationRO("236268-156-140", "Glacial Peak Seal - Glacial Air Swag", new string[] {}, false, false, false, true)); //Glacial Air Swag
            //TowerOfTime
            advancedRandomizedLocations.Add(new LocationRO("-84-522036", "TowerOfTime Seal - Time Waster Seal", new string[] {}, false, true, false)); //Time Waster Seal
            advancedRandomizedLocations.Add(new LocationRO("7610852116", "TowerOfTime Seal - Lantern Climb", new string[] {}, true, false, false)); //Lantern Climb
            advancedRandomizedLocations.Add(new LocationRO("-52-20116132", "TowerOfTime Seal - Arcane Orbs", new string[] {}, true, true, false)); //Arcane Orbs
            //Cloud Ruins
            advancedRandomizedLocations.Add(new LocationRO("-148-116420", "Cloud Ruins Seal - Ghost Pit", new string[] { "Ruxxtin_Amulet" }, true, false, false)); //Ghost Pit
            advancedRandomizedLocations.Add(new LocationRO("108140-44-28", "Cloud Ruins Seal - Toothbrush Alley", new string[] { "Ruxxtin_Amulet" }, true, false, false)); //Toothbrush Alley
            advancedRandomizedLocations.Add(new LocationRO("748780-44-28", "Cloud Ruins Seal - Saw Pit", new string[] { "Ruxxtin_Amulet" }, true, false, false)); //Saw Pit
            advancedRandomizedLocations.Add(new LocationRO("11321164-124", "Cloud Ruins Seal - Money Farm Room", new string[] { "Ruxxtin_Amulet" }, true, false, false)); //Money Farm Room
            //Underworld
            advancedRandomizedLocations.Add(new LocationRO("-276-244-444", "Underworld Seal - Sharp and Windy Climb", new string[] {}, true, false, true)); //Sharp and Windy Climb
            advancedRandomizedLocations.Add(new LocationRO("-180-148-44-28", "Underworld Seal - Spike Wall", new string[] {}, false, false, true)); //Spike Wall
            advancedRandomizedLocations.Add(new LocationRO("-180-148-60-44", "Underworld Seal - Fireball Wave", new string[] {}, true, false, true)); //Fireball Wave - also requires Acrobatic Warrior upgrade
            advancedRandomizedLocations.Add(new LocationRO("-2012-124", "Underworld Seal - Rising Fanta", new string[] {}, false, true, true)); //Rising Fanta
            //Forlorn Temple
            advancedRandomizedLocations.Add(new LocationRO("172268-284", "Forlorn Temple Seal - Rocket Maze", new string[] { "Necro", "Claustro", "Pyro", "Acro" }, true, false, false)); //Rocket Maze
            advancedRandomizedLocations.Add(new LocationRO("140172100164", "Forlorn Temple Seal - Rocket Sunset", new string[] { "Necro", "Claustro", "Pyro", "Acro" }, true, false, false)); //Rocket Sunset
            //Sunken Shrine
            advancedRandomizedLocations.Add(new LocationRO("204236-124", "Sunken Shrine Seal - Ultra Lifeguard", new string[] {}, false, false, false)); //Ultra Lifeguard
            advancedRandomizedLocations.Add(new LocationRO("172268-188-172", "Sunken Shrine Seal - Waterfall Paradise", new string[] {}, false, false, true)); //Waterfall Paradise
            advancedRandomizedLocations.Add(new LocationRO("-148-116-124-60", "Sunken Shrine Seal - Tabi Gauntlet", new string[] {}, false, false, true)); //Tabi Gauntlet
            //Reviere Turquoise
            advancedRandomizedLocations.Add(new LocationRO("844876-284", "Reviere Turquoise Seal - Bounces and Balls", new string[] {}, false, false, false)); //Bounces and Balls
            advancedRandomizedLocations.Add(new LocationRO("460492-124-108", "Reviere Turquoise Seal - Launch of Faith", new string[] {}, false, false, false)); //Launch of Faith
            advancedRandomizedLocations.Add(new LocationRO("-180-1483668", "Reviere Turquoise Seal - Flower Power", new string[] {}, false, false, false, true)); //Flower Power
            //Elemental Skylands
            advancedRandomizedLocations.Add(new LocationRO("-52-20420436", "Elemental Skylands Seal - Air Seal", new string[] { "Fairy_Bottle" }, true, false, false)); //Air Seal
            advancedRandomizedLocations.Add(new LocationRO("18361868372388", "Elemental Skylands Seal - Water Seal", new string[] { "Fairy_Bottle" }, false, true, false)); //Water Seal - Needs water dash
            advancedRandomizedLocations.Add(new LocationRO("28602892356388", "Elemental Skylands Seal - Fire Seal", new string[] { "Fairy_Bottle" }, false, true, false)); //Fire Seal


            return advancedRandomizedLocations;
        }

        public static List<string> GetSpecialTriggerNames()
        {
            List<string> triggersToIgnoreRandoItemLogic = new List<string>();

            //LOAD (initally started as a black list of locations...probably would have been better to make this a whitelist...whatever)
            triggersToIgnoreRandoItemLogic.Add("CorruptedFuturePortal"); //Need to really check for crown and get access to CF
            triggersToIgnoreRandoItemLogic.Add("Lucioles"); //CF Fairy Check
            triggersToIgnoreRandoItemLogic.Add("DecurseQueenCutscene");
            triggersToIgnoreRandoItemLogic.Add("Bridge"); //Forlorn bridge check
            triggersToIgnoreRandoItemLogic.Add("NoUpgrade"); //Dark Cave Candle check
            triggersToIgnoreRandoItemLogic.Add("OverlayArt_16"); //...also Dark Cave Candle check
            //These are for the sprite renderings of phoebes
            triggersToIgnoreRandoItemLogic.Add("PhobekinNecro");
            triggersToIgnoreRandoItemLogic.Add("PhobekinNecro_16");
            triggersToIgnoreRandoItemLogic.Add("PhobekinAcro");
            triggersToIgnoreRandoItemLogic.Add("PhobekinAcro_16");
            triggersToIgnoreRandoItemLogic.Add("PhobekinClaustro");
            triggersToIgnoreRandoItemLogic.Add("PhobekinClaustro_16");
            triggersToIgnoreRandoItemLogic.Add("PhobekinPyro");
            triggersToIgnoreRandoItemLogic.Add("PhobekinPyro_16");
            //Parents of triggers to handle sassy interaction zones
            triggersToIgnoreRandoItemLogic.Add("Colos_8");
            triggersToIgnoreRandoItemLogic.Add("Suses_8");
            triggersToIgnoreRandoItemLogic.Add("Door");
            triggersToIgnoreRandoItemLogic.Add("RuxtinStaff");

            return triggersToIgnoreRandoItemLogic;
        }

        /*
        public static Dictionary<string, EItems> GetCutsceneMappings()
        {
            //This is where all the cutscene mappings will live. These mappings will mean that the cutscene requires additional logic to ensure it has "been played" or not.
            Dictionary<string, EItems> cutsceneMappings = new Dictionary<string, EItems>();

            //LOAD
            cutsceneMappings.Add("RuxxtinNoteAndAwardAmuletCutscene", EItems.RUXXTIN_AMULET);

            return cutsceneMappings;

        }
        */
    }
}
