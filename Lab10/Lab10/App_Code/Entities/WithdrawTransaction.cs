using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for WithdrawTransaction
/// </summary>
public class WithdrawTransaction : Transaction
{
    public WithdrawTransaction(Account targetAccount, double transactionAmount)
        : base(targetAccount, transactionAmount)
    {
        Memo = "Withdraw";
    }

    public override TransactionResult completeTransaction()
    {
        return base.TargetAccount.withdraw(this);
    }
}