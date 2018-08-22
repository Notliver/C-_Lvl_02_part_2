using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lvl_2_part_2.Classes
{
    class Department :Control.DepCommands, INotifyPropertyChanged
    {
        private string _name;


        /// <summary>
        /// Создание департамента
        /// </summary>
        public string Name
        {
            get => _name;
            set => _name = value;
        }


        /// <summary>
        /// Проверяем название на соответствие правилам создания
        /// </summary>
        /// <param name="name"></param>
        public void CheckExistNameOfDepartment(string name)
        {
            if(CheckExeption.CheckExeption.CheckCorrectString(name, out string tmp))
            {
                Name = tmp;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
