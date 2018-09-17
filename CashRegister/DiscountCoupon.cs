using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    public abstract class DiscountCoupon
    { 
        public abstract ItemFactory CalculateItemQtyAndCost(ItemFactory items);
    }
}
