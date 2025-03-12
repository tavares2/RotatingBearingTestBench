using System.ComponentModel.DataAnnotations;

namespace RotatingBearingAPI.Models
{
    public class TestStep
    {
        [Key]
        public int Id { get; set; }

        public int StepNumber { get; set; }

        [Required]
        public double Setpoint { get; set; }

        [Required]
        public int Duration { get; set; }

        public int TestSequenceId { get; set; }
        public TestSequence TestSequence { get; set; }
    }
}
