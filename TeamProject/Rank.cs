using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class Rank
    {
       
        public void SortbyPrice(GoodsDB db)
        {
            int[] array = new int[db.num];
            /*for (int i = 0; i < db.num; i++)
            { 
                
            }
            */
            Array.Sort(array);
                    
        }
        public void SortbyName(GoodsDB db, string name)
        {
            int num = db.num;
            while (true)
            {
                if (num == 0) break;
                Goods findgoods = db.Find(name);
                Console.WriteLine(findgoods.name, findgoods.price, findgoods.detail);
                num--;
            };
           
        }
    }
}
