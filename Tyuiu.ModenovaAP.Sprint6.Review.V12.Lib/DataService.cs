using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyuiu.ModenovaAP.Sprint6.Review.V12.Lib
{
    public class DataService
    {
        public int GetMatrix(int[,] array, int c, int k, int l)
        {
            int cnt = 0; // Переменная - счётчик
            for (int i = k; i <= l; i++) // Цикл для подсчёта элементов от k до l
            {
                if (array[i, c] % 2 != 0) { cnt++; } // Если элемент, принадлежищий интервалу [k; l] - нечётное число, то +1 к счётчику 
            }

            return cnt;
        }
    }
}
