namespace ElderCareServerSide.Models
{
    public class Elder //נוצר פעם אחת עבור כל קשיש
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNum { get; set; }
        public string City { get; set; }
        public string RelativeName { get; set; } //null if left clear
        public string RelativeNum { get; set; } //null if left clear
        public string HelpTypes { get; set; }

        public int Insert()
        {
            DBservices dbs = new DBservices();
            return dbs.InsertElder(this);
        }

        public static List<Elder>Read()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadElders();
        }
    }
}
