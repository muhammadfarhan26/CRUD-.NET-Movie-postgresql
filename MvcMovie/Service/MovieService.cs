using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using MvcMovie.Models;
using MvcMovie.Repository;

namespace MvcMovie.Service
{
    public class MovieService
    {

        //public async Task<>

        public async Task<List<Movie>> GetALL()
        {
            MovieRepository movieRepository = new MovieRepository();
            return await movieRepository.SelectAllMovie();
        }
        public async Task<bool> InsertMovie(Movie movie)
        {
            MovieRepository movieRepository = new MovieRepository();
            await movieRepository.InsertMovie(movie);
            return true;
        }
        public async Task<Movie> DetailMovie(int? id)
        {
            MovieRepository movieRepository = new MovieRepository();
            return await movieRepository.DetailMovie(id);
        }
        public async Task<bool> EditMovie(int? id,Movie movie)
        {
            MovieRepository movieRepository = new MovieRepository();
            await movieRepository.EditMovie(id, movie);
            return true;
        }
        public async Task<bool> DeleteMovie(int? id)
        {
            MovieRepository movieRepository = new MovieRepository();
            await movieRepository.DeleteMovie(id);
            return true;
        }

        public async Task<List<Movie>> SearchMovie(string title)
        {
            MovieRepository movieRepository = new MovieRepository();
            return await movieRepository.SearchMovie(title);
        }

    }
}
