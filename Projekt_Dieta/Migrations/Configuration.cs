namespace Projekt_Dieta.Migrations
{
    using Projekt_Dieta.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Projekt_Dieta.DataAccess.EntriesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Projekt_Dieta.DataAccess.EntriesContext context)
        {
            var Dishes = new List<Dish>
            {
                new Dish() {Id = 1, Name = "Pierogi",
                    Recipe = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin varius magna vitae pretium egestas. Morbi cursus eu diam at elementum. "},

                new Dish() {Id = 2, Name = "Barszcz",
                    Recipe = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin varius magna vitae pretium egestas. Morbi cursus eu diam at elementum. "},

                new Dish() {Id = 3, Name = "Nalesniki",
                    Recipe = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin varius magna vitae pretium egestas. Morbi cursus eu diam at elementum. "}
            };
            Dishes.ForEach(d => context.Dishes.Add(d));
            context.SaveChanges();

            var Entries = new List<Entry>
            {
                new Entry() {Id = 1, Date = DateTime.Now, DishId = 1, Kcal = 100},
                new Entry() {Id = 2, Date = DateTime.Now, DishId = 2, Kcal = 200},
                new Entry() {Id = 3, Date = DateTime.Now, DishId = 1, Kcal = 300},
                new Entry() {Id = 4, Date = DateTime.Now, DishId = 3, Kcal = 400},
                new Entry() {Id = 5, Date = DateTime.Now, DishId = 3, Kcal = 500},
            };
            Entries.ForEach(e => context.Entries.Add(e));
            context.SaveChanges();
        }
    }
}
