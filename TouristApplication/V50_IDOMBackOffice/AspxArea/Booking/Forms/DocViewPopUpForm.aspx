<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DocViewPopUpForm.aspx.cs" Inherits="V50_IDOMBackOffice.AspxArea.Booking.Forms.DocViewPopUpForm" %>

<%@ Register assembly="DevExpress.Web.ASPxHtmlEditor.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxHtmlEditor" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v17.1, Version=17.1.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Content<br />
        <br />
        <dx:ASPxHtmlEditor ID="HtmlEditorItem" runat="server">
        </dx:ASPxHtmlEditor>
    
    </div>
    </form>
</body>
</html>
