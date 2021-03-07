using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame_Hosler.Models;

namespace TBQuestGame_Hosler.DataLayer
{
    public static class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Id = 10,
                Name = "Unknown",
                Strength = 1,
                Agility = 1,
                Vitality = 1,
                Magic = 1,
                LocationId = 0,
                Tier = 0,
                Damage = 1,
                Armor = 1,
                HPLoss = 0,
                ManaLoss = 0,
                PermanentStrength = 1,
                PermanentAgility = 1,
                PermanentVitality = 1,
                PermanentMagic = 1,
                Combat = Character.CombatType.None
            };
        }

        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                //"\tYou wake up in an inn, and you can't remember much. There's one thing you do know though. You need to kill whatever is at the top of the ominous, black tower you see out your window."
                "\tYou wake up on a stone floor. You have a feeling that the correct starting area has not been built yet."
            };
        }
    }
}
