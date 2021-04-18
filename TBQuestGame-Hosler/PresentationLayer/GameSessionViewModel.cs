using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame_Hosler;
using TBQuestGame_Hosler.Models;
using System.Windows.Threading;
using System.Windows;
using TBQuestGame_Hosler.DataLayer;

namespace TBQuestGame_Hosler.PresentationLayer
{
    public class GameSessionViewModel : ObservableObject
    {
        #region FIELDS

        private Player _player;
        private DateTime _gameStartTime;
        private string _gameTimeDisplay;
        private TimeSpan _gameTime;
        private int kills = 0;
        private Map _gameMap;
        private Location _currentLocation;
        private string _currentLocationInformation;
        private Location _northLocation, _eastLocation, _southLocation, _westLocation, _upLocation;
        private Random random = new Random();
        private string _storyInformation;
        private GameItem _currentGameItem;
        private Npc _npcs;

        #endregion

        #region PROPERTIES
        public Player Player
        {
            get { return _player; }
            set { _player = value; }
        }
        public string MessageDisplay
        {
            get { return _currentLocation.Message; }
        }
        public Map GetMap
        {
            get { return _gameMap; }
            set { _gameMap = value; }
        }
        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set
            {
                _currentLocation = value;
                _currentLocationInformation = _currentLocation.Description;
                CurrentLocationInformation += Environment.NewLine + "Weapon: " + _player.Inventory[0].Name + " Note: " + _player.Inventory[0].Description;
                CurrentLocationInformation += Environment.NewLine + "Armor: " + _player.Inventory[1].Name + " Note: " + _player.Inventory[1].Description;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }
        public string CurrentLocationInformation
        {
            get { return _currentLocationInformation; }
            set
            {
                _currentLocationInformation = value;
                OnPropertyChanged(nameof(CurrentLocationInformation));
            }
        }
        public string StoryInformation
        {
            get { return _storyInformation; }
            set
            {
                _storyInformation = value;
                OnPropertyChanged(nameof(StoryInformation));
            }
        }
        // expose information about travel points from current location
        public Location NorthLocation
        {
            get { return _northLocation; }
            set
            {
                _northLocation = value;
                OnPropertyChanged(nameof(NorthLocation));
                OnPropertyChanged(nameof(HasNorthLocation));
            }
        }
        public Location EastLocation
        {
            get { return _eastLocation; }
            set
            {
                _eastLocation = value;
                OnPropertyChanged(nameof(EastLocation));
                OnPropertyChanged(nameof(HasEastLocation));
            }
        }
        public Location SouthLocation
        {
            get { return _southLocation; }
            set
            {
                _southLocation = value;
                OnPropertyChanged(nameof(SouthLocation));
                OnPropertyChanged(nameof(HasSouthLocation));
            }
        }
        public Location WestLocation
        {
            get { return _westLocation; }
            set
            {
                _westLocation = value;
                OnPropertyChanged(nameof(WestLocation));
                OnPropertyChanged(nameof(HasWestLocation));
            }
        }
        public Location UpLocation
        {
            get { return _upLocation; }
            set
            {
                _upLocation = value;
                OnPropertyChanged(nameof(UpLocation));
                OnPropertyChanged(nameof(HasUpLocation));
            }
        }
        // Checks if location is null, if not, then it is true that it has*direction*location
        public bool HasNorthLocation { get { return NorthLocation != null; } }
        public bool HasEastLocation { get { return EastLocation != null; } }
        public bool HasSouthLocation { get { return SouthLocation != null; } }
        public bool HasWestLocation { get { return WestLocation != null; } }
        public bool HasUpLocation { get { return UpLocation != null; } }
        public string MissionTimeDisplay
        {
            get { return _gameTimeDisplay; }
            set
            {
                _gameTimeDisplay = value;
                OnPropertyChanged(nameof(MissionTimeDisplay));
            }
        }
        public GameItem CurrentGameItem
        {
            get { return _currentGameItem; }
            set { _currentGameItem = value; }
        }
        public Npc CurrentNpc
        {
            get { return _npcs; }
            set
            {
                _npcs = value;
                OnPropertyChanged(nameof(CurrentLocation));
                OnPropertyChanged(nameof(CurrentNpc));
            }
        }
        #endregion
        
        #region CONSTRUCTORS

        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(
            Player player,
            Map gameMap,
            GameMapCoordinates currentLocationCoordinates)
        {
            _player = player;
            
            _gameMap = gameMap;
            _gameMap.CurrentLocationCoordinates = currentLocationCoordinates;
            _currentLocation = _gameMap.CurrentLocation;
            InitializeView();

            GameTimer();
        }

        #endregion

        #region METHODS

        public void GameTimer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += OnGameTimerTick;
            timer.Start();
        }

