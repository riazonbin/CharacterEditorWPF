using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore
{
    public class Level
    {
        private int _currentLevel = 1;
        private int _currentExp = 0;
        private int growEdge = 1000;
        private int currentLevelEdge = 1000;
        public int CurrentLevel 
        {
            get { return _currentLevel; }
            set 
            {
                _currentLevel = value;
                LevelUpEvent?.Invoke();
                return;
            }
        }

        public int CurrentLevelEdge
        {
            get { return currentLevelEdge; }
            set
            {
                currentLevelEdge = value;
                return;
            }
        }

        public int CurrentExp
        {
            get { return _currentExp; }
            set
            {
                if(this.CurrentLevel > 1 && this.CurrentLevelEdge == 1000)
                {
                    _currentExp = value;
                    CurrentLevelEdge += growEdge * CurrentLevel;
                    return;
                }

                if(value >= currentLevelEdge)
                {
                    CurrentLevel++;
                    CurrentLevelEdge += growEdge * CurrentLevel;
                }
                _currentExp = value;

            }
        }

        public event LevelDelegate LevelUpEvent;
        public delegate void LevelDelegate();
    }
}
