using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customer
/// </summary>
public class Customer
{
    private CheckingAccount checkingAccount;
    public CheckingAccount Checking { get { return checkingAccount; } }

    private SavingAccount savingAccount;
    public SavingAccount Saving { get { return savingAccount; } }

    private string id;
    public string Id { get { return id; } }

    private string name;
    public string Name { get { return name; } }

    public Customer(string name)
    {
        this.name = name;
        this.checkingAccount = new CheckingAccount();
        this.savingAccount = new SavingAccount();
    }

    public Customer(string id, string name, CheckingAccount checkingAccount, SavingAccount savingAccount)
    {
        this.id = id;
        this.name = name;
        this.checkingAccount = checkingAccount;
        this.savingAccount = savingAccount;
    }

    public override string ToString()
    {
        return id + " - " + name;
    }
}