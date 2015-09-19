using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CheckingAccount
/// </summary>
public class CheckingAccount : Account
{
    public CheckingAccount()
    {

    }
    public CheckingAccount(double initialBalance)
        : base(initialBalance)
    {
    }
}