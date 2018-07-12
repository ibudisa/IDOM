<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="UnitOfferView.aspx.cs" Inherits="V50_IDOMBackOffice.AspxArea.MasterData.Forms.UnitOfferView" %>
<%@ Register assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxHtmlEditor" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxGridView ID="GridUnitOfferView" runat="server" AutoGenerateColumns="False" KeyFieldName="id" OnRowDeleting="GridUnitOfferView_RowDeleting" OnRowInserting="GridUnitOfferView_RowInserting" OnRowUpdating="GridUnitOfferView_RowUpdating" OnCustomButtonCallback="GridUnitOfferView_CustomButtonCallback" OnDataBinding="GridUnitOfferView_DataBinding" OnInit="GridUnitOfferView_Init" OnRowValidating="GridUnitOfferView_RowValidating" OnStartRowEditing="GridUnitOfferView_StartRowEditing" OnCellEditorInitialize="GridUnitOfferView_CellEditorInitialize">
        <SettingsEditing Mode="PopupEditForm">
        </SettingsEditing>
        <EditFormLayoutProperties ColCount="2">
            <Items>
                <dx:GridViewColumnLayoutItem ColumnName="TourOperatorCode">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="OfferCode">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="OfferTitel" ColSpan="2">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="OfferCount">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="UnitCode">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="OfferDescription" ColSpan="2">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="IsAutoStopBooking">
                </dx:GridViewColumnLayoutItem>
                <dx:GridViewColumnLayoutItem ColumnName="ProviderNotice" ColSpan="2">
                </dx:GridViewColumnLayoutItem>
                <dx:EditModeCommandLayoutItem ColSpan="2" HorizontalAlign="Right">
                </dx:EditModeCommandLayoutItem>
            </Items>
        </EditFormLayoutProperties>
    <Columns>
        <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
        </dx:GridViewCommandColumn>
        <dx:GridViewDataTextColumn FieldName="id" VisibleIndex="2">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="TourOperatorCode" VisibleIndex="3">
            <PropertiesTextEdit Width="100px">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="SiteCode" VisibleIndex="4">
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="OfferCode" VisibleIndex="6">
            <PropertiesTextEdit Width="100px">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="OfferTitel" VisibleIndex="7">
            <PropertiesTextEdit Width="100px">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="OfferDescription" VisibleIndex="8">
         <EditFormSettings Visible="True" />
            <EditItemTemplate>
                <dx:ASPxHtmlEditor ID="ASPxHtmlEditorDescription" runat="server"
                    Html='<%# Bind("OfferDescription") %>'>
                </dx:ASPxHtmlEditor>
            </EditItemTemplate>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataTextColumn FieldName="OfferCount" VisibleIndex="9">
            <PropertiesTextEdit Width="100px">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
        <dx:GridViewDataCheckColumn FieldName="IsAutoStopBooking" VisibleIndex="10">
        </dx:GridViewDataCheckColumn>
        <dx:GridViewDataTextColumn FieldName="ProviderNotice" VisibleIndex="11">
            <PropertiesTextEdit Width="500px">
            </PropertiesTextEdit>
        </dx:GridViewDataTextColumn>
        <dx:GridViewCommandColumn Name="PriceList" VisibleIndex="1">
            <CustomButtons>
                <dx:GridViewCommandColumnCustomButton ID="ButtonPriceList" Text="PriceList">
                    <Image Url="~/Content/Images/Add.png">
                    </Image>
                </dx:GridViewCommandColumnCustomButton>
            </CustomButtons>
        </dx:GridViewCommandColumn>
        <dx:GridViewDataComboBoxColumn FieldName="UnitCode" Name="UnitCode" VisibleIndex="5">
            <PropertiesComboBox Width="100px">
            </PropertiesComboBox>
        </dx:GridViewDataComboBoxColumn>
    </Columns>
</dx:ASPxGridView>
    </br>
</asp:Content>
