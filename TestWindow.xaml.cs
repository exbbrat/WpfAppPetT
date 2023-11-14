using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        public TestWindow(List<string> data)
        {
            InitializeComponent();

            foreach (var item in data)
            {
                ListViewRight.Items.Add(item);
            }
        }

        private void ImportDataButton_Click(object sender, RoutedEventArgs e)
        {
            // Очищаем существующие элементы в ListView перед импортом
            ListViewRight.Items.Clear();

            // Имя файла для импорта
            string filePath = @"C:\Users\nasty\source\repos\WpfAppPetT\imported_data.txt";

            try
            {
                // Проверяем, существует ли файл
                if (File.Exists(filePath))
                {
                    // Читаем все строки из файла и добавляем их в ListView
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        ListViewRight.Items.Add(line);
                    }

                    MessageBox.Show($"Данные успешно импортированы из файла: {filePath}", "Импорт завершен", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show($"Файл {filePath} не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при чтении файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ExportDataButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверяем, есть ли данные в ListView
            if (ListViewRight.Items.Count > 0)
            {
                // Создаем или перезаписываем текстовый файл
                string filePath = "exported_data.txt";

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Записываем данные из ListView в файл
                    foreach (var item in ListViewRight.Items)
                    {
                        writer.WriteLine(item.ToString());
                    }
                }

                MessageBox.Show($"Данные успешно экспортированы в файл: {filePath}", "Экспорт завершен", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Нет данных для экспорта.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
