using System.ComponentModel.DataAnnotations;

namespace RotatingBearingAPI.Models
{
    public class TestSequence
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public List<TestStep> Steps { get; set; } = new List<TestStep>();
    }
}
