using System;

namespace MoviesApp.Repository
{
    internal class Movie
    {
        public int Mid { get; set; }
        public string Moviename { get; set; }
        public string DirectorName { get; set; }
        public DateTime DateofRelease { get; set; }
    }
}