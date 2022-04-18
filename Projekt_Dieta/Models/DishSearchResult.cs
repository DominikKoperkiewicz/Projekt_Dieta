using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Dieta.Models
{
    public class DishSearchResult
    {
        public string Title;
        public NutrientsInfo Nutrition { get; set; }
    }
}
