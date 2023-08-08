using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Entites.RequestParameters
{
    public class RequestParameters
    {
        public String? SearchTerm { get; set; }
        public int minPrice { get; set; } = 0;
        public int maxPrice { get; set; } = int.MaxValue;

    }
}