using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.IO;

/// <summary>
/// Summary description for CustomerDataAccess
/// </summary>
public static class CustomerDataAccess
{
	public static ArrayList getAllCustomers()
    {
        ArrayList customers = new ArrayList();
        StreamReader sr = null;
        try
        {
            string path = HttpContext.Current.Request.PhysicalApplicationPath;
            string[] files = Directory.GetFiles(path + "\\App_Data");
            foreach (string file in files)
            {
                FileStream customerFile = new FileStream(file, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(customerFile);

                //Read customer ID
                string id = sr.ReadLine();

                //Read customer name
                string name = sr.ReadLine();

                //Read account balances
                double checkingBalance = double.Parse(sr.ReadLine());
                double savingBalances = double.Parse(sr.ReadLine());

                //restore accounts
                CheckingAccount checkingAccount = new CheckingAccount(checkingBalance);
                SavingAccount savingAccount = new SavingAccount(savingBalances);

                //restore customer
                Customer customer = new Customer(id, name, checkingAccount, savingAccount);

                customers.Add(customer);
                sr.Close();
            }
        }
        finally
        {
            if (sr != null)
            {
                sr.Close();
            }
        }
        return customers;
    }
    public static Customer getCustomerById(string id)
    {
        ArrayList customers = getAllCustomers();
        foreach (Customer customer in customers)
        {
            if (customer.Id.ToUpper() == id.ToUpper())
            {
                return customer;
            }
        }
        return null;
    }
    public static Customer getCustomerByName(string name)
    {
        ArrayList customers = getAllCustomers();
        foreach (Customer customer in customers)
        {
            if (customer.Name.ToUpper() == name.ToUpper())
            {
                return customer;
            }
        }
        return null;
    }
    public static void saveCustomer(Customer customer)
    {
        if (customer == null)
            return;

        StreamWriter sw = null;
        try
        {
            if (!Directory.Exists(@"..\App_Data"))
            {
                Directory.CreateDirectory(@"..\App_Data");
            }
            string fileName = "Customer" + customer.Id + ".txt";

            FileStream customerFile = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            sw = new StreamWriter(customerFile);

            //write customer id
            sw.WriteLine(customer.Id);

            //write customer name
            sw.WriteLine(customer.Name);

            //write balances
            sw.WriteLine(customer.Checking.Balance);
            sw.WriteLine(customer.Saving.Balance);
        }
        catch (IOException e)
        {
            Console.WriteLine("An IO exception has been thrown!");
            Console.WriteLine(e.ToString());
        }
        finally
        {
            if (sw != null)
            {
                sw.Close();
            }
        }
    }
}