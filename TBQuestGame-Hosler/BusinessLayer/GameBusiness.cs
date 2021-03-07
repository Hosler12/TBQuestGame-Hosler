using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGame_Hosler.PresentationLayer;
using TBQuestGame_Hosler.Models;
using TBQuestGame_Hosler.DataLayer;

namespace TBQuestGame_Hosler.BusinessLayer
{
    public class GameBusiness
    {
        GameSessionViewModel _gameSessionViewModel;
        bool _newPlayer = true;
        Player _player = new Player();
        PlayerSetupView _playerSetupView = null;
        List<string> _messages;        

        public GameBusiness()
        {
            SetupPlayer();
            InitializeDataSet();
            InstantiateAndShowView();
        }

        /// <summary>
        /// initialize data set
        /// </summary>
        private void SetupPlayer()
        {
            if (_newPlayer)
            {
                _playerSetupView = new PlayerSetupView(_player);
                _playerSetupView.ShowDialog();
                _player = GameData.PlayerData(); // In persistence update, use _username, and set it up in ~/PresentationLayer/PlayerSetupView.xaml.cs
            }
            else
            {
                _player = GameData.PlayerData();
            }
        }
        private void InitializeDataSet()
        {
            //_player = GameData.PlayerData();
            _messages = GameData.InitialMessages();
        }

        /// <summary>
        /// create view model with data set
        /// </summary>
        private void InstantiateAndShowView()
        {
            //
            // instantiate the view model and initialize the data set
            //
            _gameSessionViewModel = new GameSessionViewModel(_player, _messages);
            GameSessionView gameSessionView = new GameSessionView(_gameSessionViewModel);

            gameSessionView.DataContext = _gameSessionViewModel;

            gameSessionView.Show();

        }
    }
}