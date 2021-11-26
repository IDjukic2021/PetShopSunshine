using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetStoreSunshine.Data
{
    public class ViewModel
    {
        public Order Order { get; set; }
        public Animal Animal { get; set; }
        public AnimalFood AnimalFood { get; set; }
    }
}
