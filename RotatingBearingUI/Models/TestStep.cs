namespace RotatingBearingUI.Models
{
    public class TestStep
    {
        public int Id { get; set; }
        public int StepNumber { get; set; }
        public double Setpoint { get; set; }
        public int Duration { get; set; }
        public int TestSequenceId { get; set; }
    }
}
