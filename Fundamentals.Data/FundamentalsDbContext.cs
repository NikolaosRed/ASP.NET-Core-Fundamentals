using Fundamentals.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fundamentals.Data
{
	public class FundamentalsDbContext : DbContext
	{
		public DbSet<Movie> Movies { get; set; }
		public FundamentalsDbContext(DbContextOptions<FundamentalsDbContext> options) : base(options)
		{

		}

	}
}
