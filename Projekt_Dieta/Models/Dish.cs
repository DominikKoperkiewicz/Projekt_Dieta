using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Dieta.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SpoonacularSourceUrl { get; set; }
        public string Instructions { get; set; }
        public NutrientsInfo Nutrition { get; set; }
        public List<Ingredients> ExtendedIngredients;

    }
}
