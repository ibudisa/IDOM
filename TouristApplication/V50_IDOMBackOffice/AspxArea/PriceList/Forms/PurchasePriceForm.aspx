<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeBehind="PurchasePriceForm.aspx.cs" Inherits="V50_IDOMBackOffice.AspxArea.PriceList.Forms.PurchasePriceForm" %>

<%@ Register src="../Controls/PriceListControl.ascx" tagname="PriceListControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    
        <uc1:PriceListControl ID="PriceListControl1" runat="server" />
    
    </div>
</asp:Content>
  
