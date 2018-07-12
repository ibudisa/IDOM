<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="BookingProcessDetailsView.aspx.cs" Inherits="V50_IDOMBackOffice.AspxArea.Booking.Forms.BookingProcessDetailsView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    
        <table style="width: 100%">
            <tr>
                <td>Name : </td>
                <td><% Response.Write(model.TravelApplicant_Adress); %></td>
                <td>Telefon</td>
                <td><% Response.Write(model.TravelApplicant_MobilePhone); %></td>
            </tr>
            <tr>
                <td>Adresse : </td>
                <td><% Response.Write(model.Offer_SiteName); %></td>
                <td>Mobile :</td>
                <td><% Response.Write(model.Offer_CheckIn); %></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Anlage : </td>
                <td><% Response.Write(model.Offer_OfferName); %></td>
                <td>CheckIn :</td>
               <td><% Response.Write(model.Offer_CheckOut); %></td>
            </tr>
            <tr>
                <td>Angebot:</td>
                <td><% Response.Write(model.Offer_CheckOut); %></td>
                <td>CheckOut : </td>
               <td><% Response.Write(model.Offer_CheckOut); %></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
               <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Status dokumenta</td>
                <td>
        <dx:ASPxLabel ID="lblStatus" runat="server">
        </dx:ASPxLabel>
                </td>
                <td>&nbsp;</td>
               <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
               <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
        <dx:ASPxComboBox ID="ASPxComboBoxStatus" runat="server" ValueType="System.String" TextField="Text" ValueField="ValueId" Width="100%">
        </dx:ASPxComboBox>
                </td>
                <td>
        <dx:ASPxButton ID="ASPxButtonSelect" runat="server" Text="Select" OnClick="ASPxButtonSelect_Click" Width="132px">
        </dx:ASPxButton>
                    <br />
                </td>
                <td>&nbsp;</td>
               <td>&nbsp;</td>
            </tr>
        </table>
        <br />
    <table style="width: 100%">
        <tr>
            <td style="width: 96px">
                <dx:ASPxButton ID="btnCompare" runat="server" OnClick="btnCompare_Click" Text="Compare">
                </dx:ASPxButton>
            </td>
            <td>
                <dx:ASPxLabel ID="lblCompare" runat="server" Text="ASPxLabel">
                </dx:ASPxLabel>
            </td>
        </tr>
    </table>
        <br />
        <dx:ASPxPopupControl ID="ASPxPopup" runat="server" ClientInstanceName="popup" Height="400px" Width="800px" AllowResize="True" ContentUrl="DocView/BookingInquiryDocView.aspx" HeaderText="Document View" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" ShowMaximizeButton="True">
        </dx:ASPxPopupControl>
    
    <p>
        <dx:ASPxGridView ID="GridBookingProcessItemView" runat="server" AutoGenerateColumns="False" KeyFieldName="Id" OnCustomButtonCallback="GridBookingProcessItemView_CustomButtonCallback" ClientInstanceName="GridBookingProcessItemView">
            <ClientSideEvents EndCallback="function(s, e) {
	popup.SetContentUrl(&quot;DocViewPopUpForm.aspx?id=&quot; + GridBookingProcessItemView.cpKeyValue);
	 popup.Show();
    }" />
            <Columns>
                <dx:GridViewCommandColumn ShowInCustomizationForm="True" VisibleIndex="0">
                </dx:GridViewCommandColumn>
                <dx:GridViewDataDateColumn FieldName="CreateDate" ShowInCustomizationForm="True" VisibleIndex="2">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataTextColumn FieldName="DocumentNr" ShowInCustomizationForm="True" VisibleIndex="3">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="DocumentTitel" ShowInCustomizationForm="True" VisibleIndex="4">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="Author" ShowInCustomizationForm="True" VisibleIndex="5">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn FieldName="LastChange" ShowInCustomizationForm="True" VisibleIndex="6">
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataComboBoxColumn FieldName="BookingProcessTyp" VisibleIndex="7">
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataComboBoxColumn FieldName="DocumentStatus" VisibleIndex="8">
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewCommandColumn VisibleIndex="9">
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="ButtonEmail" Text="Email">
                            <Image Url="~/Content/Images/Add.png">
                            </Image>
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                </dx:GridViewCommandColumn>
            </Columns>
        </dx:ASPxGridView>
    </p>
</asp:Content>
