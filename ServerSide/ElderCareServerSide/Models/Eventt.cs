namespace ElderCareServerSide.Models
{
    public class Eventt
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public DateTime Date { get; set; }
        public int AssociationId { get; set; }
        public string HelipingAssociations { get; set; }
        public int Participants { get; set; }


        public static List<Eventt> ReadAll()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadEvents();
        }

        public int Insert()
        {
            DBservices dbs = new DBservices();
            return dbs.InsertEvent(this);
        }
    }
}
