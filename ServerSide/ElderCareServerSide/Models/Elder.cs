namespace ElderCareServerSide.Models
{
    public class Elder
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNum { get; set; }
        public string City { get; set; }
        public string RelativeName { get; set; }
        public string RelativeNum { get; set; }
        public string[] HelpTypes { get; set; }

    }
}
