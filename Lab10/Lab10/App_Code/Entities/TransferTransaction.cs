using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TransferTransaction
/// </summary>
public class TransferTransaction : DepositTransaction
{
    private WithdrawTransaction withdrawTransacation;
    public WithdrawTransaction WithdrawTransacation { get { return withdrawTransacation; } }

    public TransferTransaction(Account fromAccount, Account targetAccount, double transactionAmount)
        : base(targetAccount, transactionAmount)
    {
        Memo = "Transfer In";

        withdrawTransacation = new WithdrawTransaction(fromAccount, transactionAmount);
        withdrawTransacation.Memo = "Transfer Out";
    }

    public override TransactionResult completeTransaction()
    {
        TransactionResult withdrawResult = withdrawTransacation.TargetAccount.withdraw(withdrawTransacation);
        if (withdrawResult == TransactionResult.SUCCESS)
        {
            base.TargetAccount.deposit(this);
            return TransactionResult.SUCCESS;
        }
        else
        {
            return withdrawResult;
        }
    }
}