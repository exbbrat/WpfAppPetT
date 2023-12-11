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
                MessageBox.Show("Ви успішно зайшли у систему!");

                // Скрыть текущее окно
                this.Hide();

                // Показать второе окно
                SettingsWindow window = new SettingsWindow();

                /// 4 butt. 
                /// 3 menuitem 
                /// textbox( only number) 
                window.Show();
            }
            else
            {
                MessageBox.Show("Вы вказали невірні дані для входу.");
            }
        }

        private void ExitButtonAuthWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow window = new MainWindow();
            window.Show();
        }
    }
}
