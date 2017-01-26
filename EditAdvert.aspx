<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="EditAdvert.aspx.cs" Inherits="EditAdvert" %>

<%-- Add content controls here --%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="jumbotron">
        <div runat="server" id="xmlGeneratedContent">
        </div>
        <asp:Button ID="btnDelete" runat="server" Text="Избриши" OnClick="btnDelete_Click" />
        <asp:Button ID="btnApprove" runat="server" Text="Измени" OnClick="btnApprove_Click" />
    </div>
    <asp:Label ID="lblerror" runat="server" Text=""></asp:Label>
</asp:Content>