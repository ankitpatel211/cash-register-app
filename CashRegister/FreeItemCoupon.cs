using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class FreeItemCoupon : DiscountCoupon
    {
        private int buyingQty { get; set; }
        private int freeQty { get; set; }
        private int buyingQtyConst { get; set; }

        public FreeItemCoupon(int buyingQtyConst)
        { 
            this.buyingQtyConst = buyingQtyConst;
        }


        /// <summary>
        /// count free qty from buying quantities
        /// </summary>
        /// <param name="buyingQty"></param>
        /// <returns></returns>
        private int howManyFreeItems(int buyingQty)
        {
            decimal freeQty = buyingQty / buyingQtyConst;
            return Convert.ToInt16(Math.Floor(freeQty));
        }

        /// <summary>
        /// calculate free qty from buying quantities
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override ItemFactory CalculateItemQtyAndCost(ItemFactory item)
        {
            if (item.Qty >= buyingQtyConst)
            {
                int freeQty = howManyFreeItems(item.Qty);
                if (freeQty >= 1)
                    item.FreeItemQty = freeQty;
            }
           
            return item;
        }
    }
}
