using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Caselet
{
    public class CurrentAccount : Account
    {

        int MaxwithdrawalAmount = 50000;
        int MaxDepositAmount = 1000000;
        int minbal = 10000;


        public void createAccount(CurrentAccount obj)
        {
            Console.WriteLine("Enter the username");
            obj.name = Console.ReadLine();
            Console.WriteLine("Enter the amount to be deposited");
            obj.balance = Convert.ToInt32(Console.ReadLine());
            if (obj.balance >= minbal)
            {
                Program.calist.Add(obj);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Savings Account is created successfully ");
                Console.ResetColor();
                Console.WriteLine("AccountNumber:{0}", obj.acc_Number);
                Console.WriteLine("AccountName:{0}", obj.name);
                Console.WriteLine("AccountBalance:{0}", obj.balance);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Amount should be morethan 10000 to create an account");
                Console.ResetColor();
            }
           
        }

        public void editAccount(CurrentAccount obj)
        {
            Console.WriteLine("Enter the account number");
            long numcheck = Convert.ToInt64(Console.ReadLine());
            foreach (var item in Program.calist)
            {
                if (item.acc_Number == numcheck)
                {
                    Console.WriteLine("AccountName:{0}",item.name);
                    Console.WriteLine("Enter the  new username ");
                    item.name = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Your username is modified successfully");
                    Console.ResetColor();
                    Console.WriteLine("AccountName:{0}",item.name);

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter the valid Account number");
                    Console.ResetColor();
                }
            }

        }

        public void deposit(CurrentAccount obj)
        {
            Console.WriteLine("Enter the account number");
            long numcheck = Convert.ToInt64(Console.ReadLine());
            foreach (var item in Program.calist)
            {
                if (item.acc_Number == numcheck)
                {
                    Console.WriteLine("AccountName:{0}",item.name);
                    Console.WriteLine("Enter the amount to be deposited");
                    int deposit = Convert.ToInt32(Console.ReadLine());
                    // To check the amount is in valid range
                    int amnt = 0;
                    //amnt = amnt + deposit;

                    try
                    {
                        if (deposit < MaxDepositAmount)
                        {
                            item.balance += deposit;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Amount is deposited successfully");
                            Console.ResetColor();
                        }

                        else
                        {
                            throw new MaxDepositAmtException("You can not deposit ammount greater than 1000000 ");
                        }
                    }
                    catch(MaxDepositAmtException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ResetColor();

                    }


                }
                else
                {
                    Console.WriteLine("Please enter the valid account number");
                }

            }
        }

        public void withdrawal(CurrentAccount obj)
        {
            Console.WriteLine("Enter the account number");
            long numcheck = Convert.ToInt64(Console.ReadLine());
            foreach (var item in Program.calist)
            {
                if (item.acc_Number == numcheck)
                {
                    Console.WriteLine("AccountName:{0}",item.name);
                    Console.WriteLine("Enter the amount to be Withdrawn");
                    int withdraw = Convert.ToInt32(Console.ReadLine());
                    // To check the amount is in valid range
                    // int amnt = 0;
                    //amnt = amnt + deposit;

                    try
                    {

                        if (withdraw < MaxwithdrawalAmount  )
                        {

                            if ((item.balance - withdraw) > minbal)
                            {
                                item.balance -= withdraw;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Amount is withdrawn successfully");
                                Console.ResetColor();
                            }

                            else
                            {
                                throw new minBalException("Withdrawal Error!-minBalance after withdrawal should be greater than 1000");
                            }
                            
                        }

                        else
                        {
                            throw new MaxwithdrawalAmount("You can not withdraw ammount greater than 50000");
                        }
                    }
                    catch (minBalException e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ResetColor();


                    }

                    catch (MaxwithdrawalAmount e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(e.Message);
                        Console.ResetColor();


                    }


                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please entere the valid account number");
                    Console.ResetColor();
                }

            }

        }

        public void checkBalance(CurrentAccount obj)
        {
            Console.WriteLine("Enter the account number");
            long numcheck = Convert.ToInt64(Console.ReadLine());
            foreach (var item in Program.calist)
            {
                if (item.acc_Number == numcheck)
                {
                    Console.WriteLine("AccountBalance:{0}",item.balance);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter the valid account number");
                    Console.ResetColor();
                }
            }
        }

        public void closeAccount(CurrentAccount obj)
        {
            Console.WriteLine("Enter the account number");
            long numcheck = Convert.ToInt64(Console.ReadLine());
            foreach (var item in Program.calist)
            {
                try
                {
                    if (item.acc_Number == numcheck)
                    {

                        if (item.balance == 0)
                        {
                            Program.calist.Remove(item);
                        }
                        else
                        {
                            throw new AccountCloseException((" To close the Account the balance should be zero"));
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter the valid account number");
                        Console.ResetColor();
                    }
                }
                catch(AccountCloseException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                }
            }
        }


        public void getAccountDetails()
        {
            Console.WriteLine("Enter the account number");
            long numcheck = Convert.ToInt64(Console.ReadLine());
            foreach (var item in Program.calist)
            {
                if (item.acc_Number == numcheck)
                {
                    Console.WriteLine("AccountNumber:{0}", item.acc_Number);
                    Console.WriteLine("AccountName:{0}", item.name);
                    Console.WriteLine("AccountBalance:{0}", item.balance);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter the valid account number");
                    Console.ResetColor();
                }
            }
        }
    }
}


