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
using Lvl_2_part_2.Classes;
using Lvl_2_part_2.Control;

namespace Lvl_2_part_2.Windows
{
    /// <summary>
    /// Логика взаимодействия для WAdjustmentDep.xaml
    /// </summary>
    public partial class WAdjustmentDep : Window
    {
        public WAdjustmentDep()
        {
            InitializeComponent();
            DataContext = DepCommands.getInstance();
        }
    }
}
