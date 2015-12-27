using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace TeamProject
{
    class Member
    {
        //  constructer
        public Member()
        {
            Clear();
        }
        public Member(string accountName, string safetycode, string userName, string email, string id, string phonenum)
        {
            accountName_ = accountName;
            safetycode = safetycode_;
            userName_ = userName;
            email_ = email;
            id_ = id;
            phonenum_ = phonenum;
        }

        public string accountname { get { return accountName_; } }
        /// <summary>
        /// 注意：存 "安全碼" 非密碼
        /// </summary>
        public string safetycode { get { return safetycode_; } }
        /// <summary>
        /// 使用者姓名
        /// </summary>
        public string username { get { return userName_; } }
        /// <summary>
        /// 電子郵件
        /// </summary>
        public string email { get { return email_; } }
        /// <summary>
        /// 身分證字號
        /// </summary>
        public string id { get { return id_; } }
        public string phonenum { get { return phonenum_; } }
        public bool isOnline() { return isOnline_; }

        public void Clear()
        {
            accountName_ = "";
            safetycode_ = "";
            userName_ = "";
            email_ = "";
            id_ = "";
            phonenum_ = "";
            isOnline_ = false;
        }

        public void SetAccountName(string AccountName) { accountName_ = AccountName; }
        public void SetSafetyCode(string SafetyCode) { safetycode_ = Cypher(SafetyCode); }
        public void SetUserName(string UserName) { userName_ = UserName; }
        public void SetEmail(string Email) { email_ = Email; }
        public void SetId(string Id) { id_ = Id; }
        public void SetPhoneNum(string PhoneNum) { phonenum_ = PhoneNum; }
        public void SetOnlineState(bool State) { isOnline_ = State; }

        public void Logout()
        {
            System.Console.WriteLine("Are you sure to log out(Y/N)?\n");
            string tmp = System.Console.ReadLine();
            if (tmp == "Y")
            {
                isOnline_ = false;
            }
        }

        public List<Goods> buylist = new List<Goods>();
        //  private  
        private string accountName_;
        private string safetycode_;    // 注意：存 "安全碼" 非密碼
        private string userName_;   //使用者姓名
        private string email_;
        private string id_;      // 身分證字號
        private string phonenum_;
        private bool isOnline_ = false;
        private string Cypher(string pt)
        {
            MD5 md5Hash = MD5.Create();
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(pt)); // 把明文轉換成byte[]並hash
            StringBuilder ct = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                ct.Append(data[i].ToString("x2")); //把hash過的byte[]轉成16進位表示的string
            }

            return ct.ToString();
        }
    }
}