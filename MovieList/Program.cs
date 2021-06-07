using System;
using System.Collections.Generic;
using System.Linq;

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

            Movie m5 = new Movie("Toy Story 4", Genre.Comedy);
            movies.Add(m5);

            Movie m6 = new Movie("Anchorman", Genre.Comedy);
            movies.Add(m6);

            Movie m7 = new Movie("Dude Where's My Car?", Genre.Comedy);
            movies.Add(m7);

            Movie m8 = new Movie("The Beach", Genre.Drama);
            movies.Add(m8);

            Movie m9 = new Movie("The Holiday", Genre.Romance);
            movies.Add(m9);

            Movie m10 = new Movie("The Goonies", Genre.Comedy);
            movies.Add(m10);

            Console.WriteLine("Here are the accepted genres.");
            Genre[] acceptedGenres = (Genre[])Enum.GetValues(typeof(Genre));

            

            for (int i = 0; i < acceptedGenres.Length; i++)
            {
                Console.WriteLine($"{i}: {acceptedGenres[i]}");
            }

            bool goOn = true;

            while (goOn == true)
            {
                List<Movie> genreMovies = new List<Movie>();
                int input = GetGenreIndex();
                Genre inputGenre = (Genre)acceptedGenres[input];

                foreach (Movie m in movies)
                {
                    if (m.genre == inputGenre)
                    {
                        genreMovies.Add(m);
                    }
                }
                List<Movie> sortedMovies = genreMovies.OrderBy(x => x.Title).ToList();

                foreach (Movie m in sortedMovies)
                {
                    Console.WriteLine(m.Title);
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

        public static int GetGenreIndex()
        {
            string input = GetUserInput("Please enter the number for the genre you would like to see.");
            int output = -1;

            try
            {
                output = int.Parse(input);
            }
            catch (FormatException)
            {
                Console.WriteLine("You must enter a number listed above.");
                output = GetGenreIndex();

            }
            return output;
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
