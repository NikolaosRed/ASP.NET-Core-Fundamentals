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
    public class DetailModel : PageModel
    {
		private readonly IMovieData movieData;
		[TempData]
		public string Message { get; set; }

		public DetailModel(IMovieData movieData)
		{
			this.movieData = movieData;
		}
		public Movie Movie { get; set; }
		public IActionResult OnGet(int movieId)
		{
			Movie = movieData.GetById(movieId);
			if (Movie == null)
			{
				return RedirectToPage("./NotFound");
			}
			return Page();
		}
	}
}
