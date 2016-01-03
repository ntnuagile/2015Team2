using System.Collections.Generic;

namespace TeamProject
{
    class shopping_cart
    {
        
        List<Goods> want = new List<Goods>();
        List<int> ngood = new List<int>();
        public void Add(Goods g,int num)
        {
            bool yes = false;
            for (int i = 0; i < want.Count;i++ )
            {
                if (want[i].name.Equals(g.name))
                {
                    yes = true;
                    if (ngood[i] + num <= g.stock)
                    {
                        PriceSum_ += g.price * num;
                        ngood[i] += num;
                        //want.Add(g);
                    }
                    else return;
                }
            }
            if(!yes)
            {
                    if (num <= g.stock)
                    {
                        PriceSum_ += g.price * num;
                        ngood.Add(num);
                        want.Add(g);
                    }
                    else return;
            }
        }
        public void delete(Goods g,int num)
        {
            for (int i = 0; i < want.Count; i++)
            {
                if (want[i].name.Equals(g.name))
                {
                    if (num < ngood[i])
                    {
                        ngood[i] -= num;
                    }
                    else
                    {  
                       ngood.RemoveAt(i);
                       want.Remove(g);
                    }
                    PriceSum_ -= g.price * num;
                }
            } 
        }
        public void deleteAll()
        {
            want.Clear();
            ngood.Clear();
            PriceSum_ = 0;
        }
        public int PriceSum { get { return PriceSum_; } }
        public string Result()
        {
            string s = "";
            s += "購物車\n" +
                 "\n";
            s += string.Format("{0}\t{1}\t{2}\tx\t{3}\t=\t{4}\n", "項次", "品名", "價格","數量", "金額");
            for (int i = 0; i < want.Count; i++)
            {   
                int m = want[i].price * ngood[i];
                s += string.Format("{0}\t{1}\t{2}\tx\t{3}\t=\t{4}\n", i+1, want[i].name, want[i].price, ngood[i], m);
            }
            s += "\n";
            s += string.Format("{0}\t:\t{1}", "總金額", PriceSum_);
            return s;
        }
        private int PriceSum_ = 0;
    }
}
