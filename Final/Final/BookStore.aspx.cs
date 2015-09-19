using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookStore : System.Web.UI.Page
{
    private Book _book;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //start with an empty shopping cart.
            ShoppingCart cart = ShoppingCart.RetrieveShoppingCart();
            cart.EmptyShoppingCart();

            //get all books in the catalog.
            ArrayList books = BookCatalogDataAccess.GetAllBooks();
            PopulateDropdown(books);
        }
    }

    protected void PopulateDropdown(ArrayList books)
    {
        // Add default item to drop down list
        var defaultItem = new ListItem
        {
            Selected = true,
            Value = "-1",
            Text = "Select a Book..."
        };

        ddlBookSelection.Items.Add(defaultItem);

        // Iterate through each customer and populate the dropdown list
        foreach (var listItem in from Book book in BookCatalogDataAccess.GetAllBooks()
                                 select new ListItem
                                 {
                                     Value = book.Id,
                                     Text = book.Title
                                 })
        {
            // Add the list item to the dropdown list
            ddlBookSelection.Items.Add(listItem);
        }
    }

    protected void ddlBookSelection_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Get the selected book object
        _book = BookCatalogDataAccess.GetBookById(ddlBookSelection.SelectedValue);

        // Output the book description and price
        desc.InnerText = _book.Description;
        lblPrice.Text = Convert.ToString("$" + _book.Price, CultureInfo.InvariantCulture);
    }
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        desc.InnerText = "";

        var book = BookCatalogDataAccess.GetBookById(ddlBookSelection.SelectedValue);

        // Add the book to an order
        BookOrder order = new BookOrder(book, Convert.ToInt32(txtQuantity.Text));

        // Add the order to the cart
        ShoppingCart cart = ShoppingCart.RetrieveShoppingCart();
        cart.AddBookOrder(order);

        var itemText = " item";
        var copyText = " copy";

        if (cart.NumOfItems > 1)
        {
            itemText = " items";
            copyText = " copies";
        }

        // Display confirmation
        desc.InnerText = txtQuantity.Text + copyText + "  of " + book.Title + " is added to the shopping cart";

        // Update the cart item count
        btnViewCart.Text = "View Cart (" + cart.NumOfItems + itemText + ")";

        // Update the dropdown
        ddlBookSelection.Items.RemoveAt(ddlBookSelection.SelectedIndex);
        ddlBookSelection.SelectedValue = "-1";
    }
    protected void btnViewCart_Click(object sender, EventArgs e)
    {
        pnlBookSelectionView.Visible = false;
        pnlShoppingCartView.Visible = true;

        // Generate the table header
        var tHead = new TableHeaderRow();
        tblCart.Rows.Add(tHead);

        var tHeadCellTitle = new TableHeaderCell();
        var tHeadCellQuantity = new TableHeaderCell();
        var tHeadCellSubtotal = new TableHeaderCell();

        tHeadCellTitle.Text = "Title";
        tHeadCellQuantity.Text = "Quantity";
        tHeadCellSubtotal.Text = "Subtotal";

        tHead.Cells.Add(tHeadCellTitle);
        tHead.Cells.Add(tHeadCellQuantity);
        tHead.Cells.Add(tHeadCellSubtotal);
        
        ShoppingCart cart = ShoppingCart.RetrieveShoppingCart();

        if (cart.IsEmpty)
        {
            var tRow = new TableRow();
            tblCart.Rows.Add(tRow);

            var tCell = new TableCell();

            tCell.ColumnSpan = 3;
            tCell.HorizontalAlign = HorizontalAlign.Center;
            tCell.Text = "<span class='error'>Your shopping Cart is Empty</span>";
            tRow.Cells.Add(tCell);
        }

        // Table generation loop
        foreach (BookOrder order in cart.BookOrders)
        {
            // Start creating the table rows
            var tRow = new TableRow();
            tblCart.Rows.Add(tRow);

            // Now the table cells
            var tCellTitle = new TableCell();
            var tCellQuantity = new TableCell();
            var tCellSubtotal = new TableCell();

            tCellTitle.Text = order.Book.Title;
            tCellQuantity.Text = Convert.ToString(order.NumOfCopies);
            tCellSubtotal.Text = Convert.ToString(String.Format("{0:C0}", order.Book.Price * order.NumOfCopies));

            tRow.Cells.Add(tCellTitle);
            tRow.Cells.Add(tCellQuantity);
            tRow.Cells.Add(tCellSubtotal);
        }

        if (!cart.IsEmpty)
        {
            // Generate the table footer
            var tFoot = new TableRow();
            tblCart.Rows.Add(tFoot);

            var tFootTotalLabel = new TableCell();
            var tFootTotal = new TableCell();

            tFootTotalLabel.Text = "Total";
            tFootTotalLabel.HorizontalAlign = HorizontalAlign.Right;
            tFootTotalLabel.ColumnSpan = 2;
            tFootTotal.Text = Convert.ToString("$" + cart.TotalAmountPayable);

            tFoot.Cells.Add(tFootTotalLabel);
            tFoot.Cells.Add(tFootTotal);
        }
    }
}