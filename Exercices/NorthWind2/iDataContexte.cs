using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind2
{
    public interface IDataContexte      // faut pas mettre de public dans les methodes ( c'est forcement public)
    {
        IList<string> GetPaysFournisseurs();        // i liste est plus general que juste liste et ainsi plus compatible, avec idictionnary ou d'autres liste

        IList<Order> GetClientsCommandes(string IDclient);

        int GetNbProduitFct(string payschoi);

        IList<Supplier> GetFournisseurs(string payschoix);

        int GetNbProduit(string payschoix);

        MonProduit ChargeProduit(int saisie);

        IList<MaCategories> AfficheCategorie();

        IList<MonProduit> AfficheProduitCategorie(Guid idproduit);

        bool ModifierAjoutProduit(MonProduit produitnouveau);

        int EnregistrerModifProduits();

        bool SupprimeProduit(int saisie);

        void GérerErreurSql(SqlException e);

        void AjouterProduitCategorie(MonProduit produitnouveau);

        IList<Customer> AfficheClient();

        IList<MonProduit> GETProduitLocal();
       // IList<Order> GetClientsCommandesEfficace(string IDclient);


        void EnregistrerModifsProduits();
    }
}
