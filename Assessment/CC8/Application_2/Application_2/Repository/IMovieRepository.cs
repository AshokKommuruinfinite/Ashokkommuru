using System.Collections.Generic;

namespace MoviesApp.Repository

{

    public interface IMovieRepository

    {

        void Add(Movie movie);

        void Update(Movie movie);

        void Delete(int id);

        Movie GetById(int id);

        IEnumerable<Movie> GetAll();

        IEnumerable<Movie> GetByYear(int year);

        IEnumerable<Movie> GetByDirector(string directorName);

    }

}

