<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="BookingView.aspx.cs" Inherits="V50_IDOMBackOffice.SupportForms.BookingView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <table style="width: 100%">
            <tr>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Offer data&nbsp;</td>
            </tr>
        </table>
        <br />
        <table style="width: 100%">
            <tr>
                <td style="width: 69px; height: 25px">Country:</td>
                <td style="width: 125px; height: 25px">
                    <dx:ASPxTextBox ID="txtCountry" runat="server" Width="170px">
                    </dx:ASPxTextBox>
                </td>
                <td style="width: 112px; height: 25px">Place:</td>
                <td style="height: 25px">
                    <dx:ASPxTextBox ID="txtPlace" runat="server" Width="170px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 69px">SiteCode:</td>
                <td style="width: 125px">
                    <dx:ASPxComboBox ID="comboboxSite" runat="server" AutoPostBack="True" OnSelectedIndexChanged="comboboxSite_SelectedIndexChanged" ValueType="System.String" TextField="Name" ValueField="Id">
                    </dx:ASPxComboBox>
                </td>
                <td style="width: 112px">UnitCode:</td>
                <td>
                    <dx:ASPxComboBox ID="comboboxUnit" runat="server" AutoPostBack="True" OnSelectedIndexChanged="comboboxUnit_SelectedIndexChanged" ValueType="System.String" TextField="Name" ValueField="Id">
                    </dx:ASPxComboBox>
                </td>
            </tr>
            <tr>
                <td style="width: 69px">OfferCode:</td>
                <td style="width: 125px">
                    <dx:ASPxComboBox ID="comboboxOffer" runat="server" ValueType="System.String" TextField="Name" ValueField="Id">
                    </dx:ASPxComboBox>
                </td>
                <td style="width: 112px">TourOperator:</td>
                <td>
                    <dx:ASPxTextBox ID="txtTourOperator" runat="server" Width="170px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 69px">CheckIn:</td>
                <td style="width: 125px">
                    <dx:ASPxDateEdit ID="ASPxDateEditCheckIn" runat="server">
                    </dx:ASPxDateEdit>
                </td>
                <td style="width: 112px">CheckOut:</td>
                <td>
                    <dx:ASPxDateEdit ID="ASPxDateEditCheckOut" runat="server">
                    </dx:ASPxDateEdit>
                </td>
            </tr>
            <tr>
                <td style="width: 69px">Adults:</td>
                <td style="width: 125px">
                    <dx:ASPxTextBox ID="txtAdults" runat="server" Width="170px">
                    </dx:ASPxTextBox>
                </td>
                <td style="width: 112px">Children:</td>
                <td>
                    <dx:ASPxTextBox ID="txtChildren" runat="server" Width="170px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Other data&nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 69px">ProviderId:</td>
                <td style="width: 125px">
                    <dx:ASPxTextBox ID="txtProviderId" runat="server" Width="170px">
                    </dx:ASPxTextBox>
                </td>
                <td style="width: 112px">PartnerId:</td>
                <td>
                    <dx:ASPxTextBox ID="txtPartnerId" runat="server" Width="170px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 69px">Season:</td>
                <td style="width: 125px">
                    <dx:ASPxTextBox ID="txtSeason" runat="server" Width="170px">
                    </dx:ASPxTextBox>
                </td>
                <td style="width: 112px">BookingNumber:</td>
                <td>
                    <dx:ASPxTextBox ID="txtBookingNumber" runat="server" Width="170px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 69px">PaymentDate:</td>
                <td style="width: 125px">
                    <dx:ASPxDateEdit ID="ASPxDateEditPayment" runat="server">
                    </dx:ASPxDateEdit>
                </td>
                <td style="width: 112px">PaymentValue:</td>
                <td>
                    <dx:ASPxTextBox ID="txtPaymetnValue" runat="server" Width="170px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4">&nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
        AddBooking</p>
    <p>
        <dx:ASPxButton ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" Width="90px">
        </dx:ASPxButton>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>
