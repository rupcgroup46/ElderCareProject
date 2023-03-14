namespace ElderCareServerSide.Models
{
    public class Application
    {
        public int ID { get; set; }
        public string Status { get; set; } //default null
        public string HelpType { get; set; }
        public string City { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime UpdateDate { get; set; } //default null
        public DateTime EndDate { get; set; } //default null
        public int ElderID { get; set; } //elder's info
        public int AssociationID { get; set; } //association's info
    }
}
