using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DepositTransaction
/// </summary>
public class DepositTransaction : Transaction
{
    public DepositTransaction(Account targetAccount, double transactionAmount)
        : base(targetAccount, transactionAmount)
    {
        Memo = "Deposit";
    }

    public override TransactionResult completeTransaction()
    {
        return base.TargetAccount.deposit(this);
    }
}