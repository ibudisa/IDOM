<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="UnitForm.aspx.cs" Inherits="V50_IDOMBackOffice.AspxArea.MasterData.Forms.UnitForm" %>
<%@ Register assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxHtmlEditor" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxRichEdit.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRichEdit" tagprefix="dx" %>
<%@ Register src="../../PriceList/Controls/PriceListControl.ascx" tagname="PriceListControl" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <dx:ASPxPageControl ID="PageUnitControl" runat="server" ActiveTabIndex="4" OnActiveTabChanged="PageUnitControl_ActiveTabChanged">
        <TabPages>
            <dx:TabPage Name="Objekt Info" Text="Objekt Info" ToolTip="Objekt Info">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <br>
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 115px">Site name:</td>
                                <td>
                                    <dx:ASPxLabel ID="lblSite" runat="server">
                                    </dx:ASPxLabel>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 115px">Unit name:</td>
                                <td>
                                    <dx:ASPxLabel ID="lblUnit" runat="server">
                                    </dx:ASPxLabel>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br></br>
                        <br>
                        <br></br>
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 116px">Max Belegung:</td>
                                <td style="width: 167px">
                                    <dx:ASPxTextBox ID="txtMaxBelegung" runat="server" Width="134px">
                                    </dx:ASPxTextBox>
                                </td>
                                <td style="width: 87px">Erwachsene:</td>
                                <td>
                                    <dx:ASPxTextBox ID="txtErwachsene" runat="server" Width="170px">
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 118px">Haustier:</td>
                                <td>
                                    <dx:ASPxComboBox ID="comboHaustier" runat="server" style="margin-left: 0px" TextField="Name" ValueField="Id">
                                    </dx:ASPxComboBox>
                                </td>
                            </tr>
                        </table>
                        <br>
                        <br>
                        <dx:ASPxFormLayout ID="LayoutObjektInfo" runat="server">
                            <Items>
                                <dx:TabbedLayoutGroup Name="UnitGroup">
                                    <Items>
                                        <dx:LayoutGroup Caption="Innenbereich" Name="Innenbereich">
                                            <Items>
                                                <dx:LayoutGroup Caption="Innenbereich" ColCount="2" Name="Innenbereich">
                                                    <Items>
                                                        <dx:LayoutItem Caption="MobileHeim Grose:" FieldName="MobilehomeSize" Name="MobileHeimGrose">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxTextBox ID="txtMobilHeimGrose" runat="server">
                                                                    </dx:ASPxTextBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Doppelbetten:" FieldName="DoubleBeds" Name="Doppelbetten">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxTextBox ID="txtDoppelbetten" runat="server">
                                                                    </dx:ASPxTextBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Einzelbetten:" FieldName="SingleBeds" Name="Einzelbetten">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxTextBox ID="txtEinzelbetten" runat="server">
                                                                    </dx:ASPxTextBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Klimaanlage:" FieldName="AirConditioning" Name="Klimaanlage">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxCheckBox ID="chkKlimaanlage" runat="server" CheckState="Unchecked">
                                                                    </dx:ASPxCheckBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Bader:" FieldName="Bathrooms" Name="Bader">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxTextBox ID="txtBader" runat="server">
                                                                    </dx:ASPxTextBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Schlafzimmer:" FieldName="Bedrooms" Name="Schlafzimmer">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxTextBox ID="txtSchlafzimmer" runat="server">
                                                                    </dx:ASPxTextBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Etagenbett:" FieldName="BunkBeds" Name="Etagenbett">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxTextBox ID="txtEtagenbett" runat="server">
                                                                    </dx:ASPxTextBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Zusatzbett:" FieldName="ExtraBeds" Name="Zusatzbett">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxTextBox ID="txtZusatzbett" runat="server">
                                                                    </dx:ASPxTextBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="WC:" FieldName="WC" Name="WC">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxTextBox ID="txtWC" runat="server">
                                                                    </dx:ASPxTextBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                    </Items>
                                                </dx:LayoutGroup>
                                                <dx:LayoutGroup Caption="Zusatzausstattung" ColCount="2" Name="Zusatzausstattung">
                                                    <Items>
                                                        <dx:LayoutItem Caption="Kaffemaschine" FieldName="Coffeemachine" Name="Kaffemaschine">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxCheckBox ID="chkKaffemaschine" runat="server" CheckState="Unchecked">
                                                                    </dx:ASPxCheckBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Kuhl-/Gefrierschrank" FieldName="Fridge" Name="Kuhl">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxCheckBox ID="chkKuhl" runat="server" CheckState="Unchecked">
                                                                    </dx:ASPxCheckBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Kinderbett" FieldName="Childbed" Name="Kinderbett">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxCheckBox ID="chkKinderbett" runat="server" CheckState="Unchecked">
                                                                    </dx:ASPxCheckBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="DVD Player" FieldName="DVDPlayer" Name="DVDPlayer">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxCheckBox ID="chkDVD" runat="server" CheckState="Unchecked">
                                                                    </dx:ASPxCheckBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                    </Items>
                                                </dx:LayoutGroup>
                                            </Items>
                                        </dx:LayoutGroup>
                                        <dx:LayoutGroup Caption="Aussenbereich" Name="Aussenbereich">
                                            <Items>
                                                <dx:LayoutGroup Caption="Aussenbereich" ColCount="2" Name="Aussenbereich">
                                                    <Items>
                                                        <dx:LayoutItem Caption="Terasse Typ" FieldName="TerraceType" Name="TerasseTyp">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxComboBox ID="comboboxTerasseTyp" runat="server" TextField="Name" ValueField="Id">
                                                                    </dx:ASPxComboBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Parzellengrose" FieldName="ParcelSize" Name="Parzellengrose">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxTextBox ID="txtParzellengrose" runat="server">
                                                                    </dx:ASPxTextBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Sonnenschirm" FieldName="Sunshade" Name="Sonnenschirm">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxCheckBox ID="chkSonnenschirm" runat="server" CheckState="Unchecked">
                                                                    </dx:ASPxCheckBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Sollardusche" FieldName="SolarShower" Name="Sollardusche">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxCheckBox ID="chkSollardusche" runat="server" CheckState="Unchecked">
                                                                    </dx:ASPxCheckBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Terassengrose" FieldName="TerraceSize" Name="Terassengrose">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxTextBox ID="txtTerassengrose" runat="server">
                                                                    </dx:ASPxTextBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Sonnenliegen" FieldName="Sunloungers" Name="Sonnenliegen">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxCheckBox ID="chkSonnenliegen" runat="server" CheckState="Unchecked">
                                                                    </dx:ASPxCheckBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Holzmobel" FieldName="WoodenFurniture" Name="Holzmobel">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxCheckBox ID="chkHolzmobel" runat="server" CheckState="Unchecked">
                                                                    </dx:ASPxCheckBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Wasserkocher" FieldName="Kettle" Name="Wasserkocher">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxCheckBox ID="chkWasserkocher" runat="server" CheckState="Unchecked">
                                                                    </dx:ASPxCheckBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                    </Items>
                                                </dx:LayoutGroup>
                                            </Items>
                                        </dx:LayoutGroup>
                                        <dx:LayoutGroup Caption="Besonderheiten" Name="Besonderheiten">
                                            <Items>
                                                <dx:LayoutGroup Caption="Im Preis inklusive" ColCount="2" Name="ImPreisinklusive">
                                                    <Items>
                                                        <dx:LayoutItem Caption="Handtucher" FieldName="Towel" Name="Handtucher">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxCheckBox ID="chkHandtucher" runat="server" CheckState="Unchecked">
                                                                    </dx:ASPxCheckBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Bettwasche" FieldName="BedWashing" Name="Bettwasche">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxCheckBox ID="chkBettwasche" runat="server" CheckState="Unchecked">
                                                                    </dx:ASPxCheckBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="PKW Stellplatz" FieldName="Parkinglot" Name="PKWStellplatz">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxCheckBox ID="chkPKWStellplatz" runat="server" CheckState="Unchecked">
                                                                    </dx:ASPxCheckBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Endreinigung" FieldName="FinishCleaning" Name="Endreinigung">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxCheckBox ID="chkEndreinigung" runat="server" CheckState="Unchecked">
                                                                    </dx:ASPxCheckBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                    </Items>
                                                </dx:LayoutGroup>
                                                <dx:LayoutGroup Caption="Weitere Besonderheiten" ColCount="3" Name="WeitereBesonderheiten">
                                                    <Items>
                                                        <dx:LayoutItem Caption="WiFi-Internet kostenlos" FieldName="WiFiInternetPriceFree" Name="WiFi-Internetkostenlos">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxCheckBox ID="chkWiFikostenlos" runat="server" CheckState="Unchecked">
                                                                    </dx:ASPxCheckBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="WiFi-Internet gegen Gebuhr" FieldName="WiFiInternet" Name="WiFi-InternetgegenGebuhr">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxCheckBox ID="chkWiFiGebuhr" runat="server" CheckState="Unchecked">
                                                                    </dx:ASPxCheckBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                        <dx:LayoutItem Caption="Eigener Pool" FieldName="Pool" Name="EigenerPool">
                                                            <LayoutItemNestedControlCollection>
                                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                                    <dx:ASPxCheckBox ID="chkEigenerPool" runat="server" CheckState="Unchecked">
                                                                    </dx:ASPxCheckBox>
                                                                </dx:LayoutItemNestedControlContainer>
                                                            </LayoutItemNestedControlCollection>
                                                        </dx:LayoutItem>
                                                    </Items>
                                                </dx:LayoutGroup>
                                            </Items>
                                        </dx:LayoutGroup>
                                        <dx:LayoutGroup Caption="Lage" ColCount="2" Name="Lage">
                                            <Items>
                                                <dx:LayoutItem Caption="Entfernung zum Strand von" FieldName="BeachDistanceFrom" Name="EntfernungzumStrandvon">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxTextBox ID="txtEntfernungzumStrandvon" runat="server">
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="Standort" FieldName="LocationSite" Name="Standort">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxComboBox ID="comboboxStandort" runat="server" TextField="Name" ValueField="Id">
                                                            </dx:ASPxComboBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="bis" FieldName="BeachDistanceTo" Name="bis">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxTextBox ID="txtbis" runat="server">
                                                            </dx:ASPxTextBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                                <dx:LayoutItem Caption="Lage zum Meer" FieldName="LocationSea" Name="LagezumMeer">
                                                    <LayoutItemNestedControlCollection>
                                                        <dx:LayoutItemNestedControlContainer runat="server">
                                                            <dx:ASPxComboBox ID="comboboxLagezumMeer" runat="server" TextField="Name" ValueField="Id">
                                                            </dx:ASPxComboBox>
                                                        </dx:LayoutItemNestedControlContainer>
                                                    </LayoutItemNestedControlCollection>
                                                </dx:LayoutItem>
                                            </Items>
                                        </dx:LayoutGroup>
                                    </Items>
                                </dx:TabbedLayoutGroup>
                            </Items>
                        </dx:ASPxFormLayout>
                        <br>
                        <br>
                        <br></br>
                        &nbsp;
                        <dx:ASPxButton ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update">
                        </dx:ASPxButton>
                        <br>
                        <br></br>
                        <br></br>
                        <br></br>
                        <br></br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                     
                     
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Name="Beschreibung" Text="Beschreibung">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <strong><span style="font-size: medium">Kurzbeschreibung<br />
                        <br />
                        <table style="width: 100%">
                            <tr>
                                <td style="width: 173px"><strong><span style="font-size: medium">
                                    <dx:ASPxComboBox ID="comboboxLanguageKurz" runat="server" TextField="Name" ValueField="Id">
                                    </dx:ASPxComboBox>
                                    </span></strong></td>
                                <td><strong><span style="font-size: medium">
                                    <dx:ASPxButton ID="btnGenerateKurz" runat="server" OnClick="btnGenerateKurz_Click" Text="Text Automatisch Generieren">
                                    </dx:ASPxButton>
                                    </span></strong></td>
                            </tr>
                        </table>
                        <br /></strong>
                        </span>
                        <dx:ASPxHtmlEditor ID="HtmlEditorKurzBeschreibung" runat="server">
                        </dx:ASPxHtmlEditor>
                        <br>
                        </br>
                        
                        <br />
                        <table class="dxhe-dialogControlsWrapper">
                            <tr>
                                <td style="width: 139px">
                                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Aktuelle Text Lange:">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxLabel ID="lblKurz" runat="server">
                                    </dx:ASPxLabel>
                                </td>
                            </tr>
                        </table>
                        <br>
                        <br>
                        <dx:ASPxButton ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit">
                        </dx:ASPxButton>
                        <strong><span style="font-size: medium">
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        Page Beschreibung<br /></span></strong>
                        <table class="dxhe-dialogControlsWrapper">
                            <tr>
                                <td style="width: 214px">
                                    <dx:ASPxComboBox ID="comboboxLanguage" runat="server" TextField="Name" ValueField="Id">
                                    </dx:ASPxComboBox>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="btnGenerate" runat="server" OnClick="btnGenerate_Click" Text="Text Automatisch Generieren">
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                        </table>
                        
                        <br></br>
                        <br></br>
                        <dx:ASPxHtmlEditor ID="HtmlEditorPageBeschreibung" runat="server">
                        </dx:ASPxHtmlEditor>
                        <br>
                        <br>
                        <dx:ASPxButton ID="btnSubmita" runat="server" OnClick="btnSubmita_Click" Text="Submit">
                        </dx:ASPxButton>
                        <br></br>
                        </br>
                        </br>
                        </br>
                        </br>
                      
                                                     
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Name="Bildergalerie" Text="Bildergalerie">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <br />
                        <br>
                        <br>
                        <br>
                        <dx:ASPxFileManager ID="UnitFileManager" runat="server" ClientInstanceName="FileManager" Height="367px" OnCustomCallback="UnitFileManager_CustomCallback" OnFilesUploaded="UnitFileManager_FilesUploaded" OnFileUploading="UnitFileManager_FileUploading" OnInit="UnitFileManager_Init" OnLoad="UnitFileManager_Load" ProviderType="Physical" Width="520px">
                            <Settings EnableMultiSelect="True" RootFolder="~/" ThumbnailFolder="~/Thumb/" />
                            <SettingsFileList>
                                <ThumbnailsViewSettings ThumbnailHeight="220px" ThumbnailWidth="220px">
                                </ThumbnailsViewSettings>
                            </SettingsFileList>
                            <SettingsEditing AllowDelete="True" AllowDownload="True" />
                            <SettingsFolders Visible="False" />
                            <SettingsToolbar ShowFilterBox="False" ShowPath="False">
                                <Items>
                                    <dx:FileManagerToolbarCustomButton CommandName="CropLogo" Text="Logo Image">
                                    </dx:FileManagerToolbarCustomButton>
                                    <dx:FileManagerToolbarCustomButton CommandName="CropTitel" Text="Titel Image">
                                    </dx:FileManagerToolbarCustomButton>
                                    <dx:FileManagerToolbarDownloadButton ToolTip="Download">
                                    </dx:FileManagerToolbarDownloadButton>
                                    <dx:FileManagerToolbarDeleteButton ToolTip="Delete (Del)">
                                    </dx:FileManagerToolbarDeleteButton>
                                    <dx:FileManagerToolbarRefreshButton ToolTip="Refresh">
                                    </dx:FileManagerToolbarRefreshButton>
                                </Items>
                            </SettingsToolbar>
                            <SettingsUpload>
                                <AdvancedModeSettings EnableMultiSelect="True">
                                </AdvancedModeSettings>
                            </SettingsUpload>
                            <SettingsAzure AccountName="adriabookblob" ContainerName="dataimage" />
                        </dx:ASPxFileManager>
                        <br>
                        <br>
                        <br>
                        <br></br>
                        <br><span style="font-size: small">Hochladen<br />
                        <br />
                        <br />
                        </span>
                        <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Allowed file extensions: .jpg, .jpeg, .gif, .png">
                        </dx:ASPxLabel>
                        <br>
                        <br>
                        <br></br>
                        <br>
                        <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Maximum file size: 4MB.">
                        </dx:ASPxLabel>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>

                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Name="Stop Booking" Text="Stop Booking">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <table class="dxeBinImgCPnlSys">
                            <tr>
                                <td style="width: 76px">
                                    <dx:ASPxButton ID="btnSetStopBooking" runat="server" OnClick="btnSetStopBooking_Click" Text="Set Stop Booking">
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="btnResetStopBooking" runat="server" OnClick="btnResetStopBooking_Click" Text="Reset Stop Booking">
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <br />
                        <dx:ASPxCalendar ID="calendarUnit" runat="server" Columns="3" EnableMultiSelect="True" OnDayCellPrepared="calendarUnit_DayCellPrepared" Rows="2" ShowClearButton="False" ShowTodayButton="False">
                        </dx:ASPxCalendar>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Name="Preisliste" Text="Preisliste">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <br />
                        <dx:ASPxFormLayout ID="LayoutDaten" runat="server">
                            <Items>
                                <dx:LayoutGroup Caption="Daten" ColCount="2">
                                    <Items>
                                        <dx:LayoutItem Caption="Max Persons" FieldName="MaxPersons" Name="MaxPersons">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox ID="txtMaxPersons" runat="server">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Max Adults" FieldName="MaxAdults" Name="MaxAdults">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxTextBox ID="txtMaxAdults" runat="server">
                                                    </dx:ASPxTextBox>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Open Date" FieldName="OpenDate" Name="Open Date">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxDateEdit ID="LayoutDaten_E1" runat="server">
                                                    </dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Close Date" FieldName="CloseDate" Name="CloseDate">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxDateEdit ID="txtCloseDate" runat="server">
                                                    </dx:ASPxDateEdit>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                        <dx:LayoutItem Caption="Update" Name="btnUpdates">
                                            <LayoutItemNestedControlCollection>
                                                <dx:LayoutItemNestedControlContainer runat="server">
                                                    <dx:ASPxButton ID="btnUpdates" runat="server" OnClick="btnUpdates_Click" Text="Update">
                                                    </dx:ASPxButton>
                                                </dx:LayoutItemNestedControlContainer>
                                            </LayoutItemNestedControlCollection>
                                        </dx:LayoutItem>
                                    </Items>
                                </dx:LayoutGroup>
                            </Items>
                        </dx:ASPxFormLayout>
                        <br />
                        <br>
                        <table class="dxflInternalEditorTable">
                            <tr>
                                <td style="width: 77px">
                                    <dx:ASPxButton ID="btnCopy" runat="server" Text="Copy" AutoPostBack="false">
                                         <ClientSideEvents Click="function(s, e) {
	                                      FeedPopupControl.Show();
                                       }" />
                                    </dx:ASPxButton>
                                </td>
                                <td>
                                   <dx:ASPxPopupControl ID="PopupControlData" runat="server" AllowDragging="True" AllowResize="True"
        CloseAction="CloseButton" ContentUrl="~/AspxArea/MasterData/Forms/UnitPopUp.aspx"
        EnableViewState="False" PopupElementID="popupArea" PopupHorizontalAlign="WindowCenter"
        PopupVerticalAlign="WindowCenter" ShowFooter="True" Width="585px"
        Height="300px" FooterText="Copy data"
        HeaderText="Document form" ClientInstanceName="FeedPopupControl" EnableHierarchyRecreation="True">
                                       <ContentCollection>
