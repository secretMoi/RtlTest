using Microsoft.EntityFrameworkCore;
using Models.Models;

namespace MicroService.Data
{
	public class RtlContext : DbContext
	{
		public RtlContext(DbContextOptions<RtlContext> options) : base(options)
		{

		}

		// liste des tables
		public DbSet<Test> Tests { get; set; } // map entity framework avec nos modèles
	}
}
