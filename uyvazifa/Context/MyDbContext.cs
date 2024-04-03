using Microsoft.EntityFrameworkCore;
using uyvazifa.Model;

namespace uyvazifa.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public MyDbContext() { }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = localhost; database = Training; TrustServerCertificate=True; Integrated Security = true");
        }
    }
}