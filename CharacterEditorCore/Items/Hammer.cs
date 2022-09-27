using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Items
{
    public class Hammer : IItem
    {
        public Hammer()
        {
            Name = "Hammer";
        }

        public string Name { get; set; }
    }
}
