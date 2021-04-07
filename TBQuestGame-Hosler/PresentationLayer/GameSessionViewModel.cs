using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame_Hosler;
using TBQuestGame_Hosler.Models;
using System.Windows.Threading;

namespace TBQuestGame_Hosler.PresentationLayer
{
    public class GameSessionViewModel : ObservableObject
    {
        #region FIELDS

        private Player _player;
        private DateTime _gameStartTime;
        private string _gameTimeDisplay;
        private TimeSpan _gameTime;

        private Map _gameMap;
        private Location _currentLocation;
        private string _currentLocationInformation;
        private Location _northLocation, _eastLocation, _southLocation, _westLocation, _upLocation;
        private Random random = new Random();

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

        internal void Purchase()
        {
            var purchase = new Purchase();
            purchase.ShowDialog();
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
        /// handle the retreat event in the view.
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
                            if (battleNpc.Attack() < _player.Armor)
                            {
                                pDamageReceived = battleNpc.Attack();
                            }
                            _player.Agility += 1;
                            _player.Armor = _player.Agility * _player.PermanentAgility * _player.Inventory[1].Bonus;
                            break;
                        case 2:
                            battleNpc.BattleMode = BattleModeName.CAST;
                            pDamageReceived = battleNpc.Cast();
                            break;
                    }
                    _player.HPLoss += pDamageReceived;
                    _player.MaxHP = _player.Vitality * _player.PermanentVitality * 10;
                    _player.Health = _player.MaxHP - _player.HPLoss;
                    if (eDamageReceived > battleNpc.SkillLevel * 10)
                    {
                        battleInformation += $"You have slain {_currentLocation.Npcs[0].Name}. " + Environment.NewLine;
                        _currentLocation.Npcs.Remove(_currentLocation.Npcs[0]);
                    }
                    else
                    {
                        battleInformation += "You stare in dismay as the tower heals the enemy's wounds." + Environment.NewLine;
                    }
                    if (_player.HPLoss > _player.Vitality * _player.PermanentVitality * 10)
                    {
                        battleInformation += $"You have been slain by {_currentLocation.Npcs[0].Name}.";
                    }

                    // build out the text for the current location information
                    battleInformation +=
                        $"Player: {_player.BattleMode}     Hit Points: {_player.Health}" + Environment.NewLine +
                        $"NPC: {battleNpc.BattleMode}     Hit Points: {battleNpc.SkillLevel * 10}" + Environment.NewLine;

                }
                CurrentLocationInformation = battleInformation;
            }
        }
        #endregion

        #region HELPER METHODS

        private int DieRoll(int sides)
        {
            return random.Next(1, sides + 1);
        }
        #endregion
    }
}
