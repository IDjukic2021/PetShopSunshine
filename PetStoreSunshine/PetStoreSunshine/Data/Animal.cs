using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PetStoreSunshine.Data
{
    public class Animal
    {   [Key]
        public int AnimalsId { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public string SubKingdoms { get; set; }
        public string Name { get; set; }
    }

}
