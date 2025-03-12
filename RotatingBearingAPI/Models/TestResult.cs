using System.ComponentModel.DataAnnotations;

namespace RotatingBearingAPI.Models
{
    public class TestResult
    {
        [Key]
        public int Id { get; set; }

        public DateTime Timestamp { get; set; }

        [Required]
        public double RotationSpeed { get; set; }

        [Required]
        public double StressLevel { get; set; }

        [Required]
        public double Temperature { get; set; }

        public int TestSequenceId { get; set; }
        public TestSequence TestSequence { get; set; }
    }
}
