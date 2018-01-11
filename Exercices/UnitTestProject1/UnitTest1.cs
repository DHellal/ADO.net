using NorthWind2;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace NorthWind2.Tests
{
    [TestClass()]
    public class TestDataContext      // a l'utilisateur de faire les autres methodes de cdlasses et assembly ( static !)
    {





        [TestMethod()]          // pour considerer comme methode de test
        public void GetPaysFournisseursTest()
        {
            Assert.AreEqual(16, Northwind2App.DataContexte.GetPaysFournisseurs().Count);
            Assert.AreEqual(Northwind2App.DataContexte.GetPaysFournisseurs().Count - 1, Northwind2App.DataContexte.GetPaysFournisseurs().IndexOf("USA"));
        }

        [TestMethod()]
        public void GetFournisseursTest()
        {
            
            foreach (Entites e in Northwind2App.DataContexte.GetFournisseurs("Japan"))
            {


                Assert.IsTrue(e.SupplierId == 4 | e.SupplierId == 6);

                

            }
        }



        [TestMethod()]
        public void GetNbProduitTest()
        {
            Assert.AreEqual(7, Northwind2App.DataContexte.GetNbProduit("UK"));
        }


        [TestMethod()]
        public void GetClientsCommandesTest()
        {
            //Assert.AreEqual(91, Contexte.GetClientsCommandes().Capacity);
        }




        [TestMethod()]
        public void AfficheCategorie()
        {
            Assert.AreEqual(8, Northwind2App.DataContexte.AfficheCategorie().Count);

            MaCategories liste = Northwind2App.DataContexte.AfficheCategorie()[Northwind2App.DataContexte.AfficheCategorie().Count -1];

            Assert.AreEqual("Seafood", liste.Name);
                

        }


        [TestMethod()]
        public void AfficheProduitCategorieTest()
        {


            foreach ( var c in Northwind2App.DataContexte.AfficheCategorie())
            {
                if (c.Name == "Seafood")
                {          
                    Assert.AreEqual(12, Northwind2App.DataContexte.AfficheProduitCategorie(c.CategoryId).Count);
                    Assert.AreEqual(40, Northwind2App.DataContexte.AfficheProduitCategorie(c.CategoryId)[6].ProductId);

                }
            }
            


        }


        [TestMethod()]
        public void ModifierAjoutProduitTest()
        {
            foreach (var c in Northwind2App.DataContexte.AfficheCategorie())
            {
                if (c.Description == "Cheeses")
                {
                    Northwind2App.DataContexte.ModifierAjoutProduit(null, c.CategoryId, "fromage", 2, 12, 3, false);

                    Assert.AreNotEqual(11, Northwind2App.DataContexte.AfficheProduitCategorie(c.CategoryId).Count);
                }

                
            }
            
        }

        [TestMethod()]
        public void SupprimeProduitTest()
        {
            foreach (var c in Northwind2App.DataContexte.AfficheCategorie())      // faire plutot une liste et stocke
            {
                if (c.Description == "Cheeses")
                {

                    foreach (var p in Northwind2App.DataContexte.AfficheProduitCategorie(c.CategoryId))
                    {

                        if(p.Name == "fromage") Northwind2App.DataContexte.SupprimeProduit(p.ProductId);

                        Assert.AreNotEqual(10, Northwind2App.DataContexte.AfficheProduitCategorie(c.CategoryId).Count);
                    }



                }
                
            }


        }

        public void ModifierAjoutProduit1()
        {
            Assert.AreEqual(7, Northwind2App.DataContexte.GetNbProduit("UK"));
        }

        public void ModifierAjoutProduit2()
        {
            Assert.AreEqual(7, Northwind2App.DataContexte.GetNbProduit("UK"));
        }
    }
}

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
