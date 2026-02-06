using System;
using System.Collections;
using System.Collections.Generic;

namespace Atlas
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Atlas!!");

            List<string> words = new List<string>
            {
                "Punjab",
                "Delhi",
                "Kerala",
                "Amritsar",
                "Lucknow",
                "Bangalore",
                "Mumbai",
                "Goa",
                "Gujarat",
                "Chennai",
                "Pune",
                "Himachal",
                "Manali"
            };

            Random rnd = new Random();
            string word = words[rnd.Next(words.Count)].ToLower();

            char[] display = new char[word.Length];
            for (int i = 0; i < display.Length; i++)
                display[i] = '_';

            ArrayList guessedLetters = new ArrayList();
            int lives = 5;

            Console.WriteLine("Guess the word");

            while (lives > 0 && new string(display).Contains('_'))
            {
                Console.WriteLine("\nWord:");
                Console.WriteLine(string.Join(" ", display));

                Console.WriteLine("Guessed letters: " +
                    string.Join(", ", guessedLetters.ToArray()));

                Console.Write("Enter a letter: ");
                string input = Console.ReadLine().ToLower();

                if (input.Length != 1 || !char.IsLetter(input[0]))
                {
                    Console.WriteLine("⚠️ Wrong input! Enter only one letter.");
                    continue;
                }

                char guess = input[0];

                if (guessedLetters.Contains(guess))
                {
                    Console.WriteLine("⚠️ Letter already guessed!");
                    continue;
                }

                guessedLetters.Add(guess);

                bool found = false;
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == guess)
                    {
                        display[i] = guess;
                        found = true;
                    }
                }

                if (!found)
                {
                    lives--;
                    Console.WriteLine("❌ Wrong guess! Lives left: " + lives);
                }
                else
                {
                    Console.WriteLine("✅ Correct guess!");
                }
            }

            if (!new string(display).Contains('_'))
            {
                Console.WriteLine("\n🎉 SUCCESS! You guessed the word: " + word);
            }
            else
            {
                Console.WriteLine("\n❌ Try again! The word was: " + word);
            }
        }
    }
}
