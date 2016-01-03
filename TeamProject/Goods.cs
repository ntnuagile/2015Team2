using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class Goods
    {
        public Goods() {
            Clear();
        }

        public string name   { get { return name_ ;  } }
        public    int price  { get { return price_;  } }
        public    int stock  { get { return stock_;  } }
        public string detail { get { return detail_; } }
        public string type   { get { return type_;   } }

        public void SetName(string name) {
            name_ = name;
        }
        public void SetPrice(int price) {
            price_ = price;
        }
        public void SetStock(int stock) {
            stock_ = stock;
        }
        public void SetDetail(string detail) {
            detail_ = detail;
        }
        public void SetType(string type) {
            type_ = type;
        }
        public void Clear() {
            name_ = ""; price_ = 0; stock_ = 0; detail_ = ""; type_ = "";
        }
      
  
    // --------------------------------------------------------------   Private

        private string name_ ;
        private int price_ ;
        private int stock_ ;              // 庫存
        private string detail_ ;          // 說明
        private string type_ ;            // 類別
    
    }

    class GoodsDB {

        public int num { get { return database_.Count; } }
        public void Add( Goods good) {
            int index;
            index = FindIndex(good.name);
            if(index==-1)
                database_.Add(good) ;
            else
            {
                database_[index].SetStock(database_[index].stock+good.stock);
            }
        }
        public void Remove(Goods good) {
            database_.Remove(good);
        }
        public void Remove(int idx) {
            database_.RemoveAt(idx);
        }
        public Goods Find(string name) {
            foreach( Goods good in database_ ){
                if( good.name.Equals(name)){
                    return good ;
                }
            }
            throw new ArgumentNullException() ;
        }
        public int FindIndex(string name)
        {
            for (int i=0;i<num; i+=1)
            {
                if (database_[i].name.Equals(name))
                {
                    return i;
                }
            }
            return -1;
        }
        public Goods this[int idx]{
            get {
                return database_[idx];
            }
            set {
                database_[idx] = value;
            }
        }
        public void Clear() {
            database_.Clear();
        }
        public bool SellGoods(String name,int number)
        {
            int index = FindIndex(name);
            if (index != -1 && number <= database_[index].stock)
            {
                database_[index].SetStock(database_[index].stock - number);
                return true;
            }
            return false;
            
        }

    // --------------------------------------------------------------   Private
        private List<Goods> database_ = new List<Goods>();
    }

    
        
    


}
