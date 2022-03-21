using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03
{
    public class Player
    {
        public string Name { get; set; }
        public GameOptions Options { get; set; }

        public Player() { }

        public Player(string name, GameOptions options) 
        {
            Options = options;
            Name = name;
        }

        public virtual int SetUserTry(int gameNumber)
        {
            int userTry;
            Console.WriteLine($"Введите число ({Options.MinUserTry}-{Options.MaxUserTry}): ");
            while (!int.TryParse(Console.ReadLine(), out userTry) || userTry < Options.MinUserTry || userTry > Options.MaxUserTry)
            {
                Console.WriteLine($"Введите число от {Options.MinUserTry} до {Options.MaxUserTry}: ");
            }
            return userTry;
        }
    }
}