<dx:PopupControlContentControl runat="server"> 
</dx:PopupControlContentControl>
</ContentCollection>
<FooterTemplate>  
    <table style="border: none">
        <tr>
            <td>
                <dx:ASPxButton ID="btnOK" runat="server" AutoPostBack="False" Text="OK" Width="80px"
                    OnClick="btnOK_Click">
                    <ClientSideEvents Click="function(s, e) { FeedPopupControl.Hide();
                            // client-side processing is here
                            e.processOnServer = true;
                            // do some processing at the server side
                        }" />
                </dx:ASPxButton>
            </td>
            <td>
                <dx:ASPxButton ID="btnCancel" runat="server" AutoPostBack="False" ClientInstanceName="btnCancel"
                    Text="Cancel" Width="80px">
                    <ClientSideEvents Click="function(s, e) { FeedPopupControl.Hide(); }" />
                </dx:ASPxButton>
            </td>
        </tr>
      </table>

</FooterTemplate>
    </dx:ASPxPopupControl>
        </td>
    </tr>
</table>
                        <br>
                        <br>
                        <br>
                        <br>
                        <br></br>
                        <uc1:PriceListControl ID="PriceListControl1" runat="server" />
                        <br>
                        <br>
                        <br></br>
                        <br>
                        <br>
                        <br>
                        <br>
                        <br></br>
                        <br>
                        <br>
                        <br></br>
                        <br>
                        <br>
                        <br></br>
                        <br>
                        <br></br>
                        <br>
                        <br></br>
                        <br>
                        <br></br>
                        <br>
                        <br></br>
                        <br>
                        <br></br>
                        <br></br>
                        <br></br>
                        <br></br>
                        <br></br>
                        <br></br>
                        <br></br>
                        <br></br>
                        <br></br>
                        <br></br>
                        <br></br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                        </br>
                                  
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="Offers">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <dx:ASPxGridView ID="GridUnitOfferView" runat="server" AutoGenerateColumns="False" KeyFieldName="id" OnCellEditorInitialize="GridUnitOfferView_CellEditorInitialize" OnCustomButtonCallback="GridUnitOfferView_CustomButtonCallback" OnDataBinding="GridUnitOfferView_DataBinding" OnInit="GridUnitOfferView_Init" OnRowDeleting="GridUnitOfferView_RowDeleting" OnRowInserting="GridUnitOfferView_RowInserting" OnRowUpdating="GridUnitOfferView_RowUpdating" OnRowValidating="GridUnitOfferView_RowValidating" OnStartRowEditing="GridUnitOfferView_StartRowEditing">
                            <SettingsEditing Mode="PopupEditForm">
                            </SettingsEditing>
                            <EditFormLayoutProperties ColCount="2">
                                <Items>
                                    <dx:GridViewColumnLayoutItem ColumnName="TourOperatorCode">
                                    </dx:GridViewColumnLayoutItem>
                                    <dx:GridViewColumnLayoutItem ColumnName="OfferCode">
                                    </dx:GridViewColumnLayoutItem>
                                    <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="OfferTitel">
                                    </dx:GridViewColumnLayoutItem>
                                    <dx:GridViewColumnLayoutItem ColumnName="OfferCount">
                                    </dx:GridViewColumnLayoutItem>
                                    <dx:GridViewColumnLayoutItem ColumnName="UnitCode" Visible="False">
                                    </dx:GridViewColumnLayoutItem>
                                    <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="OfferDescription">
                                    </dx:GridViewColumnLayoutItem>
                                    <dx:GridViewColumnLayoutItem ColumnName="IsAutoStopBooking">
                                    </dx:GridViewColumnLayoutItem>
                                    <dx:GridViewColumnLayoutItem ColSpan="2" ColumnName="ProviderNotice">
                                    </dx:GridViewColumnLayoutItem>
                                    <dx:EditModeCommandLayoutItem ColSpan="2" HorizontalAlign="Right">
                                    </dx:EditModeCommandLayoutItem>
                                </Items>
                            </EditFormLayoutProperties>
                            <Columns>
                                <dx:GridViewCommandColumn ShowDeleteButton="True" ShowEditButton="True" ShowInCustomizationForm="True" ShowNewButtonInHeader="True" VisibleIndex="0">
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="id" ShowInCustomizationForm="True" VisibleIndex="2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="TourOperatorCode" ShowInCustomizationForm="True" VisibleIndex="3">
                                    <PropertiesTextEdit Width="100px">
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="SiteCode" ShowInCustomizationForm="True" VisibleIndex="4">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="OfferCode" ShowInCustomizationForm="True" VisibleIndex="5">
                                    <PropertiesTextEdit Width="100px">
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="OfferTitel" ShowInCustomizationForm="True" VisibleIndex="6">
                                    <PropertiesTextEdit Width="100px">
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="OfferDescription" Name="OfferDescription" ShowInCustomizationForm="True" VisibleIndex="7">
                                    <EditFormSettings Visible="True" />
                                    <EditItemTemplate>
                                        <dx:ASPxHtmlEditor ID="ASPxHtmlEditorDescription" runat="server" Html='<%# Bind("OfferDescription") %>'>
                                        </dx:ASPxHtmlEditor>
                                    </EditItemTemplate>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="OfferCount" ShowInCustomizationForm="True" VisibleIndex="8">
                                    <PropertiesTextEdit Width="100px">
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataCheckColumn FieldName="IsAutoStopBooking" ShowInCustomizationForm="True" VisibleIndex="9">
                                </dx:GridViewDataCheckColumn>
                                <dx:GridViewDataTextColumn FieldName="ProviderNotice" ShowInCustomizationForm="True" VisibleIndex="10">
                                    <PropertiesTextEdit Width="500px">
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewCommandColumn Name="PriceList" ShowInCustomizationForm="True" VisibleIndex="1">
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="ButtonPriceList" Text="PriceList">
                                            <Image Url="~/Content/Images/Add.png">
                                            </Image>
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="UnitCode" Name="UnitCode" ShowInCustomizationForm="True" VisibleIndex="11">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
        </TabPages>
    </dx:ASPxPageControl>
</asp:Content>
