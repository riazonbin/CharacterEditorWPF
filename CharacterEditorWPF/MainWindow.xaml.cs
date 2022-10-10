using CharacterEditorCore;
using CharacterEditorCore.Abilities;
using CharacterEditorCore.Equipments;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CharacterEditorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Character currentCharacter;
        public bool isInitializing;
        public bool isCharacterSelected;
        public bool isClearingData;
        public bool isChangingType;

        public MainWindow()
        {
            InitializeComponent();
            NavigationFrame.Navigate(new MainPage());
        }
    }
}
