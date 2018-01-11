using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind2
{
    public class Contexte1 : IDataContexte
    {

        #region Exo 1.2
        public  IList<string> GetPaysFournisseurs()
        {

            List<string> MaListe = new List<string>();

            var cmd = new SqlCommand();
            cmd.CommandText = "select distinct Country from Supplier S inner join Address A on (A.AddressId = S.AddressId) ";

            using (var bdd = new SqlConnection(Settings.Default.Northwind2Connect))
            {

                cmd.Connection = bdd;

                bdd.Open();
                using (SqlDataReader lis = cmd.ExecuteReader())
                {
                    while (lis.Read())
                    {
                        MaListe.Add((string)lis["Country"]);

                    }

                }


                return MaListe;

            }


        }

        public  IList<Entites> GetClientsCommandes(string IDclient)
        {
            List<Entites> MaListe = new List<Entites>();

            var cmd = new SqlCommand();
            cmd.CommandText = @"

select C.ContactName, C.CustomerId, O.OrderDate, O.OrderId, O.ShippedDate
from Customer C
left outer join Orders O on (O.CustomerId = C.CustomerId)
where C.CustomerId = @idcleint
 ";

            var param = new SqlParameter
            {
                SqlDbType = SqlDbType.NVarChar,
                ParameterName = "@idcleint",
                Value = IDclient

            };
            // Ajout à la collection des paramètres de la commande
            cmd.Parameters.Add(param);


            using (var bdd = new SqlConnection(Settings.Default.Northwind2Connect))
            {

                cmd.Connection = bdd;

                bdd.Open();

                using (var lis1 = cmd.ExecuteReader())
                {
                    while (lis1.Read())
                    {
                        Entites intermediaire = new Entites();


                        intermediaire.ContactName = (string)lis1["ContactName"];
                        intermediaire.OrderId = (int)lis1["OrderId"];
                        intermediaire.CustomerId = (string)lis1["CustomerId"];
                        intermediaire.OrderDate = (DateTime)lis1["OrderDate"];
                        intermediaire.ShippedDate = lis1["ShippedDate"].ToString();


                        MaListe.Add(intermediaire);


                    }

                }

                return MaListe;


            }
        }

        public  int GetNbProduitFct(string payschoi)
        {
            int MaListe = 0;

            var cmd = new SqlCommand();
            cmd.CommandText = @"

select dbo.ufn_GetProduit (@pays)
 ";

            var param = new SqlParameter
            {
                SqlDbType = SqlDbType.NVarChar,
                ParameterName = "@pays",
                Value = payschoi
            };
            // Ajout à la collection des paramètres de la commande
            cmd.Parameters.Add(param);


            using (var bdd = new SqlConnection(Settings.Default.Northwind2Connect))
            {

                cmd.Connection = bdd;

                bdd.Open();

                MaListe = (int)cmd.ExecuteScalar();     // retourne 0



                return MaListe;

            }
        }

        public  IList<Supplier> GetFournisseurs(string payschoix)
        {

            List<Supplier> MaListe = new List<Supplier>();

            var cmd = new SqlCommand();
            cmd.CommandText = @"

select distinct CompanyName, SupplierId
from Supplier S
inner join Address A on (A.AddressId = S.AddressId)
where A.Country = @pays
 ";

            var param = new SqlParameter
            {
                SqlDbType = SqlDbType.NVarChar,
                ParameterName = "@pays",
                Value = payschoix
            };
            // Ajout à la collection des paramètres de la commande
            cmd.Parameters.Add(param);


            using (var bdd = new SqlConnection(Settings.Default.Northwind2Connect))
            {

                cmd.Connection = bdd;

                bdd.Open();

                using (var lis1 = cmd.ExecuteReader())
                {
                    while (lis1.Read())
                    {
                        Supplier intermediaire = new Supplier();

                        intermediaire.CompanyName = (string)lis1["CompanyName"];
                        intermediaire.SupplierId = (int)lis1["SupplierId"];

                        MaListe.Add(intermediaire);


                    }

                }


                return MaListe;

            }


        }

        public  int GetNbProduit(string payschoix)
        {

            int MaListe = 0;

            var cmd = new SqlCommand();
            cmd.CommandText = @"

select COUNT(*)
from Product P
inner join Supplier S on (S.SupplierId = P.SupplierId)
inner join Address A on (A.AddressId = S.AddressId) 
where A.Country = @pays                                                         
 ";                                                                         // ne pas mettre des guillemnt autour du @

            var param = new SqlParameter
            {
                SqlDbType = SqlDbType.NVarChar,
                ParameterName = "@pays",
                Value = payschoix
            };
            // Ajout à la collection des paramètres de la commande
            cmd.Parameters.Add(param);


            using (var bdd = new SqlConnection(Settings.Default.Northwind2Connect))
            {

                cmd.Connection = bdd;

                bdd.Open();

                MaListe = (int)cmd.ExecuteScalar();     // retourne 0

            }

            return MaListe;
        }

        #endregion


        public  MonProduit ChargeProduit(int saisie)
        {
            MonProduit Monproduit1 = new MonProduit();



            var cmd = new SqlCommand();
            cmd.CommandText = @"


select P.ProductId, p.Name, p.UnitPrice, p.UnitsInStock, SupplierId, CategoryId
from Product P
where P.ProductId = @id
 ";

            var param = new SqlParameter
            {
                SqlDbType = SqlDbType.NVarChar,
                ParameterName = "@id",
                Value = saisie
            };
            // Ajout à la collection des paramètres de la commande
            cmd.Parameters.Add(param);



            using (var bdd = new SqlConnection(Settings.Default.Northwind2Connect))
            {

                cmd.Connection = bdd;

                bdd.Open();

                using (var lis1 = cmd.ExecuteReader())
                {
                    while (lis1.Read())
                    {
                        
                        Monproduit1.ProductId = (int)lis1["ProductId"];
                        Monproduit1.Name = (string)lis1["Name"];
                        Monproduit1.UnitPrice = (decimal)lis1["UnitPrice"];
                        Monproduit1.UnitsInStock = (int)lis1["UnitsInStock"];
                        Monproduit1.SupplierId = (int)lis1["SupplierId"];
                        Monproduit1.CategoryId = (Guid)lis1["CategoryId"];





                    }

                }


                return Monproduit1;
            }
        }

        public   IList<MaCategories> AfficheCategorie()
        {
            List<MaCategories> MaListe = new List<MaCategories>();



            var cmd = new SqlCommand();
            cmd.CommandText = @"

select C.CategoryId, C.Name, C.Description
from Category C
 ";


            using (var bdd = new SqlConnection(Settings.Default.Northwind2Connect))
            {

                cmd.Connection = bdd;

                bdd.Open();

                using (var lis1 = cmd.ExecuteReader())
                {
                    while (lis1.Read())
                    {
                        MaCategories intermediaire = new MaCategories();

                        intermediaire.CategoryId = (Guid)lis1["CategoryId"];       // sinon type guid
                        intermediaire.Name = (string)lis1["Name"];
                        intermediaire.Description = (string)lis1["Description"];


                        MaListe.Add(intermediaire);


                    }

                }

                

                return MaListe;
            }



        }
        
        public   IList<MonProduit> AfficheProduitCategorie(Guid idproduit)
        {
            List<MonProduit> MaListe = new List<MonProduit>();



            var cmd = new SqlCommand();
            cmd.CommandText = @"


select P.ProductId, p.Name, p.UnitPrice, p.UnitsInStock 
from Product P
inner join Category C on (C.CategoryId = P.CategoryId)
where C.CategoryId = @id
 ";

            var param = new SqlParameter
            {
                SqlDbType = SqlDbType.UniqueIdentifier,
                ParameterName = "@id",
                Value = idproduit
            };
            // Ajout à la collection des paramètres de la commande
            cmd.Parameters.Add(param);



            using (var bdd = new SqlConnection(Settings.Default.Northwind2Connect))
            {

                cmd.Connection = bdd;

                bdd.Open();

                using (var lis1 = cmd.ExecuteReader())
                {
                    while (lis1.Read())
                    {
                        MonProduit intermediaire = new MonProduit();
                        intermediaire.ProductId = (int)lis1["ProductId"];
                        intermediaire.Name = (string)lis1["Name"];
                        intermediaire.UnitPrice = (decimal)lis1["UnitPrice"];
                        intermediaire.UnitsInStock = (int)lis1["UnitsInStock"];

                        

                        MaListe.Add(intermediaire);


                    }

                }


                return MaListe;
            }

        }
      
        public   bool ModifierAjoutProduit(int? saisie, Guid idcate, string nom, int idfourni, decimal prixunit, int stock, bool choix)
        {
            if (choix)
            {
                var cmd = new SqlCommand();
                cmd.CommandText = @"
update Product set
CategoryId = @idcate ,
 Name = @nom, 
 SupplierId = @idfourni, 
 UnitPrice = @prixunit, 
 UnitsInStock = @stock 
 where ProductID = @idproduit
 ";


                var param0 = new SqlParameter
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@idproduit",
                    Value = saisie
                };

                var param1 = new SqlParameter
                {
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    ParameterName = "@idcate",
                    Value = idcate
                };

                var param2 = new SqlParameter
                {
                    SqlDbType = SqlDbType.NVarChar,
                    ParameterName = "@nom",
                    Value = nom
                };

                var param3 = new SqlParameter
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@idfourni",
                    Value = idfourni
                };

                var param4 = new SqlParameter
                {
                    SqlDbType = SqlDbType.Money,
                    ParameterName = "@prixunit",
                    Value = prixunit
                };

                var param5 = new SqlParameter
                {
                    SqlDbType = SqlDbType.SmallInt,
                    ParameterName = "@stock",
                    Value = stock
                };

                cmd.Parameters.Add(param0);
                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.Parameters.Add(param5);



                using (var bdd = new SqlConnection(Settings.Default.Northwind2Connect))
                {

                    cmd.Connection = bdd;

                    bdd.Open();

                    cmd.ExecuteNonQuery();


                    return true;
                }


            }       // modifier produit


            else
            {


                var cmd = new SqlCommand();
                cmd.CommandText = @"


insert Product (CategoryId, Name, SupplierId, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued)
values(@idcate,@nom,@idfourni,@prixunit,@stock,'0','0','0')
 ";

                var param1 = new SqlParameter
                {
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    ParameterName = "@idcate",
                    Value = idcate
                };

                var param2 = new SqlParameter
                {
                    SqlDbType = SqlDbType.NVarChar,
                    ParameterName = "@nom",
                    Value = nom
                };

                var param3 = new SqlParameter
                {
                    SqlDbType = SqlDbType.Int,
                    ParameterName = "@idfourni",
                    Value = idfourni
                };

                var param4 = new SqlParameter
                {
                    SqlDbType = SqlDbType.Money,
                    ParameterName = "@prixunit",
                    Value = prixunit
                };

                var param5 = new SqlParameter
                {
                    SqlDbType = SqlDbType.SmallInt,
                    ParameterName = "@stock",
                    Value = stock
                };

                cmd.Parameters.Add(param1);
                cmd.Parameters.Add(param2);
                cmd.Parameters.Add(param3);
                cmd.Parameters.Add(param4);
                cmd.Parameters.Add(param5);



                using (var bdd = new SqlConnection(Settings.Default.Northwind2Connect))
                {

                    cmd.Connection = bdd;

                    bdd.Open();

                    cmd.ExecuteNonQuery();


                    return true;
                }


            }        // ajoute produit
        }
      
        public   bool SupprimeProduit(int saisie)
        {
            var cmd = new SqlCommand();
            cmd.CommandText = @"

	 delete from Product where ProductId = @idproduit

 ";
//            begin try

//     delete from Product where ProductId = @idproduit
//end try
//begin catch
//if ERROR_NUMBER() = 547

//    select 1
//end catch

            var param0 = new SqlParameter
            {
                SqlDbType = SqlDbType.Int,
                ParameterName = "@idproduit",
                Value = saisie
            };

            cmd.Parameters.Add(param0);



            using (var bdd = new SqlConnection(Settings.Default.Northwind2Connect))
            {

                cmd.Connection = bdd;

                bdd.Open();


                try
                {

                    cmd.ExecuteNonQuery();
                    return true;

                }
                catch(SqlException e)
                {

                    GérerErreurSql(e);
                    return false;

                }



                //int erreur = 0;
                //erreur = (int)cmd.ExecuteScalar();

                //if (erreur == 1) return false;
                
            }
        }
        
        public  void GérerErreurSql(SqlException e)
        {

            Console.WriteLine("Commande en cours pour ce produit");
        }
        
        public  void AjouterProduitCategorie(MonProduit produitnouveau)
        {

            var com1 = new SqlCommand();
            com1.CommandText = @"delete from OrderDetails where OrderId = @id";
            com1.Parameters.Add(new SqlParameter
            {
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id",
             //   Value = idCmde
            });

            var com2 = new SqlCommand();
            com2.CommandText = @"delete from Orders where OrderId = @id";
            com2.Parameters.Add(new SqlParameter
            {
                SqlDbType = SqlDbType.Int,
                ParameterName = "@id",
               // Value = idCmde
            });




        }

        public int EnregistrerModifProduits()
        {
            return 0;
        }

        IList<Order> IDataContexte.GetClientsCommandes(string IDclient)
        {
            throw new NotImplementedException();
        }

        public IList<Customer> AfficheClient()
        {
            throw new NotImplementedException();
        }

        public IList<MonProduit> GETProduitLocal()
        {
            throw new NotImplementedException();
        }
    }
}
