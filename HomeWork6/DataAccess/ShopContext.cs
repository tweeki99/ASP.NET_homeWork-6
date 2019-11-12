namespace HomeWork6.DataAccess
{
    using HomeWork6.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ShopContext : DbContext
    {
        public ShopContext()
            : base("name=ShopContext")
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}