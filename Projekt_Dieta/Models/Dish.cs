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
        public string Image { get; set; }
        public string SpoonacularSourceUrl { get; set; }
        public string Instructions { get; set; }
        public float Servings { get; set; }
        public NutrientsInfo Nutrition { get; set; }
        public List<Ingredient> ExtendedIngredients { get; set; }

        /// <summary>
        /// Returns ingredients in a string
        /// </summary>
        /// <returns>String of ingredients in format "a";"b";"c"</returns>
        public string GetIngredients()
        {
            string result = "Can't find ingredients";
            if (this.ExtendedIngredients != null)
            {
                result = String.Empty;
                foreach (var item in ExtendedIngredients)
                {
                    result += $"{item.Original}|";
                }
            }
            return result;
        }
    }

}
