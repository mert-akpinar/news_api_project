using bitirme_projesi.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace bitirme_projesi.DataAccessLayer.Context
{
	public class NewsContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=DESKTOP-R9DVO40;initial catalog=BitirmeProjesiDB; integrated Security=true");			
		}
		public DbSet<News> Newss { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<Author> Authors { get; set; }
	}
}
