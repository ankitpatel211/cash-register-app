using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    class PercentageCoupon : DiscountCoupon
    {
        private int percentage { get; set; }

        public int Percentage
        {
            get
            {
                return percentage;
            }

            set
            {
                percentage = value;
            }
        }

        public PercentageCoupon(int percentage)
        {
            this.percentage = percentage;
        }

        /// <summary>
        /// Calculate percentage discount from item cost
        /// </summary>
        /// <param name="totalItemCost"></param>
        /// <returns></returns>
        private double percentageDiscountTotalItemCost(double totalItemCost)
        {
            return totalItemCost - ((totalItemCost * percentage) / 100);
        }

        /// <summary>
        /// Calculate percentage discount cost
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override ItemFactory CalculateItemQtyAndCost(ItemFactory item)
        {  
            item.Cost = percentageDiscountTotalItemCost(item.Cost);
            return item;
        }

    }
}
