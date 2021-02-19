using Fundamentals.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fundamentals.Data
{
	public class SqlMovieData :IMovieData
	{
		private readonly FundamentalsDbContext db;

		public SqlMovieData(FundamentalsDbContext db)
		{
			this.db = db;
		}
		public Movie Add(Movie newMovie)
		{
			db.Add(newMovie);
			return newMovie;
		}

		public int Commit()
		{
			return db.SaveChanges();
		}

		public Movie Delete(int id)
		{
			var movie = GetById(id);
			if (movie != null)
			{
				db.Remove(movie);
			}
			return movie;
		}

		public Movie GetById(int id)
		{
			return db.Movies.Find(id);
		}

		public int GetCountOfMovies()
		{
			return db.Movies.Count();
		}

		public IEnumerable<Movie> GetMovieByName(string name)
		{
			var query = from m in db.Movies
						where m.Title.Contains(name) || string.IsNullOrEmpty(name)
						orderby m.Title
						select m;
			return query;
		}

		public Movie Update(Movie updatedMovie)
		{
			var entity = db.Movies.Attach(updatedMovie);
			entity.State = EntityState.Modified;
			return updatedMovie;
		}
	}
}

