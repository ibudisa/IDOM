<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Main.master" CodeBehind="B2BCustomerDetailsView.aspx.cs" Inherits="V50_IDOMBackOffice.AspxArea.Booking.Forms.B2BCustomerDetailsView" %>

<%@ Register src="../Controls/ProviderEditControl.ascx" tagname="ProviderEditControl" tagprefix="uc1" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div>
            <uc1:ProviderEditControl ID="ProviderEditControl1" runat="server" />
        </div>
  
</asp:Content>