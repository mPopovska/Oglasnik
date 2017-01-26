<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyAdverts.aspx.cs" Inherits="MyAdverts" %>

<%-- Add content controls here --%>

<asp:Content ID="CategoryPlaceHolder" ContentPlaceHolderID="CategoryPlaceHolder" runat="server">
    <asp:DropDownList ID="ddlCategory" runat="server" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
        <asp:ListItem Value="avtomobili">Компјутери</asp:ListItem>
        <asp:ListItem Value="kompjuteri">Автомобили</asp:ListItem>
        <asp:ListItem Value="televizori">Мобилни телефони</asp:ListItem>
        <asp:ListItem Value="mobilni_telefoni">Телевизори</asp:ListItem>
        <asp:ListItem Value="bela_tehnika">Компјутерска опрема</asp:ListItem>
        <asp:ListItem Value="kompjuterska_oprema">Бела техника</asp:ListItem>
        <asp:ListItem Value="ostanato">Останато</asp:ListItem>
    </asp:DropDownList>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div runat="server" id="xmlGeneratedContent">
    </div>  
    <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
</asp:Content>
