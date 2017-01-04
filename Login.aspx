<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="LoginFormContent" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="loginForm" class="form-horizontal container">
        <fieldset>
            <legend>Најава</legend>

            <div class="row">
                <div class="form-group">
                    <label for="txtTitle" class="col-lg-2 control-label">Внесете корисничко име:</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="form-group">
                    <div class="col-lg-2"></div>
                    <div class="col-lg-10">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Внесете корисничко име!" ForeColor="Red" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="form-group">
                    <label for="txtTitle" class="col-lg-2 control-label">Внесете лозинка:</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="form-group">
                    <div class="col-lg-2"></div>
                    <div class="col-lg-10">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Внесете лозинка!" ForeColor="Red" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="form-group">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10">
                        <asp:Button ID="btnLogin" class="btn btn-default" runat="server" Text="Најава" OnClick="btnLogin_Click" />
                    </div>
                    <div class="col-lg-1">
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </fieldset>       
    </div>    
</asp:Content>