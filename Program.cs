using System;

namespace PalindromeChecker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             1. Prompt user to enter a word or sentence.
             2. Check user input if nothing prompt them again.
             3. Check wheter user input is just a word or sentence.
             4. Ask user that they want to check more or quit program.
             */
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
                        Console.WriteLine($"\"{userInput}\" is{SpaceOrNot(isPalindrome)} a palindrome.");
                    else
                        Console.WriteLine($"\"{userInput}\" is a sentence and has{SpaceOrNot(hasPalindrome)} palindromes.");

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
            // Check whether the user input word is a single word or not.
            return !input.Contains(" ");
        }

        static bool IsPalindrome(string word)
        {
            // Get the user input, reverse that word, input to array, and build a new string.
            // Leverage the built-in method `string.Equals()` for comparing two strings (string a, string b).
            // The third parameter tell method to use binary sorted between 2 strings and ignoring the case
            // of strings being compared.
            string reversed = new string(word.Reverse().ToArray());
            return string.Equals(word, reversed, StringComparison.OrdinalIgnoreCase);
        }

        static bool HasPalindrome(string sentence)
        {
            // Leverage our two methods for spliting sentence into an array,
            // and using `IsPalindrome` and make sure a word has more than 1 character.
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
            // Listing separators characters for spliting words within the sentence,
            // and leverage the `RemoveEmptyEntries` to omit array elements that
            // contain an empty string from the result.
            char[] separators = { ' ', '.', ',', '!', ';', ':' };
            return sentence.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }

        static string SpaceOrNot(bool input)
        {
            // This method is dependency only with two method `IsPalindrome` and `HasPalindrome`,
            // insert a `not` word with in that sentence.
            return input ? " " : " not ";
        }
    }
}
