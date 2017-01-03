<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Signup.aspx.cs" Inherits="Signup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!--title></!--title>
    <link rel="stylesheet" href="~/Content/bootstrap.css" />
    <style type="text/css">
        #registrationForm {
            margin: 120px 500px;
        }
    </style-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="registrationForm" class="form-horizontal">
        <fieldset>
            <legend>Регистрација</legend>
            <div class="form-group">
                <label for="txtTitle" class="col-lg-4 control-label">Внесете име:</label>
                <div class="col-lg-8">
                    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-lg-8">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Внесете име!" ForeColor="Red" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label for="txtTitle" class="col-lg-4 control-label">Внесете презиме:</label>
                <div class="col-lg-8">
                    <asp:TextBox ID="txtSurname" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-lg-8">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Внесете презиме!" ForeColor="Red" ControlToValidate="txtSurname"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label for="txtTitle" class="col-lg-4 control-label">Внесете е-маил:</label>
                <div class="col-lg-8">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-lg-8">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Внесете е-маил!" ForeColor="Red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                </div>
            </div>
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
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-lg-8">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Внесете лозинка!" ForeColor="Red" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                <label for="txtTitle" class="col-lg-4 control-label">Потврдете лозинка:</label>
                <div class="col-lg-8">
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-lg-8">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Внесете лозинка!" ForeColor="Red" ControlToValidate="txtConfirmPassword"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Лозинките не се совпаѓаат!" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" ForeColor="Red"></asp:CompareValidator>
                </div>
            </div>
            <div class="form-group">
                &nbsp;<div class="col-lg-8">
                    &nbsp;<br />
                    &nbsp;
                    <asp:Button ID="btnSignin" runat="server" Text="Регистрација" style="margin-left: 0px; float:right; margin-top:20px; height: 29px;" Width="117px" OnClick="btnSignin_Click" />
                </div>
                <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
            </div>
        </fieldset>
    </div>
</asp:Content>


