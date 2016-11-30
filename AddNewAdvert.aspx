<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddNewAdvert.aspx.cs" Inherits="AddNewAdvert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 45px;
        }
        .auto-style2 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Внесете нов оглас:"></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTitle" runat="server" Text="Наслов"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblBody" runat="server" Text="Текст"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="tbContent" TextMode="MultiLine" Columns="50" Rows="5" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblImage" runat="server" Text="Слика"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="fuImage" runat="server" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="Зачувај" OnClick="btnSubmit_Click" />
                </td>
            </tr>
        </table> 
        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
