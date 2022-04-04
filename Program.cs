using System;
using System.Collections.Generic;
using static System.Random;
using System.Text;


namespace Hangman
{
    public class Program
    {

        private static void printHangman(int wrong)
        {
            if (wrong == 0)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 1)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("    |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 2)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine("O   |");
                Console.WriteLine("|   |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 3)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|  |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 4)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("    |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 5)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O  |");
                Console.WriteLine("/|\\ |");
                Console.WriteLine("/   |");
                Console.WriteLine("   ===");
            }
            else if (wrong == 6)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("    ===");
            }

            else if (wrong == 7)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("    ====");
            }

            else if (wrong == 8)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("   =====");
            }

            else if (wrong == 9)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine(" ======");

            }

            else if (wrong == 10)
            {
                Console.WriteLine("\n+---+");
                Console.WriteLine(" O   |");
                Console.WriteLine("/|\\  |");
                Console.WriteLine("/ \\  |");
                Console.WriteLine("=======");

            }
        }

        private static int printWord(List<char> totalGuessedLetters, String myWord)
        {

            int counter = 0;
            int totalRightLetters = 0;
            Console.Write("\r\n");

            foreach (char c in myWord)
            {
                if (totalGuessedLetters.Contains(c))
                {
                    Console.Write(c + " ");
                    totalRightLetters += 1;
                }


                else
                {
                    Console.Write("  ");
                }
                counter += 1;
            }
            return totalRightLetters;


        }


        private static void printLines(String myWord)
        {

            foreach (char c in myWord)
            {

                Console.OutputEncoding = System.Text.Encoding.Unicode;
                Console.Write("\u0305 ");
            }
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Lets play Hangman:)");
            Console.WriteLine("-----------------------------------------");


            Random rand = new Random();

            List<string> manyWords = new List<string> { "book", "cinema", "autopsy", "grinder", "enigma", "batman", "squirrel", "teemo", "allah", "lionking" };

            int index = rand.Next(manyWords.Count);

            String myWord = manyWords[index];



            foreach (char c in myWord)
            {
                Console.Write("_ ");
            }


            int lengthOfWord = myWord.Length;
            int timesWrong = 0;
            List<char> currentLettersGuessed = new List<char>();
            int lettersRight = 0;

            while (timesWrong != 10 && lettersRight != lengthOfWord)
            {
                Console.WriteLine("\nTotal Letters guessed so far: ");
                foreach (char letter in currentLettersGuessed)
                {
                    Console.Write(letter + "  ");
                }

                Console.WriteLine("\nGuess a letter or the whole word: ");


                string wordGuess = Console.ReadLine();

                char letterGuessed = wordGuess.ToCharArray()[0];

                StringBuilder sb = new StringBuilder();

                {

                    if (wordGuess == myWord)
                    {

                        Console.Clear();
                        Console.WriteLine("Congratulations! You've won. The correct word is: " + myWord);


                    }

                    else
                    {

                        if (currentLettersGuessed.Contains(letterGuessed))
                        {
                            Console.WriteLine("\r\n You have already guessed this letter");
                            printHangman(timesWrong);
                            lettersRight = printWord(currentLettersGuessed, myWord);
                            printLines(myWord);


                        }

                        else
                        {

                            bool right = false;

                            for (int i = 0; i < myWord.Length; i++) { if (letterGuessed == myWord[i]) { right = true; break; } }

                            if (right)
                            {
                                printHangman(timesWrong);
                                currentLettersGuessed.Add(letterGuessed);
                                lettersRight = printWord(currentLettersGuessed, myWord);
                                Console.Write("\r\n");
                                printLines(myWord);
                            }

                            else
                            {
                                timesWrong += 1;
                                currentLettersGuessed.Add(letterGuessed);
                                printHangman(timesWrong);
                                lettersRight = printWord(currentLettersGuessed, myWord);
                                Console.Write("\r\n");
                                printLines(myWord);

                              
                                sb.Append(new char[] { letterGuessed });
                                Console.WriteLine("\r\nWrong letters: {0} chars: {1}", sb.Length, sb.ToString()); ;

                            }
                           
                                                                    
                                    }
                                

                                {




                                }


                            }
                        }

                    }

                }
            }

        }

    
    
