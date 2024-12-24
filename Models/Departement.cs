namespace ProjetGL.Models
{
    public class Departement:User
    {
        private string name; 
        private string email;
        private string password;


        public Departement(string email, string password, string name)
        {
            this.email = email;
            this.password = password;
            this.Name = name;
        }

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
    }
}
