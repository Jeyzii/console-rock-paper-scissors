using System;

namespace back_end_wph_exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string playerName = Console.ReadLine();

            int playerHealth = 3;
            int computerHealth = 3;

            Random random = new Random();

            while (playerHealth > 0 && computerHealth > 0)
            {
                Console.WriteLine($"\n{playerName}'s Health: {playerHealth} | Computer's Health: {computerHealth}");
                Console.WriteLine("\nChoose: Q for Rock, W for Paper, E for Scissors, X to Quit");

                string playerChoice = Console.ReadLine().ToUpper();

                if (playerChoice == "X")
                {
                    break;
                }

                string[] choices = { "Q", "W", "E" };
                string computerChoice = choices[random.Next(3)];

                Console.WriteLine($"\n{playerName} chooses: {GetChoiceName(playerChoice)}");
                Console.WriteLine($"Computer chooses: {GetChoiceName(computerChoice)}");

                string result = DetermineWinner(playerChoice, computerChoice);
                Console.WriteLine(result);

                if (result == "You win!")
                {
                    computerHealth--;
                }
                else if (result == "You lose!")
                {
                    playerHealth--;
                }

                if (playerHealth == 0)
                {
                    Console.WriteLine($"\n{playerName} has run out of health. You lose!");
                }
                else if (computerHealth == 0)
                {
                    Console.WriteLine("Computer has run out of health. You win!");
                }
            }

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }

        static string GetChoiceName(string choice)
        {
            switch (choice)
            {
                case "Q":
                    return "Rock";
                case "W":
                    return "Paper";
                case "E":
                    return "Scissors";
                default:
                    return "Invalid choice";
            }
        }

        static string DetermineWinner(string playerChoice, string computerChoice)
        {
            if (playerChoice == computerChoice)
            {
                return "Tie";
            }
            else if ((playerChoice == "Q" && computerChoice == "E") ||
                    (playerChoice == "W" && computerChoice == "Q") ||
                    (playerChoice == "E" && computerChoice == "W"))
            {
                return "You win!";
            }
            else
            {
                return "You lose!";
            }
        }
    }
}
