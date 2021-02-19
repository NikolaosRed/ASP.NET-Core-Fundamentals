using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fundamentals.Core;
using Fundamentals.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ASP.NET_Core_Fundamentals.Pages.Movies
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;
        private readonly IMovieData movieData;
		private readonly ILogger<ListModel> logger;

		public string Message { get; set; }
        public IEnumerable<Movie> Movies { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }


        public ListModel(IConfiguration config, IMovieData movieData, ILogger<ListModel> logger)
        {
            this.config = config;
            this.movieData = movieData;
			this.logger = logger;
		}

        public void OnGet(string searchTerm)
        {

            //Message = config["Message"];
            //Movies = movieData.GetAll();
            logger.LogInformation("Executing ListModel");
            Movies = movieData.GetMovieByName(searchTerm);
        }
    }
}
