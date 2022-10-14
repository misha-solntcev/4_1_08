using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Вариант 8
Дана целочисленная квадратная матрица. Определить:
1.сумму элементов в тех столбцах, которые не содержат отрицательных элементов;
2.минимум среди сумм модулей элементов диагоналей, параллельных побочной
диагонали матрицы. */

namespace _4_1_08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] array = new int[,]
            {
                { 8, 0, 6, -4, 8 },
                { 4, 1, 36, 7, 8 },
                { 7, 8, 9, 0, 2 },
                { 12, 0, 3, -4, 5 },
                { 13, 0, 6, 7, 8 }                
            };
            int n = array.GetLength(0);
            int m = array.GetLength(1);

            // Сумма элементов в тех столбцах, которые не содержат отрицательных элементов;            
            List<int> list = new List<int>();
            for (int i = 0; i < n; i++)
            {
                bool flag = true;
                int sum = 0;
                for (int j = 0; j < m; j++)
                {
                    sum += array[i, j];
                    if (array[i, j] < 0)
                    {
                        flag = false;
                    }                        
                }
                if (flag)
                    list.Add(sum);
            }
            Console.Write($"Суммы: ");
            foreach (int sum in list)
                Console.Write($"{sum}, ");
            Console.WriteLine();

            //*/ Диагонали, параллельные побочной диагонали матрицы.
            List<int>[] diags = new List<int>[n+4];
            int d = diags.Length;
            for (int i = 0; i < d; i++)
                diags[i] = new List<int>();

            for (int k = 1; k < n; k++)            
                for (int i = 0; i < n; i++)                
                    for (int j = 0; j < m; j++)
                    {
                        if (i == (n - 1) - j - k)                        
                            diags[k - 1].Add(array[i, j]);                        
                        if (i == (n - 1) - j + k)                        
                            diags[k + 4].Add(array[i, j]);                        
                    }
            Console.WriteLine("Диагонали:");
            for (int i = 0; i < d; i++)
            {
                foreach (int l in diags[i])
                {
                    Console.Write($"{l}, ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();


            // Суммы модулей элементов диагоналей.
            List<int> summ = new List<int>();
            for (int i = 0; i < d; i++)
            {
                int sum = 0;
                for (int j = 0; j < diags[i].Count; j++)
                {
                    sum += Math.Abs(diags[i][j]);
                }
                summ.Add(sum);                    
            }
            Console.WriteLine($"Суммы модулей элементов диагоналей: ");
            foreach (int sum in summ)
                Console.Write($"{sum}, ");
            Console.WriteLine();

            // Минимум среди сумм модулей.
            int min = summ[0];
            for (int i = 1; i < d; i++)
                if (summ[i] < min)
                    min = summ[i];

            Console.WriteLine($"min = {min}");
                





            Console.ReadKey();
        }
    }
}
