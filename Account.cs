using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caselet
{
   public abstract class Account
    {
        public readonly long acc_Number;
        public string name;
        public int balance = 0;
        public Account()
        {
            this.acc_Number = genRandomnum();
           

        }

        //public  void openAccount(){}
        //public  void closeAccount(){}
        //public  void editAccount(){}
        //public  void deposit(){}
        //public  void withdrawal( ){}
        //public  void checkBalance( ){}

        long genRandomnum()
        {
            long acc_num = 0;
            Random r = new Random();
            string w = "";
            int i;
            for (i = 1; i < 13; i++)
            {
                w += r.Next(0, 9).ToString();
            }
            if (w.Length == 12)
            {
                acc_num = Convert.ToInt64(w);

            }
          
            return acc_num;

        }

    }
}
