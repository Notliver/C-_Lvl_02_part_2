using Lvl_2_part_2.CheckExeption;
using Lvl_2_part_2.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lvl_2_part_2.Control
{
    class EmpCommands : INotifyPropertyChanged
    {
        private Employee selectedEmployee;
        private static EmpCommands example;
        private static object syncRoot = new Object();


        /// <summary>
        /// Получаем/присваиваем сотрудника
        /// </summary>
        public ObservableCollection<Employee> Employees { get; set; }
        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                selectedEmployee = value;
                OnPropertyChanged("SelectedEmpoyee");
            }
        }

        public void Clear()
        {
            Employees.Clear();
        }

        /// <summary>
        /// Описывает логику добавления сотрудника
        /// </summary>
        private RelayCommand addCommand;
        public RelayCommand AddCommand => addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        Employee employee = new Employee("Фамилия", "Имя", "Отчество");
                        Employees.Add(employee);
                        SelectedEmployee = employee;
                    }));

        /// <summary>
        /// Описываем логику удаления сотрудника
        /// </summary>
        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand => deleteCommand ??
                (deleteCommand = new RelayCommand(obj =>
                {
                    Employee employee = obj as Employee;
                    if (employee != null)
                    {
                        var key = Employees.IndexOf(employee);
                        Employees.Remove(employee);
                        if (Employees.Count > 0)
                        {
                            if (key > 0) SelectedEmployee = Employees[key - 1];
                            else SelectedEmployee = Employees[0];
                        }
                    }
                },
                (obj) => Employees.Count > 0));

        /// <summary>
        /// Создаем коллекцию сотрудников
        /// </summary>
        protected EmpCommands()
        {
            Employees = new ObservableCollection<Employee>();
            var departments = DepCommands.getInstance();
            for (int i = 0; i < 10; i++)
            {
                Employees.Add(new Employee("Фамилия " + i, " Имя " + i, "Отчество " + i, departments.Departments[+i]));
            }
        }

        /// <summary>
        /// Событие на изменение значения
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        /// <summary>
        /// Значение для многопользовательской базы
        /// </summary>
        /// <returns></returns>
        public static EmpCommands getInstance()
        {
            if (example == null)
            {
                lock (syncRoot)
                    if (example == null)
                        example = new EmpCommands();
            }
            return example;
        }
    }
}
