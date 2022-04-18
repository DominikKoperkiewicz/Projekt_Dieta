using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Dieta.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public int DishID { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Recipe { get; set; }
        public float Calories { get; set; }
        public float Fat { get; set; }
        public float Carbohydrates { get; set; }
        public string Ingrideints { get; set; }

        public Entry(Dish dish)
        {
            DishID = dish.Id;
            Title = dish.Title;
            Url = dish.SpoonacularSourceUrl;
            Recipe = dish.Instructions;
            
        }
    }
    
}
