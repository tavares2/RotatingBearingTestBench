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


            // Seed TestSequences
            modelBuilder.Entity<TestSequence>().HasData(
                new TestSequence
                {
                    Id = 1,
                    Name = "Test Sequence 1"
                },
                new TestSequence
                {
                    Id = 2,
                    Name = "Test Sequence 2"
                }
            );

            // Seed TestSteps for the Test Sequences
            modelBuilder.Entity<TestStep>().HasData(
                new TestStep
                {
                    Id = 1,
                    StepNumber = 1,
                    Setpoint = 500,
                    Duration = 10, // In seconds
                    TestSequenceId = 1
                },
                new TestStep
                {
                    Id = 2,
                    StepNumber = 2,
                    Setpoint = 1000,
                    Duration = 15, // In seconds
                    TestSequenceId = 1
                },
                new TestStep
                {
                    Id = 3,
                    StepNumber = 1,
                    Setpoint = 800,
                    Duration = 12, // In seconds
                    TestSequenceId = 2
                }
            );

            // Seed TestResults for the Test Sequences
            modelBuilder.Entity<TestResult>().HasData(
                new TestResult
                {
                    Id = 1,
                    TestSequenceId = 1,
                    RotationSpeed = 1500,
                    StressLevel = 8.5,
                    Temperature = 60.0,
                    Timestamp = new DateTime(2025, 3, 12, 10, 30, 0)
                },
                new TestResult
                {
                    Id = 2,
                    TestSequenceId = 2,
                    RotationSpeed = 1200,
                    StressLevel = 6.7,
                    Temperature = 55.3,
                    Timestamp = new DateTime(2025, 3, 12, 10, 40, 0)
                }
            );
        }



    }
}
