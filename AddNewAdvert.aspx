<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddNewAdvert.aspx.cs" Inherits="AddNewAdvert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <!--title>Додади нов оглас</!--title>
    <link rel="stylesheet" href="~/Content/bootstrap.css" />

    <style>
        #newAdvertForm {
            margin: 120px 500px;
        }
    </style-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="newAdvertForm" class="form-horizontal">
        <fieldset>
                <legend>Додади нов оглас</legend>
                <div class="form-group">
                    <label for="txtTitle" class="col-lg-2 control-label">Наслов</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label for="tbContent" class="col-lg-2 control-label">Содржина</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="tbContent" TextMode="MultiLine" Columns="50" Rows="5" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <label for="fuImage" class="col-lg-2 control-label">Додади слика</label>
                    <div class="col-lg-10">
                        <asp:FileUpload ID="fuImage" runat="server" />
                    </div>
                </div>
                <div class="form-group">
                    &nbsp;<div class="col-lg-10">
                        &nbsp;<br />
                        &nbsp;
                        <asp:Button ID="btnCancel" runat="server" class="btn btn-default" Text="Откажи" type="reset"/>
                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-default" Text="Зачувај" OnClick="btnSubmit_Click" />

                    </div>

                    <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                </div>
            </fieldset>
        </div>
</asp:Content>


