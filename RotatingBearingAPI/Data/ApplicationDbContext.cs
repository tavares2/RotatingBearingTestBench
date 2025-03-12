using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using RotatingBearingAPI.Models;

namespace RotatingBearingAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
            // Define the tables in the database
            public DbSet<TestSequence> TestSequences { get; set; }
            public DbSet<TestStep> TestSteps { get; set; }
            public DbSet<TestResult> TestResults { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Set up relationships

            modelBuilder.Entity<TestStep>()
                .HasOne(ts => ts.TestSequence)
                .WithMany(s => s.Steps)
                .HasForeignKey(ts => ts.TestSequenceId);

            modelBuilder.Entity<TestResult>()
                .HasOne(tr => tr.TestSequence)
                .WithMany()
                .HasForeignKey(tr => tr.TestSequenceId);
        }



    }
}
