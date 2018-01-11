using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind2.Pages
{
    public class PageAccueil : MenuPage
    {
        public PageAccueil( bool addDefaultOptions = false) : base("Accueil", addDefaultOptions)        // ici on mets faux, car pas besoin d'ajouter les menu par default (qui sont qu'on peut revenir a la page d'accueil)
        {
            Menu.AddOption("0", "Sortir", () => Environment.Exit(0));

            Menu.AddOption("1", "Fournisseurs", () => Northwind2App.Instance.NavigateTo(typeof(PageFournisseur)));

            Menu.AddOption("2", "Produits", () => Northwind2App.Instance.NavigateTo(typeof(PageProduit)));



        }
    }
}
