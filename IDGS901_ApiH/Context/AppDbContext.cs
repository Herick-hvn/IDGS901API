using IDGS901_ApiH.Models;
using Microsoft.EntityFrameworkCore;

namespace IDGS901_ApiH.Context
{
    public class AppDbContext : DbContext
    {
        private const string conectionstring = "conexion";

        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base (options)
        { }
        public DbSet<Alumnos> Alumnos { get; set; }

    }
}
