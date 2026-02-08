HomeworkTask();
void HomeworkTask()
{
    /// Create a guessing game where the user has to guess a randomly generated number 
    /// between 1 and 100. The list of numbers gradually becomes smaller as the user guesses
    /// and is given hints by the program of "higher" or "lower".
    /// The user with the lowest number of guesses is congratulated.

    User user1 = new User();
    Console.Write("What is your name? ");
    user1.name = Console.ReadLine();
    user1.score = Game();

    Console.WriteLine("");

    User user2 = new User();
    Console.Write("What is your name? ");
    user2.name = Console.ReadLine();
    user2.score = Game();

    CompareScores(user1.score, user2.score);

    int Game()
    {
        Random rnd = new Random();
        int numtoguess = rnd.Next(1, 101);              /// Creates the random number for the user to guess

        int lower = 1;                                  /// sets the initial lower value
        int higher = 100;                               /// sets the initial higher value
        bool victory = false;
        int guesses = 0;

        while (victory == false)
        {
            PrintRange(lower, higher);                  /// prints list from 1 to 100
            int guess = AskForNum("Guess a number! ");

            if (CheckValidNum(guess, lower, higher))    /// checks the number is between 1 and 100
            {                                           /// if valid, proceeds
                if (guess < numtoguess)
                {
                    Console.WriteLine("Higher!");
                    Console.WriteLine("");
                    lower = guess + 1;                  /// adjusts printed list to only show numbers greater than the guess
                    guesses += 1;
                }
                else if (guess > numtoguess)
                {
                    Console.WriteLine("Lower!");
                    Console.WriteLine("");
                    higher = guess - 1;                 /// adjusts printed list to only show numbers smaller than the guess
                    guesses += 1;
                }
                else
                {
                    guesses++;
                    Console.WriteLine($"Congratulations, you guessed it in {guesses} guesses!");
                    victory = true;
                }
            }
        }
        return guesses;
    }

    void PrintRange(int n1, int n2)                     /// From task 1 - prints the valid range
    {
        for (int i = n1; i < n2; i++)
        {
            Console.Write($"{i}, ");
        }
        Console.Write($"{n2}");                         /// Writes the final number without a comma afterwards.
        Console.WriteLine("");
    }

    bool CheckValidNum(int num, int n1, int n2)
    {
        if (num < n1 || num > n2)
        {
            Console.WriteLine("That's not a number within the valid range! ");
            return false;
        }
        else
        {
            return true;
        }
    }

    int AskForNum(string m)
    {
        bool v = false;
        int n = 0;

        while (v == false)
        {
            Console.Write(m);
            if (int.TryParse(Console.ReadLine(), out int i))
            {
                v = true;
                n = i;
            }
            else
            {
                Console.WriteLine("Not a valid number! ");
            }
        }
        return n;
    }

    void CompareScores(int s1, int s2)
    {
        if (s1 < s2)
        {
            Console.WriteLine($"{user1.name} wins with a score of {user1.score}!");
        }
        else if (s2 < s1)
        {
            Console.WriteLine($"{user2.name} wins with a score of {user2.score}!");
        }
        else
        {
            Console.WriteLine("It's a tie!");
        }
    }
}

class User
{
    public int score;
    public string name;
}