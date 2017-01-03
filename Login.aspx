<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!--title></!--title>
    <link rel="stylesheet" href="~/Content/bootstrap.css" />
    <style type="text/css">
        #loginForm {
            margin: 120px 500px;
        }
    </style-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="loginForm" class="form-horizontal">
        <fieldset>
            <legend>Најава</legend>
            <div class="form-group">
                <label for="txtTitle" class="col-lg-4 control-label">Внесете корисничко име:</label>
                <div class="col-lg-8">
                    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-lg-8">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Внесете корисничко име!" ForeColor="Red" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label for="txtTitle" class="col-lg-4 control-label">Внесете лозинка:</label>
                <div class="col-lg-8">
                    <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-lg-8">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Внесете лозинка!" ForeColor="Red" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                &nbsp;<div class="col-lg-8">
                    &nbsp;<br />
                    &nbsp;
                    <asp:Button ID="btnLogin" runat="server" Text="Најава" style="margin-left: 0px; float:right; margin-top:20px" Width="102px" OnClick="btnLogin_Click" />
                </div>

                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </div>
        </fieldset>
       
    </div>
    
</asp:Content>


