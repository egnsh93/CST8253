using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

/// <summary>
/// Summary description for Account
/// </summary>
public class Account
{
    private double balance;
    public double Balance { get { return balance; } }

    private ArrayList transactionHistories;
    public ArrayList TransactionHistories { get { return ArrayList.ReadOnly(transactionHistories); } }

    public Account()
    {
        balance = 0.0;
        transactionHistories = new ArrayList();
    }
    public Account(double initialBalance)
    {
        balance = initialBalance;
        transactionHistories = new ArrayList();
    }
    public virtual TransactionResult deposit(DepositTransaction depositTransaction)
    {
        balance += depositTransaction.TransactionAmount;
        transactionHistories.Add(depositTransaction);
        return TransactionResult.SUCCESS;
    }

    public virtual TransactionResult withdraw(WithdrawTransaction withdrawTransaction)
    {
        if (withdrawTransaction.TransactionAmount > this.balance)
        {
            return TransactionResult.INSUFFICIENT_FUND;
        }
        balance -= withdrawTransaction.TransactionAmount;
        transactionHistories.Add(withdrawTransaction);

        return TransactionResult.SUCCESS;
    }
}