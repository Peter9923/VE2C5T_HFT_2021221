using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VE2C5T_GUI_2021222.WpfClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] numbers;
        public MainWindow(){
            numbers = new string[] {"Numpad0", "Numpad1", "Numpad2", "Numpad3", "Numpad4", "Numpad5", "Numpad6", "Numpad7", "Numpad8", "Numpad9",
            "D0", "D1", "D2", "D3", "D4", "D5", "D6", "D7", "D8", "D9"};
            InitializeComponent();
        }

        private bool IsItANumber(string shouldCheckString) {
            if (numbers.Contains(shouldCheckString.ToString())){
                return true;
            }

            return false;
        }


        private async void mygrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Source is TextBox t && t.Tag != null && t.Tag.ToString() == "0" && IsItANumber(e.Key.ToString()) == false)
            {
                t.Background = Brushes.DarkRed;
                e.Handled = true;
                await Task.Delay(1000);
                t.Background = Brushes.White;
            }
        }
    }
}
