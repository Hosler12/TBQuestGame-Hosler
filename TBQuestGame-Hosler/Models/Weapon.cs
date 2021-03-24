﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame_Hosler.Models
{
    public class Weapon : GameItem
    {
        public int Bonus { get; set; }
        public Weapon(int id, string name, int value, int bonus, string description)
            : base(id, name, value, description)
        {
            Bonus = bonus;
        }

        public override string InformationString()
        {
            return $"{Name}: {Description}\nDamage: {Bonus}";
        }
    }
}
