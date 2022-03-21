using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03
{
    class Program
    {
        static void Main(string[] args)
        {
            #region ПЗ
            // Просматривая сайты по поиску работы, у вас вызывает интерес следующая вакансия:

            // Требуемый опыт работы: без опыта
            // Частичная занятость, удалённая работа
            //
            // Описание 
            //
            // Стартап «Micarosppoftle» занимающийся разработкой
            // многопользовательских игр ищет разработчиков в свою команду.
            // Компания готова рассмотреть C#-программистов не имеющих опыта в разработке, 
            // но желающих развиваться в сфере разработки игр на платформе .NET.
            //
            // Должность Интерн C#/
            //
            // Основные требования:
            // C#, операторы ввода и вывода данных, управляющие конструкции 
            // 
            // Конкурентным преимуществом будет знание процедурного программирования.
            //
            // Не технические требования: 
            // английский на уровне понимания документации и справочных материалов
            //
            // В качестве тестового задания предлагается решить следующую задачу.
            //
            // Написать игру, в которою могут играть два игрока.
            // При старте, игрокам предлагается ввести свои никнеймы.
            // Никнеймы хранятся до конца игры.
            // Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам.
            // Игроки ходят по очереди(игра сообщает о ходе текущего игрока)
            // Игрок, ход которого указан вводит число userTry, которое может принимать значения 1, 2, 3 или 4,
            // введенное число вычитается из gameNumber
            // Новое значение gameNumber показывается игрокам на экране.
            // Выигрывает тот игрок, после чьего хода gameNumber обратилась в ноль.
            // Игра поздравляет победителя, предлагая сыграть реванш
            // 
            // * Бонус:
            // Подумать над возможностью реализации разных уровней сложности.
            // В качестве уровней сложности может выступать настраиваемое, в начале игры,
            // значение userTry, изменение диапазона gameNumber, или указание большего количества игроков (3, 4, 5...)

            // *** Сложный бонус
            // Подумать над возможностью реализации однопользовательской игры
            // т е игрок должен играть с компьютером


            // Демонстрация
            // Число: 12,
            // Ход User1: 3
            //
            // Число: 9
            // Ход User2: 4
            //
            // Число: 5
            // Ход User1: 2
            //
            // Число: 3
            // Ход User2: 3
            //
            // User2 победил!
            #endregion
            Console.WriteLine("Правила игры:");
            Console.WriteLine(GameOptions.Rules);
            Console.WriteLine("Нажмите любую кнопку для продолжения...");
            Console.ReadKey();
            Console.Clear();
            GameOptions options = new GameOptions();

            string mainChoise;
            do
            {
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Играть");
                Console.WriteLine("2. Настройки");
                Console.WriteLine("0. Выход");
                mainChoise = Console.ReadLine();
                Console.Clear();
                switch (mainChoise)
                {
                    case "1":
                        int playerCount;
                        Game game;
                        Console.WriteLine("Выберите количество игроков (1-5): ");
                        while (!int.TryParse(Console.ReadLine(), out playerCount) || playerCount > 5 || playerCount < 1) 
                        {
                            Console.WriteLine("Введите число от 1 до 5: ");
                        }
                        if (playerCount == 1)
                        {
                            int botLevel;
                            Console.WriteLine("Выберите уровень бота (1-3): ");
                            while (!int.TryParse(Console.ReadLine(), out botLevel) || (botLevel < 1 || botLevel > 3))
                            {
                                Console.WriteLine("Введите число от 1 до 3: ");
                            }
                            Console.WriteLine("Введите имя игрока: ");
                            game = new Game(options, Console.ReadLine(), botLevel);
                        }
                        else
                        {
                            string[] names = new string[playerCount];
                            for (int i = 0; i < playerCount; i++)
                            {
                                Console.WriteLine($"Введите имя игрока {i+1}: ");
                                names[i] = Console.ReadLine();
                            }
                            game = new Game(options, playerCount, names);
                        }
                        Console.Clear();
                        bool revenge = true;
                        while (revenge)
                        {
                            game.GameProgress();
                            Console.WriteLine("Реванш? \n1 - да");
                            string answer = Console.ReadLine();
                            if (answer != "1")
                            {
                                revenge = false;
                            }
                        }
                        Console.Clear();
                        break;
                    case "2":
                        options.OptionMenu();
                        break;
                    case "0":
                        Console.WriteLine("До свидания!");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Выберите существующий пункт меню!");
                        break;
                }
            } while (mainChoise != "0");
        }
    }
}
