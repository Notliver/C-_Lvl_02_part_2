using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lvl_2_part_2.CheckExeption
{
    class CheckExeption
    {
        /// <summary>
        /// Проверяем строку на наличие данных
        /// </summary>
        /// <param name="str"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool CheckCorrectString(string str, out string result)
        {
            if (str == null || str == "" )
            {
                throw new ArgumentException("Неверный формат");
            } else
            {
                result = str;
                return true;
            }

        }
    }
}
