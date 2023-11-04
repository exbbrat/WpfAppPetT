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
using WpfAppPetT;

namespace WpfAppPetT
{
    /// <summary>
    /// Interaction logic for RegWindow.xaml
    /// </summary>
    public partial class RegWindow : Window
    {
        public RegWindow()
        {
            InitializeComponent();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            string password1 = CreatePasswordBox.Password;
            string password2 = ConfirmPasswordBox.Password;

            if (password1 != password2)
            {
                // Display an error message to the user.
                MessageBox.Show("The passwords do not match.");
            }
            else
            {
                MessageBox.Show("Ви успішно створили акаунт!");
                this.Hide();

                // Показать второе окно
                AuthWindow window = new AuthWindow();
                window.Show();
            }
        }
    }
}
