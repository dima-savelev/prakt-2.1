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
using LibMas;
using Lib_13;
using Microsoft.Win32;

namespace prakt_2._1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private int[] _array;

        private void Create(object sender, RoutedEventArgs e)
        {
            try
            {
                int count = Convert.ToInt32(column.Text);
                _array = new int[count];
                dataGrid.ItemsSource = VisualArray.ToDataTable(_array).DefaultView;
                rezultOut.Clear();
            }
            catch
            {
                MessageBox.Show("Введён неверный размер таблицы", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MainOperation(object sender, RoutedEventArgs e)
        {
            if (_array == null) return;
            Practice.Multiply(_array, out int rezult);
            if (rezult == 1)
            {
                MessageBox.Show("Нет чисел больше 2", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            rezultOut.Text = Convert.ToString(rezult);
        }

        private void FillDataGrid(object sender, RoutedEventArgs e)
        {
            try
            {
                int minimum = Convert.ToInt32(numberMin.Text);
                int maximum = Convert.ToInt32(numberMax.Text);
                int count = Convert.ToInt32(column.Text);
                _array = new int[count];
                ArrayOperation.FillArrayRandom(_array, minimum, maximum);
                dataGrid.ItemsSource = VisualArray.ToDataTable(_array).DefaultView;
            }
            catch
            {
                MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            //Определяем номер столбца
            int indexColumn = e.Column.DisplayIndex;
            //Проверяем правильное значение ввел пользователь
            if (!int.TryParse(((TextBox)e.EditingElement).Text, out int number))
            {
                MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            //Заносим введенное значение в массив
            _array[indexColumn] = number;
            rezultOut.Clear();
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            ArrayOperation.ClearArray(_array);
            dataGrid.ItemsSource = VisualArray.ToDataTable(_array).DefaultView;
            column.Clear();
            numberMin.Clear();
            numberMax.Clear();
            rezultOut.Clear();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OpenArray(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Все файлы (*.*)|*.*|Текстовые файлы|*.txt";
            open.FilterIndex = 2;
            open.Title = "Открытие таблицы";
            if (open.ShowDialog() == true)
            {
                if (open.FileName != string.Empty)
                {
                    ArrayOperation.OpenArray(out _array, open.FileName);
                    column.Text = _array.Length.ToString();
                    dataGrid.ItemsSource = VisualArray.ToDataTable(_array).DefaultView;
                }
            }
        }

        private void SaveArray(object sender, RoutedEventArgs e)
        {
            if (_array == null)
            {
                MessageBox.Show("Таблица пуста", "Ошибка");
                return;
            }
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = ".txt";
            save.Filter = "Все файлы (*.*)|*.*|Текстовые файлы|*.txt";
            save.FilterIndex = 2;
            save.Title = "Сохранение таблицы";
            if (save.ShowDialog() == true)
            {
                ArrayOperation.SaveArray(_array, save.FileName);
            }
        }

        private void Info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Савельев Дмитрий Александрович В13\nПрактическая работа №2\nВвести n целых чисел. Найти произведение чисел > 2. Результат вывести на экран.", "Информация о программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
