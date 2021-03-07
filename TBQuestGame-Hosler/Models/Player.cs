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

        #endregion

        #region PROPERTIES

        public int Strength
        {
            get { return _strength; }
            set { _strength = value; }
        }
        public int Agility
        {
            get { return _agility; }
            set { _agility = value; }
        }
        public int Vitality
        {
            get { return _vitality; }
            set { _vitality = value; }
        }
        public int Magic
        {
            get { return _magic; }
            set { _magic = value; }
        } 
        public double Damage
        {
            get { return _damage; }
            set { _damage = value; }
        }
        public double Armor
        {
            get { return _armor; }
            set { _armor = value; }
        }
        public double HPLoss
        {
            get { return _hploss; }
            set { _hploss = value; }
        }
        public double PermanentStrength
        {
            get { return _permanentstrength; }
            set { _permanentstrength = value; }
        }
        public double PermanentAgility
        {
            get { return _permanentagility; }
            set { _permanentagility = value; }
        }
        public double PermanentVitality
        {
            get { return _permanentvitality; }
            set { _permanentvitality = value; }
        }
        public double PermanentMagic
        {
            get { return _permanentmagic; }
            set { _permanentmagic = value; }
        }
        public double MaxHP
        {
            get { return Vitality * PermanentVitality * 10; }
            set { _maxhp = value; }
        }
        public double Health
        {
            get { return MaxHP - HPLoss; }
            set { _health = value; }
        }
        public double ManaLoss
        {
            get { return _manaloss; }
            set { _manaloss = value; }
        }
        public double MaxMana
        {
            get { return Magic * PermanentMagic * 10; }
            set { _mana = value; }
        }
        public double Mana
        {
            get { return MaxMana - ManaLoss; }
            set { _mana = value; }
        }

        #endregion

        #region CONSTRUCTORS



        #endregion

        #region METHODS



        #endregion

        #region EVENTS



        #endregion
    }
}
