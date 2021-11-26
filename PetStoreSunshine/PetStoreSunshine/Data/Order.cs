using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PetStoreSunshine.Data
{
    public class Order
    {   [Key]
        public int OrderId { get; set; }
        
        public int AnimalsId { get; set; }
        public int AnimalFoodId { get; set; }
        public int Piece { get; set; }
        public string Note { get; set; }
    }
}
