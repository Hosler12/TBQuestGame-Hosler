using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TBQuestGame_Hosler.PresentationLayer
{
    /// <summary>
    /// Interaction logic for GameSessionView.xaml
    /// </summary>

    public partial class GameSessionView : Window
    {
        GameSessionViewModel _gameSessionViewModel;
        public GameSessionView(GameSessionViewModel gameSessionViewModel)
        {
            _gameSessionViewModel = gameSessionViewModel;

            InitializeWindowTheme();

            InitializeComponent();
        }

        private void InitializeWindowTheme()
        {
            this.Title = "Banana Men Productions";
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.ExitApplication();
        }
        private void NorthTravelButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveNorth();
        }
        private void EastTravelButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveEast();
        }
        private void SouthTravelButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveSouth();
        }
        private void WestTravelButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveWest();
        }
        private void UpTravelButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.MoveUp();
        }
        private void CastButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.OnPlayerCast();
        }
        private void AttackButton_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.OnPlayerAttack();
        }

        private void Purchase_Click(object sender, RoutedEventArgs e)
        {
            _gameSessionViewModel.Purchase();
        }
    }
}
