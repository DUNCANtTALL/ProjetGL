namespace ProjetGL.Buisness
{
    public static class ServicesPages
    {
        public static GestionUsers managerUsers; //un service
        public static GestionMessages managerMessages; 
        public static GestionBesoin gestionBesoin;

        static ServicesPages()
        {
            managerUsers = new GestionUsers();
            managerMessages = new GestionMessages();
            gestionBesoin = new GestionBesoin();

        }
    }
}
