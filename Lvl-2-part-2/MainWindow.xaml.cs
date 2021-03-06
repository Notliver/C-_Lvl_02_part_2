﻿using Lvl_2_part_2.Control;
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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

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
            var connectionString =
            ConfigurationManager.ConnectionStrings["DBEmployeesConnection"].ConnectionString;

            SqlConnection connection = new SqlConnection(connectionString);

            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand command = new SqlCommand(
                "SELECT Last name, First name, Patronymic, Department FROM DBEmplouees", connection);

            adapter.SelectCommand = command;

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            EmployeesDataGrid.DataContext = dataTable.DefaultView;






            EmpCommands data = EmpCommands.getInstance();

            DataContext = data;
            AdjEmp.Click += (s, e) => OpenWindow<WAdjustment>();
            AdjDep.Click += (s, e) => OpenWindow<WAdjustmentDep>();
            Delete.Click += delegate { data.Clear(); };
            Exit.Click += (s, e) => Application.Current.Shutdown();
        }

        /// <summary>
        /// Базовая логика открытия окна(взял из инета)
        /// </summary>
        /// <typeparam name="T"></typeparam>
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
    }
}
