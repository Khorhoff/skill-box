using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example_005
{
    class Program
    {
        public static Random rnd = new Random();

        /// <summary>
        /// Метод для ввода матрицы с клавиатуры
        /// </summary>
        /// <param name="rows">Количество строк</param>
        /// <param name="colums">Количество столбцов</param>
        /// <returns>Заполненная матрица</returns>
        static int[,] InputMatrix(int rows, int colums)
        {
            int[,] matr = new int[rows, colums];
            Console.WriteLine($"Введите {rows*colums} элементов");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    while (!int.TryParse(Console.ReadLine(), out matr[i,j]))
                    {
                        Console.WriteLine("Введите число: ");
                    }
                }
            }
            return matr;
        }

        /// <summary>
        /// Метод для заполнения матрицы случайными числами в заданном диапазоне
        /// </summary>
        /// <param name="rows">Количество строк</param>
        /// <param name="colums">Количество столбцов</param>
        /// <param name="min">Нижняя граница диапазона</param>
        /// <param name="max">Верхняя граница диапазона</param>
        /// <returns>Заполненная матрица</returns>
        static int[,] InputMatrix(int rows, int colums, int min, int max)
        {
            int[,] matr = new int[rows, colums];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < colums; j++)
                {
                    matr[i,j] = rnd.Next(min, max);
                }
            }
            return matr;
        }

        /// <summary>
        /// Метод для вывода матрицы
        /// </summary>
        /// <param name="matr">Матрица</param>
        static void OutputMatrix(int[,] matr)
        {
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    Console.Write($"{matr[i,j],3} ");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Метод умножает матрицу на число
        /// </summary>
        /// <param name="mart">Матрица</param>
        /// <param name="multiplier">Множитель</param>
        /// <returns>Мартица, умноженная на число</returns>
        static int[,] MultiplyNumber(int[,] matr, int multiplier) 
        {
            int[,] answer = new int[matr.GetLength(0), matr.GetLength(1)];
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j= 0; j < matr.GetLength(1); j++)
                {
                    answer[i, j] = matr[i, j] * multiplier;
                }
            }
            return answer;
        }

        /// <summary>
        /// Метод складывает 2 матрицы
        /// </summary>
        /// <param name="matr1">Первая матрица</param>
        /// <param name="matr2">Вторая матрица</param>
        /// <returns>Матрица, являющаяся суммой</returns>
        static int[,] Addition(int[,] matr1, int[,] matr2)
        {
            int[,] answer = new int[matr1.GetLength(0), matr1.GetLength(1)];
            for (int i = 0; i < matr1.GetLength(0); i++)
            {
                for (int j = 0; j < matr1.GetLength(1); j++)
                {
                    answer[i, j] = matr1[i, j] + matr2[i, j];
                }
            }
            return answer;
        }

        /// <summary>
        /// Метод вычитает 2 матрицы
        /// </summary>
        /// <param name="matr1">Первая матрица</param>
        /// <param name="matr2">Вторая матрица</param>
        /// <returns>Матрица, являющаяся разностью</returns>
        static int[,] Subtraction(int[,] matr1, int[,] matr2)
        {
            int[,] answer = new int[matr1.GetLength(0), matr1.GetLength(1)];
            for (int i = 0; i < matr1.GetLength(0); i++)
            {
                for (int j = 0; j < matr1.GetLength(1); j++)
                {
                    answer[i, j] = matr1[i, j] - matr2[i, j];
                }
            }
            return answer;
        }

        /// <summary>
        /// Метод перемножает 2 матрицы
        /// </summary>
        /// <param name="matr1">Первая матрица</param>
        /// <param name="matr2">Вторая матрица</param>
        /// <returns>Матрица, являющаяся произведением</returns>
        static int[,] Multiplication(int[,] matr1, int[,] matr2)
        {
            int[,] answer = new int[matr1.GetLength(0), matr2.GetLength(1)];
            for (int i = 0; i < matr1.GetLength(0); i++)
                {
                    for (int j = 0; j < matr2.GetLength(1); j++)
                    {
                    answer[i, j] = 0;

                        for (int k = 0; k < matr1.GetLength(1); k++)
                        {
                        answer[i, j] += matr1[i, k] * matr2[k, j];
                        }
                    }
                }
            return answer;
        }

        /// <summary>
        /// Метод находит слово с минимальной длинной
        /// </summary>
        /// <param name="text">Текст для поиска</param>
        /// <returns>Слово с минимальной длинной</returns>
        static string MinLength(string text)
        {
            string answer = "";
            string[] words = text.Split(',', ' ', '.');
            int lenght = words[0].Length;
            foreach (var word in words)
            {
                if (lenght > word.Length && word.Length != 0)
                {
                    lenght = word.Length;
                    answer = word;
                }
            }
            return answer;
        }

        /// <summary>
        /// Находит все слова с максимальной длинной
        /// </summary>
        /// <param name="text">Текст для поиска</param>
        /// <returns>Набор слов с максимальной длинный</returns>
        static List<string> MaxLenght(string text)
        {
            List<string> answer = new List<string>();
            string[] words = text.Split(',', ' ', '.');
            int lenght = words[0].Length;
            foreach (var word in words)
            {
                if (lenght < word.Length)
                {
                    lenght = word.Length;
                }
            }
            foreach (var word in words)
            {
                if (lenght == word.Length)
                {
                    answer.Add(word);
                }
            }
            return answer;
        }

        /// <summary>
        /// Метод убирает идущие подрят повторяющиеся символы
        /// </summary>
        /// <param name="text">Текст для изменения</param>
        /// <returns>Текст без повторений</returns>
        static string RemovingRepeats(string text)
        {
            text = text.ToLower();
            string answer = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (i != 0 && text[i] == text[i-1])
                {
                    continue;
                }
                answer += text[i];
            }
            return answer;
        }

        /// <summary>
        /// Метод определяет, является ли последовательность геометрической или арифметической прогрессией
        /// </summary>
        /// <param name="subsequence">Последовательность чисел</param>
        /// <returns>Строка с ответом</returns>
        static string IsProgression(params double[] subsequence)
        {
            double arithmeticStep = subsequence[1] - subsequence[0];
            bool isArithmetic = true;
            for (int i = 0; i < subsequence.Length; i++)
            {
                if (i != 0 && subsequence[i] - subsequence[i - 1] != arithmeticStep)
                {
                    isArithmetic = false;
                    break;
                }
            }
            if (isArithmetic)
            {
                return "Последовательность является арифметической прогрессией";
            }

            double geometricStep = subsequence[1] / subsequence[0];
            bool isGeometric = true;
            for (int i = 0; i < subsequence.Length; i++)
            {
                if (i != 0 && subsequence[i] / subsequence[i - 1] != geometricStep)
                {
                    isGeometric = false;
                    break;
                }
            }
            if (isGeometric)
            {
                return "Последовательность является геометрической прогрессией";
            }

            return "Обыкновенная последовательность чисел";
        }

        /// <summary>
        /// Метод вычисляет значение функции Аккермана
        /// </summary>
        /// <param name="n">Первый параметр</param>
        /// <param name="m">Второй параметр</param>
        /// <returns>Значение функции</returns>
        static uint AckermannFunction(uint n, uint m)
        {
            if (n == 0)
                return m + 1;
            else
              if ((n != 0) && (m == 0))
                return AckermannFunction(n - 1, 1);
            else
                return AckermannFunction(n - 1, AckermannFunction(n, m - 1));
        }

        /// <summary>
        /// Метод задерживает консоль и очищает ее после пропуска задержки
        /// </summary>
        static void NextTask()
        {
            Console.WriteLine("Нажмите любую кнопку...");
            Console.ReadKey();
            Console.Clear();
        }

        static void Main(string[] args)
        {
            #region ПЗ
            // Домашнее задание
            // Требуется написать несколько методов
            //
            // Задание 1.
            // Воспользовавшись решением задания 3 четвертого модуля
            // 1.1. Создать метод, принимающий число и матрицу, возвращающий матрицу умноженную на число
            // 1.2. Создать метод, принимающий две матрицу, возвращающий их сумму
            // 1.3. Создать метод, принимающий две матрицу, возвращающий их произведение
            //
            // Задание 2.
            // 1. Создать метод, принимающий  текст и возвращающий слово, содержащее минимальное количество букв
            // 2.* Создать метод, принимающий  текст и возвращающий слово(слова) с максимальным количеством букв 
            // Примечание: слова в тексте могут быть разделены символами (пробелом, точкой, запятой) 
            // Пример: Текст: "A ББ ВВВ ГГГГ ДДДД  ДД ЕЕ ЖЖ ЗЗЗ"
            // 1. Ответ: А
            // 2. ГГГГ, ДДДД
            //
            // Задание 3. Создать метод, принимающий текст. 
            // Результатом работы метода должен быть новый текст, в котором
            // удалены все кратные рядом стоящие символы, оставив по одному 
            // Пример: ПППОООГГГООООДДДААА >>> ПОГОДА
            // Пример: Ххххоооорррооошшшиий деееннннь >>> хороший день
            // 
            // Задание 4. Написать метод принимающий некоторое количесво чисел, выяснить
            // является заданная последовательность элементами арифметической или геометрической прогрессии
            // 
            // Примечание
            //             http://ru.wikipedia.org/wiki/Арифметическая_прогрессия
            //             http://ru.wikipedia.org/wiki/Геометрическая_прогрессия
            //
            // *Задание 5
            // Вычислить, используя рекурсию, функцию Аккермана:
            // A(2, 5), A(1, 2)
            // A(n, m) = m + 1, если n = 0,
            //         = A(n - 1, 1), если n <> 0, m = 0,
            //         = A(n - 1, A(n, m - 1)), если n> 0, m > 0.
            // 
            // Весь код должен быть откоммментирован
            #endregion

            int[,] matr1 = InputMatrix(3, 3, 0, 16);
            int[,] matr2 = InputMatrix(3, 3, 0, 16);
            Console.WriteLine("Матрица 1:");
            OutputMatrix(matr1);
            Console.WriteLine("Матрица 2:");
            OutputMatrix(matr2);
            Console.WriteLine("Матрица 1 * 2");
            OutputMatrix(MultiplyNumber(matr1, 2));
            Console.WriteLine("Матрица 1 + матрица 2");
            OutputMatrix(Addition(matr1, matr2));
            Console.WriteLine("Матрица 1 - матрица 2");
            OutputMatrix(Subtraction(matr1, matr2));
            Console.WriteLine("Матрица 1 * матрица 2");
            OutputMatrix(Multiplication(matr1, matr2));

            NextTask();

            Console.WriteLine("Text: a ss ddd,ee www. rr gggg ff xxxx");
            Console.WriteLine($"Минимальная длинна: {MinLength("a ss ddd,ee www, rr gggg ff xxxx")}");
            Console.Write($"Минимальная длинна: ");
            List<string> words = MaxLenght("a ss ddd,ee www, rr gggg ff xxxx");
            foreach (var word in words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();

            NextTask();

            Console.WriteLine("Text: aaaaasssssdddddfffffggggghhhhhhhhhhhhh");
            Console.WriteLine($"Без повторений: {RemovingRepeats("aaaaasssssdddddfffffggggghhhhhhhhhhhhh")}");

            NextTask();

            Console.WriteLine("Последовательность: 1 2 4 8 16");
            Console.WriteLine(IsProgression(1,2,4,8,16));
            Console.WriteLine("Последовательность: 1 2 3 4 5");
            Console.WriteLine(IsProgression(1, 2, 3, 4, 5));
            Console.WriteLine("Последовательность: 1 2 4 8 17");
            Console.WriteLine(IsProgression(1, 2, 4, 8, 17));

            NextTask();

            Console.WriteLine($"AckermannFunction(3,2) = {AckermannFunction(3, 2)}");

            NextTask();
        }
    }
}
