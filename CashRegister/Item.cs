using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister
{
    public class ItemFactory
    {
        private string name;
        private int buyQuantity;
        private int freeQuantity;
        private double weight;
        private double cost;
        private int typeOfDiscount;
        private int percentage;
        private int buyQtyConst;

        /// <summary>
        /// No discount object initialization
        /// </summary>
        /// <param name="name"></param>
        /// <param name="buyQuantity"></param>
        /// <param name="weight"></param>
        public ItemFactory(string name, int buyQuantity, double weight)
        {
            this.name = name;
            this.buyQuantity = buyQuantity;
            this.weight = weight;
            this.Cost = calcCost; 
        }

        /// <summary>
        /// With type of discount
        /// </summary>
        /// <param name="name"></param>
        /// <param name="buyQuntity"></param>
        /// <param name="weight"></param>
        /// <param name="typeOfDiscount"></param>
        public ItemFactory(string name,int buyQty, double weight,int typeOfDiscount)
        {
            this.name = name;
            this.buyQuantity = buyQty;
            this.weight = weight;
            this.typeOfDiscount = typeOfDiscount;
            this.Cost = calcCost;
        }


        /// <summary>
        /// Calculate Item discount by discount coupon
        /// </summary>
        /// <param name="typeOfDiscount"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public ItemFactory TypeOfDiscountCoupon(int typeOfDiscount, ItemFactory item)
        {
            ItemFactory discountedItem = null;
            switch (typeOfDiscount)
            {
                case ((int)discountTypes.Percentage):
                    var pc = new PercentageCoupon(Percentage);
                    discountedItem = pc.CalculateItemQtyAndCost(item);
                    break;
                case ((int)discountTypes.BuyXGetYFree):
                    var fic = new FreeItemCoupon(BuyQtyConst);
                    discountedItem = fic.CalculateItemQtyAndCost(item);
                    break;
                default:
                    discountedItem = item;
                    break;
            }
            return discountedItem;
        }

        /// <summary>
        /// Create an instance of random class
        /// </summary>
        private Random createRandom
        {
            get
            {
                return new Random();
            }
        }

        /// <summary>
        /// Calculate item cost from 1 to 30
        /// </summary>
        private double calcCost
        {
           
            get
            {
                return cost;
            }
            set
            {
                cost = createRandom.NextDouble() * 10;
            }
        }
       
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Qty
        {
            get { return buyQuantity; }
            set { buyQuantity = value; }
        }

        public int FreeItemQty
        {
            get { return freeQuantity; }
            set { freeQuantity = value; }
        }

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public double Cost
        {
            get { return calcCost; }
            set { calcCost = value; }
        }
        public int TypeOfDiscount
        {
            get
            {
                return typeOfDiscount;
            }
            set
            {
                typeOfDiscount = value;
            }
        }

        //can assign value from db or external file
        public int Percentage
        {
            get
            {
                return percentage = 10;
            }
        }


        //Buying quantity constanst for buy x get y discount coupon
        public int BuyQtyConst
        {
            get
            {
                return buyQtyConst = 3;
            }
        }

        //Calculate total item cost
        public double calculateTotalOfAllItems(IList<ItemFactory> items)
        {
            double totalCost = 0.0d;
            foreach(var item in items)
            {
                totalCost += item.cost;
            }

            return totalCost;
        }

        public enum discountTypes
        {
            Percentage = 1 ,
            BuyXGetYFree = 2
        }

       

    }
}
