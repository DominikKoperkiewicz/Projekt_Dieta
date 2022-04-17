using Projekt_Dieta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Dieta.API
{
    public class DishProcessor
    {
        public static async Task<Dish> LoadDish(int dishID)
        {
            string url = $"https://api.spoonacular.com/recipes/informationBulk?ids={ dishID }&includeNutrition=true&apiKey=ef70bb600b644411936f9c2ffc9bb265";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    List<Dish> dishes = await response.Content.ReadAsAsync<List<Dish>>(); 
                    return dishes.First();
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        
    }
}
