﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Items
{
    public class Crossbow : IItem
    {
        public Crossbow()
        {
            Name = "Crossbow";
        }

        public string Name { get; set; }
    }
}
