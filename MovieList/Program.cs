using System;
using System.Collections.Generic;

namespace MovieList
{
    class Program
    {
        static void Main(string[] args)
        {
            // Make a movie class
            // Create Genre Enum
            // Allow my user to search by genre
            List<Movie> movies = new List<Movie>();

            Movie m1 = new Movie("Fight Club", Genre.Action);
            movies.Add(m1);

            Movie m2 = new Movie("Shrek", Genre.Romance);
            movies.Add(m2);

            Movie m3 = new Movie("The Notebook", Genre.Romance);
            movies.Add(m3);

            Movie m4 = new Movie("Spaceballs", Genre.Comedy);
            movies.Add(m4);

            Console.WriteLine("Here are the accepted genres.");
            Genre[] acceptedGenres = (Genre[])Enum.GetValues(typeof(Genre));

            foreach (Genre g in acceptedGenres)
            {
                Console.WriteLine(g);
            }

            bool goOn = true;

            while (goOn == true)
            {

                string input = GetUserInput("Please input a movie genre you wish to search.");
                Genre inputGenre = (Genre)Enum.Parse(typeof(Genre), input);

                foreach (Movie m in movies)
                {
                    if (m.genre == inputGenre)
                    {
                        Console.WriteLine(m.Title);
                    }
                }

                goOn = GetContinue();
            }
        }

        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string input = Console.ReadLine().Trim();
            if (input == "")
            {
                input = GetUserInput("Blanks are not acceptable input. Try again.");
            }
            return input;
        }


        public static bool GetContinue()
        {
            string input = GetUserInput("Would you like to continue? Y/N");
            if (input.ToLower() == "y")
            {
                return true;
            }
            else if (input.ToLower() == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("I don't understand that input. Please try again.");
                return GetContinue();
            }
        }
    }
}
