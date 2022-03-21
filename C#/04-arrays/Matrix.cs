using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_04
{
    public class Matrix
    {
        public int[,] Array { get; set; }
        public int Rows { get; set; }
        public int Colums { get; set; }
        public static Random Rnd = new Random();

        public Matrix() { }

        public Matrix(int r, int c)
        {
            Rows = r;
            Colums = c;
            Array = new int[r, c];
        }

        public static Matrix Input(int R, int C, int min, int max)
        {
            Matrix m = new Matrix(R, C);
            for (int i = 0; i < m.Rows; i++)
            {
                for (int j = 0; j < m.Colums; j++)
                {
                    m.Array[i, j] = Rnd.Next(min, max);
                }
            }
            return m;
        }

        public void Output()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Colums; j++)
                {
                    Console.Write($"{Array[i,j],10}");
                }
                Console.WriteLine();
            }
        }

        public static void Addition(Matrix m1, Matrix m2)
        {
            Matrix ansv = new Matrix(m1.Rows, m1.Colums);
            if (m1.Rows != m2.Rows || m1.Colums != m2.Colums)
            {
                Console.WriteLine("Матрицы разные по размеру, невозможно выполнить действие");
            }
            else
            {
                for (int i = 0; i < m1.Rows; i++)
                {
                    for (int j = 0; j < m1.Colums; j++)
                    {
                        ansv.Array[i, j] = m1.Array[i, j] + m2.Array[i, j];
                    }
                }

                ansv.Output();
            }
        }

        public static void Subtraction(Matrix m1, Matrix m2)
        {
            Matrix ansv = new Matrix(m1.Rows, m1.Colums);
            if (m1.Rows != m2.Rows || m1.Colums != m2.Colums)
            {
                Console.WriteLine("Матрицы разные по размеру, невозможно выполнить действие");
            }
            else
            {
                for (int i = 0; i < m1.Rows; i++)
                {
                    for (int j = 0; j < m1.Colums; j++)
                    {
                        ansv.Array[i, j] = m1.Array[i, j] - m2.Array[i, j];
                    }
                }
                ansv.Output();
            }
        }

        public static Matrix Multiplication(Matrix m1, int multiplier)
        {
            Matrix ansv = new Matrix(m1.Rows, m1.Colums);
            for (int i = 0; i < m1.Rows; i++)
            {
                for (int j = 0; j < m1.Colums; j++)
                {
                    ansv.Array[i, j] = m1.Array[i, j] * multiplier;
                }
            }
            return ansv;
        }

        public static void Multiplication(Matrix m1, Matrix m2)
        {
            Matrix ansv = new Matrix(m1.Rows, m2.Colums);
            if (m1.Colums != m2.Rows)
            {
                Console.WriteLine("Матрицы не подходят по размерам, невозможно выполнить дейстивие");
            }
            else
            {
                for (int i = 0; i < m1.Rows; i++)
                {
                    for (int j = 0; j < m2.Colums; j++)
                    {
                        ansv.Array[i, j] = 0;

                        for (int k = 0; k < m1.Colums; k++)
                        {
                            ansv.Array[i, j] += m1.Array[i, k] * m2.Array[k, j];
                        }
                    }
                }
                ansv.Output();
            }
        }
    }
}
