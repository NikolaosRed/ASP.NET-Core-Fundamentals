using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Fundamentals.Core
{
	public class Movie
	{
		public int MovieId { get; set; }
		[Required, StringLength(100)]
		public string Title { get; set; }
		[Required, Range(1, 50)]
		public int EpisodeId { get; set; }

		public string OpeningCrawl { get; set; }

		public string Director { get; set; }

		public string Producer { get; set; }

		public string ReleaseDate { get; set; }

		public string Characters { get; set; }

		public string Planets { get; set; }

		public string Starships { get; set; }

		public string Vehicles { get; set; }

		public string Species { get; set; }
		public string Created { get; set; }
		public string Edited { get; set; }
		public string Url { get; set; }

		public Rating Rating { get; set; }
	}
}
