using MessengerRandomizerMappingGenerator.RandomizerGeneration.Constants;
using MessengerRandomizerMappingGenerator.RandomizerGeneration.Exception;
using MessengerRandomizerMappingGenerator.RandomizerGeneration.RO;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MessengerRandomizerMappingGenerator.RandomizerGeneration
{
    /// <summary>
    /// Util class doing all the rando mapping generation work
    /// </summary>
    class RandomizerGenerator
    {

        private static List<LocationRO> randomizedLocations;
        private static List<string> randomizedItems;
        private static Dictionary<LocationRO, int> coinResults;
        private static Dictionary<LocationRO, string> locationToItemMapping;

        ///<summary> Used to represent all the required items to complete this seed, along with what they currently block. This is to prevent self locks.</summary>
        private static Dictionary<string, HashSet<string>> requiredItems;
        
        private static Random randomNumberGen;



        private static int REQUIRED_ITEM_PLACEMENT_ATTEMPT_LIMIT = 10;

        /// <summary>
        /// Generates the seed that will be used for mapping
        /// </summary>
        /// <returns>the seed for mapping</returns>
        public static int GenerateSeed()
        {
            int seed = (int)(DateTime.Now.Ticks & 0x0000DEAD);
            Console.WriteLine($"Seed '{seed}' generated.");
            return seed;
        }

        /// <summary>
        /// Main mapping generation function. 
        /// </summary>
        /// <param name="seed">Seed used to generate mapping</param>
        /// <returns>Mappings of locations to items</returns>
        public static Dictionary<LocationRO, string> GenerateRandomizedMappings(SeedRO seed)
        {
            Console.WriteLine($"Beginning mapping generation for seed '{seed.Seed}'.");

            //Initialze needed things
            randomizedLocations = new List<LocationRO>();
            randomizedItems = new List<string>();
            coinResults = new Dictionary<LocationRO, int>();
            locationToItemMapping = new Dictionary<LocationRO, string>();
            requiredItems = new Dictionary<string, HashSet<string>>();

            //We now have a seed. Let's initialize our locations and items lists.
            randomizedLocations = RandomizerConstants.GetRandoLocationList();
            randomizedItems = new List<string>(RandomizerConstants.GetRandoItemList());
            randomizedItems.AddRange(RandomizerConstants.GetNotesList());
            

            //Difficulty setting - if this is an advanced seed, add the other items and checks into the fray
            if (seed.Settings.ContainsKey(SettingType.Difficulty) && SettingValue.Advanced.Equals(seed.Settings[SettingType.Difficulty]))
            {
                //Advanced difficulty seed
                randomizedLocations.AddRange(RandomizerConstants.GetAdvancedRandoLocationList());
                
                //randomizedItems.AddRange(RandomizerConstants.GetAdvancedRandoItemList());
            }

            //Get our randomizer set up
            randomNumberGen = new Random(seed.Seed);


            //Begin filling out the mappings. Both collections need to logically be the same size.

            if (randomizedLocations.Count > randomizedItems.Count)
            {
                //During advanced item placement, there will be more locations than items. Fill in the rest of the spots with trash items.
                int difference = randomizedLocations.Count - randomizedItems.Count;

                for (int i = 0; i < difference; i++)
                {
                    randomizedItems.Add("Time_Shard");
                }
            }

            if (randomizedLocations.Count < randomizedItems.Count)
            {
                //This check is here to make sure nothing was missed during development and check/item counts remain consistent. This should never break during typical usage and should only happen when changes to the logic engine are occurring.
                throw new RandomizerException($"Mismatched number of items between randomized items({randomizedItems.Count}) and checks({randomizedLocations.Count}). Minous needs to correct this so the world can work again...");
            }
            
            


            //Let the mapping flows begin!
            switch (seed.SeedType)
            {
                case SeedType.No_Logic:
                    //No logic, fast map EVERYTHING!
                    FastMapping(randomizedItems);
                    Console.WriteLine("No-Logic mapping generation complete.");
                    break;
                case SeedType.Logic:
                    //Basic logic. Start by placing the notes then do the logic things!
                    FastMapping(RandomizerConstants.GetNotesList());
                    //Set up required items
                    //GetRequiredItemsFromMappings();

                    int logicalMappingAttempts = 1;
                    bool isLogicalMappingComplete = false;
                    do
                    {
                        if (logicalMappingAttempts > REQUIRED_ITEM_PLACEMENT_ATTEMPT_LIMIT)
                        {
                            throw new RandomizerException($"Logical mapping attempts amount exceeded. Check to make sure there are no bugs causing potential infinite loops in seed '{seed}'");
                        }

                        //Now that the notes have a home, lets get all the items we are going to need to collect them. We will do this potentially a few times to ensure that all required items are accounted for.
                        bool hasValidItemToMap = false;

                        while (!hasValidItemToMap)
                        {
                            GetRequiredItemsFromMappings();

                            string randomItemToMap = null;
                            bool isAllRequiredItemsMapped = true;
                            foreach (string randoItemRO in requiredItems.Keys)
                            {
                                if (!locationToItemMapping.ContainsValue(randoItemRO))
                                {
                                    //We have found an item that has not been mapped yet
                                    randomItemToMap = randoItemRO;
                                    isAllRequiredItemsMapped = false;
                                    break;
                                }
                            }

                            if (isAllRequiredItemsMapped)
                            {
                                //We are done!
                                isLogicalMappingComplete = true;
                                break;
                            }

                            bool isNote = false;
                            //Note check
                            foreach (string note in RandomizerConstants.GetNotesList())
                            {
                                if (note.Equals(randomItemToMap))
                                {
                                    //Tis a note, try again
                                    isNote = true;
                                    break;
                                }
                            }

                            hasValidItemToMap = !isNote;

                            if (!hasValidItemToMap)
                            {
                                continue;
                            }

                            if (hasValidItemToMap)
                            {
                                //Send these items through the logical mapper and get them a home
                                LogicalMapping(randomItemToMap);
                            }

                        }
                        ++logicalMappingAttempts;
                    }
                    while (!isLogicalMappingComplete);


                    //At this point we should be done with logical mapping. Let's cleanup the remaining items.
                    FastMapping(randomizedItems);
                    Console.WriteLine("Basic logic mapping completed.");
                    break;
            }
            //The mappings should be created now.
            return locationToItemMapping;
        }

        /// <summary>
        /// Performs mappings that do not care about logic
        /// </summary>
        /// <param name="items">List of items to map</param>
        private static void FastMapping(List<string> items)
        {
            //Setting up local list to make sure of what I am messing with.
            List<string> localItems = new List<string>(items);

            //randomly place passed items into available locations without checking logic requirements
            for (int itemIndex = randomNumberGen.Next(localItems.Count); localItems.Count > 0; itemIndex = randomNumberGen.Next(localItems.Count))
            {
                int locationIndex = randomNumberGen.Next(randomizedLocations.Count);
                Console.WriteLine($"Item Index '{itemIndex}' generated for item list with size '{localItems.Count}'. Locations index '{locationIndex}' generated for location list with size '{randomizedLocations.Count}'");
                locationToItemMapping.Add(randomizedLocations[locationIndex], localItems[itemIndex]);
                Console.WriteLine($"Fast mapping occurred. Added item '{localItems[itemIndex]}' at index '{itemIndex}' to check '{randomizedLocations[locationIndex].PrettyLocationName}' at index '{locationIndex}'.");
                //Removing mapped items and locations
                randomizedItems.Remove(localItems[itemIndex]); //Doing this just in case its in the main list
                Console.WriteLine($"Removing location at index '{locationIndex}' from location list sized '{randomizedLocations.Count}'");
                randomizedLocations.RemoveAt(locationIndex);
                Console.WriteLine($"Removing item at index '{itemIndex}' from items list sized '{localItems.Count}'");
                localItems.RemoveAt(itemIndex);
            }
            //All the passed items should now have a home
        }

        /// <summary>
        /// Collects the list required items from the existing mappings this run.
        /// </summary>
        /// <returns>The collection of required items for the existing mapping</returns>
        private static Dictionary<string, HashSet<string>> GetRequiredItemsFromMappings()
        {
            //Key Items set so I can control how many of those I choose to handle per run
            HashSet<string> keyItems = new HashSet<string>();

            foreach (LocationRO location in locationToItemMapping.Keys)
            {
                //Lets start interrogating the location object to see what items it has marked as required. Let's start with the key items.
                if (location.IsWingsuitRequired)
                {
                    AddRequiredItem("Wingsuit", location);
                    keyItems.Add("Wingsuit");
                }
                if (location.IsRopeDartRequired)
                {
                    AddRequiredItem("Rope_Dart", location);
                    keyItems.Add("Rope_Dart");
                }
                if (location.IsNinjaTabiRequired)
                {
                    AddRequiredItem("Ninja_Tabis", location);
                    keyItems.Add("Ninja_Tabis");
                }
                //Checking if either Wingsuit OR Rope Dart is required is a separate check.
                if (location.IsEitherWingsuitOrRopeDartRequired)
                {
                    //In this case, let's randomly pick one to be placed somewhere
                    int coin;
                    if (coinResults.ContainsKey(location))
                    {
                        coin = coinResults[location];
                        Console.WriteLine($"Coin previously flipped for location '{location.PrettyLocationName}'. Result was '{coin}'");
                    }
                    else
                    {
                        coin = randomNumberGen.Next(2);
                        Console.WriteLine($"Coin flipped! Result is '{coin}' for location '{location.PrettyLocationName}'");
                        coinResults.Add(location, coin);
                    }



                    switch (coin)
                    {
                        case 0://Wingsuit
                            AddRequiredItem("Wingsuit", location);
                            keyItems.Add("Wingsuit");
                            break;
                        case 1://Rope Dart
                            AddRequiredItem("Rope_Dart", location);
                            keyItems.Add("Rope_Dart");
                            break;
                        default://Something weird happened...just do wingsuit :P
                            AddRequiredItem("Wingsuit", location);
                            keyItems.Add("Wingsuit");
                            break;
                    }
                }

                //Next lets look through the other items. 
                foreach (string requiredItem in location.AdditionalRequiredItemsForCheck)
                {

                   
                    foreach (string randoItem in randomizedItems)
                    {
                        if (randoItem.Equals(requiredItem))
                        {
                            AddRequiredItem(randoItem, location);
                            break;
                        }
                    }

                    
                }
            }


            //In case a key item gets slated as a required item but it's already been mapped, we should remove it from our collections
            List<string> duplicateKeyItems = new List<string>(); //Have to capture the list to clean up AFTER the loop because C# says so. Can't modify the HashSet you are iterating. (Makes sense)
            foreach (string keyItem in keyItems)
            {
                if (!randomizedItems.Contains(keyItem))
                {
                    //This means that this key item was already mapped, we do not need to map it again
                    duplicateKeyItems.Add(keyItem);
                }
            }

            //Duplicate cleanup --- Pretty sure this is a problem. 
            foreach (string dupKeyItem in duplicateKeyItems)
            {
                //Cleanup
                keyItems.Remove(dupKeyItem);
            }


            //I was having a problem with some seeds setting all the key items at the beginning and not considering each other. I think how I will handle this is by only allowing one of them set each run through and throwing the rest out. I expect them to get picked up on subsequent runs.
            if (keyItems.Count > 1)
            {
                //This means I have more than 1 key item to process. Let's pick random ones to remove from the required items list until none remain.
                for (int i = randomNumberGen.Next(keyItems.Count); keyItems.Count > 1; i = randomNumberGen.Next(keyItems.Count))
                {
                    string itemToRemove = keyItems.ElementAt(i);
                    Console.WriteLine($"Found multiple key items during required item mapping. Tossing '{itemToRemove}' from this run.");
                    keyItems.Remove(itemToRemove);
                }
            }

            //Logging
            Console.WriteLine("For the provided checks: ");
            foreach (LocationRO location in locationToItemMapping.Keys)
            {
                Console.WriteLine(location.PrettyLocationName);
            }
            Console.WriteLine("Found these items to require for seed:");
            foreach (string requiredItem in requiredItems.Keys)
            {

                if (locationToItemMapping.Values.Contains(requiredItem))
                {
                    Console.WriteLine($"{requiredItem} (Mapped)");
                }
                else
                {
                    Console.WriteLine(requiredItem);
                }



                //I need to look through blocked items until there are no more for this item
                foreach (string blockedItem in requiredItems[requiredItem])
                {
                    Console.WriteLine($"\tWhich in turn blocks '{blockedItem}'");
                }
            }
            if (requiredItems.Count == 0)
            {
                Console.WriteLine("No required items found, returning an empty set!");
            }
            Console.WriteLine("Required item determination complete!");

            //All done!
            return requiredItems;
        }

        /// <summary>
        /// This utility function will help manage the temporary required item dictionary for me.
        /// </summary>
        /// <param name="item">item to add</param>
        /// <param name="location">location to add item to</param>
        private static void AddRequiredItem(string item, LocationRO location)
        {

            //Check to see if the item is already a key in the dictionary. If not, add it.
            if (!requiredItems.ContainsKey(item))
            {
                requiredItems.Add(item, new HashSet<string>());
            }

            requiredItems[item].Add(locationToItemMapping[location]);

            HashSet<string> blockerItems = new HashSet<string>();

            //Let's go through all the item blockers for the items our item blocks
            foreach (string blockedItem in requiredItems[item])
            {
                if (requiredItems.ContainsKey(blockedItem))
                {
                    HashSet<string> recursiveBlockedItems = new HashSet<string>();

                    if (requiredItems.TryGetValue(blockedItem, out recursiveBlockedItems))
                    {
                        //Let the recursion begin!
                        RecursiveBlockedItemCheck(recursiveBlockedItems, ref blockerItems);
                    }
                }
            }

            //Now that we're done with that nonsense, let's add what we've found
            foreach (string blockerItem in blockerItems)
            {
                requiredItems[item].Add(blockerItem);
            }
        }

        /// <summary>
        /// Recursively checks for all blocked items
        /// </summary>
        /// <param name="recursiveBlockedItems">Set of items that are blocking other items</param>
        /// <param name="blockerItems">Set of new blocking items to require</param>
        private static void RecursiveBlockedItemCheck(HashSet<string> recursiveBlockedItems, ref HashSet<string> blockerItems)
        {
            foreach (string recursiveBlockedItem in recursiveBlockedItems)
            {
                //There are situations where a few items might block each other. I'm putting something here to protect against an infinite loop for now.
                if (blockerItems.Contains(recursiveBlockedItem))
                {
                    //No need to add and look through again this run
                    return;
                }

                blockerItems.Add(recursiveBlockedItem);

                HashSet<string> evenMoreRecursiveBlockedItems = new HashSet<string>();

                //This is to recursively capture blocked items we caught on previous iterations so we can keep track of ALL blocked items
                if (requiredItems.TryGetValue(recursiveBlockedItem, out evenMoreRecursiveBlockedItems))
                {
                    RecursiveBlockedItemCheck(evenMoreRecursiveBlockedItems, ref blockerItems);
                }
            }
        }

        /// <summary>
        /// Will complete the mappings per item received. 
        /// This mapping takes in to account the required items for each location it tries to place an item into to avoid basic lockouts.
        /// </summary>
        private static void LogicalMapping(string item)
        {
            Console.WriteLine("|||Using Logical Mapping flow.|||");
            bool hasAHome = false;

            //create a new list based off the randomized locations list that has a randomized order. This will be used to placing things.
            List<LocationRO> tempRandoLocations = new List<LocationRO>(randomizedLocations);
            List<LocationRO> randoSortedLocations = new List<LocationRO>();
            
            //Populate new list
            for (int locationIndex = randomNumberGen.Next(tempRandoLocations.Count); tempRandoLocations.Count > 0; locationIndex = randomNumberGen.Next(tempRandoLocations.Count))
            {
                randoSortedLocations.Add(tempRandoLocations[locationIndex]);
                tempRandoLocations.RemoveAt(locationIndex);
            }

            //Find a home
            for (int i = 0; i < randoSortedLocations.Count; i++)
            {
                hasAHome = IsLocationSafeForItem(randoSortedLocations[i], item);
                //Check the item itself
                if (hasAHome)
                {
                    //Next we need to check the location for each and every item this item blocks. We need to catch the moment an item proves it cannot be here and mark it so we can move on.
                    foreach (string blockedItem in requiredItems[item])
                    {
                        hasAHome = IsLocationSafeForItem(randoSortedLocations[i], blockedItem);

                        if (!hasAHome)
                        {
                            break;
                        }
                    }
                }

                if (hasAHome)
                {
                    Console.WriteLine($"Found a home for item '{item}' at location '{randoSortedLocations[i].PrettyLocationName}'.");
                    locationToItemMapping.Add(randoSortedLocations[i], item);
                    randomizedLocations.Remove(randoSortedLocations[i]);
                    randomizedItems.Remove(item);
                    break;
                }
            }
            if (!hasAHome)
            {
                //Getting here means that we must have checked through all the remaining locations and that none of them could house an item we needed to place. For now let's throw an exception.
                throw new RandomizerNoMoreLocationsException("This seed was not completeable due to running out of locations to place things.");
            }

        }

        /// <summary>
        /// Checks to see if location is safe for item to be there
        /// </summary>
        /// <param name="location">Location to check</param>
        /// <param name="item">Item to check</param>
        /// <returns></returns>
        private static bool IsLocationSafeForItem(LocationRO location, string item)
        {
            bool isSafe = false;

            switch (item)
            {
                case "Wingsuit": //Try to find a home for wingsuit.
                    if (!location.IsWingsuitRequired)
                    {
                        //if a coin flip on this location hasn't happened yet, do it now.
                        if (!coinResults.ContainsKey(location))
                        {
                            coinResults.Add(location, randomNumberGen.Next(2));
                        }
                        //if the location is not a RDorWS check we are good
                        //If it IS a RDorWS check, check to see if it is locked based on RD(coin flip is 1) If it is we are good. 
                        isSafe = !(location.IsEitherWingsuitOrRopeDartRequired && coinResults[location] != 1);
                    }
                    break;
                case "Rope_Dart": //same for rope dart
                    if (!location.IsRopeDartRequired)
                    {
                        //if a coin flip on this location hasn't happened yet, do it now.
                        if (!coinResults.ContainsKey(location))
                        {
                            coinResults.Add(location, randomNumberGen.Next(2));
                        }

                        //if the location is not a RDorWS check we are good
                        //If it IS a RDorWS check, check to see if it is locked based on RD(coin flip is 1) If it is we are good. 
                        isSafe = !(location.IsEitherWingsuitOrRopeDartRequired && coinResults[location] == 1);
                    }
                    break;
                case "Ninja_Tabis": //Tabis, the check is more simple
                    if (!location.IsNinjaTabiRequired)
                    {
                        isSafe = true;
                    }
                    break;
                default: //All other required items
                    if (!location.AdditionalRequiredItemsForCheck.Contains(item))
                    {
                        isSafe = true;
                    }
                    break;
            }
            Console.WriteLine($"Item '{item}' is safe at Location '{location.PrettyLocationName}' --- {isSafe}");
            return isSafe;
        }



    }
}
