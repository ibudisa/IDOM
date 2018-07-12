<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="RetailPriceForm.aspx.cs" Inherits="V50_IDOMBackOffice.AspxArea.PriceList.Forms.RetailPriceForm" %>
<%@ Register src="../Controls/PriceListControl.ascx" tagname="PriceListControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <table class="dxeBinImgCPnlSys">
        <tr>
            <td style="width: 89px">
                <dx:ASPxComboBox ID="comboboxPrice" runat="server" TextField="Name" ValueField="Id" ValueType="System.String">
                </dx:ASPxComboBox>
            </td>
            <td >
                <dx:ASPxButton ID="btnSelect" runat="server" Text="Select" OnClick="btnSelect_Click">
                </dx:ASPxButton>
            </td>
        </tr>
    </table>
    <p>
        &nbsp;</p>
    <uc1:PriceListControl ID="PriceListControl1" runat="server" />
</asp:Content>
