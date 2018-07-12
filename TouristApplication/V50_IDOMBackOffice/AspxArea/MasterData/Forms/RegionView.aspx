<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="RegionView.aspx.cs" Inherits="V50_IDOMBackOffice.AspxArea.MasterData.Forms.RegionView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxGridView ID="GridRegionView" runat="server" AutoGenerateColumns="False" KeyFieldName="Id" OnRowDeleting="GridRegionView_RowDeleting1" OnRowInserting="GridRegionView_RowInserting1" OnRowUpdating="GridRegionView_RowUpdating1" OnDataBinding="GridRegionView_DataBinding" OnInit="GridRegionView_Init" OnRowValidating="GridRegionView_RowValidating" OnStartRowEditing="GridRegionView_StartRowEditing" OnCellEditorInitialize="GridRegionView_CellEditorInitialize">
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
        <EditFormLayoutProperties ColCount="2">
            <Items>
                <dx:GridViewColumnLayoutItem ColumnName="RegionId">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="RegionName">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="CountryId">
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
            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="Id" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RegionId" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="RegionName" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ImageGalleryPath" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ImageThumbnailsPath" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataComboBoxColumn FieldName="CountryId" Name="CountryId" VisibleIndex="4">
                <PropertiesComboBox TextField="Name" ValueField="Id">
                </PropertiesComboBox>
            </dx:GridViewDataComboBoxColumn>
        </Columns>
    </dx:ASPxGridView>
    </asp:Content>
