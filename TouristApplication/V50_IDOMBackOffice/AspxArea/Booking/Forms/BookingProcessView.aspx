<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="BookingProcessView.aspx.cs" Inherits="V50_IDOMBackOffice.AspxArea.Booking.Forms.BookingProcessView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <dx:ASPxGridView ID="GridBookingProcessView" runat="server" AutoGenerateColumns="False" KeyFieldName="Id" OnCellEditorInitialize="GridBookingProcessView_CellEditorInitialize" OnCustomButtonCallback="GridBookingProcessView_CustomButtonCallback" OnDataBinding="GridBookingProcessView_DataBinding" OnInit="GridBookingProcessView_Init" OnRowDeleting="GridBookingProcessView_RowDeleting" OnRowInserting="GridBookingProcessView_RowInserting" OnRowUpdating="GridBookingProcessView_RowUpdating">
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
        <Settings ShowFilterRow="True" />
        <SettingsSearchPanel Visible="True" />
        <Columns>
            <dx:GridViewCommandColumn VisibleIndex="0" ShowClearFilterButton="True">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Country" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="PlaceName" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SiteName" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TourOperatorCode" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="CheckIn" VisibleIndex="6">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataDateColumn FieldName="CheckOut" VisibleIndex="7">
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataTextColumn FieldName="FirstName" VisibleIndex="8">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="LastName" VisibleIndex="9">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="TravelerCountry" VisibleIndex="10">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Address" VisibleIndex="11">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn FieldName="Status" Name="Status" VisibleIndex="12">
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewCommandColumn Name="Details" VisibleIndex="16">
                <CustomButtons>
                    <dx:GridViewCommandColumnCustomButton ID="ButtonBookingDetails" Text="BookingDetails">
                        <Image Url="~/Content/Images/Add.png">
                        </Image>
                    </dx:GridViewCommandColumnCustomButton>
                </CustomButtons>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="TravelApplicantId" VisibleIndex="13">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="PartnerId" VisibleIndex="14">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Season" VisibleIndex="15">
            </dx:GridViewDataTextColumn>
        </Columns>
    </dx:ASPxGridView>
</asp:Content>
