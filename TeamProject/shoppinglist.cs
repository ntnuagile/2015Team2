using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class shoppinglist
    {
       shopping_cart sc;
       public void PrintList()
        {
            sc.Result();
            System.Console.WriteLine("The total price is ");
            System.Console.WriteLine(sc.PriceSum);
        }

    }
}
