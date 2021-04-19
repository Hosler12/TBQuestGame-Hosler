﻿using System;
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

        public static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }
        private static Npc NpcById(int id)
        {
            return Npcs().FirstOrDefault(i => i.Id == id);
        }
        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates() { Row = 0, Column = 0, Floor = 0 };
        }

        public static Map GameMap()
        {
            int rows = 3;
            int columns = 3;
            int floors = 6;

            Map gameMap = new Map(rows, columns, floors);

            // First Floor
            gameMap.MapLocations[0, 0, 0] = new Location()
            {
                Id = 1,
                Name = "Entrance",
                Description = "Tower entrance",
                Message = "An eerie silence deafens you as the door slides shut behind you.",
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
                Description = "Healing mist",
                Message = "You open the door, and purple mist flows over you. It may heal your body, but it can't heal a wounded heart.",
                ModifyHealth = -2,
                ModifyVitality = 1
            };
            gameMap.MapLocations[1, 0, 0] = new Location()
            {
                Id = 4,
                Name = "Void",
                Description = "Calm in the storm",
                Message = "You enter a room with blank walls, floors, and doors. Just to be sure, you check the ceiling. Blank.",
                ModifyMagic = 1
            };
            gameMap.MapLocations[1, 1, 0] = new Location()
            {
                Id = 5,
                Name = "Blockade",
                Description = "Blocked doors",
                Message = "You need to push a lot to get this door open. Inside, you find furniture blocking the doors. Not for long.",
                ModifyStrength = 1,

            };
            gameMap.MapLocations[1, 2, 0] = new Location()
            {
                Id = 6,
                Name = "Siphon",
                Description = "Mana drain",
                Message = "You feel yourself lose energy. You decide that staying to find out what happened to it would probably be a bad idea.",
                ModifyMana = 1,

            };
            gameMap.MapLocations[2, 0, 0] = new Location()
            {
                Id = 7,
                Name = "Trap",
                Description = "Sudden arrow",
                Message = "You open the door, and an arrow embeds itself into your kidney. That's why we have two.",
                ModifyHealth = 2,
                ModifyAgility = 1
            };
            gameMap.MapLocations[2, 1, 0] = new Location()
            {
                Id = 8,
                Name = "Void",
                Description = "Calm in the storm",
                Message = "You enter a room with blank walls, floors, and doors. Just to be sure, you check the ceiling. Blank.",
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
                Description = "Chaotic bubbles",
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
                Description = "Healing mist",
                Message = "You open the door, and purple mist flows over you. It may heal your body, but it can't heal a wounded heart.",
                ModifyHealth = -2,
                ModifyVitality = 1
            };
            gameMap.MapLocations[1, 0, 1] = new Location()
            {
                Id = 14,
                Name = "Void",
                Description = "Calm in the storm",
                Message = "You enter a room with blank walls, floors, and doors. Just to be sure, you check the ceiling. Blank.",
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
                Id = 16,
                Name = "Fight",
                Description = "Enemy",
                Message = "You see a monster that looks so bland you want to put it out of your misery.",
                Npcs = new ObservableCollection<Npc>
                {
                    NpcById(1001)
                },
            };
            gameMap.MapLocations[2, 0, 1] = new Location()
            {
                Id = 17,
                Name = "Pool",
                Description = "Makeshift moat",
                Message = "You open the door, take a step, and fall into some water. YOU'RE DROWNING! Oh wait, it's only knee deep, false alarm. You cough up some water, and thank the divines nobody witnessed that. Hopefully.",
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
                Description = "Camp",
                Message = "You feel like this is the perfect room to rest in for a while.",
                ModifyHealth = -2,
                ModifyMana = -2
            };

            // Third Floor
            gameMap.MapLocations[0, 0, 2] = new Location()
            {
                Id = 21,
                Name = "Fight",
                Description = "Enemy",
                Message = "You see a skeleton. You thought it was underwerwhelming until it started dancing to... something?",
                Npcs = new ObservableCollection<Npc>
                {
                    NpcById(1002)
                },
            };
            gameMap.MapLocations[0, 1, 2] = new Location()
            {
                Id = 22,
                Name = "Fight",
                Description = "Enemy",
                Message = "As soon as you enter, a man starts shouting in what you think is supposed to be an old version of common.",
                Npcs = new ObservableCollection<Npc>
                {
                    NpcById(1003)
                },
            };
            gameMap.MapLocations[0, 2, 2] = new Location()
            {
                Id = 23,
                Name = "Weather Room",
                Description = "Weather room",
                Message = "The temperature here fluctuates every minute, from blistering heat to biting cold.",
                ModifyHealth = 20,
                ModifyVitality = 1
            };
            gameMap.MapLocations[1, 0, 2] = new Location()
            {
                Id = 24,
                Name = "Mana Pool",
                Description = "Mana pool",
                Message = "You enter a room and feel magic in the air. You eat it all, and only kind of regret it afterwards. You're not sure how you ate it though.",
                ModifyMagic = 1,
                ModifyMana = -20
            };
            gameMap.MapLocations[1, 1, 2] = new Location()
            {
                Id = 25,
                Name = "Flying blades",
                Description = "Trapped weapons room",
                Message = "You enter the room, and suddenly a bunch of weapons fly at you! Fortunately, you dodge most of the pointy ones.",
                ModifyAgility = 1,
                ModifyHealth = 20
            };
            gameMap.MapLocations[1, 2, 2] = new Location()
            {
                Id = 26,
                Name = "Fight",
                Description = "Enemy",
                Message = "You are blinded by snow for a few seconds, then it collates into a very angry looking blue person.",
                Npcs = new ObservableCollection<Npc>
                {
                    NpcById(1004)
                },
            };
            gameMap.MapLocations[2, 0, 2] = new Location()
            {
                Id = 27,
                Name = "Healing Pool",
                Description = "Health pool",
                Message = "Good thing it's more than a healing mist, because that wouldn't cut it.",
                ModifyHealth = -20,
                ModifyVitality = 1
            };
            gameMap.MapLocations[2, 1, 2] = new Location()
            {
                Id = 28,
                Name = "Mana Pool",
                Description = "Mana pool",
                Message = "You enter a room and feel magic in the air. You eat it all, and only kind of regret it afterwards. You're not sure how you ate it though.",
                ModifyMagic = 1,
                ModifyMana = -20
            };
            gameMap.MapLocations[2, 2, 2] = new Location()
            {
                Id = 29,
                Name = "Healing Pool",
                Description = "Health pool",
                Message = "Good thing it's more than a healing mist, because that wouldn't cut it.",
                ModifyHealth = -20,
                ModifyVitality = 1
            };

            // Fourth Floor
            gameMap.MapLocations[0, 0, 3] = new Location()
            {
                Id = 31,
                Name = "Fight",
                Description = "Enemy",
                Message = "You walk into the room, and see a baby horse. It turns to you, and begins saying words that shouldn't be repeated in any medium. It also wants to kick you, but that seemed like a minor point here.",
                Npcs = new ObservableCollection<Npc>
                {
                    NpcById(1005)
                },
            };
            gameMap.MapLocations[0, 1, 3] = new Location()
            {
                Id = 32,
                Name = "Anti-gravity room",
                Description = "Up is down",
                Message = "As soon as you enter, you fall upwards, or maybe it's now downwards now? Fortunately, you can still reach the doors after you make sure your everything is aligned correctly.",
                ModifyHealth = 50,
                ModifyVitality = 1
            };
            gameMap.MapLocations[0, 2, 3] = new Location()
            {
                Id = 33,
                Name = "Exploding runes",
                Description = "Exploding runes",
                Message = "You see some paper on the walls with some words you can't read. Wait, you can read this one! 'I prepared exploding runes today'. Oh shiii.",
                ModifyHealth = 50,
                ModifyVitality = 1
            };
            gameMap.MapLocations[1, 0, 3] = new Location()
            {
                Id = 34,
                Name = "Fight",
                Description = "Enemy",
                Message = "You see a man in a horse mask holding a long, thin blade. He's wearing the rest of the costume too...",
                Npcs = new ObservableCollection<Npc>
                {
                    NpcById(1006)
                },
            };
            gameMap.MapLocations[1, 1, 3] = new Location()
            {
                Id = 35,
                Name = "Healing Pool",
                Description = "Health pool",
                Message = "Good thing it's more than a healing mist, because that wouldn't cut it.",
                ModifyHealth = -20,
                ModifyVitality = 1
            };
            gameMap.MapLocations[1, 2, 3] = new Location()
            {
                Id = 36,
                Name = "Fight",
                Description = "Enemy",
                Message = "You see a zombie with a strange shirt. Kind of boring really.",
                Npcs = new ObservableCollection<Npc>
                {
                    NpcById(1007)
                },
            };
            gameMap.MapLocations[2, 0, 3] = new Location()
            {
                Id = 37,
                Name = "Fight",
                Description = "Enemy",
                Message = "You see a zombie with a strange shirt. Kind of boring really.",
                Npcs = new ObservableCollection<Npc>
                {
                    NpcById(1008)
                },
            };
            gameMap.MapLocations[2, 1, 3] = new Location()
            {
                Id = 38,
                Name = "Mana Pool",
                Description = "Mana pool",
                Message = "You enter a room and feel magic in the air. You eat it all, and only kind of regret it afterwards. You're not sure how you ate it though.",
                ModifyMagic = 1,
                ModifyMana = -20
            };
            gameMap.MapLocations[2, 2, 3] = new Location()
            {
                Id = 39,
                Name = "Healing Pool",
                Description = "Health pool",
                Message = "Good thing it's more than a healing mist, because wouldn't cut it.",
                ModifyHealth = -20,
                ModifyVitality = 1
            };

            // Fifth floor
            gameMap.MapLocations[0, 0, 4] = new Location()
            {
                Id = 41,
                Name = "Healing Pool",
                Description = "Health pool",
                Message = "Good thing it's more than a healing mist, because wouldn't cut it.",
                ModifyHealth = -20,
                ModifyVitality = 1
            };
            gameMap.MapLocations[0, 1, 4] = new Location()
            {
                Id = 42,
                Name = "Mana Pool",
                Description = "Mana pool",
                Message = "You enter a room and feel magic in the air. You eat it all, and only kind of regret it afterwards. You're not sure how you ate it though.",
                ModifyMagic = 1,
                ModifyMana = -20
            };
            gameMap.MapLocations[0, 2, 4] = new Location()
            {
                Id = 43,
                Name = "Fight",
                Description = "Enemy",
                Message = "You enter the room, and see a being that makes you feel a lot of shame for some reason. It might be the bad hair choice.",
                Npcs = new ObservableCollection<Npc>
                {
                    NpcById(1009)
                },
            };
            gameMap.MapLocations[1, 0, 4] = new Location()
            {
                Id = 34,
                Name = "Fight",
                Description = "Enemy",
                Message = "You see a ball of flies. Based on what you've seen so far, they definitely aren't normal.",
                Npcs = new ObservableCollection<Npc>
                {
                    NpcById(1010)
                },
            };
            gameMap.MapLocations[1, 1, 4] = new Location()
            {
                Id = 35,
                Name = "Healing Pool",
                Description = "Health pool",
                Message = "Good thing it's more than a healing mist, because that wouldn't cut it.",
                ModifyHealth = -20,
                ModifyVitality = 1
            };
            gameMap.MapLocations[1, 2, 4] = new Location()
            {
                Id = 36,
                Name = "Fight",
                Description = "Enemy",
                Message = "You enter the room, and are immediately yelled at by some demon for your shirt choice. You decide to call her Helen.",
                Npcs = new ObservableCollection<Npc>
                {
                    NpcById(1011)
                },
            };
            gameMap.MapLocations[2, 0, 4] = new Location()
            {
                Id = 37,
                Name = "Fight",
                Description = "Enemy",
                Message = "You see a normal looking person, then he rips a chunk of floor out of the ground and throws it at you. You barely dodged it.",
                Npcs = new ObservableCollection<Npc>
                {
                    NpcById(1012)
                },
            };
            gameMap.MapLocations[2, 1, 4] = new Location()
            {
                Id = 38,
                Name = "Fight",
                Description = "Enemy",
                Message = "You enter the room, and chaos ensues. You're not sure what that man is wearing, or what that giant flat reptile is, but it you already don't like where this is going.",
                Npcs = new ObservableCollection<Npc>
                {
                    NpcById(1013)
                },
            };
            gameMap.MapLocations[2, 2, 4] = new Location()
            {
                Id = 39,
                Name = "Healing Pool",
                Description = "Health pool",
                Message = "Good thing it's more than a healing mist, because wouldn't cut it.",
                ModifyHealth = -20,
                ModifyVitality = 1
            };

            // Sixth floor
            gameMap.MapLocations[0, 0, 5] = new Location()
            {
                Id = 51,
                Name = "Healing Pool",
                Description = "Health pool",
                Message = "Good thing it's more than a healing mist, because wouldn't cut it.",
                ModifyHealth = -20,
                ModifyVitality = 1
            };
            gameMap.MapLocations[0, 1, 5] = new Location()
            {
                Id = 52,
                Name = "Mana Pool",
                Description = "Mana pool",
                Message = "You enter a room and feel magic in the air. You eat it all, and only kind of regret it afterwards. You're not sure how you ate it though.",
                ModifyMagic = 1,
                ModifyMana = -20
            };
            gameMap.MapLocations[0, 2, 5] = new Location()
            {
                Id = 53,
                Name = "Healing Pool",
                Description = "Health pool",
                Message = "Good thing it's more than a healing mist, because wouldn't cut it.",
                ModifyHealth = -20,
                ModifyVitality = 1
            };
            gameMap.MapLocations[1, 0, 5] = new Location()
            {
                Id = 54,
                Name = "Mana Pool",
                Description = "Mana pool",
                Message = "You enter a room and feel magic in the air. You eat it all, and only kind of regret it afterwards. You're not sure how you ate it though.",
                ModifyMagic = 1,
                ModifyMana = -20
            };
            gameMap.MapLocations[1, 1, 5] = new Location()
            {
                Id = 55,
                Name = "Boss",
                Description = "Probably the last enemy.",
                Message = "This is probably the boss of the tower. The surrounding rooms will heal you.",
                Npcs = new ObservableCollection<Npc>
                {
                    NpcById(1014)
                },
            };
            gameMap.MapLocations[1, 2, 5] = new Location()
            {
                Id = 56,
                Name = "Healing Pool",
                Description = "Health pool",
                Message = "Good thing it's more than a healing mist, because wouldn't cut it.",
                ModifyHealth = -20,
                ModifyVitality = 1
            };
            gameMap.MapLocations[2, 0, 5] = new Location()
            {
                Id = 57,
                Name = "Mana Pool",
                Description = "Mana pool",
                Message = "You enter a room and feel magic in the air. You eat it all, and only kind of regret it afterwards. You're not sure how you ate it though.",
                ModifyMagic = 1,
                ModifyMana = -20
            };
            gameMap.MapLocations[2, 1, 5] = new Location()
            {
                Id = 58,
                Name = "Healing Pool",
                Description = "Health pool",
                Message = "Good thing it's more than a healing mist, because wouldn't cut it.",
                ModifyHealth = -20,
                ModifyVitality = 1
            };
            gameMap.MapLocations[2, 2, 5] = new Location()
            {
                Id = 59,
                Name = "Mana Pool",
                Description = "Mana pool",
                Message = "You enter a room and feel magic in the air. You eat it all, and only kind of regret it afterwards. You're not sure how you ate it though.",
                ModifyMagic = 1,
                ModifyMana = -20
            };
            return gameMap;
        }
        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new Weapon(1000, "Fist", 1, "Jab, Cross, Hook, Uppercut"),
                new Weapon(1001, "Dagger", 2, "Cheese not included"),
                new Weapon(1002, "Club", 4, "Slightly sturdier stick"),
                new Weapon(1003, "Short Spear", 5, "Spear is a generous term here"),
                new Weapon(1004, "Great Club", 6, "You just got suckered into buying a REALLY big stick"),
                new Weapon(1005, "Spear", 10, "Spear is accurate here though"),
                new Weapon(1006, "Shortsword", 12, "A long dagger"),
                new Weapon(1007, "Sword", 15, "The classic choice"),
                new Weapon(1008, "Glaive", 20, "You got a bonus shortsword with your spear!"),
                new Weapon(1009, "Greatsword", 30, "Used for delivering messages of a certain type"),
                new Armor(2000, "Clothes", 1, "The clothes on your back"),
                new Armor(2001, "Hide", 5, "That wasn't a command"),
                new Armor(2002, "Scale", 10, "No I didn't mean scale mail, that would be wrong"),
                new Armor(2003, "Chain", 15, "Because hauberks are expensive"),
                new Armor(2004, "Plate", 20, "Pee flap included"),
            };
        }
        public static List<Npc> Npcs()
        {
            return new List<Npc>()
            {
                new Minion()
                {
                    Id = 1001,
                    Name = "Lieutenant Obvious",
                    Description = "A being that looks so generic you're forgetting what it looks like while looking at it.",
                    Messages = new List<string>()
                    {
                        "Minions unite! Or not."
                    },
                    SkillLevel = 2,
                },
                new Minion()
                {
                    Id = 1002,
                    Name = "Skelly",
                    Description = "A skeleton with a name and appearance so classic you can almost hear a certain song while it dances.",
                    SkillLevel = 5,
                },
                new Minion()
                {
                    Id = 1003,
                    Name = "Shakespear",
                    Description = "An old man with a spear and no poetic talent. He might have been telling you to get off his lawn.",
                    SkillLevel = 5,
                },
                new Minion()
                {
                    Id = 1004,
                    Name = "Blizzard",
                    Description = "What started as a bunch of snow in there air has collected into one pissed off blue person. You've made nature mad now.",
                    SkillLevel = 10,
                },
                new Minion()
                {
                    Id = 1005,
                    Name = "Foul Fowl",
                    Description = "It says words so bad I'd lose my non-existent PG-13 rating.",
                    SkillLevel = 10,
                },
                new Minion()
                {
                    Id = 1006,
                    Name = "Furry",
                    Description = "Some person wearing a horse mask. Usually you don't mind furries, but the sword is making you rethink that.",
                    SkillLevel = 15,
                },
                new Minion()
                {
                    Id = 1007,
                    Name = "Zombo",
                    Description = "Some zombie with a shirt that reads, I'm with stupid =>.",
                    SkillLevel = 15,
                },
                new Minion()
                {
                    Id = 1008,
                    Name = "Zombotar",
                    Description = "Some zombie with a shirt the reads, <= I'm with nerd.",
                    SkillLevel = 23,
                },
                new Minion()
                {
                    Id = 1009,
                    Name = "Failure",
                    Description = "You see what must be the physical embodiment of all your failures. You don't know why you know, but the hair feels like the deciding evidence.",
                    SkillLevel = 23,
                },
                new Minion()
                {
                    Id = 1010,
                    Name = "Tsetse flies",
                    Description = "Why did nature create these, and why are there so many here.",
                    SkillLevel = 35,
                },
                new Minion()
                {
                    Id = 1011,
                    Name = "Hellish Helen",
                    Description = "The name's reduplication is the only pleasent thing about this demon, and you added one of the words.",
                    SkillLevel = 35,
                },
                new Minion()
                {
                    Id = 1012,
                    Name = "Asura",
                    Description = "It is a normal looking person, but based on it's strength, it definitely isn't.",
                    SkillLevel = 53,
                },
                new Minion()
                {
                    Id = 1013,
                    Name = "Florida Man",
                    Description = "He wears a gaudish shirt that says Florida, has a funny shaped pipe with bad smelling smoke, and a weird reptile that wants to eat you.",
                    SkillLevel = 53,
                },
                new Minion()
                {
                    Id = 1014,
                    Name = "The Boss",
                    Description = "You get the sudden urge to call this man boss, but the desire to kill things outweighs that urge.",
                    SkillLevel = 80,
                },
            };
        }
    }
}
