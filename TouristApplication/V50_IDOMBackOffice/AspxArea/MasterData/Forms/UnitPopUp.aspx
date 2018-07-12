<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UnitPopUp.aspx.cs" Inherits="V50_IDOMBackOffice.AspxArea.MasterData.Forms.UnitPopUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 137px;
        }
        .auto-style5 {
            width: 138px;
        }
        .auto-style6 {
            width: 140px;
        }
        .auto-style7 {
            width: 141px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">SiteCode:</td>
                <td>
                    <dx:ASPxComboBox ID="comboboxSiteCode" runat="server" ValueType="System.String" TextField="Name" ValueField="Id" AutoPostBack="True" OnSelectedIndexChanged="comboboxSiteCode_SelectedIndexChanged">
                    </dx:ASPxComboBox>
                </td>
            </tr>
        </table>
    <div>
    
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style5">OfferCode:</td>
                <td>
                    <dx:ASPxComboBox ID="comboboxOfferCode" runat="server" ValueType="System.String" TextField="Name" ValueField="Id" AutoPostBack="True" OnSelectedIndexChanged="comboboxOfferCode_SelectedIndexChanged">
                    </dx:ASPxComboBox>
                </td>
            </tr>
        </table>
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style6">PriceListType:</td>
                <td>
                    <dx:ASPxComboBox ID="comboboxPriceListType" runat="server" ValueType="System.String" TextField="Name" ValueField="Id">
                    </dx:ASPxComboBox>
                </td>
            </tr>
        </table>
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style7">Faktor:</td>
                <td>
                    <dx:ASPxTextBox ID="txtFaktor" runat="server" Width="170px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
        </table>
        <br />
        <br />
        <dx:ASPxButton ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="AddPrice">
        </dx:ASPxButton>
    </br>
    </div>
    </form>
</body>
</html>
