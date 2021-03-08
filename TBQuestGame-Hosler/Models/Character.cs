using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame_Hosler.Models
{
    public class Character : ObservableObject
    {
        #region ENUMERABLES

        public enum CombatType
        {
            Heavy,
            Medium,
            Light,
            None
        }

        #endregion

        #region FIELDS

        protected int _id;
        protected string _name;
        protected int _locationId;
        protected CombatType _combat;
        protected int _tier;
        protected int _level;

        #endregion

        #region PROPERTIES

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int LocationId
        {
            get { return _locationId; }
            set { _locationId = value; }
        }
        public CombatType Combat
        {
            get { return _combat; }
            set { _combat = value; }
        }
        public int Tier
        {
            get { return _tier; }
            set { _tier = value; }
        }
        public int Level  // for npcs only
        {
            get { return _level; }
            set { _level = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, CombatType combat, int locationId, int tier) 
        {
            _name = name;
            _combat = combat;
            _locationId = locationId;
            _tier = tier;
        }
        
        #endregion

        #region METHODS

        public virtual string DefaultGreeting()
        {
            return $"Hello, my name is {_name} and I use tier {_tier} {_combat} equipment.";
        }

        #endregion
    }
}
