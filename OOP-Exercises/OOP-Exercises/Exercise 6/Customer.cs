using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Exercises.Exercise_6
{
    public class Customer
    {
        public string Name { get; set; }
        public Dictionary<string, int> ShopList { get; set; }


        public Customer(string name)
        {
            Name = name;
        }

        public decimal Bill(Dictionary<string, decimal> allProducts)
        {
            decimal totalBill=0;
            foreach (string product in ShopList.Keys)
            {
                if (allProducts.ContainsKey(product))
                {
                    totalBill += allProducts[product] * ShopList[product];
                }
            }
            return totalBill;
        }

    }
}
