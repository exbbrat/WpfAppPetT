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
using System.Windows.Threading;

namespace WpfAppPetT
{
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class TestWindow : Window
    {
        private DispatcherTimer timer; // Об'єкт таймера
        private TimeSpan timeLeft; // Залишений час
        internal TestWindow(List<string> data)
        {
            InitializeComponent();
            //StartTimer();

            foreach (var item in data)
            {
                ListViewP1.Items.Add(item);
            }
        }

        //private void StartTimer()
        //{
        //    timeLeft = TimeSpan.FromMinutes(3); // Встановлення початкового часу (3 хвилини)

        //    // Створення та налаштування таймера
        //    timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
        //    {
        //        timerLabel.Content = timeLeft.ToString(@"mm\:ss"); // Оновлення Label з відліком часу

        //        if (timeLeft == TimeSpan.Zero)
        //        {
        //            timer.Stop(); // Зупинка таймера, коли час вичерпаний
        //            MessageBox.Show("Час вийшов!");
        //        }

        //        timeLeft = timeLeft.Add(TimeSpan.FromSeconds(-1)); // Віднімання однієї секунди
        //    }, Application.Current.Dispatcher);

        //    timer.Start(); // Початок таймера
        //}
        private void ImportDataButton_Click(object sender, RoutedEventArgs e)
        {
            // Очищаем существующие элементы в ListView перед импортом
            ListViewP1.Items.Clear();

            // Имя файла для импорта
            string filePath = @"D:\____Файли з диску\C# Python\Программирование\GitHub_Projects\imported_data.txt";

            try
            {
                // Проверяем, существует ли файл
                if (File.Exists(filePath))
                {
                    // Читаем все строки из файла и добавляем их в ListView
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        ListViewP1.Items.Add(line);
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
            if (ListViewP1.Items.Count > 0)
            {
                // Создаем или перезаписываем текстовый файл
                string filePath = "exported_data.txt";

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    // Записываем данные из ListView в файл
                    foreach (var item in ListViewP1.Items)
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

        internal void UpdateListViewVisibility()
        {
            // Настраиваем видимость ListView в зависимости от значения numberOfListViewsToShow
            //ListViewP1.Visibility = numberOfListViewsToShow >= 1 ? Visibility.Visible : Visibility.Collapsed;
            //ListViewP2.Visibility = numberOfListViewsToShow >= 2 ? Visibility.Visible : Visibility.Collapsed;
            //ListViewP3.Visibility = numberOfListViewsToShow >= 3 ? Visibility.Visible : Visibility.Collapsed;
            //ListViewP4.Visibility = numberOfListViewsToShow >= 4 ? Visibility.Visible : Visibility.Collapsed;
            //ListViewP5.Visibility = numberOfListViewsToShow >= 5 ? Visibility.Visible : Visibility.Collapsed;
            //ListViewP6.Visibility = numberOfListViewsToShow >= 6 ? Visibility.Visible : Visibility.Collapsed;
            //// ... настраиваем остальные ListView до ListViewP6 ...
        }

        private void TestWindow_loaded()
        {
            //string selectedValue = propGamers;

            //var temp = int.Parse(selectedValue);
            //var tmpint = 0;

            //// Определение количества ListViewToShow в зависимости от выбранного элемента в ComboBox
            //if (temp == 2)
            //{
            //    // show 1, 2 player
            //    ListViewP1.Visibility = Visibility.Visible;
            //    ListViewP2.Visibility = Visibility.Visible;
            //}
            //else if (temp == 4)
            //{
            //    // show 4 play
            //    numberOfListViewsToShow = 4;
            //}
            //else if (temp == 6)
            //{
            //    // show 6 play 
            //    numberOfListViewsToShow = 6;
            //}
        }
        private bool isTimerRunning = false; // Флаг для отслеживания состояния таймера

        private void StartTimerButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isTimerRunning)
            {
                timeLeft = TimeSpan.FromMinutes(3); // Установка начального времени (3 минуты)

                // Создание и настройка таймера
                timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
                {
                    timerLabel.Content = timeLeft.ToString(@"mm\:ss"); // Обновление Label с отсчетом времени

                    if (timeLeft == TimeSpan.Zero)
                    {
                        timer.Stop(); // Остановка таймера, если время вышло
                        MessageBox.Show("Время вышло!");
                        isTimerRunning = false; // Сброс флага
                    }

                    timeLeft = timeLeft.Add(TimeSpan.FromSeconds(-1)); // Уменьшение времени на одну секунду
                }, Application.Current.Dispatcher);

                timer.Start(); // Запуск таймера
                isTimerRunning = true; // Установка флага
            }
            else
            {
                MessageBox.Show("Таймер уже запущен!"); // Сообщение, если таймер уже запущен
            }
        }

        private void ResetTimerButton_Click(object sender, RoutedEventArgs e)
        {
            // Остановка таймера, если он запущен
            if (timer != null && timer.IsEnabled)
            {
                timer.Stop();
            }

            // Установка времени на начальное значение (3 минуты в данном случае)
            timeLeft = TimeSpan.FromMinutes(3);

            // Обновление Label с отображением времени на начальное значение
            timerLabel.Content = timeLeft.ToString(@"mm\:ss");

            isTimerRunning = false; // Сброс флага запущенности таймера 
        }
    }
}
