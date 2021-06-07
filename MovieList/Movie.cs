using System;
using System.Collections.Generic;
using System.Text;

namespace MovieList
{
    public enum Genre
    {
        Horror,
        Comedy,
        Romance,
        Mystery,
        Action
    }

    class Movie
    {
        public string Title { get; set; }
        public Genre genre { get; set; }

        public Movie(string title, Genre genre)
        {
            Title = title;
            this.genre = genre;
        }
    }
}
