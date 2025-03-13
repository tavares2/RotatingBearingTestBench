using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RotatingBearingAPI.Models
{
    public class TestSequence
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TestStep> Steps { get; set; } 
    }
}
