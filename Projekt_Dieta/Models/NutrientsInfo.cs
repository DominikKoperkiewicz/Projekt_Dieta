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
                    if (item.Name == "Calories")
                        result += item.Amount.ToString() + item.Unit + " ";
                    if (item.Name == "Protein")
                        result += item.Amount.ToString() + item.Unit + " Proteins ";
                    if (item.Name == "Fat")
                        result += item.Amount.ToString() + item.Unit + " Fat ";
                    if (item.Name == "Carbohydrates")
                        result += item.Amount.ToString() + item.Unit + " Carbs ";
                }
            }
            return result;
        }

        public string NutriInfoStringLong()
        {
            string result = "No nutri info! ";
            if (this.Nutrients != null)
            {
                result = String.Empty;
                foreach (var item in this.Nutrients)
                {
                    if (item.Name == "Calories" || item.Name == "Fat" || item.Name == "Carbohydrates" || item.Name == "Proteins")
                        result +=item.Name + " " + item.Amount.ToString() + item.Unit + " ";
                }
            }
            return result;
        }

        /// <summary>
        /// Retrieves calories
        /// </summary>
        /// <returns>Float with calories ammount</returns>
        public float NutriInfoCalories()
        {
            float result = this.Nutrients.Find(Nutrients => Nutrients.Name == "Calories").Amount;

            return result;
        }
        /// <summary>
        /// Retrieves fat
        /// </summary>
        /// <returns>Float with fat ammount</returns>
        public float NutriInfoFat()
        {
            float result = this.Nutrients.Find(Nutrients => Nutrients.Name == "Fat").Amount;

            return result;
        }
        /// <summary>
        /// Retrieves carbs
        /// </summary>
        /// <returns>Float with carbs ammount</returns>
        public float NutriInfoCarbs()
        {
            float result = this.Nutrients.Find(Nutrients => Nutrients.Name == "Carbohydrates").Amount;

            return result;
        }
        /// <summary>
        /// Retrieves proteins
        /// </summary>
        /// <returns></returns>
        public float NutriInfoProteins()
        {
            
            float result = this.Nutrients.Find(Nutrients => Nutrients.Name == "Protein").Amount;

            return result;
        }
    }
}
