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
using System.Text.RegularExpressions;
namespace WpfAppPetT
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            bool showMessage = false; // Переменная для определения, нужно ли выводить MessageBox

            if (ComboBoxLeft.SelectedItem is ComboBoxItem selectedComboBoxItem)
            {
                // Получите содержимое выбранного элемента ComboBoxItem
                string selectedItemContent1 = selectedComboBoxItem.Content.ToString();

                // Добавьте содержимое в ListView
                ListViewLeft.Items.Add(selectedItemContent1);
                showMessage = true;

            }
            if (ComboBoxMiddle.SelectedItem is ComboBoxItem selectedComboBoxItem2)
            {
                // Получите содержимое выбранного элемента ComboBoxItem
                string selectedItemContent2 = selectedComboBoxItem2.Content.ToString();

                // Добавьте содержимое в ListView
                ListViewLeft.Items.Add(selectedItemContent2);
                showMessage = true;

            }
            if (ComboBoxRight.SelectedItem is ComboBoxItem selectedComboBoxItem3)
            {
                // Получите содержимое выбранного элемента ComboBoxItem
                string selectedItemContent3 = selectedComboBoxItem3.Content.ToString();

                // Добавьте содержимое в ListView
                ListViewLeft.Items.Add(selectedItemContent3);
                showMessage = true;

            }

            if (SetTextbox.Text != null)
            {
                ListViewLeft.Items.Add(SetTextbox.Text);
                showMessage = true;
            }

            if (showMessage)
            {
                // Вывод MessageBox с двумя кнопками ("OK" и "Отмена")
                MessageBoxResult result = MessageBox.Show("Данные были успешно добавлены в ListView. Продолжить?", "Подтверждение", MessageBoxButton.OKCancel);

                if (result == MessageBoxResult.OK)
                {
                    // Пользователь нажал "OK", выполните необходимые действия
                    this.Hide();

                    // Показать второе окно
                    TestWindow window = new TestWindow();
                    window.Show();
                }
                else
                {
                    // Пользователь нажал "Отмена", выполните необходимые действия или ничего не делайте
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            ListViewLeft.Items.Clear();
        }

        //private void ApplyButtonMiddle_Click(object sender, RoutedEventArgs e)
        //{
        //    if (ComboBoxMiddle.SelectedItem is ComboBoxItem selectedComboBoxItem)
        //    {
        //        // Получите содержимое выбранного элемента ComboBoxItem
        //        string selectedItemContent = selectedComboBoxItem.Content.ToString();

        //        // Добавьте содержимое в ListView
        //        ListViewLeft.Items.Add(selectedItemContent);
        //    }
        //}

        //private void ApplyButtonRight_Click(object sender, RoutedEventArgs e)
        //{
        //    if (ComboBoxRight.SelectedItem is ComboBoxItem selectedComboBoxItem)
        //    {
        //        // Получите содержимое выбранного элемента ComboBoxItem
        //        string selectedItemContent = selectedComboBoxItem.Content.ToString();

        //        // Добавьте содержимое в ListView
        //        ListViewLeft.Items.Add(selectedItemContent);
        //    }
        //}
    }
}
