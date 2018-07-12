<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PriceListControl.ascx.cs" Inherits="V50_IDOMBackOffice.AspxArea.PriceList.Controls.PriceListControl" %>
<%@ Register assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxHtmlEditor" tagprefix="dx" %>

<p>
    Site Name :
    <dx:ASPxLabel ID="lblSiteName" runat="server" Text="ASPxLabel">
    </dx:ASPxLabel>
</p>
<p>
    Unit Name :
    <dx:ASPxLabel ID="lblUnitName" runat="server" Text="ASPxLabel">
    </dx:ASPxLabel>
</p>
&nbsp;<dx:ASPxPageControl ID="PriceListPageControl" runat="server" ActiveTabIndex="4" Width="100%">
    <TabPages>
        <dx:TabPage Name="Seasonprices" Text="Season prices">
            <ContentCollection>
                <dx:ContentControl runat="server">
                    <dx:ASPxGridView ID="GridSeasonAndPriceView" runat="server" AutoGenerateColumns="False" KeyFieldName="Id" OnRowDeleting="GridSeasonAndPriceView_RowDeleting" OnRowInserting="GridSeasonAndPriceView_RowInserting" OnRowUpdating="GridSeasonAndPriceView_RowUpdating" OnCellEditorInitialize="GridSeasonAndPriceView_CellEditorInitialize" OnDataBinding="GridSeasonAndPriceView_DataBinding" OnInit="GridSeasonAndPriceView_Init" OnRowValidating="GridSeasonAndPriceView_RowValidating" OnStartRowEditing="GridSeasonAndPriceView_StartRowEditing" OnInitNewRow="GridSeasonAndPriceView_InitNewRow">
                        <SettingsEditing Mode="PopupEditForm">
                        </SettingsEditing>
                        <EditFormLayoutProperties ColCount="2">
                            <Items>
                                <dx:GridViewColumnLayoutItem ColumnName="FromPersons">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="ToPersons">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="FromDate">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="ToDate">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="Eur">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="PriceType">
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
                            <dx:GridViewDataTextColumn FieldName="FromPersons" ShowInCustomizationForm="True" VisibleIndex="2">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ToPersons" ShowInCustomizationForm="True" VisibleIndex="3">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="FromDate" ShowInCustomizationForm="True" VisibleIndex="4">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn FieldName="ToDate" ShowInCustomizationForm="True" VisibleIndex="5">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="Eur" ShowInCustomizationForm="True" VisibleIndex="6">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="PriceType" Name="PriceType" ShowInCustomizationForm="True" VisibleIndex="7">
                            </dx:GridViewDataComboBoxColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </dx:ContentControl>
            </ContentCollection>
        </dx:TabPage>
        <dx:TabPage Name="Actions" Text="Actions">
            <ContentCollection>
                <dx:ContentControl runat="server">
                    <dx:ASPxGridView ID="GridSeasonUnitActionView" runat="server" AutoGenerateColumns="False" KeyFieldName="Id" OnRowDeleting="GridSeasonUnitActionView_RowDeleting" OnRowInserting="GridSeasonUnitActionView_RowInserting" OnRowUpdating="GridSeasonUnitActionView_RowUpdating" OnCellEditorInitialize="GridSeasonUnitActionView_CellEditorInitialize" OnDataBinding="GridSeasonUnitActionView_DataBinding" OnInit="GridSeasonUnitActionView_Init" OnRowValidating="GridSeasonUnitActionView_RowValidating" OnStartRowEditing="GridSeasonUnitActionView_StartRowEditing" OnInitNewRow="GridSeasonUnitActionView_InitNewRow">
                        <SettingsEditing Mode="PopupEditForm">
                        </SettingsEditing>
                        <EditFormLayoutProperties ColCount="2">
                            <Items>
                                <dx:GridViewColumnLayoutItem ColumnName="ActionType" ColSpan="2">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="ActionStart">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="ActionEnd">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="FromDate">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="ToDate">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="MinStayDays">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="MinPrice">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="FreeNights">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="DiscountPercent">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="DiscountEur">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="CanBeCombined">
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
                            <dx:GridViewDataDateColumn FieldName="ActionStart" ShowInCustomizationForm="True" VisibleIndex="3">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn FieldName="ActionEnd" ShowInCustomizationForm="True" VisibleIndex="4">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn FieldName="FromDate" ShowInCustomizationForm="True" VisibleIndex="5">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn FieldName="ToDate" ShowInCustomizationForm="True" VisibleIndex="6">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="MinStayDays" ShowInCustomizationForm="True" VisibleIndex="7">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="MinPrice" ShowInCustomizationForm="True" VisibleIndex="8">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="FreeNights" ShowInCustomizationForm="True" VisibleIndex="9">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="DiscountPercent" ShowInCustomizationForm="True" VisibleIndex="10">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="DiscountEur" ShowInCustomizationForm="True" VisibleIndex="11">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="ActionType" Name="ActionType" ShowInCustomizationForm="True" VisibleIndex="2">
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataCheckColumn FieldName="CanBeCombined" ShowInCustomizationForm="True" VisibleIndex="12">
                            </dx:GridViewDataCheckColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </dx:ContentControl>
            </ContentCollection>
        </dx:TabPage>
        <dx:TabPage Name="Availability" Text="Availabilty">
            <ContentCollection>
                <dx:ContentControl runat="server">
                    <dx:ASPxGridView ID="GridSeasonUnitAvailabiltyView" runat="server" AutoGenerateColumns="False" OnRowDeleting="GridSeasonUnitAvailabiltyView_RowDeleting" OnRowInserting="GridSeasonUnitAvailabiltyView_RowInserting" OnRowUpdating="GridSeasonUnitAvailabiltyView_RowUpdating" KeyFieldName="Id" OnInit="GridSeasonUnitAvailabiltyView_Init" OnRowValidating="GridSeasonUnitAvailabiltyView_RowValidating" OnStartRowEditing="GridSeasonUnitAvailabiltyView_StartRowEditing" OnInitNewRow="GridSeasonUnitAvailabiltyView_InitNewRow">
                        <SettingsEditing Mode="PopupEditForm">
                        </SettingsEditing>
                        <EditFormLayoutProperties ColCount="2">
                            <Items>
                                <dx:GridViewColumnLayoutItem ColumnName="FromDate">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="ToDate">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="IsAutoStopBooking">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="UnitCount">
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
                            <dx:GridViewDataDateColumn FieldName="FromDate" ShowInCustomizationForm="True" VisibleIndex="2">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn FieldName="ToDate" ShowInCustomizationForm="True" VisibleIndex="3">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataCheckColumn FieldName="IsAutoStopBooking" ShowInCustomizationForm="True" VisibleIndex="4">
                            </dx:GridViewDataCheckColumn>
                            <dx:GridViewDataTextColumn FieldName="UnitCount" ShowInCustomizationForm="True" VisibleIndex="5">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </dx:ContentControl>
            </ContentCollection>
        </dx:TabPage>
        <dx:TabPage Name="Services" Text="Services">
            <ContentCollection>
                <dx:ContentControl runat="server">
                    <dx:ASPxGridView ID="GridSeasonUnitServiceView" runat="server" AutoGenerateColumns="False" KeyFieldName="Id" OnRowDeleting="GridSeasonUnitServiceView_RowDeleting" OnRowInserting="GridSeasonUnitServiceView_RowInserting" OnRowUpdating="GridSeasonUnitServiceView_RowUpdating" OnCellEditorInitialize="GridSeasonUnitServiceView_CellEditorInitialize" OnDataBinding="GridSeasonUnitServiceView_DataBinding" OnInit="GridSeasonUnitServiceView_Init" OnRowValidating="GridSeasonUnitServiceView_RowValidating" OnStartRowEditing="GridSeasonUnitServiceView_StartRowEditing" OnInitNewRow="GridSeasonUnitServiceView_InitNewRow">
                        <SettingsEditing Mode="PopupEditForm">
                        </SettingsEditing>
                        <EditFormLayoutProperties ColCount="2">
                            <Items>
                                <dx:GridViewColumnLayoutItem ColumnName="ServiceType">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="IsOptional">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="Description" ColSpan="2">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="FromDate">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="ToDate">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="OfOld">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="ToOld">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="OfDay">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="ToDay">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="Eur">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="ServiceInterval">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="ServiceUnit">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="PaymentPlace">
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
                            <dx:GridViewDataCheckColumn FieldName="IsOptional" ShowInCustomizationForm="True" VisibleIndex="3">
                            </dx:GridViewDataCheckColumn>
                            <dx:GridViewDataTextColumn FieldName="Description" ShowInCustomizationForm="True" VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataDateColumn FieldName="FromDate" ShowInCustomizationForm="True" VisibleIndex="5">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn FieldName="ToDate" ShowInCustomizationForm="True" VisibleIndex="6">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="OfOld" ShowInCustomizationForm="True" VisibleIndex="7">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ToOld" ShowInCustomizationForm="True" VisibleIndex="8">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="OfDay" ShowInCustomizationForm="True" VisibleIndex="9">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ToDay" ShowInCustomizationForm="True" VisibleIndex="10">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Eur" ShowInCustomizationForm="True" VisibleIndex="11">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="ServiceType" Name="ServiceType" ShowInCustomizationForm="True" VisibleIndex="2">
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="ServiceInterval" Name="ServiceInterval" ShowInCustomizationForm="True" VisibleIndex="12">
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="ServiceUnit" Name="ServiceUnit" ShowInCustomizationForm="True" VisibleIndex="13">
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn FieldName="PaymentPlace" Name="PaymentPlace" ShowInCustomizationForm="True" VisibleIndex="14">
                            </dx:GridViewDataComboBoxColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </dx:ContentControl>
            </ContentCollection>
        </dx:TabPage>
        <dx:TabPage Name="Conditions" Text="Conditions">
            <ContentCollection>
                <dx:ContentControl runat="server">
                    <dx:ASPxGridView ID="GridSeasonUnitConditionView" runat="server" AutoGenerateColumns="False" KeyFieldName="Id" OnRowDeleting="GridSeasonUnitConditionView_RowDeleting" OnRowInserting="GridSeasonUnitConditionView_RowInserting" OnRowUpdating="GridSeasonUnitConditionView_RowUpdating" OnCellEditorInitialize="GridSeasonUnitConditionView_CellEditorInitialize" OnDataBinding="GridSeasonUnitConditionView_DataBinding" OnHtmlEditFormCreated="GridSeasonUnitConditionView_HtmlEditFormCreated" OnInit="GridSeasonUnitConditionView_Init" OnRowValidating="GridSeasonUnitConditionView_RowValidating" OnStartRowEditing="GridSeasonUnitConditionView_StartRowEditing" OnHtmlDataCellPrepared="GridSeasonUnitConditionView_HtmlDataCellPrepared" OnRowCommand="GridSeasonUnitConditionView_RowCommand" OnInitNewRow="GridSeasonUnitConditionView_InitNewRow" OnAutoFilterCellEditorCreate="GridSeasonUnitConditionView_AutoFilterCellEditorCreate" OnHtmlRowCreated="GridSeasonUnitConditionView_HtmlRowCreated">
                        <SettingsEditing Mode="PopupEditForm">
                        </SettingsEditing>
                        <EditFormLayoutProperties ColCount="2">
                            <Items>
                                <dx:GridViewColumnLayoutItem ColumnName="FromDate">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="ToDate">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="MinStay">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="ReleaseDays">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="ArrivalActual" Name="ArrivalActual">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="DepartureActual" Name="DepartureActual">
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
                            <dx:GridViewDataDateColumn FieldName="FromDate" ShowInCustomizationForm="True" VisibleIndex="2">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn FieldName="ToDate" ShowInCustomizationForm="True" VisibleIndex="3">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="MinStay" ShowInCustomizationForm="True" VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ReleaseDays" ShowInCustomizationForm="True" VisibleIndex="5">
                            </dx:GridViewDataTextColumn>
                             <dx:GridViewDataTextColumn FieldName="ArrivalActual" ShowInCustomizationForm="True" VisibleIndex="6" Name="ArrivalActual">
                                 <DataItemTemplate>
                                    <dx:ASPxLabel ID="ArrivalASPxLabel" runat="server" Value='<%# Bind("ArrivalActual") %>' />
                                  </DataItemTemplate>
                                <EditItemTemplate>
                                    <dx:ASPxCheckBoxList ID="ASPxCheckBoxListArrival" runat="server" ValueType="System.String">
                                    </dx:ASPxCheckBoxList>
                                </EditItemTemplate>
                            </dx:GridViewDataTextColumn>
                             <dx:GridViewDataTextColumn FieldName="DepartureActual" ShowInCustomizationForm="True" VisibleIndex="7" Name="DepartureActual">
                                  <DataItemTemplate>
                                    <dx:ASPxLabel ID="DepartureASPxLabel" runat="server" Value='<%# Bind("DepartureActual") %>' />
                                  </DataItemTemplate>
                                 <EditItemTemplate>
                                     <dx:ASPxCheckBoxList ID="ASPxCheckBoxListDeparture" runat="server" ValueType="System.String">
                                     </dx:ASPxCheckBoxList>
                                 </EditItemTemplate>
                            </dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </dx:ContentControl>
            </ContentCollection>
        </dx:TabPage>
        <dx:TabPage Name="Paymentmodes" Text="Payment modes">
            <ContentCollection>
                <dx:ContentControl runat="server">
                    <dx:ASPxGridView ID="GridPaymentModeView" runat="server" AutoGenerateColumns="False" KeyFieldName="Id" OnRowDeleting="GridPaymentModeView_RowDeleting" OnRowInserting="GridPaymentModeView_RowInserting" OnRowUpdating="GridPaymentModeView_RowUpdating" OnCellEditorInitialize="GridPaymentModeView_CellEditorInitialize" OnDataBinding="GridPaymentModeView_DataBinding" OnInit="GridPaymentModeView_Init" OnRowValidating="GridPaymentModeView_RowValidating" OnStartRowEditing="GridPaymentModeView_StartRowEditing" OnInitNewRow="GridPaymentModeView_InitNewRow">
                        <SettingsEditing Mode="PopupEditForm">
                        </SettingsEditing>
                        <EditFormLayoutProperties ColCount="2">
                            <Items>
                                <dx:GridViewColumnLayoutItem ColumnName="PaymentModeTitel">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="PaymentModeDescription" ColSpan="2">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="BookingFromDate">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="BookingToDate">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="CheckInFromDate">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="CheckInToDate">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="MinDayToArrival">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="MaxDayToArrival">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="PriceDownPaymentPercent">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="PriceDownPaymentAfterDays">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="PriceDownPaymentEur">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="PriceRemainingBeforDays">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="CancellationFeesToDays">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="CancellationFeesPercent">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="PricePercentDiscount">
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
                            <dx:GridViewDataDateColumn FieldName="BookingFromDate" ShowInCustomizationForm="True" VisibleIndex="4" Caption="From Date" Name="Booking From Date">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn FieldName="BookingToDate" ShowInCustomizationForm="True" VisibleIndex="5" Caption="To Date" Name="Booking To Date">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn FieldName="CheckInFromDate" ShowInCustomizationForm="True" VisibleIndex="6" Caption="Check In From">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn FieldName="CheckInToDate" ShowInCustomizationForm="True" VisibleIndex="7" Caption="Check In To">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="MinDayToArrival" ShowInCustomizationForm="True" VisibleIndex="8" Caption="Min Day" Name="Min Day">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="PriceDownPaymentPercent" ShowInCustomizationForm="True" VisibleIndex="10" Caption="Price Down Percent" Name="Price Down Percent">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="CancellationFeesToDays" ShowInCustomizationForm="True" VisibleIndex="14" Caption="Cancellation Fees" Name="Cancellation Fees">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="CancellationFeesPercent" ShowInCustomizationForm="True" VisibleIndex="15" Caption="Cancellation Percent" Name="Cancellation Percent">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="PaymentModeTitel" ShowInCustomizationForm="True" VisibleIndex="2" Caption="Titel" Name="Payment Titel">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="PaymentModeDescription" ShowInCustomizationForm="True" VisibleIndex="3" Caption="Description" Name="Payment Description">
                               <PropertiesTextEdit Height="200px" Width="100px">
                            </PropertiesTextEdit>
                            <EditFormSettings Visible="True" />
                            <EditItemTemplate>
                                <dx:ASPxHtmlEditor ID="ASPxHtmlEditorDescription" runat="server"
                                    Html='<%# Bind("PaymentModeDescription") %>'  Height="200px">
                                </dx:ASPxHtmlEditor>
                             </EditItemTemplate>
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="MaxDayToArrival" ShowInCustomizationForm="True" VisibleIndex="9" Caption="Max Day" Name="Max Day">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="PriceDownPaymentAfterDays" ShowInCustomizationForm="True" VisibleIndex="11" Caption="Payment After" Name="Price down payment after">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="PriceDownPaymentEur" ShowInCustomizationForm="True" VisibleIndex="12" Caption="Payment Eur" Name="Price Down Payment">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="PriceRemainingBeforDays" ShowInCustomizationForm="True" VisibleIndex="13" Caption="Price Remaining" Name="Price Remaining">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="PricePercentDiscount" ShowInCustomizationForm="True" VisibleIndex="16" Caption="Discount" Name="Discount">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </dx:ContentControl>
            </ContentCollection>
        </dx:TabPage>
        <dx:TabPage Name="Special prices" Text="Special prices">
            <ContentCollection>
                <dx:ContentControl runat="server">
                    <dx:ASPxGridView ID="GridSpecialPricesView" runat="server" AutoGenerateColumns="False" KeyFieldName="Id" OnRowDeleting="GridSpecialPricesView_RowDeleting" OnRowInserting="GridSpecialPricesView_RowInserting" OnRowUpdating="GridSpecialPricesView_RowUpdating" OnInit="GridSpecialPricesView_Init" OnRowValidating="GridSpecialPricesView_RowValidating" OnStartRowEditing="GridSpecialPricesView_StartRowEditing">
                        <SettingsEditing Mode="PopupEditForm">
                        </SettingsEditing>
                        <EditFormLayoutProperties ColCount="2">
                            <Items>
                                <dx:GridViewColumnLayoutItem ColumnName="CheckIn">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="CheckOut">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="FromPersons">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="ToPersons">
                                </dx:GridViewColumnLayoutItem>
                                <dx:GridViewColumnLayoutItem ColumnName="Eur">
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
                            <dx:GridViewDataDateColumn FieldName="CheckIn" ShowInCustomizationForm="True" VisibleIndex="2">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataDateColumn FieldName="CheckOut" ShowInCustomizationForm="True" VisibleIndex="3">
                            </dx:GridViewDataDateColumn>
                            <dx:GridViewDataTextColumn FieldName="FromPersons" ShowInCustomizationForm="True" VisibleIndex="4">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="ToPersons" ShowInCustomizationForm="True" VisibleIndex="5">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn FieldName="Eur" ShowInCustomizationForm="True" VisibleIndex="6">
                            </dx:GridViewDataTextColumn>
                        </Columns>
                    </dx:ASPxGridView>
                </dx:ContentControl>
            </ContentCollection>
        </dx:TabPage>
    </TabPages>
</dx:ASPxPageControl>

