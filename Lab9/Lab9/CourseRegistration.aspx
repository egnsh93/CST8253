<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CourseRegistration.aspx.cs" Inherits="CourseRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Algonquin Course Registration System</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />
</head>
<body>
    <asp:Literal ID="litPageTitle" Text="<h1>Algonquin College Course Registration</h1>" runat="server"></asp:Literal>

    <form id="frmCourseRegistration" runat="server">
        <asp:Label ID="lblStudentName" runat="server" Text="Student Name:"></asp:Label>
        <asp:TextBox ID="txtStudentName" CssClass="input" runat="server"></asp:TextBox>

        <asp:Panel ID="pnlStudentType" CssClass="displayInline marginLeft15" runat="server">
            <asp:RadioButton ID="radFullTime" GroupName="studentType" Text="Full Time" runat="server" Checked="True" />
            <asp:RadioButton ID="radPartTime" GroupName="studentType" Text="Part Time" runat="server" />
            <asp:RadioButton ID="radCoop" GroupName="studentType" Text="Co-op" runat="server" />
        </asp:Panel>
        
        <asp:Literal ID="litTextAboveCourses" Text="<p>The following courses are currently available for registration</p>" runat="server"></asp:Literal>
        <asp:Label ID="lblError" CssClass="error" runat="server"></asp:Label>
        <asp:PlaceHolder ID="phAvailableCourses" runat="server"></asp:PlaceHolder>
        
        <br/>

        <asp:Button ID="btnSubmit" CssClass="button" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    </form>
    
    <div id="studentInfo" runat="server">
        <p>Thank you <asp:Label ID="lblStudentInfoName" CssClass="emphsis" runat="server"></asp:Label>, for using our online registration system.</p>
        <p>You have been registered as a <asp:Label ID="lblStudentInfoType" CssClass="distinct" runat="server"></asp:Label> for the following courses</p>
        <asp:Table ID="tblCourses" CssClass="table" runat="server"></asp:Table>
    </div>

</body>
</html>
