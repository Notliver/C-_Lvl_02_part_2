using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lvl_2_part_2.Classes
{
    class Employee: Control.DepCommands
    {
        private string _family;
        private string _name;
        private string _petrynomic;

        public Department Department { get; set }

        public ObservableCollection<Department> Departments {  get => }

        public string Family
        {
            get => _family;
            set => CheckExeption.CheckExeption.CheckCorrectString(value,out _family);
        }

        public string Name
        {
            get => _name;
            set => CheckExeption.CheckExeption.CheckCorrectString(value, out _name);
        }

        public string Petrynomic
        {
            get => _petrynomic;
            set => CheckExeption.CheckExeption.CheckCorrectString(value,out _petrynomic);
        }
    }
}
