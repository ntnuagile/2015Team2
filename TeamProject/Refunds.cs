using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class Refunds
    {
        List<Goods> gdb = new List<Goods>();
        public void Add(Goods g)
        {
            gdb.Add(g);
        }

        public void Add(Goods[] ga)
        {
            foreach (Goods g in ga)
                Add(g);
        }

        public string Result()
        {
            if (gdb.Count == 0) throw new Exception("沒東西啊!");
            int money = 0;
            string s = "";
            s += "退費明細\n" +
                 "\n";
            int count = 1;
            s += string.Format("{0}\t:{1}\t:{2}\tx\t{3}\t=\t{4}\n", "項次", "品名", "價格", "數量", "金額");
            foreach (Goods g in gdb)
            {
                int m = g.price * g.stock;
                s += string.Format("{0}\t:{1}\t:{2}\tx\t{3}\t=\t{4}\n", count, g.name, g.price, g.stock, m);
                ++count;
                money += m;
            }
            s += "\n";
            s += string.Format("小記:{0}", money);

            return s;
        }
        public string Result(Member m)
        {
            if (m == null) throw new ArgumentNullException("Member", "Member 不能是null");
            string s = "";
            s += "客戶資訊\n\n";
            s += string.Format("{0}:{1}\n", "姓名", m.username);
            s += string.Format("{0}:{1}\n", "鑾絡電話", m.phonenum);
            string temp = "";
            for (int i = 0; i < 2; ++i) temp += m.id[i];
            temp += "****";
            for (int i = 6; i < m.id.Length; ++i) temp += m.id[i];
            s += string.Format("{0}:{1}\n", "身分證字號", temp);
            return Result() +
                "\n\n" +
                s;
        }

        public string Result(string Key,Member m)
        {
            if (m.safetycode != Member.Cypher(Key))
                throw new Exception("身分驗證失敗!");
            return Result(m);
        }


    }
}
