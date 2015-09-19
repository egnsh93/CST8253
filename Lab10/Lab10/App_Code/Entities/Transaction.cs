using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Transaction
/// </summary>
public abstract class Transaction
{
    public string Memo { get; set; }

    private DateTime transactionDate;
    public DateTime TransactionDate { get { return transactionDate; } }

    private Account targetAccount;
    public Account TargetAccount { get { return targetAccount; } }

    private double transactionAmount;
    public double TransactionAmount { get { return transactionAmount; } }


    public Transaction(Account targetAccount, double transactionAmount)
    {
        this.targetAccount = targetAccount;
        this.transactionAmount = transactionAmount;

        transactionDate = DateTime.Now;
    }

    public abstract TransactionResult completeTransaction();
}