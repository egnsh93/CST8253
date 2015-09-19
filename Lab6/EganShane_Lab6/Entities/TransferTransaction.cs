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
using System.Text;
using System.Threading.Tasks;

namespace EganShane_Lab6.Entities
{
    class TransferTransaction : DepositTransaction
    {
        private readonly WithdrawTransaction _withdrawTransaction;

        public TransferTransaction(Account sourceAccount, Account destinationAccount, double amount) 
            : base(destinationAccount, amount)
        {
            SetDescription("Transfer In");
            _withdrawTransaction = new WithdrawTransaction(sourceAccount, amount);
            _withdrawTransaction.SetDescription("Transfer Out");
        }

        public override TransactionResult FinalizeTransaction()
        {
            // Withdraw the funds from the source account
            var withdrawTransaction = GetWithdrawTransaction().GetDestinationAccount().Withdraw(_withdrawTransaction);

            // Check to see if there was enough funds
            if (withdrawTransaction == TransactionResult.InsufficientFunds) return withdrawTransaction;
            
            // If yes, deposit into the destination account
            GetDestinationAccount().Deposit(this);

            // Return success message
            return TransactionResult.Success;
        }

        public WithdrawTransaction GetWithdrawTransaction()
        {
            return _withdrawTransaction;
        }
    }
}
