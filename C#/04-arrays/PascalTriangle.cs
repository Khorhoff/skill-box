using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_04
{
    static class PascalTriangle
    {
        public static void SetTriangle()
        {
            Console.WriteLine("Введите количество строк (до 25): ");
            int num;
            while (!int.TryParse(Console.ReadLine(), out num) || (num < 1 || num > 25))
            {
                Console.WriteLine("Введите число от 1 до 25: ");
            }
            for (int i = 0; i < num; i++)
            {
                for (int j = num; j > i; j--)
                {
                    Console.Write(" ");
                }
                for (int j = 0; j <= (num - i - 2) * 4 + i / 2; j++)
                {
                    Console.Write(" ");
                }
                int val = 1;
                for (int j = 0; j <= i; j++)
                {
                    Console.Write($"{val,8} ");
                    val = val * (i - j) / (j + 1);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
