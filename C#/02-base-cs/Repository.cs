using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_01
{
    /// <summary>
    /// класс компании
    /// </summary>
    class Repository
    {
        /// <summary>
        /// пользователи компнии
        /// </summary>
        public Employee[] Employees { get; set; }

        /// <summary>
        /// конструктор для выделения данных под 3 пользователей
        /// </summary>
        public Repository()
        {
            this.Employees = new Employee[3];
        }

        /// <summary>
        /// ввод данных пользователями
        /// </summary>
        public void SetData() 
        {
            string name;
            byte i = 0, age, height, rus, his, math;
            /*
            цикл для ввода данных о 3 пользователях
            задержка и чистка консоли для последовательного ввода данных и скрытия их
            от следующего пользователя
            */
            while (i < 3)
            {
                Console.WriteLine($"Ввод данных, сотрудник {i + 1}:");
                Console.WriteLine("Введите имя: ");
                name = Console.ReadLine();
                Console.WriteLine("Введите возраст: ");
                while (!byte.TryParse(Console.ReadLine(), out age))
                {
                    Console.WriteLine("неправильно введен возраст, попробуйте еще раз: ");
                }
                Console.WriteLine("Введите рост: ");
                while (!byte.TryParse(Console.ReadLine(), out height))
                {
                    Console.WriteLine("неправильно введен рост, попробуйте еще раз: ");
                }
                Console.WriteLine("Введите балл по русскому: ");
                while (!byte.TryParse(Console.ReadLine(), out rus) || rus > 10)
                {
                    Console.WriteLine("неправильно введен балл, попробуйте еще раз: ");
                }
                Console.WriteLine("Введите балл по истории: ");
                while (!byte.TryParse(Console.ReadLine(), out his) || his > 10)
                {
                    Console.WriteLine("неправильно введен балл, попробуйте еще раз: ");
                }
                Console.WriteLine("Введите балл по математике: ");
                while (!byte.TryParse(Console.ReadLine(), out math) || math > 10)
                {
                    Console.WriteLine("неправильно введен балл, попробуйте еще раз: ");
                }
                Employees[i] = new Employee(name, age, height, rus, his, math, ++i);
                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        /// <summary>
        /// вывод данных
        /// </summary>
        public void GetData()
        {
            for (int i = 0; i < Employees.Length; i++)
            {
                Employees[i].Output();
            }
        }

        /// <summary>
        /// вывод данных по центру
        /// </summary>
        public void Middle() 
        {
            Console.Clear();
            int top = Console.WindowHeight / 2;
            string str;
            for (int i = 0; i < Employees.Length; i++, top++)
            {
                str = $"имя: {Employees[i].Name}, возраст: {Employees[i].Age}, рост: {Employees[i].Height}, балл по русскому: {Employees[i].RussianMark}," +
                    $" балл по истории: {Employees[i].HistoryMark}, балл по математике: {Employees[i].MathMark}, средний балл: {Employees[i].AverageMark:#.##}";
                Console.SetCursorPosition(Console.WindowWidth / 2 - str.Length / 2, top);
                Employees[i].Output();
            }
        }
    }
}
