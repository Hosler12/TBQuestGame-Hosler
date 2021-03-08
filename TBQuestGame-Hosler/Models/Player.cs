using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame_Hosler.Models
{
    public class Player : Character
    {
        #region Variables

        private int _strength;
        private int _agility;
        private int _vitality;
        private int _magic;
        private double _health;
        private double _mana;
        private double _damage;
        private double _armor;
        private double _hploss;
        private double _maxhp;
        private double _permanentstrength;
        private double _permanentagility;
        private double _permanentvitality;
        private double _permanentmagic;
        private double _maxmana;
        private double _manaloss;

        private List<Location> _locationsVisited;

        #endregion

        #region PROPERTIES

        public int Strength
        {
            get { return _strength; }
            set { 
                _strength = value;
                OnPropertyChanged(nameof(Strength));
            }
        }
        public int Agility
        {
            get { return _agility; }
            set { _agility = value;
                OnPropertyChanged(nameof(Agility));
            }
        }
        public int Vitality
        {
            get { return _vitality; }
            set { _vitality = value;
                OnPropertyChanged(nameof(Vitality));
            }
        }
        public int Magic
        {
            get { return _magic; }
            set { _magic = value;
                OnPropertyChanged(nameof(Magic));
            }
        }
        public double PermanentStrength
        {
            get { return _permanentstrength; }
            set { _permanentstrength = value;
                OnPropertyChanged(nameof(PermanentStrength));
            }
        }
        public double PermanentAgility
        {
            get { return _permanentagility; }
            set { _permanentagility = value;
                OnPropertyChanged(nameof(PermanentAgility));
            }
        }
        public double PermanentVitality
        {
            get { return _permanentvitality; }
            set { _permanentvitality = value;
                OnPropertyChanged(nameof(PermanentVitality));
            }
        }
        public double PermanentMagic
        {
            get { return _permanentmagic; }
            set { _permanentmagic = value;
                OnPropertyChanged(nameof(PermanentMagic));
            }
        }
        public double Damage
        {
            get { return Strength * PermanentStrength; }
            set { _damage = value;
                OnPropertyChanged(nameof(Strength));
                OnPropertyChanged(nameof(Damage));
            }
        }
        public double Armor
        {
            get { return Agility * PermanentAgility; }
            set { _armor = value;
                OnPropertyChanged(nameof(Armor));
            }
        }
        public double MaxHP
        {
            get { return Vitality * PermanentVitality * 10; }
            set
            {
                _maxhp = value;
                OnPropertyChanged(nameof(Vitality));
                OnPropertyChanged(nameof(MaxHP));
                OnPropertyChanged(nameof(HPLoss));
                OnPropertyChanged(nameof(Health));
            }
        }
        public double HPLoss
        {
            get { return _hploss; }
            set
            {
                _hploss = value;
                OnPropertyChanged(nameof(HPLoss));
                OnPropertyChanged(nameof(Vitality));
                OnPropertyChanged(nameof(MaxHP));
                OnPropertyChanged(nameof(Health));
            }
        }
        public double Health
        {
            get { return MaxHP - HPLoss; }
            set { 
                _health = value;

                //
                // Resets locations when upon death
                //

                if (_health <= 0)
                {
                    _hploss = 0;
                    _manaloss = 0;
                    _permanentstrength += _strength * .1;
                    _permanentagility += _agility * .1;
                    _permanentvitality += _vitality * .1;
                    _permanentmagic += _magic * .1;
                    _strength = 1;
                    _agility = 1;
                    _vitality = 1;
                    _magic = 1;
                    //_floor = 1;
                    _locationsVisited.Clear();
                }
                OnPropertyChanged(nameof(Vitality));
                OnPropertyChanged(nameof(HPLoss));
                OnPropertyChanged(nameof(Health));
                OnPropertyChanged(nameof(MaxHP));
            }
        }
        public double ManaLoss
        {
            get { return _manaloss; }
            set {
                _manaloss = value;

                if (_manaloss > MaxMana)
                {
                    _manaloss = MaxMana; // Likely also implemented in shop to prevent over purchasing
                }
                OnPropertyChanged(nameof(Magic));
                OnPropertyChanged(nameof(MaxMana));
                OnPropertyChanged(nameof(ManaLoss));
                OnPropertyChanged(nameof(Mana));
            }
        }
        public double MaxMana
        {
            get { return Magic * PermanentMagic * 10; }
            set { _mana = value;
                OnPropertyChanged(nameof(Magic));
                OnPropertyChanged(nameof(MaxMana));
                OnPropertyChanged(nameof(ManaLoss));
                OnPropertyChanged(nameof(Mana));
            }
        }
        public double Mana
        {
            get { return MaxMana - ManaLoss; }
            set { _mana = value;
                OnPropertyChanged(nameof(Magic));
                OnPropertyChanged(nameof(MaxMana));
                OnPropertyChanged(nameof(ManaLoss));
                OnPropertyChanged(nameof(Mana));
            }
        }

        public List<Location> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Player()
        {
            _locationsVisited = new List<Location>();
        }

        #endregion

        #region METHODS

        public bool HasVisited(Location location)
        {
            return _locationsVisited.Contains(location);
        }

        #endregion

        #region EVENTS



        #endregion
    }
}
