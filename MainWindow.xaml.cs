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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppPetT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            // Показать второе окно
            AuthWindow window = new AuthWindow();
            window.Show();
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            // Показать второе окно
            RegWindow window = new RegWindow();
            window.Show();
        }
    }
}
