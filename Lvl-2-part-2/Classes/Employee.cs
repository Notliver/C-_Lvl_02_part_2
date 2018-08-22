using Lvl_2_part_2.Control;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lvl_2_part_2.Classes
{
    class Employee
    {
        private string _family;
        private string _name;
        private string _patrynomic;

        public Department Department { get; set; }

        public ObservableCollection<Department> Departments { get => DepCommands.getInstance().Departments; }

        /// <summary>
        /// Фамилия сотрудника с проверкой после внесения изменений
        /// </summary>
        public string Family
        {
            get => _family;
            set => CheckExeption.CheckExeption.CheckCorrectString(value,out _family);
        }

        /// <summary>
        /// Имя сотрудника с проверкой после внесения изменений
        /// </summary>
        public string Name
        {
            get => _name;
            set => CheckExeption.CheckExeption.CheckCorrectString(value, out _name);
        }

        /// <summary>
        /// Отчество сотрудника с проверкой после внесения изменений
        /// </summary>
        public string Patrynomic
        {
            get => _patrynomic;
            set => CheckExeption.CheckExeption.CheckCorrectString(value,out _patrynomic);
        }

        /// <summary>
        /// Конструктор сотрудника
        /// </summary>
        /// <param name="_family"></param>
        /// <param name="_name"></param>
        /// <param name="_patrynomic"></param>
        public Employee(string _family, string _name, string _patrynomic)
        {
            Family = _family;
            Name = _name;
            Patrynomic = _patrynomic;
        }

        /// <summary>
        /// Конструктор с присвоенным департаментом
        /// </summary>
        /// <param name="_family"></param>
        /// <param name="_name"></param>
        /// <param name="_patrynomic"></param>
        /// <param name="department"></param>
        public Employee(string _family, string _name, string _patrynomic, Department department): this(_family,_name,_patrynomic)
        {
            if(Departments.Contains(department))
            {
                Department = department;
            }
        }
    }
}
