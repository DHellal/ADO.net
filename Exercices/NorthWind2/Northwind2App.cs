using Outils.TConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind2
{
    public class Northwind2App : ConsoleApplication
    {
        private static Northwind2App _instance;
        private static IDataContexte _dataContexte;


        /// <summary>
        /// Obtient l'instance unique de l'application
        /// </summary>
        public static Northwind2App Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Northwind2App();

                return _instance;
            }
        }


        public static IDataContexte DataContexte
        {
            get
            {
                if (_dataContexte == null) _dataContexte = new Contexte3();     // maintenant on a juste a modifier ce contexte et on saura quel contexte ça va utiliser
                return _dataContexte;
            }

        }

        // Constructeur
        public Northwind2App()
        {
            // Définition des options de menu à ajouter dans tous les menus de pages
            MenuPage.DefaultOptions.Add(
               new Option("a", "Accueil", () => _instance.NavigateHome()));
        }
    }

}
