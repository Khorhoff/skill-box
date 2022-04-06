using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_07
{
    class Program
    {
        #region ПЗ

        //Задача

        //Что нужно сделать
        //Улучшите программу, которую разработали в модуле 6. Создайте структуру «Сотрудник» со следующими полями:

        //ID
        //Дата и время добавления записи
        //Ф.И.О.
        //Возраст
        //Рост
        //Дата рождения
        //Место рождения


        //Для записей реализуйте следующие функции:

        //Просмотр записи. Функция должна содержать параметр ID записи, которую необходимо вывести на экран.
        //Создание записи.
        //Удаление записи.
        //Редактирование записи.
        //Загрузка записей в выбранном диапазоне дат.
        //Сортировка по возрастанию и убыванию даты.


        //После всех изменений записей создайте метод перезаписи изменённых данных в файл в таком виде:

        //1#20.12.2021 00:12#Иванов Иван Иванович#25#176#05.05.1992#город Москва

        //2#15.12.2021 03:12#Алексеев Алексей Иванович#24#176#05.11.1980#город Томск


        //Советы и рекомендации
        // - Обратите внимание, что в строке есть символ # — разделитель.
        // Символа # не должно быть при чтении
        // (разбить строку на массив поможет разделение строк с помощью метода String.Split).
        // - Создайте методы для работы с записями.
        // - Файл может быть с данными изначально. Для примера скопируйте данные, продемонстрированные выше.


        //Что оценивается
        // - Создан ежедневник, в котором могут храниться записи.
        // - Одно из полей записи ― дата создания.
        // - Все записи сохраняются на диске.
        // - Все записи загружаются с диска.
        // - С диска загружаются записи в выбранном диапазоне дат.
        // - Записи можно создавать, редактировать и удалять.
        // - Записи сортируются по выбранному полю.

        #endregion

        static void Main(string[] args)
        {
            MainMenu();
        }

        /// <summary>
        /// Главное меню
        /// </summary>
        static void MainMenu()
        {
            Console.WriteLine("Выберите путь к Рабочему файлу файлу");
            string path = Console.ReadLine();
            Repository repository = new Repository(path);
            Console.Clear();
            while (true)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("1. Выбрать новый файл");
                Console.WriteLine("2. Считать данные с файла");
                Console.WriteLine("3. Записать данные в файл");
                Console.WriteLine("4. Просмотреть запись");
                Console.WriteLine("5. Добавить запись");
                Console.WriteLine("6. Изменить запись");
                Console.WriteLine("7. Удалить запись");
                Console.WriteLine("8. Просмотреть записи в выбранном диапазоне дат");
                Console.WriteLine("9. Сортировать записи по дате и просмотреть их");
                Console.WriteLine("0. Выйти");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Выберите пункт меню: ");
                string choise = Console.ReadLine();
                int id;
                if (choise == "0")
                {
                    Console.Clear();
                    Console.WriteLine("До свидания!");
                    Console.ReadKey();
                    break;
                }
                else
                    switch (choise)
                    {
                        case "1":
                            Console.Clear();

                            Console.WriteLine("Введите новый путь: ");
                            repository.SetNewPath(Console.ReadLine());
                            Console.WriteLine("Путь изменен");

                            Console.WriteLine("Нажмите любую кнопку чтобы продолжить...");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "2":
                            Console.Clear();

                            if (repository.OutputFormFile()) 
                                Console.WriteLine("Данные считаны");
                            else
                                Console.WriteLine("Файл не найден");

                            Console.WriteLine("Нажмите любую кнопку чтобы продолжить...");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "3":
                            Console.Clear();

                            if (repository.InputToFile())
                                Console.WriteLine("Данные записаны");
                            else
                                Console.WriteLine("В локальном репозитории нет записей");

                            Console.WriteLine("Нажмите любую кнопку чтобы продолжить...");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "4":
                            Console.Clear();

                            Console.WriteLine("Введите идентификатор записи(ID): ");
                            while (!int.TryParse(Console.ReadLine(), out id))
                                Console.WriteLine("Введите числовое значение: ");
                            if (!repository.ViewRecord(id))
                                Console.WriteLine("Запись не найдена");

                            Console.WriteLine("Нажмите любую кнопку чтобы продолжить...");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "5":
                            Console.Clear();

                            repository.AddEmployee();

                            Console.WriteLine("Нажмите любую кнопку чтобы продолжить...");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "6":
                            Console.Clear();

                            Console.WriteLine("Введите идентификатор записи(ID): ");
                            while (!int.TryParse(Console.ReadLine(), out id))
                                Console.WriteLine("Введите числовое значение: ");
                            if (!repository.ViewRecord(id))
                                Console.WriteLine("Запись не найдена");
                            else
                                repository.ChangeEmployee(id);

                            Console.WriteLine("Нажмите любую кнопку чтобы продолжить...");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "7":
                            Console.Clear();

                            Console.WriteLine("Введите идентификатор записи(ID): ");
                            while (!int.TryParse(Console.ReadLine(), out id))
                                Console.WriteLine("Введите числовое значение: ");
                            if (!repository.RemoveEmployee(id))
                                Console.WriteLine("Запись не найдена");
                            else
                                Console.WriteLine("Запись удалена");

                            Console.WriteLine("Нажмите любую кнопку чтобы продолжить...");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "8":
                            Console.Clear();
                            SelectMenu(repository);
                            Console.Clear();
                            break;

                        case "9":
                            Console.Clear();
                            SortMenu(repository);
                            Console.Clear();
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("Вы выбрали несуществующий пункт меню");
                            break;
                    }
            }
        }

        /// <summary>
        /// Меню выборки по дате
        /// </summary>
        /// <param name="repository">Локальный репозиторий с данными</param>
        static void SelectMenu(Repository repository)
        {
            while (true)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("1. Выборка между датами");
                Console.WriteLine("2. Выборка с минимальной датой");
                Console.WriteLine("3. Выборка с максимальной датой");
                Console.WriteLine("0. Назад в главное меню");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Выберите пункт меню: ");
                string choise = Console.ReadLine();
                DateTime firstDate;
                DateTime secondDate;
                if (choise == "0")
                    break;
                else
                    switch (choise)
                    {
                        case "1":
                            Console.Clear();

                            Console.WriteLine("Введите начальную дату(вкл): ");
                            while (!DateTime.TryParse(Console.ReadLine(), out firstDate))
                                Console.WriteLine("Неверный формат даты, введите еще раз: ");

                            Console.WriteLine("Введите конечную дату(искл): ");
                            while (!DateTime.TryParse(Console.ReadLine(), out secondDate) || secondDate <= firstDate)
                                Console.WriteLine("Введите дату, которая позже наччальной: ");

                            if (!repository.VeiwRecondBetweenDates(firstDate, secondDate))
                                Console.WriteLine("В выбранном даипазоне нет записей");

                            Console.WriteLine("Нажмите любую кнопку чтобы продолжить...");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "2":
                            Console.Clear();

                            Console.WriteLine("Введите начальную дату(вкл): ");
                            while (!DateTime.TryParse(Console.ReadLine(), out firstDate))
                                Console.WriteLine("Неверный формат даты, введите еще раз: ");

                            if (!repository.VeiwRecondBetweenDates(firstDate, true))
                                Console.WriteLine("В выбранном даипазоне нет записей");

                            Console.WriteLine("Нажмите любую кнопку чтобы продолжить...");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "3":
                            Console.Clear();

                            Console.WriteLine("Введите конечную дату(искл): ");
                            while (!DateTime.TryParse(Console.ReadLine(), out secondDate))
                                Console.WriteLine("Неверный формат даты, введите еще раз: ");

                            if (!repository.VeiwRecondBetweenDates(secondDate, false))
                                Console.WriteLine("В выбранном даипазоне нет записей");

                            Console.WriteLine("Нажмите любую кнопку чтобы продолжить...");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("Вы выбрали несуществующий пункт меню");
                            break;
                    }


            }
        }

        /// <summary>
        /// Меню сортировки(сортировка пузырьком по возростанию и сортировка по убыванию с помощью Linq)
        /// </summary>
        /// <param name="repository">Локальный репозиторий с данными</param>
        static void SortMenu(Repository repository)
        {
            while (true)
            {
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("1. Сортировка по возростанию");
                Console.WriteLine("2. Сортировка по убыванию");
                Console.WriteLine("0. Назад в главное меню");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Выберите пункт меню: ");
                string choise = Console.ReadLine();
                if (choise == "0")
                    break;
                else
                    switch (choise)
                    {
                        case "1":
                            Console.Clear();

                            if(repository.BubbleSort(true))
                                Console.WriteLine("В локальном репозитории нет записей");

                            Console.WriteLine("Нажмите любую кнопку чтобы продолжить...");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        case "2":
                            Console.Clear();

                            if (repository.LinqSort(false))
                                Console.WriteLine("В локальном репозитории нет записей");

                            Console.WriteLine("Нажмите любую кнопку чтобы продолжить...");
                            Console.ReadKey();
                            Console.Clear();
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("Вы выбрали несуществующий пункт меню");
                            break;
                    }
            }
        }
    }
}

