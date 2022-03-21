using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_06
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region ПЗ
            //Задача

            //Создайте справочник «Сотрудники».

            //Разработайте для предполагаемой компании программу, которая будет добавлять записи новых сотрудников в файл.
            //Файл должен содержать следующие данные:

            //ID
            //Дату и время добавления записи
            //Ф.И.О.
            //Возраст
            //Рост
            //Дату рождения
            //Место рождения
            //Для этого необходим ввод данных с клавиатуры.После ввода данных:

            //если файла не существует, его необходимо создать;
            //если файл существует, то необходимо записать данные сотрудника в конец файла. 

            //При запуске программы должен быть выбор:

            //введём 1 — вывести данные на экран;
            //введём 2 — заполнить данные и добавить новую запись в конец файла.


            //Файл должен иметь следующую структуру:

            //  1#20.12.2021 00:12#Иванов Иван Иванович#25#176#05.05.1992#город Москва
            //  2#15.12.2021 03:12#Алексеев Алексей Иванович#24#176#05.11.1980#город Томск
            //  …


            //Советы и рекомендации
            // * Обратите внимание, что в строке есть символ # — разделитель в строке.
            //При чтении файла необходимо убрать символ #.
            //Разбить строку на массив элементов поможет разделение строк с помощью метода String.Split.
            // * Разбейте программу на методы(чтение, запись).
            // * Новую запись внесите в конец файла.
            // * Проверьте, создан файл или нет.


            //Что оценивается
            // * Структура файла после добавления сотрудника идентична.
            // * Каждый метод выполняет одну задачу.
            // * Запись корректно выводится в консоль.
            // * Файл корректно закрывается после записи и чтения.
            #endregion 

            ShowMainMenu();
        }

        static void ShowMainMenu()
        {
            bool closeProgramm = false;
            do
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("1. Вывести данные");
                Console.WriteLine("2. Добавить запись");
                Console.WriteLine("0. Выход");
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Выберите пункт меню: ");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        Console.Clear();
                        OutputData();
                        break;
                    case '2':
                        Console.Clear();
                        InputData();
                        break;
                    case '0':
                        closeProgramm = true;
                        Console.WriteLine("До свидания!");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Выберите существующий пункт меню!");
                        break;
                }
                if (closeProgramm)
                    break;
            } while (true);
        }

        static void OutputData()
        {
            string[] anyEmp;
            string path;
            do
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Введите название файла: ");
                path = Console.ReadLine();
                if (File.Exists(path))
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine($"{"ID",3}|{"Дата и время добавления",25}|{"ФИО",30}|{"Возраст",8}|{"Рост",5}|{"День Р.",11}|{"Место Р.",15}");
                    using (StreamReader sr = new StreamReader(path))
                    {
                        while (!sr.EndOfStream)
                        {
                            anyEmp = sr.ReadLine().Split('#').ToArray();
                            Console.WriteLine($"{anyEmp[0],3}|{anyEmp[1],25}|{anyEmp[2],30}|{anyEmp[3],8}|{anyEmp[4],5}|{anyEmp[5],11}|{anyEmp[6],15}");
                        }
                    }
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Такого файла не существует");
                }
            } while (true);
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Назжмите любую кнопку чтобы продолжить");
            Console.ReadKey();
            Console.Clear();
        }

        static void InputData()
        {
            List<Employee> employees = new List<Employee>();
            do
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Введите данные: ");
                Console.WriteLine("ФИО: ");
                string fullName = Console.ReadLine();
                uint growth;
                Console.WriteLine("Рост: ");
                while (!uint.TryParse(Console.ReadLine(), out growth))
                {
                    Console.WriteLine("Некорректный ввод!");
                }
                DateTime birthDay;
                Console.WriteLine("Дата рождения (через \"-\", \"\\\", или пробел): ");
                while (!DateTime.TryParse(Console.ReadLine(), out birthDay))
                {
                    Console.WriteLine("Некорректный ввод!");
                }
                Console.WriteLine("Место роджения: ");
                string placeOfBirth = Console.ReadLine();
                employees.Add(new Employee(fullName, growth, birthDay, placeOfBirth));

                Console.WriteLine("----------------------------------");
                Console.WriteLine("Нажмите 1 чтобы давить еще или любую кнопку для продолжения");
                if (Console.ReadKey(true).KeyChar != '1')
                    break;
                Console.Clear();
            } while (true);
            Console.Clear();
            string path;
            bool isNewFile = false;
            int lastId = 0;
            do
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Введите название файла");
                if (!File.Exists(path = Console.ReadLine()))
                {
                    Console.WriteLine("Такого файла не существует, нажмите 1 чтобы создать или любую кнопку чтобы найти другой");
                    if (Console.ReadKey(true).KeyChar == '1')
                    {
                        isNewFile = true;
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Файл найден");
                    break;
                }
                Console.Clear();
            } while (true);

            if (!isNewFile)
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        lastId = int.Parse(sr.ReadLine().Split('#').ToArray()[0]);
                    }
                }
            }

            using (StreamWriter sw = new StreamWriter(path, true))
            {
                foreach (var emp in employees)
                {
                    lastId++;
                    sw.WriteLine($"{lastId}#{emp.TimeOfAdding}#{emp.FullName}#{emp.Age}#{emp.Growth}#{emp.Birthday}#{emp.PlaceOfBirth}");
                }
            }
            Console.WriteLine("Записи добавлены");
            Console.WriteLine("Назжмите любую кнопку чтобы продолжить");
            Console.ReadKey();
            Console.Clear();
        }
    }

    public struct Employee
    {
        public string TimeOfAdding { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public uint Growth { get; set; }
        public string Birthday { get; set; }
        public string PlaceOfBirth { get; set; }

        public Employee(string fullName, uint growth, DateTime birthday, string placeOfBirth)
        {
            TimeOfAdding = DateTime.Now.ToString();
            FullName = fullName;
            Age = DateTime.Now.Year - birthday.Year - (((DateTime.Now.Month < birthday.Month) ||
            ((DateTime.Now.Month == birthday.Month) && (DateTime.Now.Day < birthday.Day))) ? 1 : 0);
            Growth = growth;
            Birthday = birthday.ToShortDateString().ToString();
            PlaceOfBirth = placeOfBirth;
        }
    }
}
