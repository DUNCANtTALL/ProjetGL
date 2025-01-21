namespace ProjetGL.Buisness
{
    public static class ServicesPages
    {
        public static GestionUsers managerUsers; //un service
        public static GestionMessages managerMessages; 
        public static GestionBesoin gestionBesoin;
        public static GestionAppeleDoffre gestionAppeleDoffre;
        public static GestionCommande gestionCommande;
        public static GestionFournisseur gestionFournisseur;

        static ServicesPages()
        {
            managerUsers = new GestionUsers();
            managerMessages = new GestionMessages();
            gestionBesoin = new GestionBesoin();
            gestionAppeleDoffre = new GestionAppeleDoffre();
            gestionCommande = new GestionCommande();
            gestionFournisseur = new GestionFournisseur();

        }
    }
}
