﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PizzaNet.Domain
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PizzaNetDbEntities : DbContext
    {
        public PizzaNetDbEntities()
            : base("name=PizzaNetDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Ingridient> Ingridients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<Pizza_Ingridients> Pizza_Ingridients { get; set; }
        public virtual DbSet<Pizza_Order> Pizza_Order { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
    }
}
