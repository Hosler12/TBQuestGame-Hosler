using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                Inventory = new ObservableCollection<GameItem>()
                {
                    GameItemById(1000),
                    GameItemById(2000)
                }
            };
        }

        private static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }

        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates() { Row = 0, Column = 0, Floor = 0 };
        }

        public static Map GameMap()
        {
            int rows = 3;
            int columns = 3;
            int floors = 5;

            Map gameMap = new Map(rows, columns, floors);

            // First Floor
            gameMap.MapLocations[0, 0, 0] = new Location()
            {
                Id = 1,
                Name = "Entrance",
                Description = "Tower Entrance",
                Message = "An eerie silence deafens you as the door slides shut behind you. You can go up a floor whenever you're ready.",
            };
            gameMap.MapLocations[0, 1, 0] = new Location()
            {
                Id = 2,
                Name = "Trap",
                Description = "Sudden arrow",
                Message = "You open the door, and an arrow embeds itself into your side. It hurts a lot, in case you were curious.",
                ModifyHealth = 2,
                ModifyAgility = 1
            };
            gameMap.MapLocations[0, 2, 0] = new Location()
            {
                Id = 3,
                Name = "Healing Mist",
                Description = "A magical mist that closes wounds it touches.",
                Message = "You open the door, and purple mist flows over you. It may heal your body, but it can't heal a wounded heart.",
                ModifyHealth = -2,
                ModifyVitality = 1
            };
            gameMap.MapLocations[1, 0, 0] = new Location()
            {
                Id = 4,
                Name = "Void",
                Description = "Calm in the storm",
                Message = "You enter a room with blank walls, floors, and doors. Just to be sure, you check the ceiling. Blank",
                ModifyMagic = 1
            };
            gameMap.MapLocations[1, 1, 0] = new Location()
            {
                Id = 5,
                Name = "Blockade",
                Description = "The doors have been blocked",
                Message = "You need to push a lot to get this door open. Inside, you find furniture blocking the doors. Not for long.",
                ModifyStrength = 1,

            };
            gameMap.MapLocations[1, 2, 0] = new Location()
            {
                Id = 6,
                Name = "Siphon",
                Description = "Mana is drained in here",
                Message = "You feel yourself lose energy. You decide that staying to find out what happened to it would probably be a bad idea.",
                ModifyMana = 1,

            };
            gameMap.MapLocations[2, 0, 0] = new Location()
            {
                Id = 7,
                Name = "Trap",
                Description = "Sudden arrow",
                Message = "You open the door, and an arrow embeds itself into your kidney. That's why we have two",
                ModifyHealth = 2,
                ModifyAgility = 1
            };
            gameMap.MapLocations[2, 1, 0] = new Location()
            {
                Id = 8,
                Name = "Void",
                Description = "Calm in the storm",
                Message = "You enter a room with blank walls, floors, and doors. Just to be sure, you check the ceiling. Blank",
                ModifyMagic = 1
            };
            gameMap.MapLocations[2, 2, 0] = new Location()
            {
                Id = 9,
                Name = "Jungle Gym",
                Description = "The bar is low",
                Message = "You enter a room with a bunch of bars over a pit. It won't be extra hard to reach the other side, and the creator forgot the pit spikes!",
                ModifyAgility = 1,
                ModifyStrength = 1
            };

            // Second Floor
            gameMap.MapLocations[0, 0, 1] = new Location()
            {
                Id = 11,
                Name = "Bubbles",
                Description = "Chaotic bubles",
                Message = "You enter the room, and a bunch of colorful bubbles pop when you run into them. It hurts, so something's probably not right here.",
                ModifyHealth = 4,
                ModifyAgility = 1
            };
            gameMap.MapLocations[0, 1, 1] = new Location()
            {
                Id = 12,
                Name = "Cat",
                Description = "Cat attack",
                Message = "A cat decided to demonstrate its superior combat abilities. You're not sure how it got to the ceiling, or how it planned on getting down, but you don't stick around to ask.",
                ModifyHealth = 4,
                ModifyAgility = 1
            };
            gameMap.MapLocations[0, 2, 1] = new Location()
            {
                Id = 13,
                Name = "Healing Mist",
                Description = "A magical mist that closes wounds it touches.",
                Message = "You open the door, and purple mist flows over you. It may heal your body, but it can't heal a wounded heart.",
                ModifyHealth = -2,
                ModifyVitality = 1
            };
            gameMap.MapLocations[1, 0, 1] = new Location()
            {
                Id = 14,
                Name = "Void",
                Description = "Calm in the storm",
                Message = "You enter a room with blank walls, floors, and doors. Just to be sure, you check the ceiling. Blank",
                ModifyMagic = 1
            };
            gameMap.MapLocations[1, 1, 1] = new Location()
            {
                Id = 15,
                Name = "Illusion",
                Description = "Illusion of the past",
                Message = "You enter to see the remnants of a battlefied. You feel so alive now! Let's just hope it's not a nearby ghost making you think that.",
                ModifyVitality = 1,
            };
            gameMap.MapLocations[1, 2, 1] = new Location()
            {
                Id = 160,
                Name = "Fight",
                Description = "Insert generic enemy here later",
                Message = "You feel like the dev didn't add the enemy here like he was supposed to. In fact, this message was copy pasted! Have some damage, on the house.",
                ModifyHealth = 50,

            };
            gameMap.MapLocations[2, 0, 1] = new Location()
            {
                Id = 17,
                Name = "Pool",
                Description = "Makeshift moat",
                Message = "You open the door, take a step, and fall into some water. YOUR DROWNING! Oh wait, it's only knee deep, false alarm. You cough up some water, and thank the divines nobody witnessed that. Hopefully.",
                ModifyHealth = 2,
                ModifyStrength = 1
            };
            gameMap.MapLocations[2, 1, 1] = new Location()
            {
                Id = 18,
                Name = "Nap",
                Description = "Sleep spell",
                Message = "You enter a room, and fall over. You wake up feeling somewhat refreshed, you just hope the nose damage isn't permanent.",
                ModifyHealth = 2
            };
            gameMap.MapLocations[2, 2, 1] = new Location()
            {
                Id = 19,
                Name = "Camp",
                Description = "Restore life",
                Message = "You feel like this is the perfect room to rest in for a while.",
                ModifyHealth = -2,
                ModifyMana = -2
            };
            return gameMap;
        }

        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Weapon(1000, "Fist", 0, 1, "Jab, Cross, Hook, Uppercut."),
                new Armor(2000, "Clothes", 0, 1, "The clothes on your back"),
            };
        }
    }
}
//You feel like the dev didn't add the enemy here like he was supposed to. In fact, this message was copy pasted! Have some damage, on the house