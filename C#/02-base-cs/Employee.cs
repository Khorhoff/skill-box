using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_01
{
    /// <summary>
    /// класс пользователя
    /// </summary>
    class Employee
    {
        /// <summary>
        /// имя пользователя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// возраст пользователя
        /// </summary>
        public byte Age { get; set; }
        /// <summary>
        /// рост пользователя
        /// </summary>
        public byte Height { get; set; }
        /// <summary>
        /// балл по русскому
        /// </summary>
        public byte RussianMark { get; set; }
        /// <summary>
        /// балл по истории
        /// </summary>
        public byte HistoryMark { get; set; }
        /// <summary>
        /// балл по математике
        /// </summary>
        public byte MathMark { get; set; }
        /// <summary>
        /// тип вывода для пользователя
        /// </summary>
        public string OutputType { get; set; }
        /// <summary>
        /// средний балл по 3 предметам
        /// </summary>
        public double AverageMark { get; set; }
        /// <summary>
        /// конструктор для создания пользователя
        /// </summary>
        /// <param name="name">имя</param>
        /// <param name="age">возраст</param>
        /// <param name="height">рост</param>
        /// <param name="rus">балл по русскому</param>
        /// <param name="his">балл по истории</param>
        /// <param name="math">балл по математике</param>
        /// <param name="numOutType">тип вывода</param>
        public Employee(string name, byte age, byte height, byte rus, byte his, byte math, int numOutType)
        {
            Name = name; Age = age; Height = height; RussianMark = rus; HistoryMark = his; MathMark = math;
            if (numOutType == 1) OutputType = "Default";
            else if (numOutType == 2) OutputType = "Formatted";
            else if (numOutType == 3) OutputType = "Interpolated";
            AverageMark = ((double)RussianMark + HistoryMark + MathMark) / 3;
        }
        /// <summary>
        /// вывод в соответствии с типом вывода
        /// </summary>
        public void Output()
        {
            if (OutputType == "Interpolated")
                Console.WriteLine($"имя: {Name}, возраст: {Age}, рост: {Height}, балл по русскому: {RussianMark}, балл по истории: {HistoryMark}," +
                    $" балл по математике: {MathMark}, средний балл: {AverageMark:#.##}");
            else if (OutputType == "Formatted")
            { 
                string pattern = "имя: {0}, возраст: {1}, рост: {2}, балл по русскому: {3}, балл по истории: {4}," +
                    " балл по математике: {5}, средний балл: {6:#.##}";
                Console.WriteLine(pattern, Name, Age, Height, RussianMark, HistoryMark, MathMark, AverageMark);
            }
            else
                Console.WriteLine("имя: " + Name + ", возраст: " + Age + ", рост: " + Height + ", балл по русскому: " + RussianMark + ", балл по истории: " 
                    + HistoryMark + ", балл по математике: " + MathMark + ", средний балл: " + $"{AverageMark:#.##}");
        }
    }
}
