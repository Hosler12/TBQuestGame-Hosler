using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame_Hosler.Models
{
    public class Map
    {
        #region FIELDS

        private Location[,,] _mapLocations;
        private int _maxRows, _maxColumns, _maxFloors;
        public static GameMapCoordinates _currentLocationCoordinates;
        private List<GameItem> _standardGameItems;

        #endregion

        #region PROPERTIES

        public Location[,,] MapLocations
        {
            get { return _mapLocations; }
            set { _mapLocations = value; }
        }

        public GameMapCoordinates CurrentLocationCoordinates
        {
            get { return _currentLocationCoordinates; }
            set { _currentLocationCoordinates = value; }
        }

        public Location CurrentLocation
        {
            get { return _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column, _currentLocationCoordinates.Floor]; }
        }
        public List<GameItem> StandardGameItems
        {
            get { return _standardGameItems; }
            set { _standardGameItems = value; }
        }

        #endregion

        #region CONSTRUCTORS

        public Map(int rows, int columns, int floors)
        {
            _maxRows = rows;
            _maxColumns = columns;
            _maxFloors = floors;
            _mapLocations = new Location[rows, columns, floors];
        }

        #endregion

        #region METHODS
        // Move to location if it exists
        //
        public void MoveNorth()
        {
            //
            // not on north border
            //
            if (_currentLocationCoordinates.Row > 0)
            {
                _currentLocationCoordinates.Row -= 1;
            }
        }
        public void MoveEast()
        {
            //
            // not on east border
            //
            if (_currentLocationCoordinates.Column < _maxColumns - 1)
            {
                _currentLocationCoordinates.Column += 1;
            }
        }
        public void MoveSouth()
        {
            if (_currentLocationCoordinates.Row < _maxRows - 1)
            {
                _currentLocationCoordinates.Row += 1;
            }
        }
        public void MoveWest()
        {
            //
            // not on west border
            //
            if (_currentLocationCoordinates.Column > 0)
            {
                _currentLocationCoordinates.Column -= 1;
            }
        }
        public void MoveUp()
        {
            if (_currentLocationCoordinates.Floor < 5)
            {
                _currentLocationCoordinates.Floor += 1;
            }
        }
        // get the location if it exists
        public Location NorthLocation()
        {
            Location northLocation = null;

            //
            // not on north border
            //
            if (_currentLocationCoordinates.Row > 0)
            {
                Location nextNorthLocation = _mapLocations[_currentLocationCoordinates.Row - 1, _currentLocationCoordinates.Column, _currentLocationCoordinates.Floor];

                //
                // location exists
                //
                if (nextNorthLocation != null)
                {
                    northLocation = nextNorthLocation;
                }
            }

            return northLocation;
        }
        public Location EastLocation()
        {
            Location eastLocation = null;

            //
            // not on east border
            //
            if (_currentLocationCoordinates.Column < _maxColumns - 1)
            {
                Location nextEastLocation = _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column + 1, _currentLocationCoordinates.Floor];

                //
                // location exists 
                //
                if (nextEastLocation != null)
                {
                    eastLocation = nextEastLocation;
                }
            }

            return eastLocation;
        }
        public Location SouthLocation()
        {
            Location southLocation = null;

            //
            // not on south border
            //
            if (_currentLocationCoordinates.Row < _maxRows - 1)
            {
                Location nextSouthLocation = _mapLocations[_currentLocationCoordinates.Row + 1, _currentLocationCoordinates.Column, _currentLocationCoordinates.Floor];

                //
                // location exists and player can access location
                //
                if (nextSouthLocation != null)
                {
                    southLocation = nextSouthLocation;
                }
            }

            return southLocation;
        }
        public Location WestLocation()
        {
            Location westLocation = null;

            //
            // not on west border
            //
            if (_currentLocationCoordinates.Column > 0)
            {
                Location nextWestLocation = _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column - 1, _currentLocationCoordinates.Floor];

                //
                // location exists
                //
                if (nextWestLocation != null)
                {
                    westLocation = nextWestLocation;
                }
            }

            return westLocation;
        }
        public Location UpLocation()
        {
            Location upLocation = null;

            if (_currentLocationCoordinates.Floor < 5)
            {
                Location nextUpLocation = _mapLocations[_currentLocationCoordinates.Row, _currentLocationCoordinates.Column, _currentLocationCoordinates.Floor + 1];

                if (nextUpLocation != null)
                {
                    upLocation = nextUpLocation;
                }
            }
            return upLocation;
        }

        #endregion
    }
}
