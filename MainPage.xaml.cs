using MessengerRandomizerMappingGenerator.RandomizerGeneration;
using MessengerRandomizerMappingGenerator.RandomizerGeneration.Constants;
using MessengerRandomizerMappingGenerator.RandomizerGeneration.RO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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

        private void Button_Click(object sender, RoutedEventArgs e)
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
            
            //generate mappings!
            Dictionary<LocationRO, string> mappings = RandomizerGenerator.GenerateRandomizedMappings(seed);

            this.text += "Mapping complete, listing mapping now:\n";

            foreach(LocationRO location in mappings.Keys)
            {
                this.text += $"Item '{mappings[location]}' at Location '{location.PrettyLocationName}'\n";
            }

            this.text += "Generation complete! Enjoy the game!!!";

            //Set text in box
            TextBox text = (TextBox)FindName("Text");
            text.Text = this.text;

        }

    }
}
