using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03
{
    public class Bot:Player
    {
        public string Level { get; set; }
        public Random RandomUserTry { get; set; }

        public Bot(int level, GameOptions options) : base()
        {
            if (level == 1)
            {
                Level = "Easy";
            }
            else if (level == 2)
            {
                Level = "Normal";
            }
            else
            {
                Level = "Hard";
            }
            Name = "Бот";
            Options = options;
            RandomUserTry = new Random();
        }

        public override int SetUserTry(int gameNumber)
        {
            if (Level == "Hard" && gameNumber > Options.MaxUserTry + 1 && gameNumber <= Options.MaxUserTry * 2 + 1)
            {
                return gameNumber - (Options.MaxUserTry + 1);
            }
            if ((Level == "Hard" || Level == "Normal") && gameNumber <= Options.MaxUserTry)
            {
                return gameNumber;
            }
            return RandomUserTry.Next(Options.MinUserTry, Options.MaxUserTry + 1);
        }
    }
}
