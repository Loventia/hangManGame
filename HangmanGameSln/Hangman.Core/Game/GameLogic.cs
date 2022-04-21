using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class GameLogic
    {
        private GallowsRenderer _renderer;

        public GameLogic()
        {
            _renderer = new GallowsRenderer();
        }

        public void Play()
        {
            
            string[] wordList = new string[] { "dairy", "changling", "deer", "maverick", "ibiza", "general",
             "calisthenics", "goal", "horses", "sarcasm", "pirouline", "rental", "capstone", "programming", "mic",
             "kappa", "black", "bacon", "strawberry", "led" };
            Random random = new Random();

            //selects random variable
            string wordToGuess = wordList[random.Next(0, wordList.Length)].ToString();
            //converts letter to uppercase
            string wordToGuessUppercase = wordToGuess.ToUpper();

            StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length);
            for (int i = 0; i < wordToGuess.Length; i++)
                displayToPlayer.Append('*');
            //list of correct guesses
            List<char> correctGuesses = new List<char>();
            //list of incorrect guesses
            List<char> incorrectGuesses = new List<char>();

            int lives = 6;
            bool won = false;
            int lettersRevealed = 0;




           Console.SetCursorPosition(0, 20);

            string input;
            char guess;
            //while lives are greater than zero and user has not won
                while (!won && lives > 0)
                {
                
               
                Console.Write("Guess a letter: ");

                    input = Console.ReadLine().ToUpper();
                    guess = input[0];

                    if (correctGuesses.Contains(guess))
                    {
                        Console.WriteLine("You've already tried '{0}', and it was correct.", guess);
                        continue;
                    }
                    else if (incorrectGuesses.Contains(guess))
                    {
                        Console.WriteLine("You've already tried '{0}', and it was incorrect", guess);
                        continue;
                    }

                    if (wordToGuessUppercase.Contains(guess))
                    {
                        correctGuesses.Add(guess);

                        for (int i = 0; i < wordToGuess.Length; i++)
                        {
                            if (wordToGuessUppercase[i] == guess)
                            {
                                displayToPlayer[i] = wordToGuess[i];
                                lettersRevealed++;
                            }
                        }

                        if (lettersRevealed == wordToGuess.Length)
                            won = true;
                    }
                    else
                    {
                        incorrectGuesses.Add(guess);

                        Console.WriteLine("Nope, there's no '{0}' in it.", guess);
                        lives--;
                    //draw hangman
                     _renderer.Render(10, 10, lives);
                }

                    Console.WriteLine(displayToPlayer.ToString());
                }
                //if the user has won
                if (won)
                    Console.WriteLine("You won!");
                else
                    Console.WriteLine("You've lost! It was '{0}'", wordToGuess);

                Console.Write("Press ENTER to exit...");
                Console.ReadLine();
            }
        }

    }
 
