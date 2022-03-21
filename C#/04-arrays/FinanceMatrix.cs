using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_04
{
    public class FinanceMatrix
    {
        public static string[] ColumnNames = { "Месяц", "Доход", "Расход", "Прибыль" };
        public int NumberOfMonthsWithAPositiveProfit { get; set; } = 0;
        public List<int> MonthsWithWorstProfit { get; set; } = new List<int>();
        public Matrix Finance { get; set; }

        public FinanceMatrix()
        {
            Finance = new Matrix();
            Finance = Matrix.Input(12,4,10,201);
            Finance = Matrix.Multiplication(Finance, 1000);
            for (int i = 0; i < Finance.Rows; i++)
            {
                for (int j = 0; j < Finance.Colums; j++)
                {
                    switch (j)
                    {
                        case 0:
                            Finance.Array[i, j] = i + 1;
                            break;
                        case 3:
                            Finance.Array[i, j] = Finance.Array[i, 1] - Finance.Array[i, 2];
                            break;
                    }
                }
            }
        }

        public void Output()
        {
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"{ColumnNames[i],10}");
            }
            Console.WriteLine();
            Finance.Output();
            int[,] SortArray = Finance.Array;
            SortColumn(ref SortArray);
            int NumberOfMonthWithWorstProfit = 0;
            for (int i = 0; i < 12; i++)
            {
                if (NumberOfMonthWithWorstProfit >= 3)
                {
                    break;
                }
                if (i > 0 && SortArray[i, 3] == SortArray[i - 1, 3])
                {
                    MonthsWithWorstProfit.Add(SortArray[i, 0]);
                    continue;
                }
                MonthsWithWorstProfit.Add(SortArray[i, 0]);
                NumberOfMonthWithWorstProfit++;
            }

            for (int i = 0; i < 12; i++)
            {
                if (Finance.Array[i,3] > 0)
                {
                    NumberOfMonthsWithAPositiveProfit++;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Количество месяцев с положительной прибылью: {NumberOfMonthsWithAPositiveProfit}");
            Console.WriteLine("Месяца с худшей прибылью: ");
            foreach (var month in MonthsWithWorstProfit)
            {
                Console.Write($"{month} ");
            }
        }

        static void SortColumn(ref int[,] matr, uint column = 3)
        {
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(0) - 1; j++)
                {
                    if (matr[j, column] > matr[j + 1, column])
                    {
                        for (int c = 0; c < matr.GetLength(1); c++)
                        {
                            var temp = matr[j, c];
                            matr[j, c] = matr[j + 1, c];
                            matr[j + 1, c] = temp;
                        }
                    }
                }
            }
        }
    }
}
