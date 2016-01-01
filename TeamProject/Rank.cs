using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class Rank
    {

        public Goods[] SortbyPrice(Goods[] goodsarr, int count)
        {
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count - i - 1; j++)
                {
                    if (goodsarr[j + 1].price < goodsarr[j].price)
                    {
                        Goods temp = goodsarr[j];
                        goodsarr[j] = goodsarr[j + 1];
                        goodsarr[j + 1] = goodsarr[j];

                    }
                }
                Console.WriteLine(goodsarr[i].name, goodsarr[i].price);

            }

            return goodsarr; 
        }
       

    }
}
