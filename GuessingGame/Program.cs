using System;
using System.ComponentModel.Design;
using System.Threading.Channels;
using System.Transactions;
using static System.Net.Mime.MediaTypeNames;

namespace GuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(
                    "Welcome to the Number Guessing Game!\nThis is a two player game where Player 1 will enter a number " +
                    "between 0 and 100\nand Player 2 will try to guess that number!\nPlayer 2 will have 5 guesses to find Player 1's number!\n" +
                    "If Player 2 guesses the number correctly, the game can be restarted!\nNote: at any time you can type quit or exit to finish the game.\n" +
                    "Please press any key to start the game: ");
                Console.ReadKey();
                Console.Clear();

                // Player 1 Turn

                Console.WriteLine("Welcome Player 1!\nPlease enter a number between 0 and 100:");
                string playerOneNumberInput = Console.ReadLine().ToLower();

                if (playerOneNumberInput == "quit" || playerOneNumberInput == "exit")
                {
                    break;
                }

                int playerOneNumber;
                bool inputIsNumerical = Int32.TryParse(playerOneNumberInput, out playerOneNumber);

                if (!inputIsNumerical)
                {
                    Console.WriteLine("You did not enter a number!\nPress any key to restart.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                playerOneNumber = Math.Max(0, Math.Min(100, playerOneNumber));

                Console.WriteLine($"You entered {playerOneNumber}. The number has been saved.\nPress any key to let Player 2 guess your number.");
                Console.ReadKey();
                Console.Clear();

                // Player 2 Turn

                Console.WriteLine("Welcome Player 2!\nYou have 5 guesses to find Player 1's number.\nPress enter to start!");
                Console.ReadLine();

                int guessCount = 0;
                int guessLimit = 5;
                bool outOfGuesses = false;

                while (!outOfGuesses)
                {
                    Console.WriteLine($"Guess #{guessCount + 1}:");
                    string playerTwoInput = Console.ReadLine().ToLower();

                    if (playerTwoInput == "quit" || playerTwoInput == "exit")
                    {
                        break;
                    }

                    int playerTwoNumber;
                    bool playerTwoInputIsNumerical = Int32.TryParse(playerTwoInput, out playerTwoNumber);

                    if (!playerTwoInputIsNumerical)
                    {
                        Console.WriteLine("You did not enter a number! Please try again.");
                        continue;
                    }

                    guessCount++;

                    if (playerTwoNumber == playerOneNumber)
                    {
                        Console.WriteLine($"Congratulations! You guessed the correct number ({playerOneNumber}) in {guessCount} guesses.\nPress any key to restart.");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
                    else if (playerTwoNumber < playerOneNumber)
                    {
                        Console.WriteLine("Your guess is too low.");
                    }
                    else
                    {
                        Console.WriteLine("Your guess is too high.");
                    }

                    if (guessCount == guessLimit)
                    {
                        outOfGuesses = true;
                        Console.WriteLine($"You have run out of guesses! The correct number was {playerOneNumber}.\nPress any key to restart.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine($"{guessLimit - guessCount} guesses remaining.");
                    }
                }
            }
        }
    }
}