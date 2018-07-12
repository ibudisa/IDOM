<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="ProviderView.aspx.cs" Inherits="V50_IDOMBackOffice.AspxArea.Booking.Forms.ProviderView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxGridView ID="GridProviderView" runat="server" AutoGenerateColumns="False" KeyFieldName="Id" OnCustomButtonCallback="GridProviderView_CustomButtonCallback" OnInit="GridProviderView_Init" OnRowDeleting="GridProviderView_RowDeleting" OnRowInserting="GridProviderView_RowInserting" OnRowUpdating="GridProviderView_RowUpdating" OnRowValidating="GridProviderView_RowValidating" OnStartRowEditing="GridProviderView_StartRowEditing">
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
        <Settings ShowFilterRow="True" />
        <EditFormLayoutProperties ColCount="2">
            <Items>
                <dx:GridViewColumnLayoutItem ColumnName="PersonalIdentificationNumber">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="Name">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="Country">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="City">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="Address">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="Bank">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="IBAN">
                </dx:GridViewColumnLayoutItem>
                <dx:EditModeCommandLayoutItem ColSpan="2" HorizontalAlign="Right">
                </dx:EditModeCommandLayoutItem>
            </Items>
        </EditFormLayoutProperties>
    <Columns>
        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowInCustomizationForm="True" ShowNewButtonInHeader="True" VisibleIndex="0">
        </dx:GridViewCommandColumn>
        <dx:GridViewDataTextColumn FieldName="Id" ShowInCustomizationForm="True" VisibleIndex="1">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="PersonalIdentificationNumber" ShowInCustomizationForm="True" VisibleIndex="2">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Name" ShowInCustomizationForm="True" VisibleIndex="3">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Country" ShowInCustomizationForm="True" VisibleIndex="4">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="City" ShowInCustomizationForm="True" VisibleIndex="5">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Address" ShowInCustomizationForm="True" VisibleIndex="6">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Bank" ShowInCustomizationForm="True" VisibleIndex="7">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="IBAN" ShowInCustomizationForm="True" VisibleIndex="8">
        </dx:GridViewDataTextColumn>
        <dx:GridViewCommandColumn Name="ProviderContact" VisibleIndex="12">
            <CustomButtons>
                <dx:GridViewCommandColumnCustomButton ID="ButtonProviderContacts" Text="ProviderContacts">
                    <Image Url="~/Content/Images/Add.png">
                    </Image>
                </dx:GridViewCommandColumnCustomButton>
            </CustomButtons>
        </dx:GridViewCommandColumn>
        <dx:GridViewDataTextColumn FieldName="ProviderId" VisibleIndex="9">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Title" VisibleIndex="10">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="BookingEmail" VisibleIndex="11">
        </dx:GridViewDataTextColumn>
        <dx:GridViewCommandColumn VisibleIndex="13">
            <CustomButtons>
                <dx:GridViewCommandColumnCustomButton ID="ButtonProviderBooking" Text="ProviderBooking">
                    <Image Url="~/Content/Images/Add.png">
                    </Image>
                </dx:GridViewCommandColumnCustomButton>
            </CustomButtons>
        </dx:GridViewCommandColumn>
    </Columns>
</dx:ASPxGridView>
</asp:Content>
