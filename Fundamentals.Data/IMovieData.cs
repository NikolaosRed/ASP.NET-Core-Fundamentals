using Fundamentals.Core;
using System.Collections.Generic;
using System.Text;

namespace Fundamentals.Data
{
	public interface IMovieData
	{
		//IEnumerable<Movie> GetAll();
		IEnumerable<Movie> GetMovieByName(string name);
		Movie GetById(int id);
		Movie Update(Movie updatedMovie);
		Movie Add(Movie newMovie);
		Movie Delete(int id);
		int Commit();
		int GetCountOfMovies();

	}
}
