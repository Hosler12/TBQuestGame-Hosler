using System;
using System.Windows;
using TBQuestGame_Hosler.Models;
using TBQuestGame_Hosler.DataLayer;
using System.Collections.Generic;

namespace TBQuestGame_Hosler.PresentationLayer
{
    /// <summary>
    /// Interaction logic for Purchase.xaml
    /// </summary>
    public partial class Purchase : Window
    {
        private Player _player;
        public List<GameItem> Items { get; set; }
        public Purchase()
        {
        }
        public Purchase(Player player)
        {
            _player = player;

            InitializeComponent();

            SetupWindow();
        }
        private void SetupWindow()
        {
            PurchseComboBox.ItemsSource = Items;
        }
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}