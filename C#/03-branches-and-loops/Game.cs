using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03
{
    public class Game
    {
        public List<Player> Players { get; set; }
        public int PlayerCount { get; set; }
        public GameOptions Options { get; set; }
        public int GameNumber { get; set; }

        public Game(GameOptions options) 
        {
            Options = options;
        }

        public Game(GameOptions options,int plCount, string[] playerNames) : this(options)
        {
            PlayerCount = plCount;
            Players = new List<Player>();
            for (int i = 0; i < PlayerCount; i++)
            {
                Players.Add(new Player(playerNames[i], options));
            }
        }

        public Game(GameOptions options, string playerName, int botLevel) : this(options)
        {
            PlayerCount = 2;
            Players = new List<Player>() { new Player(playerName, options), new Bot(botLevel, options) };
        }

        public void GameProgress()
        {
            Random rand = new Random();
            GameNumber = rand.Next(Options.MinGameNumber, Options.MaxGameNumber + 1);
            int step = 0;
            int userTry;
            while (true)
            {
                Console.WriteLine();
                if (GameNumber == 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"Игровое число достигло 0, победа игрока {Players[step-1].Name}");
                    break;
                }
                step++;
                if (step > PlayerCount)
                {
                    step = 1;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Игровое число: {GameNumber}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Ход игрока {Players[step - 1].Name}");
                userTry = Players[step - 1].SetUserTry(GameNumber);
                if (GameNumber - userTry < 0)
                {
                    Console.WriteLine($"{Players[step - 1].Name} пропускает ход из-за не соблюдения правил!");
                }
                else
                {
                    GameNumber -= userTry;
                }
            }
        }
    }
}