using CharacterEditorCore;
using CharacterEditorCore.Abilities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Windows;
using System.Windows.Controls;

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
            isInitializing = true;
            InitializeComponent();
            isInitializing = false;
            RegisterClassMaps();
        }

        private static void RegisterClassMaps()
        {
            BsonClassMap.RegisterClassMap<Character>();
            BsonClassMap.RegisterClassMap<Wizard>();
            BsonClassMap.RegisterClassMap<Rogue>();
            BsonClassMap.RegisterClassMap<Warrior>();
        }

        private void cb_chooseCharact_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            isChangingType = true;
            FillListBox();

            if (cb_chooseCharact.SelectedIndex == -1)
            {
                return;
            }
            if(isCharacterSelected)
            {
                return;
            }
            isChangingType = false;

            ComboBoxItem typeItem = (ComboBoxItem)cb_chooseCharact.SelectedItem;
            string? value = typeItem.Content.ToString();

            switch (value)
            {
                case "Warrior":
                    Warrior newWarrior = new Warrior();
                    currentCharacter = newWarrior;
                    FillData(newWarrior);
                    break;

                case "Rogue":
                    Rogue newRogue = new Rogue();
                    currentCharacter = newRogue;
                    FillData(newRogue);
                    break;


                case "Wizard":
                    Wizard newWizard = new Wizard();
                    currentCharacter = newWizard;
                    FillData(newWizard);
                    break;
            }
        }

        public void FillData(Character newCharacter)
        {

            tb_strength.Text = newCharacter.Strength.ToString();
            tb_dexterity.Text = newCharacter.Dexterity.ToString();
            tb_constitution.Text = newCharacter.Constitution.ToString();
            tb_intelligence.Text = newCharacter.Intelligence.ToString();

            tb_HP.Text = newCharacter.healthPoints.ToString();
            tb_MP.Text = newCharacter.manaPoints.ToString();
            tb_attack.Text = newCharacter.attack.ToString();
            tb_magicAttack.Text = newCharacter.magicAttack.ToString();
            tb_physicalDef.Text = newCharacter.physicalDefense.ToString();

            tb_Level.Text = newCharacter.Level.CurrentLevel.ToString();
            tb_Experience.Text = newCharacter.Level.CurrentExp.ToString();
            tb_availablePoints.Text = newCharacter.AvailablePoints.ToString();
            tb_abilitiesPoints.Text = newCharacter.abilitiesPoints.ToString();

            GetInventoryToListBox();
            GetPotentialAbilitiesToCheckBox();
            GetCharactersAbilitiesToCheckBox();
        }

        private void ClearData()
        {
            isClearingData = true;

            cb_createdCharacters.SelectedIndex = -1;
            cb_createdCharacters.Items.Clear();
            cb_chooseCharact.SelectedIndex = -1;
            tb_itemToInventory.Text = "";
            lb_inventory.Items.Clear();

            tb_name.Text = "";

            tb_strength.Text = "0";
            tb_dexterity.Text = "0";
            tb_constitution.Text = "0";
            tb_intelligence.Text = "0";

            tb_HP.Text = "0";
            tb_MP.Text = "0";
            tb_attack.Text = "0";
            tb_magicAttack.Text = "0";
            tb_physicalDef.Text = "0";

            tb_Experience.Text = "0";
            tb_Level.Text = "0";
            tb_availablePoints.Text = "0";
            tb_abilitiesPoints.Text = "0";

            currentCharacter = null;
            isClearingData = false;
        }

        private void btn_increaseStrength_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            if(currentCharacter.AvailablePoints == 0)
            {
                return;
            }
            currentCharacter.Strength++;
            currentCharacter.AvailablePoints--;
            FillData(currentCharacter);
        }

        private void btn_increaseDexterity_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            if (currentCharacter.AvailablePoints == 0)
            {
                return;
            }
            currentCharacter.Dexterity++;
            currentCharacter.AvailablePoints--;
            FillData(currentCharacter);
        }

        private void btn_increaseConstitution_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            if (currentCharacter.AvailablePoints == 0)
            {
                return;
            }
            currentCharacter.Constitution++;
            currentCharacter.AvailablePoints--;
            FillData(currentCharacter);
        }

        private void btn_increaseIntelligence_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            if (currentCharacter.AvailablePoints == 0)
            {
                return;
            }
            currentCharacter.Intelligence++;
            currentCharacter.AvailablePoints--;
            FillData(currentCharacter);
        }
        private bool CheckCharactOnExistment()
        {
            try
            {
                var temp = currentCharacter.Intelligence;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You have to choose type of character!");
                return false;
            }
            return true;
        }

        private void btn_decreaseStrength_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            var oldValue = currentCharacter.Strength;
            currentCharacter.Strength--;
            if(oldValue != currentCharacter.Strength)
            {
                currentCharacter.AvailablePoints++;
            }
            FillData(currentCharacter);
        }

        private void btn_decreaseDexterity_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            var oldValue = currentCharacter.Dexterity;
            currentCharacter.Dexterity--;
            if (oldValue != currentCharacter.Dexterity)
            {
                currentCharacter.AvailablePoints++;
            }
            FillData(currentCharacter);
        }

        private void btn_decreaseConstitution_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            var oldValue = currentCharacter.Constitution;
            currentCharacter.Constitution--;
            if (oldValue != currentCharacter.Constitution)
            {
                currentCharacter.AvailablePoints++;
            }
            FillData(currentCharacter);
        }

        private void btn_decreaseIntelligence_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            var oldValue = currentCharacter.Intelligence;
            currentCharacter.Intelligence--;
            if (oldValue != currentCharacter.Intelligence)
            {
                currentCharacter.AvailablePoints++;
            }
            FillData(currentCharacter);
        }

        private void button_addCharacter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                currentCharacter.Name = tb_name.Text;

                if (currentCharacter.Name == "")
                {
                    MessageBox.Show("You have to give name to character!");
                    return;
                }

                if(MongoDBLink.MongoDB.FindById(currentCharacter._id.ToString()) is null)
                {
                    MongoDBLink.MongoDB.AddToDataBase(currentCharacter);
                }
                else
                {
                    MongoDBLink.MongoDB.ReplaceOneInDataBase(currentCharacter);
                }
                ClearData();
                FillListBox();
            }
            catch
            {
                MessageBox.Show("You have to choose type of character!");
            }

        }

        private async void FillListBox()
        {
            if(cb_createdCharacters.Items.Count != 0)
            {
                cb_createdCharacters.Items.Clear();
            }

            if (cb_chooseCharact.SelectedItem is null)
            {
                return;
            }

            ComboBoxItem typeItem = (ComboBoxItem)cb_chooseCharact.SelectedItem;
            string? type = typeItem.Content.ToString();

            var collection = MongoDBLink.MongoDB.GetCollection();
            try
            {
                var filter = new BsonDocument("_t", type);
                using (var cursor = await collection.FindAsync(filter))
                {
                    while (await cursor.MoveNextAsync())
                    {
                        var docs = cursor.Current;
                        foreach (var doc in docs)
                        {
                            cb_createdCharacters.Items.Add(doc);

                        }
                    }
                }
            }
            catch { }
        }

        private void tb_name_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                currentCharacter.Name = tb_name.Text;
            }
            catch { }
        }

        private void form_mainForm_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void cb_createdCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(isClearingData)
            {
                return;
            }
            if (isChangingType)
            {
                return;
            }

            try
            {
                var unit = (Character)cb_createdCharacters.SelectedItem;

                currentCharacter = unit;
                currentCharacter.Subscribe();

                FillData(currentCharacter);
                isCharacterSelected = true;
                tb_name.Text = currentCharacter.Name;
                isCharacterSelected = false;
            }
            catch {};
        }

        private void SetTypeForSelectedCharacter()
        {
            cb_chooseCharact.Text = currentCharacter.typeOfCharacter;
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
        }
        private void SetDataForSelectedCharacter(Character unit)
        {
        }

        private void btn_AddItem_Click(object sender, RoutedEventArgs e)
        {
            if(currentCharacter is null)
            {
                return;
            }

            if(currentCharacter.inventory.Count == currentCharacter.listCapacity)
            {
                return;
            }

            if(tb_itemToInventory.Text is null)
            {
                return;
            }

            currentCharacter.inventory.Add(new Item(tb_itemToInventory.Text));

            GetInventoryToListBox();


        }

        private void GetInventoryToListBox()
        {
            lb_inventory.Items.Clear();

            foreach(var item in currentCharacter.inventory)
            {
                lb_inventory.Items.Add(item.Name);
            }
        }

        private void GetPotentialAbilitiesToCheckBox()
        {
            cb_potentialAbilities.Items.Clear();

            foreach(var ability in currentCharacter.potentialAbilities)
            {
                cb_potentialAbilities.Items.Add(ability);
            }
        }

        private void GetCharactersAbilitiesToCheckBox()
        {
            cb_charactersAbilities.Items.Clear();

            foreach (var ability in currentCharacter.abilities)
            {
                cb_charactersAbilities.Items.Add(ability);
            }
        }

        private void btn_plus100Exp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                currentCharacter.Level.CurrentExp += 100;
                FillData(currentCharacter);
            }
            catch { }   
        }

        private void btn_plus500Exp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                currentCharacter.Level.CurrentExp += 500;
                FillData(currentCharacter);
            }
            catch { }
        }

        private void btn_plus1000Exp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                currentCharacter.Level.CurrentExp += 1000;
                FillData(currentCharacter);
            }
            catch { }
        }

        private void btn_addAbility_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(currentCharacter is null)
                {
                    return;
                }
                if(currentCharacter.abilitiesPoints == 0)
                {
                    return;
                }

                Ability potentialAbility = (Ability)cb_potentialAbilities.SelectedItem;
                if(potentialAbility is null)
                {
                    return;
                }

                currentCharacter.abilities.Add(potentialAbility);
                currentCharacter.potentialAbilities.Remove(potentialAbility);
                currentCharacter.abilitiesPoints--;

                FillData(currentCharacter);
            }
            catch { }
        }
    }
}
