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
        public int firstTeamCount = 0;
        public int secondTeamCount = 0;
        public const int maxTeamSize = 6;

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
            if(firstTeamCount == maxTeamSize && secondTeamCount == maxTeamSize)
            {
                firstTeamCount = 0;
                secondTeamCount = 0;
                lb_firstTeam.Items.Clear();
                lb_secondTeam.Items.Clear();
            }


            Random random = new Random();
            var collection = (MongoDBLink.MongoDB.GetCollection()).Find(new BsonDocument()).ToList();

            while (firstTeamCount != maxTeamSize)
            {
                firstTeamCount++;


                var randomCharacter = GetRandomCharacterFromList(collection);

                lb_firstTeam.Items.Add(new CharacterInfo(randomCharacter._id, randomCharacter.Name));

                collection.Remove(randomCharacter);
            }

            while (secondTeamCount != maxTeamSize)
            {

                var randomCharacter = GetRandomCharacterFromList(collection);

                secondTeamCount++;

                lb_secondTeam.Items.Add(new CharacterInfo(randomCharacter._id, randomCharacter.Name));

                collection.Remove(randomCharacter);
            }
        }

        private Character GetRandomCharacterFromList(List<Character> collection)
        {
            Random random = new Random();

            return collection[random.Next(0, collection.Count)];
        }
    }
}
