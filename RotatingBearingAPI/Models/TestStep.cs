using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey("TestSequenceId")]
        public int TestSequenceId { get; set; }

        public TestSequence? TestSequence { get; set; }
    }
}
