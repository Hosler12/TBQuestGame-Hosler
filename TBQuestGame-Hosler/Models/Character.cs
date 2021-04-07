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
        protected int _level;
        protected string _description;

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

        public int Level  // for npcs only
        {
            get { return _level; }
            set { _level = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        #endregion

        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(int id, string name, string description) 
        {
            _name = name;
            _id = id;
            _description = description;
        }
        
        #endregion

        #region METHODS

        public virtual string DefaultGreeting()
        {
            return $"Hello, my name is {_name} and I use level {_level} {_combat} equipment.";
        }

        #endregion
    }
}
