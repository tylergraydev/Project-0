//FILE: Account.cs
//NAME: Tyler Gray
//PURPOSE: Creates an account with a balance, and allows modifications to it with adding, subtracting, and adding interest
// Also tracks the commands in an array list and presents it at the end.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_0
{
    class Account
    {
        int numOfTrans; //index for arrays
        double[] transactions = new double[50]; //transaction value
        char[] typeOfTrans = new char[50]; //type of transaction

        public Account()
        {
            
            
        }

        public void deposit(double depositAmount)
        {
          
            transactions[numOfTrans] = depositAmount;
            typeOfTrans[numOfTrans] = 'd';
            numOfTrans = numOfTrans + 1;
        }

        public void withdraw(double withdrawAmount)
        {
            
            transactions[numOfTrans] = -1 * withdrawAmount;
            typeOfTrans[numOfTrans] = 'w';
            numOfTrans = numOfTrans + 1;
        }

        public void addInterest()
        {
            double balance = getBalance();
            transactions[numOfTrans] = (balance * .0005);
            typeOfTrans[numOfTrans] = 'c';
            numOfTrans = numOfTrans + 1;
        }

        public double getBalance()
        {
            double balance=0;
            int i = 0;
            while (i < numOfTrans)
            {
                balance = balance + transactions[i];
                i++;
            }
            return balance;
        }
        public void showTransactions()
        {
            int i = 0;
            while (i < numOfTrans)
            {
                Console.WriteLine("\n" + transactions[i] + " " + typeOfTrans[i]);
                i++;
            }
            
        }

        static void Main(string[] args)
        {
            Account accountOne = new Account();
            bool loop = true;
            string loopKey;
            string command;
            Console.WriteLine("Welcome to the Banking App");
            while (loop == true)
            {
                //Call Functions
                Console.WriteLine("\nPlease select the function you want to perform: \n (D)eposit \n (W)ithdraw \n (C)alculateInterest \n (S)howBlaance \n (Q)uit \n ");
                command = Console.ReadKey().KeyChar.ToString();

                switch (command)
                {
                    case "d":
                    case "D":
                        double depositAmount;
                        Console.WriteLine("\nHow much would you like to deposit?");
                        depositAmount = Convert.ToDouble(Console.ReadLine());
                        accountOne.deposit(depositAmount);
                        break;
                    case "W":
                    case "w":
                        double withdrawAmount;
                        Console.WriteLine("\nHow much would you like to withdraw?");
                        withdrawAmount = Convert.ToDouble(Console.ReadLine());
                        if(withdrawAmount <= accountOne.getBalance())
                        {
                            accountOne.withdraw(withdrawAmount);
                        }
                        else
                        {
                            Console.WriteLine("\nFAILED!! Insuficient Funds!!");
                        }
                        break;
                    case "C":
                    case "c":
                        Console.WriteLine("Added interest of .05% to the account"); //.05% is .0005. Seems Neglible
                        accountOne.addInterest();
                        break;
                    case "S":
                    case "s":
                        Console.WriteLine("\nThe account has a balance of  " + accountOne.getBalance());
                        break;
                    case "q":
                    case "Q":
                        accountOne.showTransactions();
                        System.Threading.Thread.Sleep(5000);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nInvalid Command");
                        break;
                }



                //Check to loop
                Console.WriteLine("Would you like to continue? (Y/N)\n");
                loopKey = Console.ReadKey().KeyChar.ToString();
                if (loopKey == "y" || loopKey == "Y")
                {
                   //Already Loops
                }
                else if (loopKey == "N" || loopKey == "n")
                {
                    loop = false;
                }


             
            }
         
        }
    }
}
