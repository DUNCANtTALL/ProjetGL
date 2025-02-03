﻿namespace ProjetGL.Buisness
{
    public static class ServicesPages
    {
        public static GestionUsers managerUsers; //un service
        public static GestionMessages managerMessages; 
        public static GestionBesoin gestionBesoin;
        public static GestionAppeleDoffre gestionAppeleDoffre;
        public static GestionCommande gestionCommande;
        public static GestionFournisseur gestionFournisseur;
        public static GestionLivraison gestionLivraison;
        public static GestionAffectation gestionAffectation;
        public static GestionPanne gestionPanne;
        public static GestionConstat gestionConstat;
        public static GestionListeNoir gestionListeNoir;

        static ServicesPages()
        {
            managerUsers = new GestionUsers();
            managerMessages = new GestionMessages();
            gestionBesoin = new GestionBesoin();
            gestionAppeleDoffre = new GestionAppeleDoffre();
            gestionCommande = new GestionCommande();
            gestionFournisseur = new GestionFournisseur();
            gestionLivraison = new GestionLivraison();
            gestionAffectation = new GestionAffectation(); 
            gestionPanne = new GestionPanne();
            gestionConstat = new GestionConstat();
            gestionListeNoir = new GestionListeNoir();


        }
    }
}
