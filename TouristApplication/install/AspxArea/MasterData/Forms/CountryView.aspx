<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="CountryView.aspx.cs" Inherits="V50_IDOMBackOffice.AspxArea.MasterData.Forms.CountryView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxGridView ID="GridCountryView" runat="server" AutoGenerateColumns="False" KeyFieldName="Id" OnInit="GridCountryView_Init" OnRowInserting="GridCountryView_RowInserting" OnRowDeleting="GridCountryView_RowDeleting" OnRowUpdating="GridCountryView_RowUpdating" OnRowInserted="GridCountryView_RowInserted" OnDataBinding="GridCountryView_DataBinding" OnRowValidating="GridCountryView_RowValidating" OnStartRowEditing="GridCountryView_StartRowEditing">
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
        <EditFormLayoutProperties ColCount="2">
            <Items>
                <dx:GridViewColumnLayoutItem ColumnName="CountryId">
                </dx:GridViewColumnLayoutItem>
                <dx:EmptyLayoutItem>
                </dx:EmptyLayoutItem>
                <dx:GridViewLayoutGroup ColSpan="2">
                    <Items>
                        <dx:GridViewColumnLayoutItem ColumnName="CountryName">
                        </dx:GridViewColumnLayoutItem>
                        <dx:GridViewColumnLayoutItem ColumnName="ImageGalleryPath">
                        </dx:GridViewColumnLayoutItem>
                        <dx:GridViewColumnLayoutItem ColumnName="ImageThumbnailsPath">
                        </dx:GridViewColumnLayoutItem>
                    </Items>
                </dx:GridViewLayoutGroup>
                <dx:EditModeCommandLayoutItem ColSpan="2" HorizontalAlign="Right">
                </dx:EditModeCommandLayoutItem>
            </Items>
        </EditFormLayoutProperties>
        <Columns>
            <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="CountryId" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="CountryName" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ImageGalleryPath" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ImageThumbnailsPath" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
        </Columns>
    </dx:ASPxGridView>
    </asp:Content>
