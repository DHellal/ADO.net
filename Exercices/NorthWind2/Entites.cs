using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#pragma warning disable CS0105 // La directive using est apparue précédemment dans cet espace de noms
#pragma warning restore CS0105 // La directive using est apparue précédemment dans cet espace de noms

namespace NorthWind2
{





    public class Entites
    {

        [Display(ShortName = "id")]     // nom des colonnes
        public int SupplierId { get; set; }

        [Display(ShortName = "None")]     // ne s'affiche pas
        public string CompanyName { get; set; }
        public string CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public int OrderId { get; set; }
        public string ContactName { get; set; }
        public string ShippedDate { get; set; }


    }


    public class Address
    {

        public Guid AddressId { get; set; }
        public string Country { get; set; }


    }


    [Table("Supplier")]
    public class Supplier
    {

        public int SupplierId { get; set; }
        public string CompanyName { get; set; }
        [Display(ShortName = "None")]
        public virtual Address Address { get; set; }
        [Display(ShortName = "None")]
        public Guid AddressId { get; set; }

    }



    [Table("Product")]
    public class MonProduit
    {
        [Display(ShortName = "None")]
        internal bool modif;

        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
       // public int UnitsInStock { get; set; }

        public Guid CategoryId { get; set; }
        [Display(ShortName = "None")]
        public virtual MaCategories Category { get; set; }

        public int SupplierId { get; set; }
        [Display(ShortName = "None")]
        public virtual Supplier Supplier { get; set; }



    }

    [Table("Orders")]
    public class Order
    {

        public int OrderId { get; set; }

        [Display(ShortName = "None")]
        public Guid AddressId{ get; set; }
        [Display(ShortName = "None")]
        public virtual Address Address { get; set; }

        [Display(ShortName = "None")]
        public string CustomerId { get; set; }
        [Display(ShortName = "None")]
        public virtual Customer Customer { get; set; }

        public DateTime OrderDate { get; set; }

        

    }



    public class Customer
    {

        public string CustomerId { get; set; }
        //public Guid AddressId { get; set; }
        //public virtual Address Address { get; set; }

        public string CompanyName { get; set; }

        public IList<Order> Commandes { get; set; }


    }

    [Table("Category")]
    public class MaCategories
    {
        [Key]
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return CategoryId + Name + Description;
        }


    }

}
