using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_Dieta.Models
{
    /// <summary>
    /// Retrieves info about nutrients from api
    /// </summary>
    public class NutrientsClass
    {
        public string Name { get; set; }
        public float Amount { get; set; }
        public string Unit { get; set; }
    }
}
