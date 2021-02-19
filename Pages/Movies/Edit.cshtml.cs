using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fundamentals.Core;
using Fundamentals.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASP.NET_Core_Fundamentals.Pages.Movies
{
    public class EditModel : PageModel
    {
		private readonly IMovieData movieData;
		private readonly IHtmlHelper htmlHelper;
		[BindProperty]
		public Movie Movie { get; set; }
		public IEnumerable<SelectListItem> Ratings { get; set; }

		public EditModel(IMovieData movieData, IHtmlHelper htmlHelper)
		{
			this.movieData = movieData;
			this.htmlHelper = htmlHelper;
		}
		public IActionResult OnGet(int? movieId)
		{
			Ratings = htmlHelper.GetEnumSelectList<Rating>();
			if (movieId.HasValue)
			{
				Movie = movieData.GetById(movieId.Value);
			}
			else
			{
				Movie = new Movie();
			}
			if (Movie == null)
			{
				return RedirectToPage("./NotFound");
			}
			return Page();
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				Ratings = htmlHelper.GetEnumSelectList<Rating>();
				return Page();
			}
			if (Movie.MovieId > 0)
			{
				movieData.Update(Movie);
			}
			else
			{
				movieData.Add(Movie);
			}
			movieData.Commit();
			TempData["Message"] = "Movie saved: " + Movie.Title;
			return RedirectToPage("./Detail", new { movieId = Movie.MovieId });
		}
	}
}
