<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FundTransfer.aspx.cs" Inherits="FundTransfer" EnableViewState="True" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lab 10 - Online Fund Transfer Service</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />
</head>
<body>
    
    <asp:Literal ID="litPageTitle" Text="<h1>Online Fund Transfer Service</h1>" runat="server"></asp:Literal>

    <form id="frmWizard" runat="server">
        <asp:Wizard ID="wizFunds" CssClass="wizard" runat="server" ActiveStepIndex="1" OnNextButtonClick="wizFunds_NextButtonClick" OnFinishButtonClick="wizFunds_FinishButtonClick">
            <SideBarStyle CssClass="SideBar"></SideBarStyle>
            <SideBarButtonStyle CssClass="SideBarButton"></SideBarButtonStyle>
            <StartNextButtonStyle CssClass="button"></StartNextButtonStyle>
            <StepNextButtonStyle CssClass="button"></StepNextButtonStyle>
            <StepPreviousButtonStyle CssClass="button"></StepPreviousButtonStyle>
            <FinishPreviousButtonStyle CssClass="button"></FinishPreviousButtonStyle>
            <FinishCompleteButtonStyle CssClass="button"></FinishCompleteButtonStyle>

            <WizardSteps>
                <asp:WizardStep ID="wizStep1" runat="server" Title="Transfer Info" StepType="Start">
                    <asp:Panel ID="pnlStep1" runat="server" CssClass="wizardStepField">
                        <fieldset>
                            <legend class="LargeDistinct">Transferor</legend>
                            <asp:RequiredFieldValidator
                                ID="rqvTransferor"
                                runat="server"
                                ForeColor="Red"
                                Display="Dynamic"
                                ControlToValidate="ddlTransferor"
                                EnableClientScript="true"
                                InitialValue="-1"
                                ErrorMessage="Must Select One"/>

                            <asp:DropDownList ID="ddlTransferor" CssClass="dropdown" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTransferor_SelectedIndexChanged" ></asp:DropDownList>
                            <asp:Label ID="lblFromAccount" runat="server" CssClass="label" Text="From Account:"></asp:Label>
                            <asp:RadioButtonList ID="rblFromAccount" CssClass="mTop15 mBottom15" runat="server">
                                <asp:ListItem Selected="True" Text="Checking"></asp:ListItem>
                                <asp:ListItem Text="Saving"></asp:ListItem> 
                            </asp:RadioButtonList>
                            <asp:Label ID="lblAmount" runat="server" Text="Amount:"></asp:Label>
                            <asp:TextBox ID="txtAmount" CssClass="input" runat="server"></asp:TextBox>

                            <asp:RequiredFieldValidator
                                ID="rqvAmount"
                                runat="server"
                                ForeColor="Red"
                                Display="Dynamic"
                                ControlToValidate="txtAmount"
                                EnableClientScript="true"
                                ErrorMessage="Cannot be blank"/>
                            
                            <asp:RangeValidator
                                ID="rqvAmountRange"
                                runat="server"
                                ForeColor="Red"
                                Display="Dynamic"
                                ControlToValidate="txtAmount"
                                EnableClientScript="true"
                                Text="Invalid Amount" />
                        </fieldset>
                    </asp:Panel>
                </asp:WizardStep>

                <asp:WizardStep ID="wizStep2" runat="server" Title="Transfer Date">
                    <asp:Panel ID="pnlStep2" runat="server" CssClass="wizardStepField">
                        <fieldset>
                            <legend class="LargeDistinct">Transfer Date</legend>
                            <asp:Calendar ID="calTransferDate" runat="server" BorderColor="Black" BorderStyle="Solid" CellSpacing="1" Font-Size="9pt" ForeColor="Black" Height="250px" NextPrevFormat="ShortMonth" Width="300px" OnDayRender="calTransferDate_DayRender" OnSelectionChanged="calTransferDate_SelectionChanged">
                                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
                                <DayStyle BackColor="#CCCCCC" />
                                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
                                <OtherMonthDayStyle ForeColor="#999999" />
                                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt" ForeColor="White" Height="12pt" />
                                <TodayDayStyle BackColor="#999999" ForeColor="White" />
                            </asp:Calendar>
                            <asp:Label ID="lblTransferOn" runat="server" Text="Transfer On:"></asp:Label>
                            <asp:TextBox ID="txtTransferOn" runat="server" CssClass="mTop15" Enabled="False"></asp:TextBox>
                        </fieldset>
                    </asp:Panel>
                </asp:WizardStep>

                <asp:WizardStep ID="wizStep3" runat="server" Title="Transferee Info">
                    <asp:Panel ID="pnlStep3" runat="server" CssClass="wizardStepField">
                        <fieldset>
                            <legend class="LargeDistinct">Transferee</legend>
                            <asp:DropDownList ID="ddlTransferee" CssClass="dropdown" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTransferee_SelectedIndexChanged"></asp:DropDownList>
                            <asp:RequiredFieldValidator
                                    ID="rqvTransferee"
                                    runat="server"
                                    ForeColor="Red"
                                    Display="Dynamic"
                                    ControlToValidate="ddlTransferee"
                                    EnableClientScript="true"
                                    InitialValue="-1"
                                    ErrorMessage="Must Select One"/>
                            <asp:Label ID="lblToAccount" 
                                runat="server" CssClass="label" Text="To Account:"></asp:Label>
                            <asp:RadioButtonList ID="rblToAccount" CssClass="mTop15 mBottom15" runat="server">
                                <asp:ListItem Selected="True" Text="Checking"></asp:ListItem>
                                <asp:ListItem Text="Saving"></asp:ListItem> 
                            </asp:RadioButtonList>
                        </fieldset>
                    </asp:Panel>
                </asp:WizardStep>
                <asp:WizardStep ID="wizStep4" runat="server" Title="Review">
                    <asp:Panel ID="pnlStep4" runat="server" CssClass="wizardStepField">
                        <fieldset>
                            <legend class="LargeDistinct">Review and Complete</legend>
                            <asp:PlaceHolder ID="phReview" runat="server"></asp:PlaceHolder>
                        </fieldset>
                    </asp:Panel>
                </asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>  
    </form>
    
    <asp:Panel ID="pnlConfirm" runat="server">
        <p>Thank you for using Online fund transfer service.</p>
        <p>Print this page for your record:</p>
        <fieldset>
            <legend class="LargeDistinct">Confirmation</legend>
            <asp:PlaceHolder ID="phConfirm" runat="server"></asp:PlaceHolder>
        </fieldset>
    </asp:Panel>

</body>
</html>
