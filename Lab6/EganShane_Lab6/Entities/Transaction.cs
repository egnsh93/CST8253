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
    abstract class Transaction
    {
        private readonly Account _destinationAccount;
        private readonly double _amount;
        private readonly DateTime _date;
        private String _description;

        protected Transaction(Account destinationAccount, double amount)
        {
            _destinationAccount = destinationAccount;
            _amount = amount;
            _date = DateTime.Now;
            _description = null;
        }

        public abstract TransactionResult FinalizeTransaction();

        public Account GetDestinationAccount()
        {
            return _destinationAccount;
        }

        public double GetAmount()
        {
            return _amount;
        }

        public DateTime GetDate()
        {
            return _date;
        }

        public String GetDescription()
        {
            return _description;
        }

        public void SetDescription(String description)
        {
            _description = description;
        }
    }
}
