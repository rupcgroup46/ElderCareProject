namespace ElderCareServerSide.Models
{
    public class Association
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } //default null
        public string Password { get; set; } //default null
        public string HelpType { get; set; } //default null
        public string City { get; set; }
        public int TotalApps { get; set; } //default null
        public int HelpedApps { get; set; } //default null
        public double HelpingRatio { get; set; } //default null
    }
}
