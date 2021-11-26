using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PetStoreSunshine.Data
{
    public class AnimalFood
    {   [Key]
        public int AnimalFoodId { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
    }

}
