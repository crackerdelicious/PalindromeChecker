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
                string? userInput = Console.ReadLine();
                if (string.IsNullOrEmpty(userInput) || string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Please type something!");
                }
                else
                {
                    Console.WriteLine(WordOrSentence(userInput) 
                        ? $"\"{userInput}\" is{SpaceOrNot(IsPalindrome(userInput))}a palindrome." 
                        : $"{userInput} is a sentence, and have{SpaceOrNot(HavePalindrome(userInput))}palindromes.");

                    do
                    {
                        Console.Write("\nDo you want to check more words or sentences? (y/n)");
                        choice = Console.ReadLine();
                        if (choice == "n")
                            Console.WriteLine("Goodbye!");
                        else if (choice == "y")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nPlease choose between (y/n).");
                        }
                    } while (choice != "n");
                }                
            } while (choice != "n");
        }
        static bool IsPalindrome(string word)
        {
            return WordComparer(word);
        }
        static bool HavePalindrome(string words)
        {
            foreach (string word in WordsSpliter(words))
            {
                if (WordComparer(word) && word.Length > 1)
                    return true;
            }
            return false;
        }
        static string[] WordsSpliter(string sentence)
        {
            char[] separators = new char[] { ' ', '.', ',', '!', ';', ':' };
            return sentence.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        }
        static bool WordOrSentence(string input)
        {
            return (WordsSpliter(input).Count() == 1);
        }
        static string SpaceOrNot(bool input)
        {
            return input ? " " : "not";
        }
        static bool WordComparer(string word)
        {
            string compare = "";
            for (int i = word.Length - 1; i >= 0; i--)
                compare += word[i];
            return (String.Compare(word.ToLower(), compare.ToLower()) == 0);
        }
    }
}