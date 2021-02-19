using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fundamentals.Core;
using Fundamentals.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP.NET_Core_Fundamentals.Pages.Movies
{
    public class DeleteModel : PageModel
    {
		private readonly IMovieData movieData;
		public Movie Movie { get; set; }

		public DeleteModel(IMovieData movieData)
		{
			this.movieData = movieData;
		}
		public IActionResult OnGet(int movieId)
		{
			Movie = movieData.GetById(movieId);
			if (Movie == null)
			{
				return RedirectToPage("./NotFound");
			}
			return Page();
		}

		public IActionResult OnPost(int movieId)
		{
			var movie = movieData.Delete(movieId);
			movieData.Commit();

			if (movie == null)
			{
				return RedirectToPage("./NotFound");
			}
			TempData["Message"] = $"{movie.Title} deleted";
			return RedirectToPage("./List");
		}
	}
}
