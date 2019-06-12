using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    class Program
    {

        public static int max { get; set; }
        static void Main(string[] args)
        {

            int theAnswer;
            string selectMode;
            int inputMode;
            int playerGuess;
            int firstGuess = 1;
            bool badValue = true;
            string playerInput;
            string name;
            int count = 0;
            int min = 1;           
           

            Console.WriteLine("Select Level of Difficulty: ");
            Console.WriteLine("1. Easy mode 1-5");
            Console.WriteLine("2. Normal mode 1-20");
            Console.WriteLine("3. Hard mode 1-50");
            selectMode = Console.ReadLine();

            if (int.TryParse(selectMode, out inputMode))
            {
                if (inputMode == 1)
                {
                    max = 6;
                }
                else if (inputMode == 2)
                {
                    max = 21;
                }
                else if (inputMode == 3)
                {
                    max = 51;
                }
                else if (inputMode < 1 || inputMode > 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Number out of range");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not valid.");
                    Console.ResetColor();
                }
            }

            Random r = new Random();
            theAnswer = r.Next(min, max);

            Console.Write("What is your name? ");
            name = Console.ReadLine();

            do
            {
                // get player input
                Console.Write($"{name}, enter your guess (1-{max - 1}): ");
                playerInput = Console.ReadLine();

                if (playerInput == "q" || playerInput == "Q")
                    break;

                //attempt to convert the string to a number
                if (!int.TryParse(playerInput, out playerGuess))
                {
                    Console.WriteLine("\n\t {0} is not a number \n", playerInput);
                }
                else if (playerGuess >= min && playerGuess <= max - 1)
                {
                    if (playerGuess == theAnswer)
                    {
                        count++;
                        if (count == firstGuess)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"{theAnswer} was the number. You Win on First Try!");
                            Console.ResetColor();
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine($"{theAnswer} was the number. You Win! Number of tries: {count}");
                            Console.ResetColor();
                            break;
                        }
                    }
                    else
                    {
                        if (playerGuess > theAnswer)
                        {
                            count++;
                            Console.WriteLine("Your guess was too High!");
                        }
                        else
                        {
                            count++;
                            Console.WriteLine("Your guess was too low!");
                        }
                    }

                }
                else if (playerGuess > max - 1 || playerGuess < min)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("This number was out of range.");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Not valid.");
                    Console.ResetColor();
                }


            } while (badValue);

            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();
        }
    }


}

