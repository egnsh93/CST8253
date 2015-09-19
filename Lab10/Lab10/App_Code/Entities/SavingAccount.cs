using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SavingAccount
/// </summary>
public class SavingAccount : Account
{
    public static double InterestRate { get; set; }

    public SavingAccount()
    {

    }
    public SavingAccount(double initialBalance)
        : base(initialBalance)
    {
    }
}