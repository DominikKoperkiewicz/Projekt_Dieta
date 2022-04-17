using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Dieta.Models
{
    public class Dish
    {
        public int DishId { get; set; }
        public string Title { get; set; }
        public string SpoonacularSourceUrl { get; set; }
        public string Instructions { get; set; }
        public NutrientsInfo Nutrition { get; set; }

        /// <summary>
        /// Leaves only info about calories, fat and carbs.
        /// </summary>
        //public void RemoveUnnecesaryNutritionInfo()
        //{
        //    foreach (var nutrition in Nutrition)
        //    {
        //        if (nutrition.Name != "Calories" || nutrition.Name != "Fat" || nutrition.Name != "Carbohydrates")
        //        {
        //            Nutrition.Remove(nutrition);
        //        }
        //    }
        //}
    }
}
