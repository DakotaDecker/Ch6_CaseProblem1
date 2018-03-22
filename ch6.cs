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
        public static int GetContestantNumber(string year)
        {
            int contestantCount;
            do
            {
                Write("Enter number of contestants {0} year (0-30): ", year);
                contestantCount = Convert.ToInt32(ReadLine());
            }
            while (contestantCount < 0 || contestantCount > 30);
            return contestantCount;
        }
        public static void FindBiggerYear(int thisYear, int lastYear)
        {
            if (thisYear > (lastYear * 2))
            {
                WriteLine("The competition is more than twice as big this year!");
            }
            else if ((thisYear > lastYear) && (thisYear < (lastYear * 2)))
            {
                WriteLine("The competition is bigger than ever!");
            }
            else
            {
                WriteLine("A tighter race this year! Come out and cast your vote!");
            }
        }
        public static void InputContestants(int thisYearContestantsCount, string[] names, string[] talents)
        {
            //asks for contestant names and talent code
            for (int i = 0; i < thisYearContestantsCount; i++)
            {
                Write("Enter contestant #{0} name: ", (i + 1));
                names[i] = ReadLine();
                string userInput;
                WriteLine("What is {0}'s talent?", names[i]);
                do
                {
                    Write("Enter 'S' for Singing, 'D' for dancing, 'M' for music, or 'O' for other: ");
                    userInput = (ReadLine()).ToUpper();
                }
                while ((userInput != "S") && (userInput != "D") && (userInput != "M") && (userInput != "O"));
                talents[i] = userInput;
            }
        }
        public static void DisplayContestants(string[] names, string[] talents)
        {
            int singers = 0, dancers = 0, musicians = 0, others = 0;
            for (int i = 0; i < names.Length; i++)
            {
                //increment respective talent counter
                switch (talents[i])
                {
                    case "S":
                        singers += 1;
                        break;
                    case "D":
                        dancers += 1;
                        break;
                    case "M":
                        musicians += 1;
                        break;
                    case "O":
                        others += 1;
                        break;
                }
            }
            //display numbers of each type of contestant
            WriteLine("Number of singers this year: {0}", singers);
            WriteLine("Number of dancers this year: {0}", dancers);
            WriteLine("Number of musicians this year: {0}", musicians);
            WriteLine("Number of others: {0}", others);

            //display names of contestants if user would like
            string contName = "";
            WriteLine("Check names of all contestants in each category?");
            do
            {
                Write("'S' for singers, 'D' for dancers, 'M' for musicians, 'O' for others, or 'Q' to quit: ");
                contName = ReadLine().ToUpper();
                for (int x = 0; x < talents.Length; x++)
                {
                    if (talents[x] == contName)
                    {
                        Write("{0} | ", names[x]);
                    }
                }
                WriteLine();
            }
            while (contName != "Q");
        }
        static void Main(string[] args)
        {
            //initialize variables
            double FEE = 25, revenue;
            int thisYearContestantsCount, lastYearContestantsCount;

            //get numbers, check if between 0-30
            thisYearContestantsCount = GetContestantNumber("this");
            lastYearContestantsCount = GetContestantNumber("last");

            //calculate revenue
            revenue = FEE * thisYearContestantsCount;

            WriteLine("Estimated " + revenue.ToString("C2") +
                " in entrance fee revenue this year.");

            FindBiggerYear(thisYearContestantsCount, lastYearContestantsCount);

            //initializes parallel arrays for contestants
            string[] names = new string[thisYearContestantsCount];
            string[] talents = new string[thisYearContestantsCount];

            //enter contestants
            InputContestants(thisYearContestantsCount, names, talents);

            //display contestants
            DisplayContestants(names, talents);

        }
    }
}