        /// <summary>
        /// initial setup of the game session view
        /// </summary>
        private void InitializeView()
        {
            _gameStartTime = DateTime.Now;
            _currentLocationInformation = CurrentLocation.Description;
            CurrentLocationInformation += Environment.NewLine + "Weapon: " + _player.Inventory[0].Name + " Note: " + _player.Inventory[0].Description;
            CurrentLocationInformation += Environment.NewLine + "Armor: " + _player.Inventory[1].Name + " Note: " + _player.Inventory[1].Description;
            StoryInformation = "You open your eyes, and hear a heavy door thuds behind you, quickly followed by a loud click. A little bit of door rattling reveals it's very locked. You obvously choose to walk in here, but you can't remember why." + Environment.NewLine + 
                "You jolt back in surprise when you realize your hand and arms are glowing. You look for a weapon to scrape it off, and instead, the glowing begins shifting towards a club-like shape." + Environment.NewLine +
                "You will it to stop and look around. Two other doors, and a glowing circle in the middle of the room. Time to explore." + Environment.NewLine;
            UpdateAvailableTravelPoints();
        }
        // Calculate available travel points
        private void UpdateAvailableTravelPoints()
        {
            //
            // reset travel location information
            //
            NorthLocation = null;
            EastLocation = null;
            SouthLocation = null;
            WestLocation = null;
            UpLocation = null;

            //
            // Nearby location exists check
            //
            if (_gameMap.NorthLocation() != null)
            {
                Location nextNorthLocation = _gameMap.NorthLocation();
                NorthLocation = nextNorthLocation;
            }
            if (_gameMap.EastLocation() != null)
            {
                Location nextEastLocation = _gameMap.EastLocation();
                EastLocation = nextEastLocation;
            }
            if (_gameMap.SouthLocation() != null)
            {
                Location nextSouthLocation = _gameMap.SouthLocation();
                SouthLocation = nextSouthLocation;
            }
            if (_gameMap.WestLocation() != null)
            {
                Location nextWestLocation = _gameMap.WestLocation();
                WestLocation = nextWestLocation;
            }
            if (_gameMap.UpLocation() != null)
            {
                Location nextUpLocation = _gameMap.UpLocation();
                UpLocation = nextUpLocation;
            }
        }
        /// <summary>
        /// player move event handler
        /// </summary>
        private void OnPlayerMove()
        {
            //
            // update player stats when in new location
            //
            if (!_player.HasVisited(_currentLocation))
            {
                //
                // add location to list of visited locations
                //
                _player.LocationsVisited.Add(_currentLocation);

                
                // update stats based on current location, then based on those changes
                
                if (_currentLocation.ModifyHealth <= 0)
                {
                    _player.HPLoss += _currentLocation.ModifyHealth;
                }
                else
                {
                    if (_currentLocation.ModifyHealth > _player.Armor)
                    { _player.HPLoss += _currentLocation.ModifyHealth; }
                }
                _player.ManaLoss += _currentLocation.ModifyMana;
                _player.Strength += _currentLocation.ModifyStrength;
                _player.Agility += _currentLocation.ModifyAgility;
                _player.Vitality += _currentLocation.ModifyVitality;
                _player.Magic += _currentLocation.ModifyMagic;
                _player.Damage = _player.Strength * _player.PermanentStrength;
                _player.Armor = _player.Agility * _player.PermanentAgility;
                _player.MaxMana = _player.Magic * _player.PermanentMagic * 10;
                if (_player.ManaLoss < 0)
                { _player.ManaLoss = 0; }
                _player.Mana = _player.MaxMana - _player.ManaLoss;
                if ( _player.Mana < 0 )
                {
                    _player.HPLoss += _player.Mana;
                    _player.ManaLoss = _player.MaxMana;
                    _player.Mana = _player.MaxMana - _player.ManaLoss;
                }
                _player.MaxHP = _player.Vitality * _player.PermanentVitality * 10;
                _player.Health = _player.MaxHP - _player.HPLoss; // Implemeent death ViewModel, not player
                
                // display a new message if available
                OnPropertyChanged(nameof(MessageDisplay));
            }
        }
        // travel in direction
        public void MoveNorth()
        {
            if (HasNorthLocation)
            {
                _gameMap.MoveNorth();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }
        public void MoveEast()
        {
            if (HasEastLocation)
            {
                _gameMap.MoveEast();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }
        public void MoveSouth()
        {
            if (HasSouthLocation)
            {
                _gameMap.MoveSouth();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }
        public void MoveWest()
        {
            if (HasWestLocation)
            {
                _gameMap.MoveWest();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }
        public void MoveUp()
        {
            if (HasUpLocation)
            {
                _gameMap.MoveUp();
                CurrentLocation = _gameMap.CurrentLocation;
                UpdateAvailableTravelPoints();
                OnPlayerMove();
            }
        }
        internal void ArmorUp()
        {
            int newArmor = _player.Inventory[1].Id + 1;
            CurrentLocationInformation = newArmor.ToString();
            _player.Inventory.Add(GameData.GameItemById(newArmor));
            if (_player.Inventory[2].Bonus * 2 <= _player.Mana)
            {
                _player.Inventory[1] = _player.Inventory[2];
                CurrentLocationInformation = "You conjure a new armor successfully, and decide that wearing two armors would look dumb. Basic fasion.";
                _player.Armor = _player.Inventory[1].Bonus + _player.Agility * _player.PermanentAgility;
                _player.ManaLoss += _player.Inventory[1].Bonus * 2;
                _player.Mana = _player.MaxMana - _player.ManaLoss;
            }
            else
            {
                CurrentLocationInformation = "You try to conjure some new armor, but find your mana pool is lacking. Too bad you don't know how to block.";
            }
            _player.Inventory.RemoveAt(2);
        }
        internal void WeaponUp()
        {
            int newWeapon = _player.Inventory[0].Id + 1;
            CurrentLocationInformation = newWeapon.ToString();
            _player.Inventory.Add(GameData.GameItemById(newWeapon));
            if (_player.Inventory[2].Bonus <= _player.Mana)
            {
                _player.Inventory[0] = _player.Inventory[2];
                CurrentLocationInformation = "You conjure a new weapon successfully, and throw away the old one because you definitely won't need that later.";
                _player.Damage = _player.Inventory[0].Bonus + _player.Strength * _player.PermanentStrength;
                _player.ManaLoss += _player.Inventory[0].Bonus;
                _player.Mana = _player.MaxMana - _player.ManaLoss;
            }
            else
            {
                CurrentLocationInformation = "You try to conjure a new weapon, but find your mana pool is lacking. Time to hit stuff more.";
            }
            _player.Inventory.RemoveAt(2);
        }
        /// <summary>
        /// running time of game
        /// </summary>
        /// <returns></returns>
        private TimeSpan GameTime()
        {
            return DateTime.Now - _gameStartTime;
        }
        /// <summary>
        /// game timer event handler
        /// 1) update mission time on window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnGameTimerTick(object sender, EventArgs e)
        {
            _gameTime = DateTime.Now - _gameStartTime;
            MissionTimeDisplay = "Mission Time " + _gameTime.ToString(@"hh\:mm\:ss");
        }
        public void ExitApplication()
        {
            Environment.Exit(0);
        }
        public void OnPlayerTalkTo()
        {
            if (_currentLocation.Npcs[0] != null && _currentLocation.Npcs[0] is ISpeak)
            {
                ISpeak speakingNpc = _currentLocation.Npcs[0] as ISpeak;
                CurrentLocationInformation = speakingNpc.Speak();
            }
        }
        /// <summary>
        /// handle the attack event in the view.
        /// </summary>
        public void OnPlayerAttack()
        {
            _player.BattleMode = BattleModeName.ATTACK;
            Battle();
        }
        /// <summary>
        /// handle the cast event in the view.
        /// </summary>
        public void OnPlayerCast()
        {
            _player.BattleMode = BattleModeName.CAST;
            Battle();
        }
        private void Battle()
        {
            string battleInformation = "";

            //
            // check to see if an NPC can battle
            //
            if (_currentLocation.Npcs != null && _currentLocation.Npcs.ElementAtOrDefault(0) != null)
            {
                if (_currentLocation.Npcs[0] is IBattle)
                {
                    IBattle battleNpc = _currentLocation.Npcs[0] as IBattle;
                    string npcName = _currentLocation.Npcs[0].Name;
                    string npcDescription = _currentLocation.Npcs[0].Description;
                    string playerWeapon = _player.Inventory[0].Name;
                    string playerArmor = _player.Inventory[1].Name;
                    double eDamageReceived = 0;
                    if (_player.BattleMode == BattleModeName.ATTACK)
                    {
                        eDamageReceived = _player.Attack();
                    }
                    else if (_player.BattleMode == BattleModeName.CAST)
                    {
                        eDamageReceived = _player.Cast();
                    }
                    double pDamageReceived = 0;
                    switch (DieRoll(2))
                    {
                        case 1:
                            battleNpc.BattleMode = BattleModeName.ATTACK;
                            if (battleNpc.Attack() > _player.Armor)
                            {
                                pDamageReceived = battleNpc.Attack();
                                _player.Agility += 1;
                                _player.Armor = _player.Agility * _player.PermanentAgility + _player.Inventory[1].Bonus;
                            }
                            break;
                        case 2:
                            battleNpc.BattleMode = BattleModeName.CAST;
                            pDamageReceived = battleNpc.Cast();
                            break;
                    }
                    _player.HPLoss += pDamageReceived;
                    _player.MaxHP = _player.Vitality * _player.PermanentVitality * 10;
                    if (eDamageReceived >= battleNpc.SkillLevel * 10)
                    {
                        battleInformation += $"You have slain {_currentLocation.Npcs[0].Name}. " + Environment.NewLine;
                        _currentLocation.Npcs.Remove(_currentLocation.Npcs[0]);
                        OnKill(npcName, npcDescription, playerWeapon, playerArmor);
                    }
                    else
                    {
                        battleInformation += "The tower heals the enemy's wounds." + Environment.NewLine;
                    }
                    if (_player.MaxHP - _player.HPLoss <= 0)
                    {
                        //OnDeath();
                        battleInformation += $"You have been slain by {_currentLocation.Npcs[0].Name}." + Environment.NewLine;
                    }
                    // build out the text for the current location information
                    battleInformation +=
                        $"Player: {_player.BattleMode}   Hit Points: {_player.Health}   Dealt: {eDamageReceived}" + Environment.NewLine +
                        $"NPC: {battleNpc.BattleMode}   Hit Points: {battleNpc.SkillLevel * 10}   Dealt: {pDamageReceived}";
                    _player.Health = _player.MaxHP - _player.HPLoss;
                }
                CurrentLocationInformation = battleInformation;
            }
        }
        #endregion
        //private void OnDeath()
        //{

        //}
        private void OnKill(string npcName, string npcDescription, string playerWeapon, string playerArmor)
        {
            kills++;
            StoryInformation += $"{npcName}: {npcDescription}" + Environment.NewLine;
            switch (kills)
            {
                case 1:
                    StoryInformation += $"You make your final strike, and {npcName} falls. Nothing should be able to heal that quickly. Sadly, you won't learn anything from beating them up in the future." + Environment.NewLine;
                    break;
                case 2:
                    StoryInformation += $"You hope this will become easier, because no matter how many times you can come back, this is mentally tiring." + Environment.NewLine;
                    break;
                case 3:
                    StoryInformation += $"It's not getting easier. {npcName} definitely won't be the strongest thing in this tower, and the more you go up, the more you worry about what is coming" + Environment.NewLine;
                    break;
                case 4:
                    StoryInformation += $"You block {npcName}'s desperate last attack. It's too bad you've learned everything you can from the previous enemies, but it feels like you had experience with fighting before the tower." + Environment.NewLine;
                    break;
                case 5:
                    StoryInformation += $"You decide to try to talk to {npcName}, since magical things can usually talk. You think. You must have killed it's father or something, because it ignored you" + Environment.NewLine;
                    break;
                case 6:
                    StoryInformation += $"Talking to this one didn't work either. It didn't chase you out of the room though, so it probably wasn't father murder. Probably." + Environment.NewLine;
                    break;
                case 7:
                    StoryInformation += $"You keep going through the tower, each life learning more and more, but the enemies don't change for some reason." + Environment.NewLine;
                    break;
                case 8:
                    StoryInformation += $"{npcName} finally falls to the ground, and you continue on. Now that it's become easier, you're starting to wonder things. Things like why are you here, and what is at the top of the tower." + Environment.NewLine;
                    break;
                case 9:
                    StoryInformation += $"As you extract your {playerWeapon} from {npcName}, you begin to regret thinking so much. Why do the enemies wait for you? Will doing this even accomplish anything?" + Environment.NewLine;
                    break;
                case 10:
                    StoryInformation += $"After you finish off {npcName}, you think one question that makes you stop. Are you a bastard? You keep moving forward at all costs, despite not being able to see the goal. Or any goal for that matter." + Environment.NewLine;
                    break;
                case 11:
                    StoryInformation += $"Another enemy dead, and more questions keep coming. Why do they just disappear, when you kill them. Where did you learn to summon equipment and fight? Why did you enter the tower" + Environment.NewLine;
                    break;
                case 12:
                    StoryInformation += $"You're done with the thinking. You don't need to know why anything is the way it is. You have a goal, and it's one that you set when you started. Explore." + Environment.NewLine;
                    break;
                case 13:
                    StoryInformation += $"Your task is continuing without issue now that you've focused. RIght now it's just you, your {playerWeapon}, and potentially hundreds of things to finish" + Environment.NewLine;
                    break;
                case 14:
                    StoryInformation += $"You kill {npcName}, and find yourself in the first room, a broken mana crystal in your hand this time. A spell gone wrong? Who cares, you have a town to protect. You don your {playerArmor} armor, summon a {playerWeapon}, and begin one last climb." + Environment.NewLine;
                    break;
                default:
                    break;
            }
        }

        #region HELPER METHODS

        private int DieRoll(int sides)
        {
            return random.Next(1, sides + 1);
        }
        #endregion
    }
}
