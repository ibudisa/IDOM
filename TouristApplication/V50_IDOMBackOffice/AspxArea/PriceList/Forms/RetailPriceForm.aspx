<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="RetailPriceForm.aspx.cs" Inherits="V50_IDOMBackOffice.AspxArea.PriceList.Forms.RetailPriceForm" %>
<%@ Register src="../Controls/PriceListControl.ascx" tagname="PriceListControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <table class="dxeBinImgCPnlSys">
        <tr>
            <td style="width: 89px">
                <dx:ASPxComboBox ID="comboboxPrice" runat="server" TextField="Name" ValueField="Id" ValueType="System.String" AutoPostBack="True" OnSelectedIndexChanged="comboboxPrice_SelectedIndexChanged">
                </dx:ASPxComboBox>
            </td>
            <td >
                &nbsp;</td>
        </tr>
    </table>
    <p>
        &nbsp;</p>
    <uc1:PriceListControl ID="PriceListControl1" runat="server" />
     <dx:ASPxButton ID="btnCopy" runat="server" Text="Copy" AutoPostBack="false">
                                         <ClientSideEvents Click="function(s, e) {
	                                      FeedPopupControl.Show();
                                       }" />
      </dx:ASPxButton>
      <dx:ASPxPopupControl ID="PopupControlData" runat="server" AllowDragging="True" AllowResize="True"
        CloseAction="CloseButton" ContentUrl="~/AspxArea/MasterData/Forms/UnitPopUp.aspx"
        EnableViewState="False" PopupElementID="popupArea" PopupHorizontalAlign="WindowCenter"
        PopupVerticalAlign="WindowCenter" ShowFooter="True" Width="585px"
        Height="300px" FooterText="Copy data"
        HeaderText="Document form" ClientInstanceName="FeedPopupControl" EnableHierarchyRecreation="True">
                                       <ContentCollection>
<dx:PopupControlContentControl runat="server"> 
</dx:PopupControlContentControl>
</ContentCollection>
<FooterTemplate>  
    <table style="border: none">
        <tr>
            <td>
                <dx:ASPxButton ID="btnOK" runat="server" AutoPostBack="False" Text="OK" Width="80px">
                    <ClientSideEvents Click="function(s, e) { FeedPopupControl.Hide();
                            // client-side processing is here
                            e.processOnServer = true;
                            // do some processing at the server side
                        }" />
                </dx:ASPxButton>
            </td>
            <td>
                <dx:ASPxButton ID="btnCancel" runat="server" AutoPostBack="False" ClientInstanceName="btnCancel"
                    Text="Cancel" Width="80px">
                    <ClientSideEvents Click="function(s, e) { FeedPopupControl.Hide(); }" />
                </dx:ASPxButton>
            </td>
        </tr>
      </table>

</FooterTemplate>
    </dx:ASPxPopupControl>
</asp:Content>
