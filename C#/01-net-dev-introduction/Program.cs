using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание базы данных из 30 сотрудников
            Repository repository = new Repository(30);

            // Печать в консоль всех сотрудников
            repository.Print("База данных до преобразования");

            // Увольнение всех работников с именем "Агата"
            repository.DeleteWorkerByName("Агата");

            // Печать в консоль сотрудников, которые не попали под увольнение
            repository.Print("База данных после первого преобразования");

            // Увольнение всех работников с именем "Аделина"
            repository.DeleteWorkerByName("Аделина");

            // Печать в консоль сотрудников, которые не попали под увольнение
            repository.Print("База данных после второго преобразования");

            //Задержка консоли
            Console.ReadKey();

            #region Домашнее задание

            // Уровень сложности: просто
            // Задание 1. Переделать программу так, чтобы до первой волны увольнени в отделе было не более 20 сотрудников

            //Чистка консоли
            Console.Clear();

            Console.WriteLine("Задание 1");

            Random rnd = new Random();
            repository = new Repository(rnd.Next(21));
            repository.Print("Отдел, где не более 20 сотрудников");

            //Задержка консоли
            Console.ReadKey();

            // Уровень сложности: средняя сложность
            // * Задание 2. Создать отдел из 40 сотрудников и реализовать несколько увольнений, по результатам
            //              которых в отделе болжно остаться не более 30 работников

            //Чистка консоли
            Console.Clear();

            Console.WriteLine("Задание 2");

            string[] names = new string[] {
                "Агата",
                "Агнес",
                "Аделаида",
                "Аделина",
                "Алдона",
                "Алима",
                "Аманда",
            };
            int i = 0;

            repository = new Repository(40);
            repository.Print("База данных до преобразования");
            while (repository.Workers.Count > 30)
            {
                repository.DeleteWorkerByName(names[i]);
                repository.Print($"База данных после {++i} преобразования");
            }
            

            //Задержка консоли
            Console.ReadKey();

            // Уровень сложности: сложно
            // ** Задание 3. Создать отдел из 50 сотрудников и реализовать увольнение работников
            //               чья зарплата превышает 30000руб

            //Чистка консоли
            Console.Clear();

            Console.WriteLine("Задание 3");

            repository = new Repository(50);
            repository.Print("База данных до преобразования");
            repository.DeleteWorkerBySalary(30000);
            repository.Print("База данных после удаления сотрудников с ЗП выше 30000руб");

            //Задержка консоли
            Console.ReadKey();

            #endregion



        }
    }
}
