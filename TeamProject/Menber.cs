using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TeamProject
{
     class Member
     {
          //  constructer
          public Member() {
               Clear();
          }
          public Member(string accountName , string safetycode , string userName , string email , string id , string phonenum)
          {
               accountName_ = accountName;
               safetycode = safetycode_;
               userName_ = userName;
               email_ = email;
               id_ = id;
               phonenum_ = phonenum;
          }

          public string accountname  { get { return accountName_; }  }
          public string safetycode { get { return safetycode_; } }
          public string username { get { return userName_; } }
          public string email { get { return email_; } }
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
          public void SetSafetyCode(string SafetyCode) { safetycode_ = SafetyCode; }
          public void SetUserName(string UserName) { userName_ = UserName; }
          public void SetEmail(string Email) { email_ = Email; }
          public void SetId(string Id) { id_ = Id; }
          public void SetPhoneNum(string PhoneNum) { phonenum_ = PhoneNum; }
          public void SetOnlineState(bool State) { isOnline_ = State; }

          public List<Goods> buylist = new List<Goods>();
          //  private  
          private string accountName_;
          private string safetycode_;    // 注意：存 "安全碼" 非密碼
          private string userName_;   //使用者姓名
          private string email_;
          private string id_;      //身分證字號
          private string phonenum_;
          private bool isOnline_ = false;

     }
}