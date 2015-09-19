/*************************************************************************/
/**                                                                     **/
/**                                                                     **/
/**    Student Name                :  Shane Egan                        **/
/**    EMail Address               :  egan0049@algonquinlive.com        **/
/**    Student Number              :  040 695 345                       **/
/**    Course Number               :  CST 8253                          **/
/**    Lab Section Number          :  011                               **/
/**    Professor Name              :  Wei Gong                          **/
/**    Assignment Name/Number/Date :  Lab 6 - OOP Design (Mar 13 2015)  **/
/**    Optional Comments           :                                    **/
/**                                                                     **/
/**                                                                     **/
/*************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using EganShane_Lab6.Entities;

namespace EganShane_Lab6
{
    class BankingSystem
    {
        public void Run()
        {
            Console.WriteLine("Welcome to the Algonquin Banking System!");
            Console.Write("\nEnter Customer Name: ");

            // Intantiate a new customer object with the customers name
            var customer = new Customer(Console.ReadLine());

            var menuSelection = 0;

            do
            {
                // Display Option Menu
                DisplayMenu();

                // Get the user's menu selection
                menuSelection = Convert.ToInt32(Console.ReadLine());

                switch (menuSelection)
                {
                    case 1:
                        // Customer wants to make a deposit
                        CustomerDeposit(customer);
                        break;
                    case 2:
                        // Customer wants to make a withdrawl
                        CustomerWithdraw(customer);
                        break;
                    case 3:
                        // Customer wants to transfer funds
                        CustomerTransfer(customer);
                        break;
                    case 4:
                        // Customer wants to check account activity
                        CustomerActivityEnquiry(customer);
                        break;
                    case 5:
                        // Customer wants to check account balance
                        CustomerBalanceEnquiry(customer);
                        break;
                    case 6:
                        Console.WriteLine("\n Thank you for using the Algonquin College Banking System!");
                        break;
                    default:
                        // Invalid, please try again
                        Console.WriteLine("Invalid selection! Enter 1 to 6 online!");
                        break;
                }
            } while (menuSelection != 6);

            Console.ReadKey();
        }

        public void CustomerDeposit(Customer name)
        {
            // Get the destination account
            Console.Write("\n Select account (1 - to Checkings Account, 2 - to Savings Account): ");
            var selection = Convert.ToInt32(Console.ReadLine());
            var destinationAccount = selection == 1 ? (Account) name.GetCheckingsAccount() : (Account) name.GetSavingsAccount();

            // Get the deposit amount
            Console.Write("\n Enter Amount: ");
            var depositAmount = Convert.ToDouble((Console.ReadLine()));

            // Create a new transaction with the deposit info
            Transaction depositTransaction = new DepositTransaction(destinationAccount, depositAmount);

            // Deposit the money into the account
            depositTransaction.FinalizeTransaction();
            Console.WriteLine("\n\tDeposit Completed");
        }

        public void CustomerWithdraw(Customer name)
        {
            // Get the source account
            Console.Write("\n Select account (1 - from Checkings Account, 2 - from Savings Account): ");
            var selection = Convert.ToInt32(Console.ReadLine());
            var sourceAccount = selection == 1 ? (Account)name.GetCheckingsAccount() : (Account)name.GetSavingsAccount();

            // Get the withdraw amount
            Console.Write("\n Enter Amount: ");
            var withdrawAmount = Convert.ToDouble((Console.ReadLine()));

            // Create a new transaction with the withdraw info
            var withdrawTransaction = new WithdrawTransaction(sourceAccount, withdrawAmount).FinalizeTransaction();

            if (withdrawTransaction == TransactionResult.Success)
            {
                Console.WriteLine("\n\tWithdrawl Completed");
            }
            else
            {
                Console.WriteLine("\n\tInsufficient funds, account balance $" + sourceAccount.GetAccountBalance());
            }
        }

        public void CustomerTransfer(Customer name)
        {
            // Get the account to transfer between
            Console.Write("\n Select account (1 - Checkings to Savings, 2 - Savings to Checkings): ");
            var selection = Convert.ToInt32(Console.ReadLine());

            Account sourceAccount;
            Account destinationAccount;

            switch (selection)
            {
                case 1:
                    sourceAccount = name.GetCheckingsAccount();
                    destinationAccount = name.GetSavingsAccount();
                    break;
                default:
                    sourceAccount = name.GetSavingsAccount();
                    destinationAccount = name.GetCheckingsAccount();
                    break;
            }

            // Get the transfer amount
            Console.Write("\n Enter Amount: ");
            var transferAmount = Convert.ToDouble((Console.ReadLine()));

            // Create a new transaction with the transfer info
            var transferTransaction = new TransferTransaction(sourceAccount, destinationAccount, transferAmount).FinalizeTransaction();

            if (transferTransaction == TransactionResult.Success)
            {
                Console.WriteLine("\n\tTransfer Completed");
            }
            else
            {
                Console.WriteLine("\n\tInsufficient funds, account balance $" + sourceAccount.GetAccountBalance());
            }
        }

        public void CustomerActivityEnquiry(Customer name)
        {
            Console.WriteLine("\n Checkings Account");
            Console.WriteLine("\n\tAccount\t\tDate\t\tActivity");
            Console.WriteLine("\t-------\t\t----\t\t--------");

            foreach (var transaction in name.GetCheckingsAccount().GetAccountActivity())
            {
                Console.WriteLine("\t$" + transaction.GetAmount() + "\t\t" + transaction.GetDate().ToString("MM/dd/yyyy") + "\t" + transaction.GetDescription());
            }


            Console.WriteLine("\n\n Savings Account");
            Console.WriteLine("\n\tAccount\t\tDate\t\tActivity");
            Console.WriteLine("\t-------\t\t----\t\t--------");

            foreach (var transaction in name.GetSavingsAccount().GetAccountActivity())
            {
                Console.WriteLine("\t$" + transaction.GetAmount() + "\t\t" + transaction.GetDate().ToString("MM/dd/yyyy") + "\t" + transaction.GetDescription());
            }
        }

        public void CustomerBalanceEnquiry(Customer name)
        {
            Console.WriteLine("\n Current balance" );
            Console.WriteLine("\n\tAccount\t\t\tBalance");
            Console.WriteLine("\t-------\t\t\t-------");

            Console.WriteLine("\tCheckings\t\t$" + name.GetCheckingsAccount().GetAccountBalance());
            Console.WriteLine("\tSavings\t\t\t$" + name.GetSavingsAccount().GetAccountBalance());
        }

        public void DisplayMenu()
        {
            Console.WriteLine("\nSelect one of the following activities:\n");
            Console.WriteLine(" 1. Deposit ...");
            Console.WriteLine(" 2. Withdraw ...");
            Console.WriteLine(" 3. Transfer ...");
            Console.WriteLine(" 4. Account Activity Enquiry ...");
            Console.WriteLine(" 5. Balance Enquiry ...");
            Console.WriteLine(" 6. Exit ...");
            Console.Write("\n Enter your selection: ");
        }

        public static void Exit()
        {
            Environment.Exit(0);
        }
    }
}
