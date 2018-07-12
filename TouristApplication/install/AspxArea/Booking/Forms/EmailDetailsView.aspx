<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="EmailDetailsView.aspx.cs" Inherits="V50_IDOMBackOffice.AspxArea.Booking.Forms.EmailDetailsView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 57%; height: 89px">
        <tr>
            <td style="width: 66px">Sender:</td>
            <td style="width: 259px">
                <dx:ASPxLabel ID="lblSender" runat="server">
                </dx:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td style="width: 66px; height: 23px">Receiver:</td>
            <td style="height: 23px; width: 259px">
                <dx:ASPxLabel ID="lblReceiver" runat="server">
                </dx:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td style="width: 66px">Subject:</td>
            <td style="width: 259px">
                <dx:ASPxLabel ID="lblSubject" runat="server">
                </dx:ASPxLabel>
            </td>
        </tr>
        <tr>
            <td style="width: 66px; height: 23px;">Content:</td>
            <td style="width: 259px; height: 23px;">
                <dx:ASPxMemo ID="MemoContent" runat="server" Height="71px" Width="170px">
                </dx:ASPxMemo>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    </br>
</asp:Content>
