using BDEfirst;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind2
{
    public class Contexte3 : DbContext, IDataContexte
    {

        public DbSet<Supplier> Supplier { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<MonProduit> MonProduit { get; set; }
        public DbSet<Customer> Client { get; set; }
        public DbSet<Order> Commande { get; set; }
        public DbSet<MaCategories> Category { get; set; }

        //private Northwind2Entities _contexte;

        public Contexte3() : base ("name=Exo1.Settings.Northwind2Connect")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


        public IList<MonProduit> GETProduitLocal()
        {

            MonProduit.Load();
            return MonProduit.Local.ToList();       // rien dans vue ? Oui car c'etait pas chargé

        }


        public IList<MaCategories> AfficheCategorie()
        {

            return Category.AsNoTracking().ToList();


        }

        public IList<Customer> AfficheClient()
        {



            return Client.AsNoTracking().ToList();



        }




        public IList<MonProduit> AfficheProduitCategorie(Guid idproduit)
        {
            return MonProduit.ToList();
        }

        public void AjouterProduitCategorie(MonProduit produitnouveau)
        {
            throw new NotImplementedException();
        }

        public MonProduit ChargeProduit(int saisie)
        {
            return MonProduit.Local.Where(p => p.ProductId == saisie).Single();
        }

        public int EnregistrerModifProduits()
        {
            throw new NotImplementedException();
        }

        public IList<Order> GetClientsCommandes(string IDclient)
        {

            return Commande.AsNoTracking().Include(c => c.Customer).Where(c => c.Customer.CustomerId == IDclient).ToList();
        }

       // public IList<Order> GetClientsCommandesEfficace(string IDclient) 
        //{

        //    var listRegion = new List<Order>();

        //    // Obtient la liste des régions et de leurs teritoires associés
        //    // triés par id de région et de territoire


        //    var req = Commande.AsNoTracking().Include(c => c.Customer).Where(c => c.Customer.CustomerId == IDclient).OrderByDescending(c => c.CustomerId).ToList();

        //            foreach(var c in req)
        //            {

                



        //            }
                
            

        //    return listRegion;

        //}

        public IList<Supplier> GetFournisseurs(string payschoix)
        {
            return Supplier.Where(a => a.Address.Country == payschoix).ToList();
            
            
        }

        public int GetNbProduit(string payschoix)
        {
            var param = new SqlParameter
            {
                SqlDbType = SqlDbType.NVarChar,
                ParameterName = "@pays",
                Value = payschoix
            };


            return Database.SqlQuery<int>("select COUNT(*) from Product P inner join Supplier S on (S.SupplierId = P.SupplierId) inner join Address A on (A.AddressId = S.AddressId) where A.Country = @pays ", param).Single(); //.ExecuteSqlCommand("select COUNT(*) from Product P inner join Supplier S on (S.SupplierId = P.SupplierId) inner join Address A on (A.AddressId = S.AddressId) where A.Country = @pays ", param);

            

        }

        public int GetNbProduitFct(string payschoi)
        {
            throw new NotImplementedException();
        }

        public IList<string> GetPaysFournisseurs()
        {
           // _contexte = new Northwind2Entities();

            return Supplier.Select(s => s.Address.Country).ToList();
            
        }

        public void GérerErreurSql(SqlException e)
        {
            throw new NotImplementedException();
        }

        public bool ModifierAjoutProduit(MonProduit produitnouveau)
        {
            if(produitnouveau.modif == false)
            {
                MonProduit.Add(produitnouveau);
                return true;


            }
            else if(produitnouveau.modif == true)
            {
                MonProduit produuit1 = new MonProduit();
                    
                produuit1 = MonProduit.Find(produitnouveau.ProductId);

                produitnouveau.ProductId = produuit1.ProductId;
                //etc


                return true;

            }




            return false;




        }

        public bool SupprimeProduit(int saisie)
        {
            throw new NotImplementedException();
        }


        public void EnregistrerModifsProduits() {

            try { SaveChanges(); }

            catch(Exception)
            {

                Console.WriteLine("Faux!");
            }
        }


    }
}
