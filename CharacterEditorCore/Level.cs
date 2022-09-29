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
        public int CurrentLevel { get; set; }
        public int CurrentExp
        {
            get { return _currentExp; }
            set
            {
                if (value > CurrentLevel * 1000)
                {
                    --CurrentLevel;
                }
                _currentExp = value;

            }
        }

        public Level()
        {
            _currentLevel = 1;
            _currentExp = 0;
        }

    }
}
