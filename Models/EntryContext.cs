using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EntryLogManagement.Models
{
    public class EntryContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<EntryLog> EntryLogs { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<AbsentReport> AbsentReports {set;get;}
        public DbSet<Alert> Alerts {get;set;}
       
        // Avoid hardcoding connection string
        private readonly string connectionString;

        public EntryContext()
        {
            // Example: Load connection string from configuration
            // this.connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            this.connectionString = "Data Source=DESKTOP-Q51CKKR\\SQLEXPRESS01;Initial Catalog=EntryLogManagement;Integrated Security=True;Trust Server Certificate=True";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            ILoggerFactory loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            optionsBuilder.UseSqlServer(connectionString)    // Connect to SQL Server
                         .UseLoggerFactory(loggerFactory)       // Configure logging
                         .UseLazyLoadingProxies();              // Enable lazy loading proxies
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

                 modelBuilder.Entity<AbsentReport>()
                .HasOne(ar => ar.Parent)
                .WithMany()
                .HasForeignKey(ar => ar.ParentId)
                .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction

            modelBuilder.Entity<AbsentReport>()
                .HasOne(ar => ar.Student)
                .WithMany()
                .HasForeignKey(ar => ar.StudentId)
                .OnDelete(DeleteBehavior.Restrict); //
        }
    }
}
