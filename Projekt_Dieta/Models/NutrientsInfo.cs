using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Dieta.Models
{
    public class NutrientsInfo
    {
        public List<NutrientsClass> Nutrients;

        public string NutriInfoString()
        {
            string result = "No nutri info! ";
            if (this.Nutrients != null)
            {
                result = String.Empty;
                foreach (var item in this.Nutrients)
                {
                    if (item.Name == "Calories" || item.Name == "Fat" || item.Name == "Carbohydrates")
                    result += item.Name + " " + item.Amount.ToString() + item.Unit + " ";
                }
            }
            return result;
        }
    }
}
