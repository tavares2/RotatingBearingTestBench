namespace RotatingBearingUITest.Models
{
    public class TestResult
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public double RotationSpeed { get; set; }
        public double StressLevel { get; set; }
        public double Temperature { get; set; }
        public int TestSequenceId { get; set; }
    }
}
