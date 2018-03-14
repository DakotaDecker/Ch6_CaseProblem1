using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

// Program written by: Eric Bjerke & Dakota Decker
// Program date: 3-11-18
// Program description: Ch6 Case Problem 1
// Encounterd issues: None

namespace Case_Study_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //initialize variables
            double FEE = 25, revenue;
            int thisYearContestantsCount, lastYearContestantsCount;
                        

            //get numbers, check if between 0-30
            do
            {
                Write("Enter number of contestants this year (0-30): ");
                thisYearContestantsCount = Convert.ToInt32(ReadLine());
            }
            while (thisYearContestantsCount < 0 || thisYearContestantsCount > 30);
            do
            {
                Write("Enter number of contestants last year (0-30): ");
                lastYearContestantsCount = Convert.ToInt32(ReadLine());
            }
            while (lastYearContestantsCount < 0 || lastYearContestantsCount > 30);

            //calculate revenue
            revenue = FEE * thisYearContestantsCount;

            WriteLine("Estimated " + revenue.ToString("C2") +
                " in entrance fee revenue this year.");

            if (thisYearContestantsCount > (lastYearContestantsCount * 2))
            {
                WriteLine("The competition is more than twice as big this year!");
            }
            else if ((thisYearContestantsCount > lastYearContestantsCount) && (thisYearContestantsCount < (lastYearContestantsCount * 2)))
            {
                WriteLine("The competition is bigger than ever!");
            }
            else
            {
                WriteLine("A tighter race this year! Come out and cast your vote!");
            }

            //initializes parallel arrays for contestants
            string[] names = new string[thisYearContestantsCount];
            string[] talents = new string[thisYearContestantsCount];

            //asks for contestant names and talent code
            for (int i = 0; i < thisYearContestantsCount; i++)
            {
                Console.Write("Enter contestant #{0} name: ", (i + 1));
                names[i] = Console.ReadLine();
                string userInput;
                do
                {
                    Console.Write("Enter 'S' for Singing, 'D' for dancing, 'M' for music, or 'O' for other: ");
                    userInput = (Console.ReadLine()).ToUpper();
                }
                while ((userInput != "S") && (userInput != "D") && (userInput != "M") && (userInput != "O"));
                talents[i] = userInput;
            }

            ReadLine();
        }
    }
}
