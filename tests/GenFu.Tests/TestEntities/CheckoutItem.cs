using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenFu.Tests.TestEntities
{
    public class CheckoutItem
    {
        public int Quantity { get; set; }
        public int Price1Amt { get; set; }//trigger price filler
        public decimal Price2Amt { get; set; }
    }
}
