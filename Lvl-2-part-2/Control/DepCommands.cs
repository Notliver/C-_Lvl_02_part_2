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
using System.Windows.Input;


namespace Lvl_2_part_2.Control
{ 
    class DepCommands : INotifyPropertyChanged
    {
        private static object syncRoot = new Object();
        private Department selectedDepartment;
        private static DepCommands example;
        public ObservableCollection<Department> Departments { get; set; }
        
        /// <summary>
        /// Выбираем/Присваиваем департамент
        /// </summary>
        public Department SelectedDepartment
        {
            get => selectedDepartment;
            set
            {
                selectedDepartment = value;
                OnPropertyChanged("SelectedDepartment");
            }
        }

        /// <summary>
        /// Описывает логику добавления департаментов
        /// </summary>
        private RelayCommand addCommand;
        public RelayCommand AddCommand => addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        Department department = new Department("Департамент");
                        Departments.Add(department);
                        SelectedDepartment = department;
                    }));

        /// <summary>
        /// Описываем логику удаления департамента
        /// </summary>
        private RelayCommand deletecommand;
        public RelayCommand DeleteCommand => deletecommand ??
                    (deletecommand = new RelayCommand(obj =>
                    {
                        Department department = obj as Department;
                        if (department != null)
                        {
                            var key = Departments.IndexOf(department);
                            Departments.Remove(department);
                            if (Departments.Count > 0)
                            {
                                if (key > 0) SelectedDepartment = Departments[key - 1];
                                else SelectedDepartment = Departments[0];
                            }
                        }
                    },
                    (obj) => Departments.Count > 0 && 
                    EmpCommands.getInstance().Employees.Where(e => e.Department == obj as Department).Count() == 0));       
        

        /// <summary>
        /// Значение для многопользовательской базы
        /// </summary>
        /// <returns></returns>
        public static DepCommands getInstance()
        {
            if (example == null)
            {
                lock (syncRoot)
                    if (example == null)
                        example = new DepCommands();
            }
            return example;
        }

        /// <summary>
        /// Описываем логику создания нового департамента
        /// </summary>
        protected DepCommands()
        {
            Departments = new ObservableCollection<Department>();
            for(int i=0; i<10; i++)
            {
                Departments.Add(new Department("Департамент " + i));
            }
        }


        /// <summary>
        /// Событие на изменение значения
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") 
            =>  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

}
