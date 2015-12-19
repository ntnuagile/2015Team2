using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class shopping_cart
    {
        
        List<Goods> want = new List<Goods>();
        public void Add(Goods g)
        {
            PriceSum_ += g.price;
            want.Add(g);
        }
        public void delete(Goods g)
        {
            PriceSum_ -= g.price ;
            want.Remove(g);
        }
        public void deleteAll()
        {
            want.Clear();
        }
        public int PriceSum { get { return PriceSum_; } }
        public void Result()
        {
            string s = "";
            s += "購物車\n" +
                 "\n";
            int count = 1;
            s += string.Format("{0}\t:{1}\t:{2}\tx\t{3}\t=\t{4}\n", "項次", "品名", "價格", "金額");
            foreach (Goods g in want)
            {   
                int m = g.price * g.stock;
                s += string.Format("{0}\t:{1}\t:{2}\tx\t{3}\t=\t{4}\n", count, g.name, g.price, m);
                ++count;
            }
        }
        private int PriceSum_ = 0;
    }
}
