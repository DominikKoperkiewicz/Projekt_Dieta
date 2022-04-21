using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Dieta.Models
{
    public class DishSearchResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string NutriString { get; set; }
        public NutrientsInfo Nutrition { get; set; }

        public void UpdateNutriString()
        {
            this.NutriString = Nutrition.NutriInfoString();
        }
    }
}
