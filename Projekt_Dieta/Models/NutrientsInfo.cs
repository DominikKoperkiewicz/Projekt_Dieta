using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Dieta.Models
{
    /// <summary>
    /// Helps with retrieving info about nutrients from api
    /// </summary>
    public class NutrientsInfo
    {
        public List<NutrientsClass> Nutrients;

        /// <summary>
        /// Converts important nutrition info to string
        /// </summary>
        /// <returns> String with Calories, Fat and Carbohydrates</returns>
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
