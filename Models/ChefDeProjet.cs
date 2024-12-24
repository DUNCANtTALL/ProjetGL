namespace ProjetGL.Models
{
    public class ChefDeProjet:User
    {
        private string name;
        private string email;
        private string password;


        public ChefDeProjet(string email, string password, string name)
        {
            this.email = email;
            this.password = password;
            name = "Chef de Projet ";
        }

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
    }
}
