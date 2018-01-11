
using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NorthWind2.Pages
{
    internal class PageProduit : MenuPage
    {
        public PageProduit(string title, bool addDefaultOptions = true) : base(title, addDefaultOptions)
        {

            Menu.AddOption("1", "Liste des produits", () => AfficherProduits());

            Menu.AddOption("2", "Creer un nouveau produit", () => CreationProduit());

            Menu.AddOption("3", "Modifier un produit", () => ModifierProduit());

            Menu.AddOption("4", "Supprimer un produit", () => SpprimerProduit());

            Menu.AddOption("5", "Creer produit sans categorie", () => CreerProduitSansCategorie());

            Menu.AddOption("6", "Produits en local", () => ProduitEnLocal());

            Menu.AddOption("7", "Entregistre modifs", () => Northwind2App.DataContexte.EnregistrerModifsProduits());



        }


        private void ProduitEnLocal()
        {



            ConsoleTable.From(Northwind2App.DataContexte.GETProduitLocal(), "nbr").Display("Nombre de produit en local");

        }







        private void CreerProduitSansCategorie()
        {
            MonProduit p1 = new MonProduit();

            p1.Name = Input.Read<string>("Saisir un nom :");

            p1.SupplierId = Input.Read<int>("Saisir nombre ID de fournisseur : ");

            p1.UnitPrice = Input.Read<decimal>("Saisir prix unitaire : ");

           // p1.UnitsInStock = Input.Read<int>("Saisir le nombre en stock : ");

            Northwind2App.DataContexte.AjouterProduitCategorie(p1);

        }

        private void SpprimerProduit()
        {
            AfficherProduits();
            int saisie = Input.Read<int>("Saisir un ID de produit à supprimer");

            if(Northwind2App.DataContexte.SupprimeProduit(saisie))
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("C'est supprimé !!");
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erreur !!");
                Console.ForegroundColor = ConsoleColor.White;


            }
           

        }

        private void ModifierProduit()
        {
            Guid idcate =  AfficherProduits();

            int saisie = Input.Read<int>("Saisir un ID de produit à modifier");

            MonProduit pamodif = Northwind2App.DataContexte.ChargeProduit(saisie);

            MonProduit produitnouveau = new MonProduit();

            produitnouveau.ProductId = pamodif.ProductId;

            produitnouveau.CategoryId = Input.Read<Guid>("Saisir un ID de categories :", pamodif.CategoryId );

            produitnouveau.Name = Input.Read<string>("Saisir un nom :", pamodif.Name);

            produitnouveau.SupplierId = Input.Read<int>("Saisir nombre ID de fournisseur : ", pamodif.SupplierId);

            produitnouveau.UnitPrice = Input.Read<decimal>("Saisir prix unitaire : ", pamodif.UnitPrice);       

           // int stock = Input.Read<int>("Saisir le nombre en stock : ", pamodif.UnitsInStock);

            produitnouveau.modif = true;



            if (Northwind2App.DataContexte.ModifierAjoutProduit(produitnouveau))
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("C'est modifié !!");
                Console.ForegroundColor = ConsoleColor.White;

            }



        }


        private void CreationProduit()
        {
            IList<MaCategories> rows = new List<MaCategories>();

            rows = Northwind2App.DataContexte.AfficheCategorie();

            ConsoleTable.From(rows).Display("Liste des categories");



            MonProduit produitnouveau = new MonProduit();

            produitnouveau.CategoryId = Input.Read<Guid>("Saisir un ID de categories :");

            produitnouveau.Name = Input.Read<string>("Saisir un nom :");

            produitnouveau.SupplierId = Input.Read<int>("Saisir nombre ID de fournisseur : ");

            produitnouveau.UnitPrice = Input.Read<decimal>("Saisir prix unitaire : ");

            


            //produitnouveau = Input.Read<int>("Saisir le nombre en stock : ");

            produitnouveau.modif = false;
            
            

            if (Northwind2App.DataContexte.ModifierAjoutProduit(produitnouveau)) {


                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Nouveau produit fait !!! ");
                Console.ForegroundColor = ConsoleColor.White;

            }

            else Console.WriteLine("probleme");



        }


        

        private Guid AfficherProduits()
        {
            IList<MaCategories> rows = new List<MaCategories>();

            rows = Northwind2App.DataContexte.AfficheCategorie();

            ConsoleTable.From(rows).Display("Liste des categories");


            Guid saisie = Input.Read<Guid>("Saisir un ID de categories");


            IList<MonProduit> prod = new List<MonProduit>();

            prod = Northwind2App.DataContexte.AfficheProduitCategorie(saisie);

            ConsoleTable.From(prod).Display("Liste des produits");
            return saisie;

        }
    }
}