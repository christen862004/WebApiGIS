using Microsoft.EntityFrameworkCore;

namespace WebApiGIS.Models
{
    public class ITIContext :DbContext
    {
        public DbSet<Department> Department { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=GISWebApi;Integrated Security=True;Encrypt=False");
        }

    }
}
