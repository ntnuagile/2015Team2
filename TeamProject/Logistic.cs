using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class Logistic
    {
        private string[] choice_ = new string[] { "Cash on delivery", "credit card" };
        private int num = 2;
        public string Result()
        {
            string s = "";
            s += "Logistic"+"\n" +
                 "\n";
            for(int i=0;i<num;i++)
            {
                s += string.Format("{0}{1}\t{2}\t\n","option",i+1,choice_[i]);
            }
            return s;
        }
    }
}
