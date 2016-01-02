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

        public bool AddMember(Member m)
        {
            for(int i = 0; i < members.Count; i = i + 1)
            {
                if (string.Compare(members[i].accountname,m.accountname)==0 )
                {
                    return false;
                }
            }
            members.Add(m);
            return true;
        }
        public bool DeleteMember(Member m)
        {
            if (!members.Contains(m) || members.Count==0 )
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
        public Member GetOneMember(int index)
        {
            if (index >= members.Count() || index < 0) return null;
            return members[index];
        }
        public bool Login()
        {
            string account, password;
            System.Console.WriteLine("Please input your ID number\n");
            account = System.Console.ReadLine();
            System.Console.WriteLine("Please input your password\n");
            password = System.Console.ReadLine();
            bool found = false;
            for (int i = 0; i < GetNumberofMembers(); i++)
            {
                if (String.Compare(account, GetOneMember(i).accountname) == 0)
                {
                    found = true;
                    if (String.Compare(Member.Cypher(password), GetOneMember(i).safetycode) == 0)
                    {
                        Random crandom = new Random();
                        int tmpinput = crandom.Next(),input;
                        System.Console.WriteLine("Please input the following word\n");
                        System.Console.WriteLine(tmpinput);
                        input = System.Console.Read();
                        if (input == tmpinput)
                        {
                            GetOneMember(i).SetOnlineState(true);
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
            }
            if (!found)
            {
                System.Console.WriteLine("This account does not exist\n");
            }

            return false;
        }

    }
}
