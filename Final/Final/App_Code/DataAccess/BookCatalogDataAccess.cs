using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.IO;

/// <summary>
/// Summary description for BookDataAccess
/// </summary>
public class BookCatalogDataAccess
{
    public static ArrayList GetAllBooks()
    {
        ArrayList books = new ArrayList();
        StreamReader sr = null;
        try
        {
            string path = HttpContext.Current.Request.PhysicalApplicationPath;
            string filePath = path + @"\App_Data\BookCatalog.txt";

            FileStream bookFile = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            sr = new StreamReader(bookFile);
            while (!sr.EndOfStream)
            {
                string id = sr.ReadLine();
                string title = sr.ReadLine();
                string description = sr.ReadLine();
                double price = double.Parse(sr.ReadLine());

                Book book = new Book(id, title, price);
                book.Description = description;

                books.Add(book);
            }
        }
        finally
        {
            if (sr != null)
            {
                sr.Close();
            }
        }
        return books;
    }

    public static Book GetBookById(string bookId)
    {
        ArrayList books = GetAllBooks();
        foreach (Book book in books)
        {
            if (string.Compare(book.Id.Trim(), bookId.Trim(), true) == 0)
            {
                return book;
            }
        }
        return null;
    }
}