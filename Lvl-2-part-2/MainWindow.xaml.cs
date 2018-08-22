using Lvl_2_part_2.Control;
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
using Lvl_2_part_2.Classes;
using Lvl_2_part_2.Windows;
using System.ComponentModel;

namespace Lvl_2_part_2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = EmpCommands.getInstance();
        }

        private void OpenWindow<T>()
            where T : Window, new()
        {
            bool check = false;
            T obj = null; ;
            foreach (var item in this.OwnedWindows)
            {
                if (item is T)
                {
                    check = true;
                    obj = item as T;
                }
            }

            if (!check)
            {
                T childWindow = new T();
                childWindow.Owner = this;
                childWindow.Show();
            }
            else
            {
                if (!obj.IsFocused)
                {
                    obj.Focus();
                }
            }
        }

        private void openWindowWAdjustmentDep_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow<WAdjustmentDep>();
        }

        private void openWindowWAdjustment_Click(object sender, RoutedEventArgs e)
        {
            OpenWindow<WAdjustment>();
        }

        /// <summary>
        /// Метод должен очищать лист
        /// Но не нашел еще варианта реализации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteAll(object sender, RoutedEventArgs e)
        {
            
                
        }
    }
}
