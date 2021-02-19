using Fundamentals.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fundamentals.Data
{
	public class InMemoryMovieData : IMovieData
	{
		List<Movie> movies;


		public InMemoryMovieData()
		{
			movies = new List<Movie>()
			{
				new Movie {
					MovieId = 1, Title = "A New Hope", EpisodeId = 4,
					OpeningCrawl = "It is a period of civil war....", Director = "George Lucas",
					Producer = "Gary Kurtz, Rick McCallum", ReleaseDate ="1977-05-25",
					Characters = "people/1/, people/2/, people/3/, people/4/",
					Planets = "planets/1/, planets/2/, planets/3/",
					Starships = "starships/2/, starships/3/, starships/5/",
					Vehicles =  "vehicles/4/, vehicles/6/, vehicles/7/",
					Species = "spices/1/, spices/2/, spices/3/, spices/4/",
					Created = "2014-12-10T14:23:31.880000Z", Edited = "2014-12-20T19:49:45.256000Z",
					Url = "http://swapi.dev/api/films/1/",
					Rating=Rating.Seven
				},
				new Movie {
					MovieId = 2, Title = "The Empire Strikes Back", EpisodeId = 5,
					OpeningCrawl = "It is a dark time for the....", Director = "Irvin Kershner",
					Producer = "Gary Kurtz, Rick McCallum", ReleaseDate ="1980-05-17",
					Characters = "people/1/, people/2/, people/3/, people/4/",
					Planets = "planets/1/, planets/2/, planets/3/",
					Starships = "starships/2/, starships/3/, starships/5/",
					Vehicles =  "vechicles/4/, vehicles/6/, vehicles/7/",
					Species = "spices/1/, spices/2/, spices/3/, spices/4/",
					Created = "2014-12-10T14:23:31.880000Z", Edited = "2014-12-20T19:49:45.256000Z",
					Url = "http://swapi.dev/api/films/2/",
					Rating=Rating.Five
				},
				new Movie {
					 MovieId = 3, Title = "Return of the Jedi", EpisodeId = 6,
					OpeningCrawl = "Luke Skywalker has returned....", Director = "Irvin Kershner",
					Producer = "Gary Kurtz, Rick McCallum", ReleaseDate ="1980-05-17",
					Characters = "people/1/, people/2/, people/3/, people/4/",
					Planets = "planets/1/, planets/2/, planets/3/",
					Starships = "starships/2/, starships/3/, starships/5/",
					Vehicles =  "vehicles/4/, vehicles/6/, vehicles/7/",
					Species = "spices/1/, spices/2/, spices/3/, spices/4/",
					Created = "2014-12-10T14:23:31.880000Z", Edited = "2014-12-20T19:49:45.256000Z",
					Url = "http://swapi.dev/api/films/3/",
					Rating=Rating.Eight
				}
			};
		}

		//public IEnumerable<Movie> GetAll()
		//{
		//	//LINQ query
		//	return from m in movies
		//		   orderby m.Title
		//		   select m;

		//	//Extension methods
		//	//return movies.OrderBy(m => m.Title); 
		//}

		public IEnumerable<Movie> GetMovieByName(string name)
		{
			return from m in movies
				   where string.IsNullOrEmpty(name) || m.Title.Contains(name)
				   orderby m.Title
				   select m;

			//return movies.OrderBy(mi => mi.Title).Where(m => m.Title.StartsWith(name) || string.IsNullOrEmpty(name));
		}
		public Movie GetById(int id)
		{
			return movies.SingleOrDefault(m => m.MovieId == id);
		}

		public Movie Delete(int id)
		{
			var movie = movies.FirstOrDefault(m => m.MovieId == id);
			if (movie != null)
			{
				movies.Remove(movie);
			}
			return movie;
		}
		public Movie Add(Movie newMovie)
		{
			movies.Add(newMovie);
			newMovie.MovieId = movies.Max(m => m.MovieId) + 1;
			return newMovie;

		}

		public Movie Update(Movie updatedMovie)
		{
			var movie = movies.SingleOrDefault(m => m.MovieId == updatedMovie.MovieId);
			if (movie != null)
			{
				movie.Title = updatedMovie.Title;
				movie.Characters = updatedMovie.Characters;
				movie.Director = updatedMovie.Director;
				movie.EpisodeId = updatedMovie.EpisodeId;
				movie.OpeningCrawl = updatedMovie.OpeningCrawl;
				movie.Planets = updatedMovie.Planets;
				movie.ReleaseDate = updatedMovie.ReleaseDate;
				movie.Species = updatedMovie.Species;
				movie.Starships = updatedMovie.Starships;
				movie.Vehicles = updatedMovie.Vehicles;
				movie.Url = updatedMovie.Url;
				movie.Rating = updatedMovie.Rating;
				movie.Edited = updatedMovie.Edited;
				movie.Created = updatedMovie.Created;
			}
			return movie;
		}

		public int Commit()
		{
			return 0;
		}

		public int GetCountOfMovies()
		{
			return movies.Count();
		}
	}
}
