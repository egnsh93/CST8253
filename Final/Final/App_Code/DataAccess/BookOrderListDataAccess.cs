using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.IO;

/// <summary>
/// Summary description for ShoppingCartDataAccess
/// </summary>
public class BookOrderListDataAccess
{
    private const string BookOrderListFile = @"\App_Data\BookOrderList.txt";

    public static void SaveBookOrder(BookOrder bookOrder)
    {
        ArrayList orders = RetrieveAllBookOrders();
        orders.Add(bookOrder);
        SaveBookOrders(orders);
    }

    public static ArrayList RetrieveAllBookOrders()
    {
        ArrayList orders = new ArrayList();
        StreamReader sr = null;
        try
        {
            string path = HttpContext.Current.Request.PhysicalApplicationPath;
            string filePath = path + @"\App_Data\BookOrderList.txt";
            if (!File.Exists(filePath))
            {
                return orders;
            }
            FileStream bookOrderList = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            sr = new StreamReader(bookOrderList);
            while (!sr.EndOfStream)
            {
                string bookId = sr.ReadLine();
                int quantity = int.Parse(sr.ReadLine());

                Book book = BookCatalogDataAccess.GetBookById(bookId);
                BookOrder bookOrder = new BookOrder(book, quantity);

                orders.Add(bookOrder);
            }
        }
        catch (Exception)
        {
            ClearBookOrderList();
        }
        finally
        {
            if (sr != null)
            {
                sr.Close();
            }
        }
        return orders;
    }

    public static void ClearBookOrderList()
    {
        string path = HttpContext.Current.Request.PhysicalApplicationPath;
        string filePath = path + @"\App_Data\BookOrderList.txt";
        File.Delete(filePath);
    }

    private static void SaveBookOrders(ArrayList orders)
    {
        StreamWriter sw = null;
        try
        {
            string path = HttpContext.Current.Request.PhysicalApplicationPath;
            string filePath = path + @"\App_Data\BookOrderList.txt";

            FileStream shoppoingCartFile = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            sw = new StreamWriter(shoppoingCartFile);

            foreach (BookOrder order in orders)
            {
                //write customer id
                sw.WriteLine(order.Book.Id);

                //write customer name
                sw.WriteLine(order.NumOfCopies);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("An IO exception has been thrown!");
            Console.WriteLine(e.ToString());
        }
        catch (Exception e)
        {
            Console.WriteLine("A gneral exception has been thrown!");
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