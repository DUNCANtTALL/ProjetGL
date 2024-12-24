namespace ProjetGL.Models
{
    public class ResponsableDesResources:User
    {
        private string name; 
        private string email;
        private string password;
        

        public ResponsableDesResources(string email, string password )
        {
            this.Email = email;
            this.Password = password;
            this.name = "Responsable Des Resources"; 
            
        }



        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }

    }
}
