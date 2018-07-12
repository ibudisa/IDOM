<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="TextProcessView.aspx.cs" Inherits="V50_IDOMBackOffice.AspxArea.Booking.Forms.TextProcessView" %>
<%@ Register assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxHtmlEditor" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    </br>
    <table class="dxhe-dialogControlsWrapper">
        <tr>
            <td class="dxhe-tableColumnDialog" style="width: 137px">&nbsp;Create Date:</td>
            <td>
                <dx:ASPxDateEdit ID="DateEdit" runat="server" style="margin-left: 0px">
                </dx:ASPxDateEdit>
            </td>
        </tr>
        <tr>
            <td class="dxhe-tableColumnDialog" style="width: 137px">Title:</td>
            <td>
                <dx:ASPxTextBox ID="txtTitle" runat="server" style="margin-bottom: 0px" Width="275px">
                </dx:ASPxTextBox>
            </td>
        </tr>
    </table>
    </br>
    <dx:ASPxHtmlEditor ID="HtmlEditorInfo" runat="server">
    </dx:ASPxHtmlEditor>
    </br>
    <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click">
    </dx:ASPxButton>
    </br>
</asp:Content>
