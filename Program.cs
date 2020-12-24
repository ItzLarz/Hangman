using System;
using System.Linq;
using System.Security.Cryptography;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            //declaring all the variables
            bool won = false;
            bool lost = false;
            bool gameOver = false;
            int x = 0;
            int y = 11;
            int z = 0;
            int numLetters;
            string[] randomWords = { "ghello" }; //set all your words in this array
            char[] doneCharacters = new char[100];
            char[] dashes = new char[100];
            string word;
            char guessLetter;
            string guessWord;
            

            //randomly choosing a word from the array
            Random random = new Random();
            word = randomWords[random.Next(0, randomWords.Length)];
            numLetters = word.Length;

            for (int i = 0; i < numLetters; i++)
            {
                dashes[i] = '_';
            }

            //starting game
            Console.WriteLine("This is a game of Hangman");
            Console.WriteLine("The word has " + numLetters + " letters");
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            



            while (!gameOver)
            {
                Console.WriteLine();
                Console.WriteLine("You have " + y + " guess(es)");
                Console.Write("Enter your letter guess or set a dash if you want to guess the word: ");
                guessLetter = char.Parse(Console.ReadLine());

                

                //if you wanted to guess a word
                if (guessLetter == '-')
                {
                    
                    Console.Write("Enter your word guess: ");
                    guessWord = Console.ReadLine();

                    //if you got the correct word
                    if (guessWord == word)
                    {
                        won = true;
                        gameOver = true;
                    }

                    else
                    {
                        y--;
                        //if you got the incorrect word
                        if (y > 0)
                        {
                            Console.WriteLine("That wasn't right, the word wasn't " + guessWord + "!");
                            Console.WriteLine();

                            for (int i = 0; i < numLetters; i++)
                            {
                                Console.Write(dashes[i]);
                                Console.Write(" ");
                            }
                            Console.WriteLine();
                            GetMan(y);
                            Console.WriteLine();
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        }

                        //if your guesses were gone
                        else
                        {
                            lost = true;
                            gameOver = true;
                        }
                    }
                }

                //if you wanted to guess a letter
                else
                {
                    if (word.Contains(guessLetter))
                    {
                        //if you already guessed the character
                        if (doneCharacters.Contains(guessLetter))
                        {
                            Console.WriteLine("ERROR: You have already guessed this character");
                            Console.WriteLine();
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        }
                        
                        //if you got the correct character
                        else
                        {
                            doneCharacters[z] = guessLetter;
                            z++;

                            int freq = word.Count(f => (f == guessLetter));
                            x += freq;

                            if (freq > 1)
                            {
                                Console.WriteLine("That was right, the word contains " + freq + " " + guessLetter + "'s!");
                                Console.WriteLine();

                                for (int i = 0; i < numLetters; i++)
                                {
                                    if (word[i] == guessLetter)
                                    {
                                        dashes[i] = guessLetter;
                                    }
                                }
                                
                                for (int i = 0; i < numLetters; i++)
                                {
                                    Console.Write(dashes[i]);
                                    Console.Write(" ");
                                }
                                
                                Console.WriteLine();
                                GetMan(y);
                                Console.WriteLine();
                                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            }

                            else
                            {
                                Console.WriteLine("That was right!");
                                Console.WriteLine();

                                for (int i = 0; i < numLetters; i++)
                                {
                                    if (word[i] == guessLetter)
                                    {
                                        dashes[i] = guessLetter;
                                    }
                                }

                                for (int i = 0; i < numLetters; i++)
                                {
                                    Console.Write(dashes[i]);
                                    Console.Write(" ");
                                }

                                Console.WriteLine();
                                GetMan(y);
                                Console.WriteLine();
                                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            }

                            //if you got all the correct characters
                            if (x >= numLetters)
                            {
                                won = true;
                                gameOver = true;
                            }
                        }
                    }

                    else
                    {   
                        //if you already guessed the character
                        if (doneCharacters.Contains(guessLetter))
                        {
                            Console.WriteLine("ERROR: You have already guessed this character");
                            Console.WriteLine();
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                        }

                        //if you guessed the incorrect character
                        else
                        {
                            doneCharacters[z] = guessLetter;
                            z++;

                            y--;

                            if (y > 0)
                            {
                                Console.WriteLine("That wasn't right, try again!");
                                Console.WriteLine();

                                for (int i = 0; i < numLetters; i++)
                                {
                                    if (word[i] == guessLetter)
                                    {
                                        dashes[i] = guessLetter;
                                    }
                                }

                                for (int i = 0; i < numLetters; i++)
                                {
                                    Console.Write(dashes[i]);
                                    Console.Write(" ");
                                }

                                Console.WriteLine();
                                GetMan(y);
                                Console.WriteLine();
                                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                            }

                            //if your guesses were gone
                            else
                            {
                                lost = true;
                                gameOver = true;
                            }
                        }
                    }
                }   
            }

            //if you win
            if (won)
            { 
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("You won the game, the word was " + word + "!");
                Console.WriteLine();
                GetMan(y);
            }

            //if you lose
            else if (lost)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("You lost the game, the word was " + word + "!");
                Console.WriteLine();
                GetMan(y);
            }

            //if you broke the game
            else
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("You broke the game, the word was " + word + "!");
                Console.WriteLine();
                GetMan(y);
            }

            
        }

        //creating all the lines for the hanging man
        static void GetMan(int num)
        {
            switch (num)
            {
                case 10:
                    Console.WriteLine("         ");
                    Console.WriteLine("         ");
                    Console.WriteLine("         ");
                    Console.WriteLine("         ");
                    Console.WriteLine("         ");
                    Console.WriteLine("\u00AF\u00AF\u00AF\u00AF\u00AF\u00AF\u00AF");
                    break;

                case 9:
                    Console.WriteLine("         ");
                    Console.WriteLine("   │     ");
                    Console.WriteLine("   │     ");
                    Console.WriteLine("   │     ");
                    Console.WriteLine("   │     ");
                    Console.WriteLine("\u00AF\u00AF\u00AF\u00AF\u00AF\u00AF\u00AF");
                    break;

                case 8:
                    Console.WriteLine("   ______");
                    Console.WriteLine("   │     ");
                    Console.WriteLine("   │     ");
                    Console.WriteLine("   │     ");
                    Console.WriteLine("   │     ");
                    Console.WriteLine("\u00AF\u00AF\u00AF\u00AF\u00AF\u00AF\u00AF");
                    break;

                case 7:
                    Console.WriteLine("   ______");
                    Console.WriteLine("   │ /   ");
                    Console.WriteLine("   │/    ");
                    Console.WriteLine("   │     ");
                    Console.WriteLine("   │     ");
                    Console.WriteLine("\u00AF\u00AF\u00AF\u00AF\u00AF\u00AF\u00AF");
                    break;

                case 6:
                    Console.WriteLine("   ______");
                    Console.WriteLine("   │ /  │");
                    Console.WriteLine("   │/    ");
                    Console.WriteLine("   │     ");
                    Console.WriteLine("   │     ");
                    Console.WriteLine("\u00AF\u00AF\u00AF\u00AF\u00AF\u00AF\u00AF");
                    break;

                case 5:
                    Console.WriteLine("   ______");
                    Console.WriteLine("   │ /  │");
                    Console.WriteLine("   │/   0");
                    Console.WriteLine("   │     ");
                    Console.WriteLine("   │     ");
                    Console.WriteLine("\u00AF\u00AF\u00AF\u00AF\u00AF\u00AF\u00AF");
                    break;

                case 4:
                    Console.WriteLine("   ______");
                    Console.WriteLine("   │ /  │");
                    Console.WriteLine("   │/   0");
                    Console.WriteLine("   │    │");
                    Console.WriteLine("   │     ");
                    Console.WriteLine("\u00AF\u00AF\u00AF\u00AF\u00AF\u00AF\u00AF");
                    break;

                case 3:
                    Console.WriteLine("   ______");
                    Console.WriteLine("   │ /  │");
                    Console.WriteLine("   │/   0");
                    Console.WriteLine("   │   /│");
                    Console.WriteLine("   │     ");
                    Console.WriteLine("\u00AF\u00AF\u00AF\u00AF\u00AF\u00AF\u00AF");
                    break;

                case 2:
                    Console.WriteLine("   ______");
                    Console.WriteLine("   │ /  │");
                    Console.WriteLine("   │/   0");
                    Console.WriteLine("   │   /│\\");
                    Console.WriteLine("   │     ");
                    Console.WriteLine("\u00AF\u00AF\u00AF\u00AF\u00AF\u00AF\u00AF");
                    break;

                case 1:
                    Console.WriteLine("   ______");
                    Console.WriteLine("   │ /  │");
                    Console.WriteLine("   │/   0");
                    Console.WriteLine("   │   /│\\");
                    Console.WriteLine("   │   / ");
                    Console.WriteLine("\u00AF\u00AF\u00AF\u00AF\u00AF\u00AF\u00AF");
                    break;

                case 0:
                    Console.WriteLine("   ______");
                    Console.WriteLine("   │ /  │");
                    Console.WriteLine("   │/   0");
                    Console.WriteLine("   │   /│\\");
                    Console.WriteLine("   │   / \\");
                    Console.WriteLine("\u00AF\u00AF\u00AF\u00AF\u00AF\u00AF\u00AF");
                    break;
            }
        }
    }
}