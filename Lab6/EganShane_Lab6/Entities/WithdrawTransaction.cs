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
    class WithdrawTransaction : Transaction
    {
        public WithdrawTransaction(Account sourceAccount, double amount)
            : base(sourceAccount, amount)
        {
            SetDescription("Withdraw");
        }

        public override TransactionResult FinalizeTransaction()
        {
            return GetDestinationAccount().Withdraw(this);
        }
    }
}
