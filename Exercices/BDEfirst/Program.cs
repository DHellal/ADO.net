using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDEfirst
{
    class Program
    {
        static void Main(string[] args)
        {

            Northwind2Entities model1 = new Northwind2Entities();

            //  model1.Supplier.Add() 

            // model1.savechange() -> sauvegarde

            model1.Database.ExecuteSqlCommand("Select * from Supplier"); // pour exe sql commande
        }
    }
}
