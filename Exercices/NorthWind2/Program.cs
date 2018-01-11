using NorthWind2.Pages;
using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind2
{
    class Program
    {
        static void Main(string[] args)
        {
            var Appli = Northwind2App.Instance;
            Appli.Title = "MON application à moi !!!!";


            PageAccueil MonAccueil = new PageAccueil();
             
            Appli.AddPage(MonAccueil);
            Appli.AddPage(new PageFournisseur("MonFournisseur"));
            Appli.AddPage(new PageProduit("Liste des Produits"));
            Appli.NavigateTo(MonAccueil);

      

            

                    
           
        }
    }
}
