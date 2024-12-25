namespace ProjetGL.Buisness
{
    public static class ServicesPages
    {
        public static GestionUsers manager; //un service

        static ServicesPages()
        {
            manager = new GestionUsers(); //on instancie le service
            //manager = new AccountManagerBD(); //on instancie le service
        }
    }
}
