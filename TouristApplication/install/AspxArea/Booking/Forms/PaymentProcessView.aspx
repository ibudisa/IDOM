<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="PaymentProcessView.aspx.cs" Inherits="V50_IDOMBackOffice.AspxArea.Booking.Forms.PaymentProcessView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="width: 184px">
                <dx:ASPxComboBox ID="comboboxtype" runat="server" TextField="Name" ValueField="Id" ValueType="System.String">
                </dx:ASPxComboBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </br>
    <table style="width: 100%">
        <tr>
            <td style="width: 167px">
                <dx:ASPxComboBox ID="comboboxWayOfPayment" runat="server" TextField="Name" ValueField="Id" ValueType="System.String">
                </dx:ASPxComboBox>
            </td>
            <td>
                <dx:ASPxButton ID="btnSelect" runat="server" Text="Select" OnClick="btnSelect_Click">
                </dx:ASPxButton>
            </td>
        </tr>
    </table>
    </br>
    <table style="width: 100%">
        <tr>
            <td style="width: 73px">Date:</td>
            <td>
                <dx:ASPxDateEdit ID="DateEditPayment" runat="server">
                </dx:ASPxDateEdit>
            </td>
        </tr>
        <tr>
            <td style="width: 73px">Value:</td>
            <td>
                <dx:ASPxTextBox ID="txtValue" runat="server" Width="170px">
                </dx:ASPxTextBox>
            </td>
        </tr>
    </table>
    <br />
    <dx:ASPxButton ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add">
    </dx:ASPxButton>
    </br>
</asp:Content>
