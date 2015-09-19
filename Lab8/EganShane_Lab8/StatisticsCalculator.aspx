<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StatisticsCalculator.aspx.cs" Inherits="EganShane_Lab8.StatisticsCalculator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lab 8 - Statistics Calculator</title>
    <link href="App_Themes/Default/SiteStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="siteContainer">
        <asp:Literal ID="litPageHeader" Text="<h1>Statistics Calculator</h1>" runat="server"></asp:Literal>
        <asp:Literal ID="litPageDesc" Text="<p>Enter three numbers and click the Submit button to find out the statistics</p>" runat="server"></asp:Literal>

        <form id="frmStatistics" runat="server">
            <div class="frmControls">
                <div class="frmField marginBottom10">
                    <asp:Label ID="lblFirstNum" runat="server" CssClass="frmLabel" Text="First Number:"></asp:Label>
                    <asp:TextBox ID="txtFirstNum" runat="server" CssClass="frmTxtField"></asp:TextBox>
                </div>

                <div class="frmField marginBottom10">
                    <asp:Label ID="lblSecondNum" runat="server" CssClass="frmLabel" Text="Second Number:"></asp:Label>
                    <asp:TextBox ID="txtSecondNum" runat="server" CssClass="frmTxtField"></asp:TextBox>
                </div>
                <div class="frmField marginBottom10">
                    <asp:Label ID="lblThirdNum" runat="server" CssClass="frmLabel" Text="Third Number:"></asp:Label>
                    <asp:TextBox ID="txtThirdNum" runat="server" CssClass="frmTxtField"></asp:TextBox>
                </div>

                <asp:Button ID="btnSubmit" runat="server" Text="Submit" />
            </div>
        </form>

        <asp:Label ID="lblError" runat="server" CssClass="error" Text="Input string was not in a correct format"></asp:Label>

        <asp:Literal ID="litSubmitHeader" Text="<h2>Statistics of the numbers you entered</h2>" runat="server"></asp:Literal>
        <asp:Label ID="lblMax" runat="server" Text="Maximum: " CssClass="resultLabel marginBottom10"></asp:Label>
        <asp:Label ID="lblMin" runat="server" Text="Minimum: " CssClass="resultLabel marginBottom10"></asp:Label>
        <asp:Label ID="lblAvg" runat="server" Text="Average: " CssClass="resultLabel marginBottom10"></asp:Label>
        <asp:Label ID="lblTotal" runat="server" Text="Total: " CssClass="resultLabel marginBottom10"></asp:Label>
    </div>
</body>
</html>
