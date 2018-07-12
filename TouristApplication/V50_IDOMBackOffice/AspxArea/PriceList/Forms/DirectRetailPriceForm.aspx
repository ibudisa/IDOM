<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="DirectRetailPriceForm.aspx.cs" Inherits="V50_IDOMBackOffice.AspxArea.PriceList.Forms.DirectRetailPriceForm" %>
<%@ Register src="../Controls/PriceListControl.ascx" tagname="PriceListControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%">
        <tr>
            <td style="width: 131px">TourOperator:</td>
            <td>
                <dx:ASPxComboBox ID="comboboxTourOperator" runat="server" ValueType="System.String" AutoPostBack="True" OnSelectedIndexChanged="comboboxTourOperator_SelectedIndexChanged" TextField="Name" ValueField="Id">
                </dx:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td style="width: 131px">SiteCode:</td>
            <td>
                <dx:ASPxComboBox ID="comboboxSite" runat="server" ValueType="System.String" AutoPostBack="True" OnSelectedIndexChanged="comboboxSite_SelectedIndexChanged" TextField="Name" ValueField="Id">
                </dx:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td style="width: 131px">OfferCode:</td>
            <td>
                <dx:ASPxComboBox ID="comboboxOffer" runat="server" ValueType="System.String" TextField="Name" ValueField="Id" AutoPostBack="True">
                </dx:ASPxComboBox>
            </td>
        </tr>
    </table>
    <br />
<uc1:PriceListControl ID="PriceListControl1" runat="server" />
<br />
    </br>
</asp:Content>
