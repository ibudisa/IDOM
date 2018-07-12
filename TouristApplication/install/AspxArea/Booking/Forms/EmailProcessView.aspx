<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeBehind="EmailProcessView.aspx.cs" Inherits="V50_IDOMBackOffice.AspxArea.Booking.Forms.EmailProcessView" %>
<%@ Register assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxHtmlEditor" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="dxhe-dialogControlsWrapper">
        <tr>
            <td style="width: 80px">
    <dx:ASPxButton ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click">
    </dx:ASPxButton>
            </td>
            <td>
                <dx:ASPxLabel ID="lblStatusName" runat="server">
                </dx:ASPxLabel>
            </td>
        </tr>
    </table>
    </br>
    <table class="dxhe-dialogControlsWrapper">
        <tr>
            <td style="width: 75px">From</td>
            <td style="width: 132px">
                <dx:ASPxComboBox ID="comboboxFrom" runat="server" ValueType="System.String" TextField="Email" ValueField="Id">
                </dx:ASPxComboBox>
            </td>
           
        </tr>
        <tr>
            <td style="width: 75px; height: 23px">To</td>
            <td style="height: 23px; width: 132px;">
                <dx:ASPxComboBox ID="comboboxTo" runat="server" ValueType="System.String" TextField="Email" ValueField="Id" DropDownStyle="DropDown">
                </dx:ASPxComboBox>
            </td>
            <td> <dx:ASPxButton ID="ASPxButton1" runat="server" OnClick="btnAdd_Click" Text="AddEmail">
                </dx:ASPxButton></td>
             
        </tr>
        </table>
     <table class="dxhe-dialogControlsWrapper">
        <tr>
            <td style="width: 75px">Subject</td>
            <td style="width: 132px">
                <dx:ASPxTextBox ID="txtSubject" runat="server" Width="590px" style="margin-left: 0px">
                </dx:ASPxTextBox>
            </td>
        </tr>
    </table>
    <br />
&nbsp;
    <br />
    <dx:ASPxPageControl ID="PageControlTemplate" runat="server" ActiveTabIndex="0" AutoPostBack="True" OnActiveTabChanged="PageControlTemplate_ActiveTabChanged" Width="670px">
        <TabPages>
            <dx:TabPage Text="Template">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        &nbsp;<table class="dxhe-dialogControlsWrapper">
                            <tr>
                                <td style="width: 152px">
                                    <dx:ASPxComboBox ID="comboboxTemplate" runat="server" TextField="Name" ValueField="Id" Width="383px">
                                    </dx:ASPxComboBox>
                                </td>
                                <td style="width: 208px">
                                    <dx:ASPxButton ID="btnLoad" runat="server" Text="Load" OnClick="btnLoad_Click">
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                        </table>
                        &nbsp;
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="Edit">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <table class="dxhe-dialogControlsWrapper">
                            <tr>
                                <td>&nbsp;</td>
                                <td style="width: 65px">
                                    <dx:ASPxButton ID="btnNew" runat="server" Text="New" OnClick="btnNew_Click">
                                    </dx:ASPxButton>
                                </td>
                                <td style="width: 332px">
                                    <dx:ASPxTextBox ID="txtEdit" runat="server" Width="345px">
                                    </dx:ASPxTextBox>
                                </td>
                                <td>
                                    <dx:ASPxButton ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click">
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                        </table>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
        </TabPages>
    </dx:ASPxPageControl>
    <br />
    <br />
    <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Text">
    </dx:ASPxLabel>
    <br />
    <br />
    <dx:ASPxHtmlEditor ID="HtmlEditorContent" runat="server">
    </dx:ASPxHtmlEditor>
    <br />
    <br />
</asp:Content>
