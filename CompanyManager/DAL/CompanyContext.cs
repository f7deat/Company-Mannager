using CompanyManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CompanyManager.DAL
{
    public class CompanyContext : DbContext
    {
        public CompanyContext() : base("CompanyContext")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Modem> Modems { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandProduct> BrandProducts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierDetail> SupplierDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Volume> Volumes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}