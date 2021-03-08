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

        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates() { Row = 0, Column = 0 };
        }

        public static Map GameMap()
        {
            int rows = 3;
            int columns = 3;
            //int floor = 1;

            Map gameMap = new Map(rows, columns);

            // floor one
            //if (floor == 1)
            //{
            gameMap.MapLocations[0, 0] = new Location()
            {
                Id = 1,
                Name = "Entrance",
                Description = "Tower Entrance",
                Message = "An eerie silence deafens you as the door slides shut behind you. No easy way out now.",
            };
            gameMap.MapLocations[0, 1] = new Location()
            {
                Id = 2,
                Name = "Trap",
                Description = "Sudden arrow",
                Message = "You open the door, and an arrow embeds itself into your side. It hurts a lot, in case you were curious.",
                ModifyHealth = 2,
                ModifyAgility = 1
            };
            gameMap.MapLocations[0, 2] = new Location()
            {
                Id = 3,
                Name = "Healing Mist",
                Description = "A magical mist that closes wounds it touches.",
                Message = "You open the door, and purple mist flows over you. It may heal your body, but it can't heal a wounded heart.",
                ModifyHealth = -2,
                ModifyVitality = 1
            };
            gameMap.MapLocations[1, 0] = new Location()
            {
                Id = 4,
                Name = "Void",
                Description = "Calm in the storm",
                Message = "You enter a room with blank walls, floors, and doors. Just to be sure, you check the ceiling. Blank",
                ModifyMagic = 1
            };
            gameMap.MapLocations[1, 1] = new Location()
            {
                Id = 5,
                Name = "Blockade",
                Description = "The doors have been blocked",
                Message = "You need to push a lot to get this door open. Inside, you find furniture blocking the doors. Not for long.",
                ModifyStrength = 1,

            };
            gameMap.MapLocations[1, 2] = new Location()
            {
                Id = 6,
                Name = "Siphon",
                Description = "Mana is drained in here",
                Message = "You feel yourself lose energy. You decide that staying to find out what happened to it would probably be a bad idea.",
                ModifyMana = 1,

            };
            gameMap.MapLocations[2, 0] = new Location()
            {
                Id = 7,
                Name = "Trap",
                Description = "Sudden arrow",
                Message = "You open the door, and an arrow embeds itself into your kidney. That's why we have two",
                ModifyHealth = 2,
                ModifyAgility = 1
            };
            gameMap.MapLocations[2, 1] = new Location()
            {
                Id = 8,
                Name = "Void",
                Description = "Calm in the storm",
                Message = "You enter a room with blank walls, floors, and doors. Just to be sure, you check the ceiling. Blank",
                ModifyMagic = 1
            };
            gameMap.MapLocations[2, 2] = new Location()
            {
                Id = 9,
                Name = "Stairs",
                Description = "Level up, the tower",
                Message = "You finally find the stairs, time to go up a level, of the tower.",
                ModifyMagic = 1,
                ModifyFloor = 1
            };
            //}

            return gameMap;
        }
    }
}
