namespace ElderCareServerSide.Models
{
    public class Application //נוצרת במערכת ככמות סוגי הסיוע שנבחרו
    {
        public int ID { get; set; }
        public string Status { get; set; } //default null
        public string HelpType { get; set; }
        public string City { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime UpdateDate { get; set; } //default null
        public DateTime EndDate { get; set; } //default null
        public int ElderID { get; set; } //elder's info
        public int HandlingAssociationID { get; set; } //handling association's info -- Null until an association reaches out.
        public string SentAssociationsID { get; set; } //array of associations that the application was sent to

        public int Insert()
        {
            DBservices dbs = new DBservices();
            return dbs.InsertApplication(this);
        }
    }
}
