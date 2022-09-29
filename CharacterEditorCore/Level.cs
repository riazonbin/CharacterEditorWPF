using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore
{
    public class Level
    {
        private int _currentLevel;
        private int _currentExp;
        private int growEdge = 1000;
        private int currentLevelEdge;
        public int CurrentLevel 
        {
            get { return _currentLevel; }
            set 
            {
                _currentLevel = value;
                LevelUpEvent();
            }
        }
        public int CurrentExp
        {
            get { return _currentExp; }
            set
            {
                if (value >= currentLevelEdge)
                {
                    ++CurrentLevel;
                    currentLevelEdge += growEdge * CurrentLevel;
                }
                _currentExp = value;

            }
        }

        public Level()
        {
            _currentLevel = 1;
            _currentExp = 0;
            currentLevelEdge = 1000;
        }

        public event LevelDelegate LevelUpEvent;
    }

    public delegate void LevelDelegate();
}
