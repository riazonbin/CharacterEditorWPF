﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Items
{
    public class Knife : IItem
    {
        public Knife()
        {
            Name = "Knife";
        }

        public string Name { get; set; }
    }
}
