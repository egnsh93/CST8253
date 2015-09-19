using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Book
/// </summary>
public class Book
{
    private string id;
    public string Id { get { return id; } }

    private string title;
    public string Title { get { return title; } }

    public string Description { get; set; }

    private double price;
    public double Price { get { return price; } }

    public Book(string id, string title, double price)
    {
        this.id = id;
        this.title = title;
        this.price = price;
    }

    public override string ToString()
    {
        return Title + " - $" + Price; 
    }
}