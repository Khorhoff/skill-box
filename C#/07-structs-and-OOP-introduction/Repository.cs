using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_07
{
    /// <summary>
    /// Структура по работе с данными
    /// </summary>
    public struct Repository
    {
        #region Поля

        /// <summary>
        /// Путь к файлу
        /// </summary>
        private string path;
        
        /// <summary>
        /// Основной список с данными
        /// </summary>
        private List<Employee> employees;

        /// <summary>
        /// Статический массив с заголовками полей для вывода в консоль
        /// </summary>
        private static string[] titles = new string[] { "ID","Время добавления","ФИО","Возраст","Рост","Дата рождения","Место рождения" };

        /// <summary>
        /// Текущий элемент для добавления записи
        /// </summary>
        private int index;

        #endregion

        #region Конструктор

        /// <summary>
        /// Создание репозитория
        /// </summary>
        /// <param name="path">Путь к файлу с данными</param>
        public Repository(string path)
        {
            index = 1;
            this.path = path;
            employees = new List<Employee>();
        }

        #endregion

        #region Методы

        /// <summary>
        /// Изменение пути к файлу
        /// </summary>
        /// <param name="path">Путь к новому файлу с данными</param>
        public void SetNewPath(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// Получение данных из файла
        /// </summary>
        /// <returns>true - данные получены успешно, false - файл не найден</returns>
        public bool OutputFormFile()
        {
            if (File.Exists(path))
            {
                employees.Clear();
                string[] line;
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        line = sr.ReadLine().Split('#');
                        if (line.Length != 7)
                            continue;
                        else
                        {
                            if (!int.TryParse(line[0], out int id) || !DateTime.TryParse(line[1], out DateTime timeOfAdding) || !uint.TryParse(line[4], out uint growth)
                                || !DateTime.TryParse(line[5], out DateTime birthday))
                                continue;
                            else
                            {
                                employees.Add(new Employee(id, line[2], growth, birthday, line[6], timeOfAdding));
                            }
                        }
                    }
                }
                if (employees.Any())
                    index = employees.Max(e => e.Id) + 1;
                Console.WriteLine($"Количество записей: {employees.Count}");

                return true;
            }
            else
                return false;
            
        }

        /// <summary>
        /// Запись данных в файл
        /// </summary>
        /// <returns></returns>
        public bool InputToFile()
        {
            if (employees.Any())
            {
                using (StreamWriter sw = new StreamWriter(path, false))
                    foreach (var employee in employees)
                        sw.WriteLine(employee.ToInputString());
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Вывод выбранных записей в консоль
        /// </summary>
        /// <param name="currentEmployees">Массив выбранных записей</param>
        public void ConsoleOutput(Employee[] currentEmployees)
        {
            Console.WriteLine($"{titles[0],5} {titles[1],20} {titles[2],15} {titles[3],10} {titles[4],10} {titles[5],15} {titles[6],15}");
            for (int i = 0; i < currentEmployees.Length; i++)
                Console.WriteLine($"{currentEmployees[i].ToOutputString()}");
        }

        /// <summary>
        /// Просмотр выбранной записи
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <returns>true - вывод удался, false - вывод не удался</returns>
        public bool ViewRecord(int id)
        {
            foreach (var employee in employees)
            {
                if (employee.Id == id)
                {
                    ConsoleOutput(new Employee[] { employee });
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Создание новой записи
        /// </summary>
        public void AddEmployee()
        {
            Console.WriteLine("Введите данные");
            Console.WriteLine("ФИО: ");
            string fullName = Console.ReadLine();

            Console.WriteLine("Рост: ");
            uint growth;
            while (!uint.TryParse(Console.ReadLine(), out growth))
            {
                Console.WriteLine("Введите числовое значение выше 0: ");
            }

            Console.WriteLine("Дата рождения: ");
            DateTime birthday;
            while (!DateTime.TryParse(Console.ReadLine(), out birthday) || DateTime.Now < birthday)
            {
                Console.WriteLine("Неверный формат даты, введите еще раз");
            }

            Console.WriteLine("Место рождения: ");
            string placeOfBirth = Console.ReadLine();

            Employee newEmployee = new Employee(index++, fullName, growth, birthday, placeOfBirth, DateTime.Now);
            employees.Add(newEmployee);
        }

        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <returns>true - удаление удалось, false - удаление не удалось</returns>
        public bool RemoveEmployee(int id)
        {
            foreach (var employee in employees)
            {
                if (employee.Id == id)
                {
                    employees.Remove(employee);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Поиск изменямой записи
        /// </summary>
        /// <param name="id">Идентификатор записи</param>
        /// <returns>true - изменение удалось, false - изменение не удалось</returns>
        public bool ChangeEmployee(int id)
        {
            for (int i = 0; i < employees.Count; i++)
            {
                if (employees[i].Id == id)
                {
                    employees[i] = ChangeEmployee(employees[i]);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Ввод и изменение данных
        /// </summary>
        /// <param name="employee">Изменяемая запись</param>
        /// <returns>Измененная запись</returns>
        private Employee ChangeEmployee(Employee employee)
        {
            Console.WriteLine("Введите новые данные");
            Console.WriteLine("ФИО: ");
            employee.FullName = Console.ReadLine();

            Console.WriteLine("Рост: ");
            uint growth;
            while (!uint.TryParse(Console.ReadLine(), out growth))
            {
                Console.WriteLine("Введите числовое значение выше 0: ");
            }
            employee.Growth = growth;
            employee.UpdateAge();

            return employee;
        }

        /// <summary>
        /// Вывод данных в выбранном диапазоне дат
        /// </summary>
        /// <param name="firstDate">Начальная дата(вкл)</param>
        /// <param name="lastDate">Конечная дата(искл)</param>
        /// <returns>true - в выбранном диапазоне есть записи, false - в выбранном диапазаное нет записей</returns>
        public bool VeiwRecondBetweenDates(DateTime firstDate, DateTime lastDate)
        {

            Employee[] toView = (from e in employees
                                 where e.TimeOfAdding >= firstDate && e.TimeOfAdding < lastDate
                                 select e).ToArray();
            if (toView.Any())
            {
                ConsoleOutput(toView);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Вывод данных в выбранном диапазоне дат
        /// </summary>
        /// <param name="Date">Дата</param>
        /// <param name="isFirst">true - выбранная дата будет считаться начальной датой, false - выбранная дата будет считаться конечной датой</param>
        /// <returns>true - в выбранном диапазоне есть записи, false - в выбранном диапазаное нет записей</returns>
        public bool VeiwRecondBetweenDates(DateTime Date, bool isFirst)
        {
            Employee[] toView;
            if (isFirst)
                toView = (from e in employees
                          where e.TimeOfAdding >= Date
                          select e).ToArray();
            else
                toView = (from e in employees
                          where e.TimeOfAdding < Date
                          select e).ToArray();

            if (toView.Any())
            {
                ConsoleOutput(toView);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Сортировка пузырьком записей по дате добавления
        /// </summary>
        /// <param name="IsAscending">true - сортировка по возростанию, false - сортировка по убыванию</param>
        /// <returns>true - сортировка удалась, false - нет записей</returns>
        public bool BubbleSort(bool IsAscending)
        {
            if (employees.Any())
            {
                if (IsAscending)
                {
                    Employee[] sortedEmployees = employees.ToArray();
                    Employee temp;
                    for (int i = 0; i < sortedEmployees.Length; i++)
                        for (int j = 1; j < sortedEmployees.Length - i; j++)
                            if (sortedEmployees[j - 1].TimeOfAdding > sortedEmployees[j].TimeOfAdding)
                            {
                                temp = sortedEmployees[j - 1];
                                sortedEmployees[j - 1] = sortedEmployees[j];
                                sortedEmployees[j] = temp;
                            }
                    ConsoleOutput(sortedEmployees);
                }
                else
                {
                    Employee[] sortedEmployees = employees.ToArray();
                    Employee temp;
                    for (int i = 0; i < sortedEmployees.Length; i++)
                        for (int j = 1; j < sortedEmployees.Length - i; j++)
                            if (sortedEmployees[j - 1].TimeOfAdding < sortedEmployees[j].TimeOfAdding)
                            {
                                temp = sortedEmployees[j - 1];
                                sortedEmployees[j - 1] = sortedEmployees[j];
                                sortedEmployees[j] = temp;
                            }
                    ConsoleOutput(sortedEmployees);
                }

                return true;
            }
            else
                return false;           
        }

        /// <summary>
        /// Сортировка записей по дате добавления с помощью Linq 
        /// </summary>
        /// <param name="IsAscending">true - сортировка по возростанию, false - сортировка по убыванию</param>
        /// <returns>true - сортировка удалась, false - нет записей</returns>
        public bool LinqSort(bool IsAscending)
        {
            if (employees.Any())
            {
                Employee[] toView;
                if (IsAscending)
                    toView = (from e in employees
                              orderby e.TimeOfAdding ascending
                              select e).ToArray();
                else
                    toView = (from e in employees
                              orderby e.TimeOfAdding descending
                              select e).ToArray();
                ConsoleOutput(toView);
                return true;
            }
            else
                return false;
        }

        #endregion
    }
}
