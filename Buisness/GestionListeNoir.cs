using ProjetGL.Data;
using ProjetGL.Models;

namespace ProjetGL.Buisness
{
    public class GestionListeNoir
    {
        IDataListNoir data = new DataListeNoir();

        public void AjouterListeNoir(User user , string raison)
        {
            data.AddUser(user,raison);
        }
        public bool VerifierListeNoir(int userID)
        {
            return data.CheckUser(userID);
        }
    }
}
