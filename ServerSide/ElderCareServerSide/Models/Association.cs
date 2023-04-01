namespace ElderCareServerSide.Models
{
    public class Association
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } //default association's name
        public string Password { get; set; } //default association's name
        public string HelpType { get; set; }
        public string City { get; set; }
        public int TotalApps { get; set; } //default null
        public int HelpedApps { get; set; } //default null
        public double HelpingRatio { get; set; } //default null

        public static List<Association> ReadAll()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadAssociations();
        }

        public static List<Association> ReadByParameters(string helpType, string city)
        {
            DBservices dbs = new DBservices();
            return dbs.ReadAssociationsByParameters(helpType, city);
        }

        public static List<string> ReadCities()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadAllCities();
        }
    }
}
