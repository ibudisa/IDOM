<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="PlaceView.aspx.cs" Inherits="V50_IDOMBackOffice.AspxArea.MasterData.Forms.PlaceView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxGridView ID="GridPlaceView" runat="server" AutoGenerateColumns="False" KeyFieldName="Id" OnRowDeleting="GridPlaceView_RowDeleting" OnRowInserting="GridPlaceView_RowInserting" OnRowUpdating="GridPlaceView_RowUpdating" OnDataBinding="GridPlaceView_DataBinding" OnInit="GridPlaceView_Init" OnRowValidating="GridPlaceView_RowValidating" OnStartRowEditing="GridPlaceView_StartRowEditing" OnCellEditorInitialize="GridPlaceView_CellEditorInitialize">
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
        <EditFormLayoutProperties ColCount="2">
            <Items>
                <dx:GridViewColumnLayoutItem ColumnName="PlaceId">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="RegionId">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="PlaceName">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="ImageGalleryPath">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="ImageThumbnailsPath">
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
            <dx:GridViewDataTextColumn FieldName="PlaceId" ShowInCustomizationForm="True" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="PlaceName" ShowInCustomizationForm="True" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ImageGalleryPath" ShowInCustomizationForm="True" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ImageThumbnailsPath" ShowInCustomizationForm="True" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn FieldName="RegionId" Name="RegionId" VisibleIndex="3">
                <PropertiesComboBox TextField="Name" ValueField="Id">
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
        </Columns>
    </dx:ASPxGridView>
</asp:Content>
