using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind2.Pages
{
    public class PageFournisseur : MenuPage

    {
        

        public PageFournisseur(string title, bool addDefaultOptions = true) : base(title, addDefaultOptions)
        {

            Menu.AddOption("1", "ListePays", () => AffichePays() );

            Menu.AddOption("2", "Fournisseurs d'un pays ", () => AfficheFournisseurPays());

            Menu.AddOption("3", "NbrProduits", () => GetNbProduit());

            Menu.AddOption("4", "NbrProduitsFct", () => GetNbProduitFct());

            Menu.AddOption("5", "Commandes des clients", () => GetClientCommand());

            

        }

        private void GetClientCommand()
        {



            ConsoleTable.From(Northwind2App.DataContexte.AfficheClient(), "Cleint").Display("Clients");

            string clientchoisi = Input.Read<string>("Choix du ID client");


            IList<Order> rows = new List<Order>();

            rows = Northwind2App.DataContexte.GetClientsCommandes(clientchoisi);

            ConsoleTable.From(rows, "nbr").Display("Nombre de produit");
        }

        private void GetNbProduitFct()
        {
            string paysChoisi = Console.ReadLine();

            List<int> rows = new List<int>();

            rows.Add(Northwind2App.DataContexte.GetNbProduitFct(paysChoisi));

            ConsoleTable.From(rows, "nbr").Display("Nombre de produit");
        }

        private static void GetNbProduit()
        {
            string paysChoisi = Console.ReadLine();

            List<int> rows = new List<int>();

            rows.Add(Northwind2App.DataContexte.GetNbProduit(paysChoisi));

            ConsoleTable.From(rows, "nbr").Display("Nombre de produit");

            
        }

        public static void AffichePays()
        {

            IList<string> rows = new List<string>();

            rows = Northwind2App.DataContexte.GetPaysFournisseurs();

            ConsoleTable.From(rows, "NomPays").Display("Pays");

        }


        public static void AfficheFournisseurPays()
        {

            string paysChoisi = Console.ReadLine();

            IList<Supplier> rows = new List<Supplier>();

            rows = Northwind2App.DataContexte.GetFournisseurs(paysChoisi);

            ConsoleTable.From(rows).Display("Tableau pays");

        }            

    }
}
