using System;

namespace PalindromeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? choice = "y";
            do
            {
                Console.Write("Enter a word or sentence: ");
                string? userInput = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Please type something!");
                }
                else
                {
                    bool isSingleWord = IsSingleWord(userInput);
                    bool isPalindrome = IsPalindrome(userInput);
                    bool hasPalindrome = HasPalindrome(userInput);

                    if (isSingleWord)
                    {
                        Console.WriteLine($"\"{userInput}\" is{SpaceOrNot(isPalindrome)} a palindrome.");
                    }
                    else
                    {
                        Console.WriteLine($"\"{userInput}\" is a sentence and has{SpaceOrNot(hasPalindrome)} palindromes.");
                    }

                    do
                    {
                        Console.Write("\nDo you want to check more words or sentences? (y/n) ");
                        choice = Console.ReadLine()?.Trim().ToLower();
                        if (choice == "n")
                        {
                            Console.WriteLine("Goodbye!");
                        }
                        else if (choice != "y")
                        {
                            Console.WriteLine("\nPlease choose between (y/n).");
                        }
                    } while (choice != "y" && choice != "n");
                }
            } while (choice != "n");
        }

        static bool IsSingleWord(string input)
        {
            return !input.Contains(" ");
        }

        static bool IsPalindrome(string word)
        {
            string reversed = new string(word.Reverse().ToArray());
            return string.Equals(word, reversed, StringComparison.OrdinalIgnoreCase);
        }

        static bool HasPalindrome(string sentence)
        {
            string[] words = WordsSplitter(sentence);
            foreach (string word in words)
            {
                if (IsPalindrome(word) && word.Length > 1)
                {
                    return true;
                }
            }
            return false;
        }

        static string[] WordsSplitter(string sentence)
        {
            char[] separators = { ' ', '.', ',', '!', ';', ':' };
            return sentence.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        static string SpaceOrNot(bool input)
        {
            return input ? " " : " not ";
        }
    }
}
