using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class Search
    {
        public string SearchGoods(string name, GoodsDB db)
        {
            Goods g = db.Find(name);
            Console.WriteLine(g.name,g.price);
            return g.name;

        }
    }
}
