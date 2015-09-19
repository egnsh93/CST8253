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

using System.Collections.Generic;

namespace EganShane_Lab7.Entities
{
    abstract class Account
    {
        private double _balance;
        private readonly List<Transaction> _transactionHistory;

        protected Account()
        {
            _balance = 0.00;
            _transactionHistory = new List<Transaction>();
        }

        public TransactionResult Deposit(DepositTransaction depositTransaction)
        {
            // Add the deposit amount to the balance
            _balance += depositTransaction.GetAmount();

            // Add the transaction to the list
            _transactionHistory.Add(depositTransaction);

            return TransactionResult.Success;
        }

        public TransactionResult Withdraw(WithdrawTransaction withdrawTransaction)
        {
            // Check for ISF
            if (withdrawTransaction.GetAmount() > _balance)
            {
                return TransactionResult.InsufficientFunds;
            }
            else
            {
                _balance -= withdrawTransaction.GetAmount();
                _transactionHistory.Add(withdrawTransaction);
            }

            return TransactionResult.Success;
        }

        public List<Transaction> GetAccountActivity()
        {
            return _transactionHistory;
        }

        public double GetAccountBalance()
        {
            return _balance;
        }

        public double SetAccountBalance(double balance)
        {
            return _balance += balance;
        }
    }
}
