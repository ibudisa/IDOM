<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersForm.aspx.cs" Inherits="V50_IDOMBackOffice.SupportForms.UsersForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 133px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">FirstName:</td>
                <td>
                    <dx:ASPxTextBox ID="txtFirstName" runat="server" Width="170px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">LastName:</td>
                <td>
                    <dx:ASPxTextBox ID="txtLastName" runat="server" Width="170px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Email:</td>
                <td>
                    <dx:ASPxTextBox ID="txtEmail" runat="server" Width="170px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">UserName:</td>
                <td>
                    <dx:ASPxTextBox ID="txtUserName" runat="server" Width="170px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Password:</td>
                <td>
                    <dx:ASPxTextBox ID="txtPassword" runat="server" Width="170px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">IPAddress:</td>
                <td>
                    <dx:ASPxTextBox ID="txtIPAddress" runat="server" Width="170px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Season:</td>
                <td>
                    <dx:ASPxTextBox ID="txtSeason" runat="server" Width="170px">
                    </dx:ASPxTextBox>
                </td>
            </tr>
        </table>
        <br />
        <dx:ASPxButton ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save">
        </dx:ASPxButton>
    </br>
    </div>
    </form>
</body>
</html>
