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
using TBQuestGame_Hosler.Models;

namespace TBQuestGame_Hosler.PresentationLayer
{
    /// <summary>
    /// Interaction logic for PlayerSetupView.xaml
    /// </summary>
    public partial class PlayerSetupView : Window
    {
        private Player _player;

        public PlayerSetupView(Player player)
        {
            _player = player;

            InitializeComponent();

            SetupWindow();
        }

        private void SetupWindow()
        {

        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage;

            if (IsValidInput(out errorMessage))
            {
                username.Text = "Username is required";
            }
            else
            {
                Visibility = Visibility.Hidden;
            }
        }
            /// <summary>
            /// validate user input and generate appropriate error messages
            /// </summary>
            /// <returns>is user input valid</returns>
        private bool IsValidInput(out string errorMessage)
        {
            errorMessage = "";

            if (username.Text == null) 
            {
                errorMessage = "Username is required";
            }
            else if (username.Text == "")
            {
                errorMessage = "Username is required";
            }
            else if (username.Text == "Username is required")
            {
                errorMessage = "Username is required";
            }
            else
            {
                string _username = username.Text;
            }

            return errorMessage == "" ? false : true;
        }
    }
}