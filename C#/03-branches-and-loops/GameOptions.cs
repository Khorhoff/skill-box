using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03
{
    public class GameOptions
    {
        public int MinGameNumber { get; set; } = 12;
        public int MaxGameNumber { get; set; } = 120;
        public int MinUserTry { get; set; } = 1;
        public int MaxUserTry { get; set; } = 4;
        public static string Rules { get; set; } = 
            "Выберите количество игроков (1-5) и выберите имена, чтобы понимать чей ход\n" +
            "Если выбран 1 игрок, вы будете играть с ботом, сложность которого вы можете выбрать\n" +
            "Программа случайно выбирает начальное игровое число из заданного диапазона(изначально от 12 до 120, можно изменить в настройках)\n" +
            "Условия победы: выбирая по очереди число из заданного диапазона (изначально от 1 до 4, можно изменить в настройках),\n" +
            "которое будет отниматься до игрового числа, довести его до 0\n" +
            "Игрок, в чей ход игровое число достигло 0, побеждает\n" +
            "Игровое чило нельзя опускать ниже 0, если же вы решили пренебречь данным правилом, вы пропустите ход!\n" +
            "Приятной игры)\n" +
            "P. S. Правила еще раз можно посмотреть в настройках";

        public GameOptions() { }

        public GameOptions(int minGN, int maxGN, int minUT, int maxUT) 
        {
            MinGameNumber = minGN;
            MaxGameNumber = maxGN;
            MinUserTry = minUT;
            MaxUserTry = maxUT;
        }

        public void ChangeGameNumber() 
        {
            int min;
            Console.WriteLine("Введите минимальное значение: ");
            while (!int.TryParse(Console.ReadLine(), out min) || min < 1)
            {
                Console.WriteLine("Введите число больше 0: ");
            }
            int max;
            Console.WriteLine("Введите максимальное значение: ");
            while (!int.TryParse(Console.ReadLine(), out max) || max < min)
            {
                Console.WriteLine($"Введите число больше минимального ({min}): ");
            }
            MinGameNumber = min;
            MaxGameNumber = max;
        }

        public void ChangeUserTry() 
        {
            int min;
            Console.WriteLine("Введите минимальное значение: ");
            while (!int.TryParse(Console.ReadLine(), out min) || min < 1)
            {
                Console.WriteLine("Введите число больше 0: ");
            }
            int max;
            Console.WriteLine("Введите максимальное значение: ");
            while (!int.TryParse(Console.ReadLine(), out max) || max < min)
            {
                Console.WriteLine($"Введите число больше минимального ({min}): ");
            }
            MinUserTry = min;
            MaxUserTry = max;
        }
        
        public void OptionMenu() 
        {
            string choise;
            do
            {
                Console.WriteLine("1. Изменить игровое число");
                Console.WriteLine("2. Изменить границы выбора числа");
                Console.WriteLine("3. Правила");
                Console.WriteLine("0. В главное меню");
                choise = Console.ReadLine();
                Console.Clear();
                switch (choise)
                {
                    case "1":
                        ChangeGameNumber();
                        Console.Clear();
                        break;
                    case "2":
                        ChangeUserTry();
                        Console.Clear();
                        break;
                    case "3":
                        Console.WriteLine(Rules);
                        Console.WriteLine("Нажмите любую кнопку для продолжения...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Введите существующий пункт меню");
                        break;
                }
            } while (choise != "0");
        }
    }
}
