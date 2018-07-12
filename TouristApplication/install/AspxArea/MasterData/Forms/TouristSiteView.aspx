<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="TouristSiteView.aspx.cs" Inherits="V50_IDOMBackOffice.AspxArea.MasterData.Forms.TouristSiteView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxGridView ID="GridTouristSiteView" runat="server" AutoGenerateColumns="False" KeyFieldName="id" OnRowDeleting="GridTouristSiteView_RowDeleting" OnRowInserting="GridTouristSiteView_RowInserting" OnRowUpdating="GridTouristSiteView_RowUpdating" OnDataBinding="GridTouristSiteView_DataBinding" OnInit="GridTouristSiteView_Init" OnRowValidating="GridTouristSiteView_RowValidating" OnStartRowEditing="GridTouristSiteView_StartRowEditing" OnCustomButtonCallback="GridTouristSiteView_CustomButtonCallback" OnCellEditorInitialize="GridTouristSiteView_CellEditorInitialize">
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
        <EditFormLayoutProperties ColCount="2">
            <Items>
                <dx:GridViewColumnLayoutItem ColumnName="SiteCode">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="PlaceId">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="RegionId">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="CountryId">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="SiteName">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="Stars">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="Description">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="ImageGalleryPath" ClientVisible="False">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="ImageThumbnailsPath" ClientVisible="False">
                </dx:GridViewColumnLayoutItem>
                <dx:EditModeCommandLayoutItem ColSpan="2" HorizontalAlign="Right">
                </dx:EditModeCommandLayoutItem>
            </Items>
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="id" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SiteCode" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="PlaceId" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CountryId" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="SiteName" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Stars" VisibleIndex="7">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="8">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ImageGalleryPath" VisibleIndex="9">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ImageThumbnailsPath" VisibleIndex="10">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Longitude" Name="Longitude" VisibleIndex="11">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Latitude" Name="Latitude" VisibleIndex="12">
            </dx:GridViewDataTextColumn>
            <dx:GridViewCommandColumn VisibleIndex="13">
                <CustomButtons>
                    <dx:GridViewCommandColumnCustomButton ID="SiteGallery" Text="SiteGallery">
                        <Image Url="~/Content/Images/Add.png">
                        </Image>
                    </dx:GridViewCommandColumnCustomButton>
                </CustomButtons>
            </dx:GridViewCommandColumn>
            <dx:GridViewDataComboBoxColumn FieldName="RegionId" Name="RegionId" VisibleIndex="4">
            </dx:GridViewDataComboBoxColumn>
        </Columns>
    </dx:ASPxGridView>
</asp:Content>
