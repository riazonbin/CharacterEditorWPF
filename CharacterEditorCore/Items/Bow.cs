using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Items
{
    public class Bow : IItem
    {
        public Bow()
        {
            Name = "Bow";
        }

        public string Name { get; set; }
    }
}
