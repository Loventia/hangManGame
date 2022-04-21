using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Core
{
    public class GameLogic
    {



        public void Play()
        {
            string [] RandomWords = new string[] { "dairy", "changling", "deer", "maverick", "ibiza", "general",
            "calisthenics", "goal", "horses", "sarcasm", "pirouline", "rental", "capstone", "programming", "mic", 
            "kappa", "black", "bacon", "strawberry", "led" };
            //select random word from array
            Random randGen = new Random();

            var idx = randGen.Next(0, 9);

            string mysteryWord = RandomWords[idx];
            //length of the word guessed
            char[] guess = new char[mysteryWord.Length];
            Console.Write("Please enter your guess: ");

            for (int p = 0; p < mysteryWord.Length; p++)
                guess[p] = '*';

            while (true)
            {
                char playerGuess = char.Parse(Console.ReadLine());
                for (int j = 0; j < mysteryWord.Length; j++)
                {
                    if (playerGuess == mysteryWord[j])
                        guess[j] = playerGuess;
                }
                Console.WriteLine(guess);
            }
        }
    }
}
        }




    }

}
           
}
        

