using Dapper;
using MvcMovie.Models;
using MvcMovie.Utility;
using Npgsql;

namespace MvcMovie.Repository
{
    public class MovieRepository
    {

        //public async
        public async Task<List<Movie>> SelectAllMovie()
        {
            using (var db= new NpgsqlConnection(MovieUtility.ConnString))
            {
                var result = await db.QueryAsync<Movie>(@"Select * From ""movie"";");
                return result.ToList();
            }
        }

        public async Task<bool> InsertMovie(Movie movie)
        {
            using (var db = new NpgsqlConnection(MovieUtility.ConnString))
            {
                var result = await db.QueryAsync<Movie>(@"INSERT INTO ""movie"" (""title"", ""releasedate"", ""genre"", ""price"") VALUES (@title, @releaseDate, @genre, @price);", movie); 
                return true;
            }
        }

        public async Task<Movie> DetailMovie(int? id)
        {
            using (var db = new NpgsqlConnection(MovieUtility.ConnString))
            {
                var result = await db.QueryAsync<Movie>(@"Select * From ""movie"" where id = @id", id);
                var pilem = result.FirstOrDefault();
                return pilem;
            }
        }
        public async Task<bool> EditMovie(int? id, Movie movie)
        {
            using (var db = new NpgsqlConnection(MovieUtility.ConnString))
            {
                var result = await db.QueryAsync<Movie>(@"UPDATE ""movie"" SET ""title"" = @title , ""releasedate"" = @releaseDate, ""genre"" = @genre, ""price"" = @price where id = @id", movie);
                return true;
            }
        }
        public async Task<bool> DeleteMovie(int? id)
        {
            using (var db = new NpgsqlConnection(MovieUtility.ConnString))
            {
                var result = await db.QueryAsync<Movie>(@"DELETE FROM ""movie"" where id = @id;", new {id});
                return true;
            }
        }
        public async Task<List<Movie>> SearchMovie(string title)
        {
            using (var db = new NpgsqlConnection(MovieUtility.ConnString))
            {
                var result = await db.QueryAsync<Movie>(@"Select * From ""movie"" where ""title"" ILIKE @title;", new { title = '%'+title+'%'}) ;
                return result.ToList();
            }
        }


    }
}
