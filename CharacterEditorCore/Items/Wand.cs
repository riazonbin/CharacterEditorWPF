using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Items
{
    public class Wand : IItem
    {
        public Wand()
        {
            Name = "Wand";
        }

        public string Name { get; set; }
    }
}
