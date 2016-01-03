using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeamProject.Tests
{
    [TestFixture]
    public class TestClass1
    {
        [Test]
        public void TestGoods()
        {
            Goods good = new Goods();
            Assert.That(good.name, Is.EqualTo(""));
            good.SetName("Apple");
            good.SetPrice(30);
            good.SetStock(100);
            good.SetType("Fruit");
            good.SetDetail("Just an apple");

            Assert.That(good.name, Is.EqualTo("Apple"));
            Assert.That(good.price, Is.EqualTo(30));
            Assert.That(good.stock, Is.EqualTo(100));
            Assert.That(good.type, Is.EqualTo("Fruit"));
            Assert.That(good.detail, Is.EqualTo("Just an apple"));

        }
        [Test]
        public void TestGoodsDB()
        {
            GoodsDB db = new GoodsDB();
            Assert.That(db.num, Is.EqualTo(0));

            Goods good = new Goods();
            good.SetName("One");
            db.Add(good);
            good = new Goods();
            good.SetName("Two");
            db.Add(good);
            Assert.That(db[0].name, Is.EqualTo("One"));
            Assert.That(db.num, Is.EqualTo(2));
            db[1] = db[1];

            try {
                db.Find("One");
            }
            catch (ArgumentNullException) {   // if not find "One"
                Assert.That(false);
            }
            try {
                db.Find("Three");
            }
            catch (ArgumentNullException){   // if not find "Three"
                Assert.That(true);
            }
            catch {
                Assert.That(false);
            }

            good = new Goods();
            good.SetName("One");
            good.SetStock(3);
            db.Add(good);
            Assert.That(db[0].stock, Is.EqualTo(3));
            db.SellGoods("One", 2);
            Assert.That(db[0].stock, Is.EqualTo(1));
            Assert.That(db.SellGoods("Two", 1), Is.EqualTo(false));
            
            db.Remove(db.Find("One"));
            Assert.That(db.num, Is.EqualTo(1));
            Assert.That(db[0].name, Is.EqualTo("Two"));

            db.Remove(0);
            Assert.That(db.num, Is.EqualTo(0));

            db.Add(good);
            db.Clear();
            Assert.That(db.num, Is.EqualTo(0));
        }



        Goods AGood(string name, int pri, int amount)
        {
            Goods g = new Goods();
            g.SetName(name);
            g.SetPrice(pri);
            g.SetStock(amount);
            return g;
        }

        [Test]
        public void TestRefunds()
        {
            Refunds r = new Refunds();
            Goods[] g = new Goods[] {
                AGood("good1",100,1),
                AGood("good2",50,2) };
            Assert.Catch<Exception>(() => r.Result());
            r.Add(g);
            Assert.That(r.Result(), Is.EqualTo("退費明細\n" + "\n" +
            "項次	:品名	:價格	x	數量	=	金額\n" +
            "1	:good1	:100	x	1	=	100\n" +
            "2	:good2	:50	x	2	=	100\n" + "\n" +
            "小記:200"));


        }
        [Test]
        public void TestRefundsWithMember()
        {
            Refunds r = new Refunds();
            Goods[] g = new Goods[] {
                AGood("good1",100,1),
                AGood("good2",50,2) };
            r.Add(g);
            Member m = null;
            Assert.Catch<ArgumentNullException>(() => r.Result(m));
            m = new Member();
            m.SetAccountName("Idiot");
            m.SetSafetyCode("1234");
            m.SetUserName("Amercan Fat");
            m.SetEmail("Idiot@gmai.com");
            m.SetId("A123321444");
            m.SetPhoneNum("0912345678");
            string list = "退費明細\n" + "\n" +
            "項次	:品名	:價格	x	數量	=	金額\n" +
            "1	:good1	:100	x	1	=	100\n" +
            "2	:good2	:50	x	2	=	100\n" + "\n" +
            "小記:200\n\n" +
            "客戶資訊\n\n" +
            "姓名:Amercan Fat\n" +
            "鑾絡電話:0912345678\n" +
            "身分證字號:A1****1444\n";
            Assert.That(r.Result(m), Is.EqualTo(list));
            Assert.Catch<Exception>(() => r.Result("0000", m));
            Assert.That(r.Result("1234",m), Is.EqualTo(list));

        }





        [Test]
        public void TestMemberClass()
        {
            Member m = new Member();
            Assert.That(m.accountname, Is.EqualTo(""));
            m.SetAccountName("Idiot");
            m.SetSafetyCode("1234");
            m.SetUserName("Amercan Fat");
            m.SetEmail("Idiot@gmai.com");
            m.SetId("A123321444");
            m.SetPhoneNum("0912345678");
            m.SetOnlineState(true);
            Assert.That(m.accountname, Is.EqualTo("Idiot"));
            Assert.That(m.safetycode, Is.EqualTo("81dc9bdb52d04dc20036dbd8313ed055"));
            Assert.That(m.username, Is.EqualTo("Amercan Fat"));
            Assert.That(m.email, Is.EqualTo("Idiot@gmai.com"));
            Assert.That(m.id, Is.EqualTo("A123321444"));
            Assert.That(m.phonenum, Is.EqualTo("0912345678"));
            Assert.That(m.isOnline, Is.EqualTo(true));
        }
        [Test]
        public void TestMemberDatabase()
        {
            Member m = new Member();
            Member n = new Member();
            MemberDatabase md = new MemberDatabase();
            
            m.SetAccountName("Idiot");
            m.SetSafetyCode("1234");
            m.SetUserName("Amercan Fat");
            m.SetEmail("Idiot@gmai.com");
            m.SetId("A123321444");
            m.SetPhoneNum("0912345678");
            m.SetOnlineState(true);

            n.SetAccountName("zzzz");
            n.SetSafetyCode("7890");
            n.SetUserName("hahaha");
            n.SetEmail("hahaha@gmail.com");
            n.SetId("G12345678");
            n.SetPhoneNum("0806449449");
            n.SetOnlineState(false);
            // test add a member
            Assert.That(md.AddMember(m), Is.EqualTo(true));
            Assert.That(md.GetNumberofMembers(), Is.EqualTo(1));
            // test delete a member
            Assert.That(md.DeleteMember(m), Is.EqualTo(true));
            Assert.That(md.GetNumberofMembers(), Is.EqualTo(0));
            Assert.That(md.DeleteMember(m), Is.EqualTo(false));
            // test get something from a member
            Assert.That(md.AddMember(m), Is.EqualTo(true));
            Assert.That(md.GetOneMember(0).accountname, Is.EqualTo("Idiot"));
            Assert.That(md.GetOneMember(m).email, Is.EqualTo("Idiot@gmai.com"));
            // test add another member
            Assert.That(md.AddMember(n), Is.EqualTo(true));
            Assert.That(md.GetNumberofMembers(), Is.EqualTo(2));
            Assert.That(md.GetOneMember(1).isOnline, Is.EqualTo(false));
            // test can add the same account
            Member same = new Member();
            same.SetAccountName("Idiot");
            same.SetSafetyCode("9999");
            same.SetUserName("aluba");
            same.SetEmail("balan@gmai.com");
            same.SetId("A12344444");
            same.SetPhoneNum("222222");
            same.SetOnlineState(true);
            Assert.That(md.AddMember(same), Is.EqualTo(false));
            // test get a member
            Member a = new Member();
            a.SetAccountName("QQ");
            a.SetSafetyCode("9999");
            a.SetUserName("aluba");
            a.SetEmail("balan@gmai.com");
            a.SetId("A12344444");
            a.SetPhoneNum("222222");
            a.SetOnlineState(true);
            Assert.That(md.GetOneMember(a), Is.EqualTo(null));
            Assert.That(md.AddMember(a), Is.EqualTo(true));
            Assert.That(md.GetOneMember(-2), Is.EqualTo(null));
            Assert.That(md.GetNumberofMembers(), Is.EqualTo(3));
            Assert.That(md.GetOneMember(3), Is.EqualTo(null));
            Assert.That(md.GetOneMember(same), Is.EqualTo(null));
            // in the md : m,n,a
        }
        [Test]
        public void TestShoppingCart()
        {
            shopping_cart s = new shopping_cart();
            Goods g1=new Goods();
            g1.SetName("Apple");
            g1.SetPrice(30);
            g1.SetStock(100);
            s.Add(g1,2);
            s.Add(g1,3);
            s.Add(g1, 100);
            Goods g2 = new Goods();
            g2.SetName("Hat");
            g2.SetPrice(50);
            g2.SetStock(50);
            s.Add(g2, 20);
            s.delete(g2, 10);
            Goods g3 = new Goods();
            g3.SetName("Flower");
            g3.SetPrice(50);
            g3.SetStock(50);
            s.Add(g3, 60);
            s.Add(g3, 20);
            s.delete(g3, 20);
            Assert.That(s.Result(), Is.EqualTo("購物車\n" + "\n" +
            "項次	品名	價格	x	數量	=	金額\n" +
            "1	Apple	30	x	5	=	150\n" +
            "2	Hat	50	x	10	=	500\n" + "\n" +
            "總金額	:	650"));
            Assert.That(s.PriceSum, Is.EqualTo(650));
            s.deleteAll();
            Assert.That(s.PriceSum, Is.EqualTo(0));
        }

        
        [Test]
        public void TestRank()
        {
            Rank r = new Rank();
            Goods[] goodsarr = new Goods[3];
            for (int i = 0; i < 3; ++i) goodsarr[i] = new Goods();
            goodsarr[0].SetName("Apple");
            goodsarr[0].SetPrice(10);
            goodsarr[1].SetName("Ball");
            goodsarr[1].SetPrice(20);
            goodsarr[2].SetName("cup");
            goodsarr[2].SetPrice(30);
            Assert.That(r.SortbyPrice(goodsarr,3), Is.EqualTo(goodsarr));

        }
        

        [Test]
        public void TestSearch()
        {
            GoodsDB b = new GoodsDB();
            Search s = new Search();
            Goods g = new Goods();
            string name = "One";
            g.SetName("One");
            g.SetPrice(10);
            b.Add(g);
            Assert.That(s.SearchGoods(name, b), Is.EqualTo(name));

        }
        [Test]
        public void TestLoginLogout()
        {
            MemberDatabase md = new MemberDatabase();
            Member m = new Member();
            Member n = new Member();
            m.SetAccountName("Peter");
            m.SetSafetyCode("0000");
            n.SetAccountName("Allen");
            n.SetSafetyCode("1111");
            md.AddMember(m);
            md.AddMember(n);
            Assert.That(md.Login("Peter", "0000"), Is.EqualTo(true));
            Assert.That(md.Login("Peter", "1234"), Is.EqualTo(false));
            Assert.That(md.Login("John", "1234"), Is.EqualTo(false));
            Assert.That(m.Logout(), Is.EqualTo(true));
            Assert.That(n.Logout(), Is.EqualTo(false));
        }
        [Test]
        public void Logistic()
        {
            Logistic l = new Logistic();
            Assert.That(l.Result(), Is.EqualTo("Logistic" + "\n" + "\n" + "option1" + "\t" + "Cash on delivery" + "\t" + "\n" + "option2" + "\t" + "credit card" + "\t" + "\n"));
        }
    }
}
