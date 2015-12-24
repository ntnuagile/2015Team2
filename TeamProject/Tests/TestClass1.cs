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
            Assert.That(db[0].name, Is.EqualTo("One"));

            try
            {
                db.Find("One");
            }
            catch (ArgumentNullException)
            {   // if not find "One"
                Assert.That(false);
            }


            Assert.That(db.num, Is.EqualTo(1));
            db.Remove(db.Find("One"));
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

            Assert.That(r.Result(m), Is.EqualTo("退費明細\n" + "\n" +
            "項次	:品名	:價格	x	數量	=	金額\n" +
            "1	:good1	:100	x	1	=	100\n" +
            "2	:good2	:50	x	2	=	100\n" + "\n" +
            "小記:200\n\n" +
            "客戶資訊\n\n" +
            "姓名:Amercan Fat\n" +
            "鑾絡電話:0912345678\n" +
            "身分證字號:A1****1444\n"));


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
            Assert.That(m.isOnline(), Is.EqualTo(true));
        }








    }
}
