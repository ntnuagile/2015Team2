using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class MemberDatabase
    {
        private List<Member> members = new List<Member>();

        public void AddMember(Member m)
        {
            members.Add(m);
        }
        public bool DeleteMember(Member m)
        {
            if (!members.Contains(m))
            {
                return false;
            }
            else
            {
                members.Remove(m);
                return true;
            }
        }
        public Member GetOneMember(Member m)
        {
            if (!members.Contains(m))
            {
                return null;
            }
            int temp = members.IndexOf(m);
            return members[temp];
        }
        public int GetNumberofMembers()
        {
            return members.Count();
        }
        public bool Login()
        {
            string account, password;
            Member log = new Member();
            System.Console.WriteLine("Please input your ID number\n");
            account = System.Console.ReadLine();
            System.Console.WriteLine("Please input your password\n");
            password = System.Console.ReadLine();
            log.SetAccountName(account);
            if (GetOneMember(log) != null)
            {
                if (String.Compare(password, GetOneMember(log).safetycode) == 0)
                {
                    Random crandom = new Random();
                    int tmpinput = crandom.Next(), input;
                    System.Console.WriteLine("Please input the following word\n");
                    System.Console.WriteLine(tmpinput);
                    input = System.Console.Read();
                    if (input == tmpinput)
                    {
                        GetOneMember(log).SetOnlineState(true);
                        return true;
                    }
                    else
                    { System.Console.WriteLine("Wrong word\n"); }
                }
                else
                {
                    System.Console.WriteLine("Wrong password\n");
                }
            }
            else
            {
                System.Console.WriteLine("This account does not exist\n");
            }
            return false;
        }
        public Member GetOneMember(int index)
        {
            if (index >= members.Count() || index < 0) return null;
            return members[index];
        }
    }
}
