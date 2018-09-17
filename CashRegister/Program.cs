using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CashRegister.ItemFactory;

namespace CashRegister
{
    class Program : IDisposable
    {
        private bool disposed;
        static void Main(string[] args)
        {
            List<ItemFactory> listOfItems = new List<ItemFactory>();
            Console.WriteLine("----Welcome to the Cash Register---------");
            ItemFactory item = Program.CashRegister();
            listOfItems.Add(item);
            b:
            Console.WriteLine("Do you want to add more items: Y/N");
            string confirmation = Console.ReadLine();
            if (confirmation == "y" || confirmation == "Yes"
                || confirmation == "Y" || confirmation == "YES")
            {
                item = Program.CashRegister();
                listOfItems.Add(item);
                goto b;
            }
            else
            {
                double totalItemCost = item.calculateTotalOfAllItems(listOfItems);

                Console.WriteLine("-----------------------Invoice-------------------------");
                Console.WriteLine("Name\tQty\tfreeQty\tDiscountType\tCost");
                foreach (var eachItem in listOfItems)
                {
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", eachItem.Name, eachItem.Qty, eachItem.FreeItemQty,
                        (eachItem.TypeOfDiscount == 1) ? discountTypes.Percentage.ToString() : discountTypes.BuyXGetYFree.ToString(), "$" + eachItem.Cost.ToString("n2"));
                }
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("\t\t\t\tTotal:{0} ", "$" + totalItemCost.ToString("n2"));
                Console.WriteLine("--------------------------------------------------------");
            }

        }

        private static ItemFactory CashRegister()
        {
            int typeOfDiscount = 0;
            ItemFactory item = null;
            Console.WriteLine("---- Scanned your items here------");
            Console.Write("Item name:");
            string itemName = Console.ReadLine();
            Console.Write("Item Qty:");
            int qty = Convert.ToInt16(Console.ReadLine());
            Console.Write("Item weight:");
            double weight = Convert.ToDouble(Console.ReadLine());
            Console.Write("Item discount type: ");
            typeOfDiscount = Convert.ToInt16(Console.ReadLine());

            if (typeOfDiscount != 0)
            {
                item = new ItemFactory(itemName, qty, weight, typeOfDiscount);
                item = item.TypeOfDiscountCoupon(typeOfDiscount, item);
            }
            else
            {
                item = new ItemFactory(itemName, qty, weight);
            }

            return item;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Dispose(true);
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
