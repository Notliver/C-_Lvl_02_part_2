using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lvl_2_part_2.Classes
{
    class Department : INotifyPropertyChanged
    {
        private string _name;

        /// <summary>
        /// Присваиваем имя
        /// </summary>
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }


        /// <summary>
        /// Создаем и проверяем название на соответствие правилам создания
        /// </summary>
        /// <param _name="_name"></param>
        public Department(string _name)
        {
            if(CheckExeption.CheckExeption.CheckCorrectString(_name, out string res))
            {
                Name = res;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string property = "") 
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
    }
}
