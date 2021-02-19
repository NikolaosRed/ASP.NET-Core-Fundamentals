using Fundamentals.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Core_Fundamentals.ViewComponents
{
	public class MovieCountViewComponent :ViewComponent
	{
		private readonly IMovieData movieData;

		public MovieCountViewComponent(IMovieData movieData)
		{
			this.movieData = movieData;
		}

		public IViewComponentResult Invoke()
		{
			var count = movieData.GetCountOfMovies();
			return View(count);
		}
	}
}
