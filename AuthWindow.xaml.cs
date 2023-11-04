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

namespace WpfAppPetT
{
    /// <summary>
    /// Interaction logic for AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginBox.Text;
            string password = PasswordBox.Password;
            bool isCorrect = login == "admin" && password == "12345";
            if (isCorrect)
            {
                //// Скрыть текущее окно
                //this.Hide();

                //// Показать второе окно
                //AuthWindow window = new AuthWindow();
                //window.Show();

                MessageBox.Show("Ви успішно зайшли у систему!");
            }
            else
            {
                MessageBox.Show("Вы вказали невірні дані для входу.");
            }
        }
    }
}
