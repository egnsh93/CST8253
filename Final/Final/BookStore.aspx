<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookStore.aspx.cs" Inherits="BookStore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Book Store</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet"/>
</head>
<body>
<h1>Algonquin College Online Book Store</h1>
<asp:Panel runat="server" ID="pnlBookSelectionView">
    <form id="frmBookStore" runat="server">
        <div class="leftSidepPan">
            <asp:DropDownList ID="ddlBookSelection" AutoPostBack="true" CssClass="dropdown" runat="server" Width="359px" OnSelectedIndexChanged="ddlBookSelection_SelectedIndexChanged"></asp:DropDownList>
            <asp:RequiredFieldValidator
                ID="rqvBookSelection"
                runat="server"
                ForeColor="Red"
                Display="Dynamic"
                ControlToValidate="ddlBookSelection"
                EnableClientScript="true"
                InitialValue="-1"
                ErrorMessage="Must Select One"/>
            <br/>
            <fieldset>
                <legend>Description</legend>
                <p id="desc" style="font-size: 14px" runat="server"></p>
            </fieldset>
        </div>
        <div class="rightSidePan">
            <div class="priceAndQuantityPan">
                Buy today to get free delivery to your classroom!<br/><br/>
                <span class="distinct">Price: </span>
                <asp:Label ID="lblPrice" CssClass="price" runat="server" Text=""></asp:Label>
                <br/>
                <br/>

                <span class="distinct">Quantity: </span>
                <asp:TextBox ID="txtQuantity" CssClass="input" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator
                    ID="rqvQuantity"
                    runat="server"
                    ForeColor="Red"
                    Display="Dynamic"
                    ControlToValidate="txtQuantity"
                    EnableClientScript="true"
                    ErrorMessage="Required"/>
                <asp:RangeValidator
                    ID="rqvAmountRange"
                    runat="server"
                    ForeColor="Red"
                    Display="Dynamic"
                    ControlToValidate="txtQuantity"
                    EnableClientScript="true"
                    Text="Invalid"
                    Type="Double"
                    MinimumValue="1"
                    MaximumValue="10"
                    SetFocusOnError="True"/>
                <br/>
                <br/> <hr/> <br/>
                <div class="center">
                    <asp:Button ID="btnAddToCart" runat="server" CssClass="button" Text="Add to Cart" OnClick="btnAddToCart_Click"/>
                </div>
            </div>
            <asp:Button ID="btnViewCart" runat="server" CssClass="ViewCartButton" Text="View Cart (0 items)" OnClick="btnViewCart_Click"/>
        </div>
    </form>
</asp:Panel>
<asp:Panel ID="pnlShoppingCartView" runat="server" Visible="false">
    <p>Please review your shopping cart below.</p>
    <asp:Table ID="tblCart" CssClass="table" runat="server"></asp:Table>
</asp:Panel>
</body>
</html>

