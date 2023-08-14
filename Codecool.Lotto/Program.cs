namespace Codecool.Lotto;

internal class Program
{
    public static void Main(string[] args)
    {
        const int quantity = 5;
        const int maxNumber = 25;
        List<int> winningNumbers = new List<int>(quantity);
        List<int> userNumbers = new List<int>(quantity);
        List<int> userWinningNumbers = new List<int>();

        List<int> computerNumbers = new List<int>();
        List<int> computerWinningNumbers = new List<int>();
        
        // user play
        // GetUserInput(quantity, maxNumber, userNumbers);
        // StartGame(quantity, maxNumber, winningNumbers, userNumbers, userWinningNumbers);
        // Output(winningNumbers, userNumbers, userWinningNumbers);

        // computer play
        while (computerWinningNumbers.Count == 0) 
        {
            winningNumbers.Clear();
            computerNumbers.Clear();
            computerWinningNumbers.Clear();
            GetComputerInput(quantity, maxNumber, computerNumbers);
            StartGame(quantity, maxNumber, winningNumbers, computerNumbers, computerWinningNumbers);
            Output(winningNumbers, computerNumbers, computerWinningNumbers);
        }
    }   

    #region Game Logic
    public static void StartGame(int quantity, int maxNumber, List<int> winningNumbers, List<int> guessNumbers, List<int> guessWinningNumbers)
    {
        var rand = new Random();
        int i = 0;
        while (i < quantity)
        {
            int randomNumber = rand.Next(maxNumber + 1);
            if (!winningNumbers.Contains(randomNumber))
            {
                winningNumbers.Add(randomNumber);
                i++;
            }
        }
        CheckWinningNumbers(winningNumbers, guessNumbers, guessWinningNumbers);
    }

    public static void CheckWinningNumbers(List<int> winningNumbers, List<int> guessNumbers, List<int> guessWinningNumbers)
    {
        foreach (var guessNr in guessNumbers)
        {
            if (winningNumbers.Contains(guessNr))
            {
                guessWinningNumbers.Add(guessNr);
            }
        }
    }


    #endregion


    #region User Input
    public static void GetUserInput(int quantity, int maxNumber, List<int> userNumbers) {
        Console.WriteLine($"You have {quantity} tries!");
        int i = 0;
        while ( i < quantity)
        {
            Console.Write($"Guess {i + 1} number between 0 and {maxNumber}: ");
            string? input = Console.ReadLine();
            bool succesfullyConverted = int.TryParse(input, out int intInput);
            if (succesfullyConverted)
            {
                if (intInput >= 0 && intInput <= maxNumber && !userNumbers.Contains(intInput))
                {
                    Console.WriteLine($"Converted '{input}' to {intInput}. {intInput} is between 0 and {maxNumber}.");
                    userNumbers.Add(intInput);
                    i++;
                }
                else 
                {
                    Console.WriteLine($"The number is not between 0 and {maxNumber} or is already chosen.");
                }
            }
            else
            {
                Console.WriteLine($"Attempted conversion of '{input ?? "<null>"}' failed.");
            }
        }
    }

    public static void GetComputerInput(int quantity, int maxNumber, List<int> computerNumbers)
    {
        var rand = new Random();
        int i = 0;
        while (i < quantity)
        {
            int randomNumber = rand.Next(maxNumber + 1);
            if (!computerNumbers.Contains(randomNumber))
            {
                computerNumbers.Add(randomNumber);
                i++;
            }
        }
    }

    #endregion


    #region Output
    public static void Output(List<int> winningNumbers, List<int> guessNumbers, List<int> guessWinningNumbers)
    {
        if (guessWinningNumbers.Count == 0) {
            DisplayResultForLoss(winningNumbers, guessNumbers);
        } 
        else 
        {
            DisplayResultForWin(winningNumbers, guessNumbers, guessWinningNumbers);
        }
    }

    public static void DisplayResultForLoss(List<int> winningNumbers, List<int> guessNumbers)
    {
        Console.WriteLine("You did not guess any number.");
        Console.Write("The winning numbers were: ");
        DisplayList(winningNumbers);

        Console.Write("Your numbers were: ");
        DisplayList(guessNumbers);
    }

    public static void DisplayResultForWin(List<int> winningNumbers, List<int> guessNumbers, List<int> guessWinningNumbers)
    {
        Console.WriteLine("Well done!");
        Console.Write("The winning numbers were: ");
        DisplayList(winningNumbers);

        Console.Write("Your numbers were: ");
        DisplayList(guessNumbers);

        Console.Write("You guess: ");
        DisplayList(guessWinningNumbers);
    }

    public static void DisplayList(List<int> numbers) {
        foreach (int number in numbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
    #endregion
}