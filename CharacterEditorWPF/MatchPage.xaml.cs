using CharacterEditorCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CharacterEditorWPF
{
    /// <summary>
    /// Логика взаимодействия для MatchPage.xaml
    /// </summary>
    public partial class MatchPage : Page
    {
        public const int maxTeamSize = 6;
        public const double maxLevelDifference = 1.5;
        public bool isBalanced = false;
        private int _balanceCount = 0;
        public const int maxBalanceIterationCount = 10;

        public MatchPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btn_autoGeneration_Click(object sender, RoutedEventArgs e)
        {
            AutoGenerate();
            ColorBalanceLabel();
        }

        private void AutoGenerate()
        {

            if (lb_firstTeam.Items.Count == maxTeamSize && lb_secondTeam.Items.Count == maxTeamSize)
            {
                FillExistingCharacters();
                lb_firstTeam.Items.Clear();
                lb_secondTeam.Items.Clear();
            }


            Random random = new Random();
            var collection = GetCharactersFromComboBox(cb_existingCharacters);

            while (lb_firstTeam.Items.Count != maxTeamSize)
            {
                CharacterInfo randomCharacter = GetRandomCharacterFromList(collection);

                lb_firstTeam.Items.Add(new CharacterInfo(ObjectId.Parse(randomCharacter.Id), randomCharacter.Name, randomCharacter.Level));

                collection.Remove(randomCharacter);
                cb_existingCharacters.Items.Remove(randomCharacter);
            }

            while (lb_secondTeam.Items.Count != maxTeamSize)
            {
                CharacterInfo randomCharacter = GetRandomCharacterFromList(collection);

                lb_secondTeam.Items.Add(new CharacterInfo(ObjectId.Parse(randomCharacter.Id), randomCharacter.Name, randomCharacter.Level));

                collection.Remove(randomCharacter);
                cb_existingCharacters.Items.Remove(randomCharacter);
            }

            if (!CheckBalance())
            {
                _balanceCount++;
                AutoGenerate();
            }
            else
            {
                _balanceCount = 0;
            }

            if(_balanceCount > maxBalanceIterationCount)
            {
                MessageBox.Show("There is no possible balanced match");
            }
        }

        private void ColorBalanceLabel()
        {
            if(isBalanced)
            {
                lb_Balance.Content = "BALANCED";
                lb_Balance.Background = new BrushConverter().ConvertFromString("Green") as Brush;
            }
            else
            {
                lb_Balance.Content = "UNBALANCED";
                lb_Balance.Background = new BrushConverter().ConvertFromString("Red") as Brush;
            }
        }

        private CharacterInfo GetRandomCharacterFromList(List<CharacterInfo> collection)
        {
            Random random = new Random();

            return collection[random.Next(0, collection.Count)];
        }

        private bool CheckBalance()
        {
            var firstTeamAvgLvl = GetAverageLevelOnTeam(lb_firstTeam);
            var secondTeamAvgLvl = GetAverageLevelOnTeam(lb_secondTeam);

            if(Math.Abs(firstTeamAvgLvl - secondTeamAvgLvl) >= maxLevelDifference)
            {
                return isBalanced = false;
            }
            return isBalanced = true;
        }

        private double GetAverageLevelOnTeam(ListBox characters)
        {
            double averageLevel = 0;

            foreach (CharacterInfo character in characters.Items)
            {
                averageLevel += character.Level;
            }

            return averageLevel / maxTeamSize;
        }

        private void lb_firstTeam_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Delete)
            {
                var selectedCharacter = lb_firstTeam.SelectedItem;
                lb_firstTeam.Items.Remove(selectedCharacter);
                cb_existingCharacters.Items.Add(selectedCharacter);

                CheckBalance();
                ColorBalanceLabel();
            }
        }

        private void lb_secondTeam_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var selectedCharacter = lb_secondTeam.SelectedItem;
                lb_secondTeam.Items.Remove(lb_secondTeam.SelectedItem);
                cb_existingCharacters.Items.Add(selectedCharacter);
                CheckBalance();
                ColorBalanceLabel();
            }
        }

        private void page_MatchPage_Loaded(object sender, RoutedEventArgs e)
        {
            FillExistingCharacters();
        }

        private void FillExistingCharacters()
        {
            var collection = (MongoDBLink.MongoDB.GetCollection()).Find(new BsonDocument()).ToList();
            cb_existingCharacters.Items.Clear();

            foreach(var character in collection)
            {
                cb_existingCharacters.Items.Add(new CharacterInfo(character._id, character.Name, character.Level.CurrentLevel));
            }
        }

        private List<CharacterInfo> GetCharactersFromComboBox(ComboBox combobox)
        {
            List<CharacterInfo> characters = new List<CharacterInfo>();

            foreach(CharacterInfo character in combobox.Items)
            {
                characters.Add(character);
            }

            return characters;
        }

        private List<CharacterInfo> GetCharactersFromListBox(ListBox listbox)
        {
            List<CharacterInfo> characters = new List<CharacterInfo>();

            foreach (CharacterInfo character in listbox.Items)
            {
                characters.Add(character);
            }

            return characters;
        }


        private void btn_addToFirstTeam_Click(object sender, RoutedEventArgs e)
        {
            if(lb_firstTeam.Items.Count == maxTeamSize)
            {
                return;
            }
            var selectedCharacter = cb_existingCharacters.SelectedItem;
            lb_firstTeam.Items.Add(selectedCharacter);
            CheckBalance();
            ColorBalanceLabel();
            cb_existingCharacters.Items.Remove(selectedCharacter);

        }

        private void btn_addToSecondTeam_Click(object sender, RoutedEventArgs e)
        {
            if (lb_secondTeam.Items.Count == maxTeamSize)
            {
                return;
            }
            var selectedCharacter = cb_existingCharacters.SelectedItem;
            lb_secondTeam.Items.Add(selectedCharacter);
            CheckBalance();
            ColorBalanceLabel();
            cb_existingCharacters.Items.Remove(selectedCharacter);
        }

        private void btn_startMatch_Click(object sender, RoutedEventArgs e)
        {
            if(!isBalanced)
            {
                return;
            }
            MatchInfo newMatch = new MatchInfo(GetCharactersFromListBox(lb_firstTeam),
                GetCharactersFromListBox(lb_secondTeam));

            MongoDBLink.MongoDB.AddMatchToDataBase(newMatch);
        }

        private void btn_GoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
