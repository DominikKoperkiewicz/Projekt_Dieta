using Projekt_Dieta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Dieta.API
{
    /// <summary>
    /// Class that reads dishes data from api
    /// </summary>
    public class DishProcessor
    {
        /// <summary>
        /// Loads dish info to a dish class.
        /// </summary>
        /// <param name="dishID"></param> id used by api to fetch all informations
        /// <returns>Dish class filled with all necessary informations</returns>
        /// <exception cref="Exception"></exception>
        public static async Task<Dish> LoadDish(int dishID)
        {
            string url = $"https://api.spoonacular.com/recipes/informationBulk?ids={ dishID }&includeNutrition=true&apiKey=d052eb07d67643e7a5dacc44b470a0f6"; //ef70bb600b644411936f9c2ffc9bb265";

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

        /// <summary>
        /// Loads dish info to a dish class.
        /// </summary>
        /// <param name="dishID"></param> id used by api to fetch all informations
        /// <returns>Dish class filled with all necessary informations</returns>
        /// <exception cref="Exception"></exception>
        public static async Task<DishSearchResults> LoadDishes(string query)
        {
            string url = $"https://api.spoonacular.com/recipes/complexSearch?query={ query }&instructionsRequired=true&addRecipeNutrition=true&number=10&apiKey=d052eb07d67643e7a5dacc44b470a0f6"; //ef70bb600b644411936f9c2ffc9bb265";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    DishSearchResults dishes = await response.Content.ReadAsAsync<DishSearchResults>();
                    return dishes;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

    }
}