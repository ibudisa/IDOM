<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="TouristUnitView.aspx.cs" Inherits="V50_IDOMBackOffice.AspxArea.MasterData.Forms.TouristUnitView" %>
<%@ Register assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxHtmlEditor" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxGridView ID="GridTouristUnitView" runat="server" AutoGenerateColumns="False" KeyFieldName="id" OnRowDeleting="GridTouristUnitView_RowDeleting" OnRowInserting="GridTouristUnitView_RowInserting" OnRowUpdating="GridTouristUnitView_RowUpdating" OnCustomButtonCallback="GridTouristUnitView_CustomButtonCallback" OnDataBinding="GridTouristUnitView_DataBinding" OnInit="GridTouristUnitView_Init" OnRowValidating="GridTouristUnitView_RowValidating" OnStartRowEditing="GridTouristUnitView_StartRowEditing" OnCellEditorInitialize="GridTouristUnitView_CellEditorInitialize">
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
        <Settings ShowFilterRow="True" />
        <SettingsSearchPanel Visible="True" />
        <EditFormLayoutProperties ColCount="2">
            <Items>
                <dx:GridViewColumnLayoutItem ClientVisible="False" ColumnName="CountryName">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ClientVisible="False" ColumnName="RegionName">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ClientVisible="False" ColumnName="PlaceName">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="UnitTitel" ColSpan="2">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="TourOperatorCode">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="TravelServiceProvider">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="UnitCode">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="SiteCode">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="SiteName" ClientVisible="False">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="Description" ColSpan="2">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="MobilhomeArea">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="TerraceArea">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="Bedroom">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="Bathrooms">
                </dx:GridViewColumnLayoutItem>

                <dx:GridViewColumnLayoutItem ColumnName="ImageGalleryPath" ClientVisible="False">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="ImageThumbnailsPath" ClientVisible="False">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="MaxPersons">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="MaxAdults">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="PurchasePriceListId" ClientVisible="False">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="OpenDate">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="CloseDate">
                </dx:GridViewColumnLayoutItem>
                <dx:EditModeCommandLayoutItem ColSpan="2" HorizontalAlign="Right">
                </dx:EditModeCommandLayoutItem>
            </Items>
        </EditFormLayoutProperties>
    <Columns>
        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0" ShowClearFilterButton="True">
        </dx:GridViewCommandColumn>
        <dx:GridViewDataTextColumn FieldName="id" VisibleIndex="1">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="CountryName" VisibleIndex="2">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="RegionName" VisibleIndex="3">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="PlaceName" VisibleIndex="4">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="UnitTitel" VisibleIndex="5">
            <PropertiesTextEdit Width="500px">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="TourOperatorCode" VisibleIndex="6">
            <PropertiesTextEdit Width="100px">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="TravelServiceProvider" VisibleIndex="7">
            <PropertiesTextEdit Width="100px">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="UnitCode" VisibleIndex="8">
            <PropertiesTextEdit Width="100px">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="SiteName" VisibleIndex="10">
            <PropertiesTextEdit Width="100px">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="MobilhomeArea" VisibleIndex="12">
            <PropertiesTextEdit Width="100px">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="TerraceArea" VisibleIndex="13">
            <PropertiesTextEdit Width="100px">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Bedroom" VisibleIndex="14">
            <PropertiesTextEdit Width="100px">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="Bathrooms" VisibleIndex="15">
            <PropertiesTextEdit Width="100px">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
       
        <dx:GridViewDataTextColumn FieldName="ImageGalleryPath" VisibleIndex="17">
            <PropertiesTextEdit Width="100px">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="ImageThumbnailsPath" VisibleIndex="18">
            <PropertiesTextEdit Width="100px">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="MaxPersons" VisibleIndex="19">
            <PropertiesTextEdit Width="100px">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="MaxAdults" VisibleIndex="20">
            <PropertiesTextEdit Width="100px">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="PurchasePriceListId" VisibleIndex="21">
            <PropertiesTextEdit Width="100px">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataDateColumn FieldName="OpenDate" VisibleIndex="22">
            <PropertiesDateEdit Width="100px">
            </PropertiesDateEdit>
        </dx:GridViewDataDateColumn>
        <dx:GridViewDataDateColumn FieldName="CloseDate" VisibleIndex="23">
            <PropertiesDateEdit Width="100px">
            </PropertiesDateEdit>
        </dx:GridViewDataDateColumn>
        <dx:GridViewCommandColumn VisibleIndex="24">
            <CustomButtons>
                <dx:GridViewCommandColumnCustomButton ID="ButtonUnit" Text="UnitDetails">
                    <Image Url="~/Content/Images/Add.png">
                    </Image>
                </dx:GridViewCommandColumnCustomButton>
            </CustomButtons>
        </dx:GridViewCommandColumn>
        <dx:GridViewDataComboBoxColumn FieldName="SiteCode" Name="SiteCode" VisibleIndex="9">
            <PropertiesComboBox Width="100px">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn>
        <dx:GridViewDataTextColumn FieldName="Description" VisibleIndex="11">
            <PropertiesTextEdit Height="200px" Width="100px">
            </PropertiesTextEdit>
            <EditFormSettings Visible="True" />
            <EditItemTemplate>
              <dx:ASPxHtmlEditor ID="ASPxHtmlEditorDescription" runat="server"
                    Html='<%# Bind("Description") %>' Height="200px">
                </dx:ASPxHtmlEditor>
            </EditItemTemplate>
        </dx:GridViewDataTextColumn>
    </Columns>
</dx:ASPxGridView>
    </br>
      
</asp:Content>
