using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BookOrder
/// </summary>
public class BookOrder
{
    private Book book;
    public Book Book { get { return book; } }

    private int numOfCopies;
    public int NumOfCopies { get { return numOfCopies; } }

    public BookOrder(Book book, int numOfCopies)
    {
        this.book = book;
        this.numOfCopies = numOfCopies;
    }
}