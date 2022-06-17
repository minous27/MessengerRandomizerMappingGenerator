using MessengerRandomizerMappingGenerator.RandomizerGeneration;
using MessengerRandomizerMappingGenerator.RandomizerGeneration.Constants;
using MessengerRandomizerMappingGenerator.RandomizerGeneration.RO;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Text.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MessengerRandomizerMappingGenerator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private string text = "";        

        public MainPage()
        {
            this.InitializeComponent();

            RadioButton radio = (RadioButton)FindName("BasicRadial");
            radio.IsChecked = true;
        }

        private void HandleChecked(object sender, RoutedEventArgs e)
        {

        }

        private void HandleUnchecked(object sender, RoutedEventArgs e)
        {

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            this.text = "Generation starting up...\n";

            CheckBox logicEngineCheckBox = (CheckBox)FindName("LogicalEngineCheckBox");
            RadioButton basicRadial = (RadioButton)FindName("BasicRadial");
            
            this.text += $"Using logic engine: '{logicEngineCheckBox.IsChecked}'\n";
            this.text += $"Is a basic seed: '{basicRadial.IsChecked}'\n";
            this.text += $"Is an advanced seed: '{!basicRadial.IsChecked}'\n";

            this.text += "Got the seed info, beginning item mapping!\n\n\n";

            //Generate seed
            int seedNum = RandomizerGenerator.GenerateSeed();
            SeedType seedType = (bool)logicEngineCheckBox.IsChecked ? SeedType.Logic : SeedType.No_Logic;
            
            Dictionary<SettingType, SettingValue> settings = new Dictionary<SettingType, SettingValue>();
            SettingValue difficulty = (bool)basicRadial.IsChecked ? SettingValue.Basic : SettingValue.Advanced;
            settings.Add(SettingType.Difficulty, difficulty);

            SeedRO seed = new SeedRO(seedNum,seedType,settings);

            try
            {
                //generate mappings!
                Dictionary<LocationRO, string> mappings = RandomizerGenerator.GenerateRandomizedMappings(seed);

                this.text += "Mapping complete, listing mapping now:\n";

                //Take the mapping I have and turn it into something nice and usable.
                MappingJsonRO mappingJson = new MappingJsonRO();
                mappingJson.Mappings = new Dictionary<string, string>();

                foreach (LocationRO location in mappings.Keys)
                {
                    this.text += $"Item '{mappings[location]}' at Location '{location.PrettyLocationName}'\n";

                    mappingJson.Mappings.Add(location.LocationName, mappings[location]);
                }

                mappingJson.Settings = settings;
                mappingJson.SeedType = seedType;

                //JSON parsing
                var options = new JsonSerializerOptions{ WriteIndented = true };
                string mappingJsonString = JsonSerializer.Serialize(mappingJson, options);

                this.text += mappingJsonString + "\n";

                Windows.Storage.StorageFolder installedLocation = Windows.ApplicationModel.Package.Current.InstalledLocation;

                this.text += "\nGeneration complete! Enjoy the game!!!";
            }
            catch(Exception ex)
            {
                this.text = $"An error occurred during generation: {ex.Message}\nPlease try again.";
            }


           

            

            //Set text in box
            TextBox text = (TextBox)FindName("Text");
            text.Text = this.text;

        }

    }
}
