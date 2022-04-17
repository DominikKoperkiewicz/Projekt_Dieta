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
        public DateTime Date { get; set; }
        public Dish dish { get; set; }
    }
}
