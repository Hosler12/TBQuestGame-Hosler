using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame_Hosler.Models
{
    /// <summary>
    /// Game map location class
    /// </summary>
    public class Location
    {
        #region FIELDS

        private int _id; // must be a unique value for each object
        private string _name;
        private string _description;
        private int _modifyHealth;
        private int _modifyMana;
        private string _message;
        private int _modifyStrength;
        private int _modifyAgility;
        private int _modifyVitality;
        private int _modifyMagic;
        private ObservableCollection<GameItem> _gameItems;

        #endregion

        #region PROPERTIES

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public int ModifyHealth
        {
            get { return _modifyHealth; }
            set { _modifyHealth = value; }
        }
        public int ModifyMana
        {
            get { return _modifyMana; }
            set { _modifyMana = value; }
        }
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        public int ModifyStrength
        {
            get { return _modifyStrength; }
            set { _modifyStrength = value; }
        }
        public int ModifyAgility
        {
            get { return _modifyAgility; }
            set { _modifyAgility = value; }
        }
        public int ModifyVitality
        {
            get { return _modifyVitality; }
            set { _modifyVitality = value; }
        }
        public int ModifyMagic
        {
            get { return _modifyMagic; }
            set { _modifyMagic = value; }
        }

        public ObservableCollection<GameItem> GameItems
        {
            get { return _gameItems; }
            set { _gameItems = value; }
        }
        #endregion

        #region Constructors
        public Location()
        {
            _gameItems = new ObservableCollection<GameItem>();
        }

        #endregion
    }
}
