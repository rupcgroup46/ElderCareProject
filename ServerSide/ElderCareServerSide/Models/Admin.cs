namespace ElderCareServerSide.Models
{
    public class Admin
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static Admin Login(string email, string password)
        {
            List<Admin> admins = new List<Admin>();
            DBservices dbs = new DBservices();
            admins = dbs.ReadAdmin();
            foreach (var admin in admins)
            {
                if (admin.Email == email && admin.Password == password)
                    return admin;
            }
            return null;
        }
    }
}
