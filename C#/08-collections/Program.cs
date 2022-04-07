using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Homework_08
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            #region Задание 1.Работа с листом

            //Что нужно сделать:

            // - Создайте лист целых чисел.
            // - Заполните лист 100 случайными числами в диапазоне от 0 до 100.
            // - Выведите коллекцию чисел на экран.
            // - Удалите из листа числа, которые больше 25, но меньше 50.
            // - Снова выведите числа на экран.

            //Рекомендация:

            // - Сделайте отдельные методы для заполнения, удаления и вывода на экран.

            //Что оценивается:

            // - В программе используется три отдельных метода. 
            // - В качестве хранилища данных используется List.

            #endregion 

            Main_1();
            Console.Clear();
            Console.WriteLine("Нажмите любую кнопку чтобы приступить к следующему заданию...");
            Console.ReadKey();
            Console.Clear();

            #region Задание 2.Телефонная книга

            //Что нужно сделать:
            // - Пользователю итеративно предлагается вводить в программу номера телефонов и ФИО их владельцев. 
            // - В процессе ввода информация размещается в Dictionary, где ключом является номер телефона, а значением — ФИО владельца.
            // - Таким образом, у одного владельца может быть несколько номеров телефонов.
            // - Признаком того, что пользователь закончил вводить номера телефонов, является ввод пустой строки. 
            // - Далее программа предлагает найти владельца по введенному номеру телефона.Пользователь вводит номер телефона и ему выдаётся ФИО владельца.
            // - Если владельца по такому номеру телефона не зарегистрировано, программа выводит на экран соответствующее сообщение.


            //Совет:

            // - Для того, чтобы находить значение в Dictionary, нужно использовать TryGetValue.

            //Что оценивается:

            // - Программа разделена на логические методы.
            // - Для хранения элементов записной книжки используется Dictionary.

            #endregion

            Main_2();
            Console.Clear();
            Console.WriteLine("Нажмите любую кнопку чтобы приступить к следующему заданию...");
            Console.ReadKey();
            Console.Clear();

            #region Задание 3.Проверка повторов


            //Что нужно сделать:

            //Пользователь вводит число.
            //Число сохраняется в HashSet коллекцию.
            //Если такое число уже присутствует в коллекции, то пользователю на экран выводится сообщение, что число уже вводилось ранее.
            //Если числа нет, то появляется сообщение о том, что число успешно сохранено. 

            //Советы и рекомендации:

            // - Для добавление числа в HashSet используйте метод Add.

            //Что оценивается:

            // - В программе в качестве коллекции используется HashSet.

            #endregion

            Main_3();
            Console.Clear();
            Console.WriteLine("Нажмите любую кнопку чтобы приступить к следующему заданию...");
            Console.ReadKey();
            Console.Clear();

            #region Задание 4.Записная книжка

            //Что нужно сделать:

            //Программа спрашивает у пользователя данные о контакте:

            //ФИО
            //Улица
            //Номер дома
            //Номер квартиры
            //Мобильный телефон
            //Домашний телефон

            //С помощью XElement создайте xml файл, в котором есть введенная информация.
            //XML файл должен содержать следующую структуру:

            //< Person name =”ФИО человека” >
            // < Address >
            //  < Street > Название улицы </ Street >
            //  < HouseNumber > Номер дома </ HouseNumber >
            //  < FlatNumber > Номер квартиры </ FlatNumber >
            // </ Address >
            // < Phones >
            //  < MobilePhone > 89999999999999 </ MobilePhone >
            //  < FlatPhone > 123 - 45 - 67 < FlatPhone >
            // </ Phones >
            //</ Person >

            //Советы и рекомендации:

            // - Заполняйте XElement в ходе заполнения данных.
            // - Изучите возможности XElement в документации Microsoft.

            //Что оценивается:

            // - Программа создаёт Xml файл, содержащий все данные о контакте.

            #endregion

            Main_4(); 
            Console.Clear();
            Console.WriteLine("Нажмите любую кнопку чтобы закончить...");
            Console.ReadKey();
            Console.Clear();
        }

        #region Решение 1


        static void Main_1()
        {
            List<int> list = FillList_1();
            OutputList_1(list);
            Console.ReadKey();
            list = RemoveFrom25To50(list);
            OutputList_1(list);
            Console.ReadKey();
        }

        static List<int> FillList_1()
        {
            List<int> list = new List<int>();
            for (int i = 0; i < 100; i++)
                list.Add(rnd.Next(101));
            return list;
        }

        static void OutputList_1(List<int> list)
        {
            foreach (var item in list)
                Console.WriteLine(item);
            Console.WriteLine($"---Количество: {list.Count}");
        }

        static List<int> RemoveFrom25To50(List<int> list)
        {
            list.RemoveAll(From25To50);
            return list;
        }

        static bool From25To50(int num)
        {
            return num > 25 && num < 50;
        }

        #endregion

        #region Решение 2

        static void Main_2()
        {
            Dictionary<string, string> phoneBook = FillDictionary_2();
            Console.WriteLine("Введите номер который хотите найти: ");
            SearchByPhone_2(phoneBook, Console.ReadLine());
            Console.ReadKey();
        }

        static Dictionary<string, string> FillDictionary_2()
        {
            Dictionary<string, string> phoneBook = new Dictionary<string, string>();
            string phone, name;
            do
            {
                Console.WriteLine("Введите номер телефона: ");
                phone = Console.ReadLine();
                if (phone == "")
                    break;
                if (phoneBook.ContainsKey(phone))
                {
                    Console.WriteLine("Такой номер уже есть");
                    Console.WriteLine("Для окончания ввода нажмите Enter");
                    continue;
                }
                Console.WriteLine("Введите имя: ");
                name = Console.ReadLine();
                phoneBook.Add(phone, name);
                Console.WriteLine("Для окончания ввода нажмите Enter");
            } while (true);
            return phoneBook;
        }

        static void SearchByPhone_2(Dictionary<string, string> phoneBook, string phone)
        {
            if (phoneBook.TryGetValue(phone, out string name))
                Console.WriteLine($"Найден {name}");
            else
                Console.WriteLine("Номер не найден");
        }
        #endregion

        #region Решение 3

        static void Main_3()
        {
            HashSet<int> hashset = new HashSet<int> { 1, 3, 5, 7, 9 };
            Console.WriteLine("hashset: ");
            foreach (var item in hashset)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine("\nВведите число для добавления:");
            int num;
            while (!int.TryParse(Console.ReadLine(), out num))
            {
                Console.WriteLine("Введите число:");
            }
            if (hashset.Add(num))
                Console.WriteLine("Число успешно добавлено");
            else
                Console.WriteLine("Такое число уже есть");
            Console.WriteLine("\nhashset: ");
            foreach (var item in hashset)
            {
                Console.Write($"{item} ");
            }
            Console.ReadKey();
        }

        #endregion

        #region Решение 4

        static void Main_4()
        {
            Console.WriteLine("Введите количество человек: ");
            uint personCount;
            while (!uint.TryParse(Console.ReadLine(), out personCount))
            {
                Console.WriteLine("Введите число: ");
            }

            XElement people = new XElement("People");
            
            for (int i = 0; i < personCount; i++)
            {
                Console.Clear();
                Console.WriteLine($"Человек {i+1}/{personCount}");
                Console.WriteLine("-------------------------------");

                Console.WriteLine("Введите имя: ");
                string name = Console.ReadLine();

                Console.WriteLine("Введите название улицы: ");
                string street = Console.ReadLine();

                Console.WriteLine("Введите номер дома: ");
                int houseNumber;
                while (!int.TryParse(Console.ReadLine(), out houseNumber))
                {
                    Console.WriteLine("Введите число: ");
                }

                Console.WriteLine("Введите номер квартиры: ");
                int flatNumber;
                while (!int.TryParse(Console.ReadLine(), out flatNumber))
                {
                    Console.WriteLine("Введите число: ");
                }

                Console.WriteLine("Введите номер мобильного телефона: ");
                string mobilePhone = Console.ReadLine();

                Console.WriteLine("Введите номер домашнего телефона: ");
                string flatPhone = Console.ReadLine();

                people.Add(new XElement("Person",
                    new XAttribute("name", name),
                    new XElement("Adres",
                     new XElement("Street", street),
                     new XElement("HouseNumber", houseNumber),
                     new XElement("FlatNumber", flatNumber)),
                    new XElement("Phones",
                     new XElement("MobilePhone", mobilePhone),
                     new XElement("FlatPhone", flatPhone))));
            }
            XDocument xdoc = new XDocument();
            xdoc.Add(people);
            xdoc.Save("people.xml");
            Console.ReadKey();
        }

        #endregion
    }
}
