using Projekt_Dieta.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Dieta.DataAccess
{
    public class EntriesContext : DbContext
    {
        public EntriesContext() : base("EntriesDB")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        //tutaj DbSet skladnikow 
    }
}
