<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddNewAdvert.aspx.cs" Inherits="AddNewAdvert" %>

<asp:Content ID="AddNewAdvertFormContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <div id="newAdvertForm" class="form-horizontal container">
        <fieldset>
            <legend>Додади нов оглас</legend>

            <div class="row">
                <div class="form-group">
                    <label for="txtTitle" class="col-lg-2 control-label">Наслов</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="form-group">
                    <label for="tbContent" class="col-lg-2 control-label">Содржина</label>
                    <div class="col-lg-10">
                        <asp:TextBox ID="tbContent" TextMode="MultiLine" Columns="50" Rows="5" runat="server"></asp:TextBox>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="form-group">
                    <label for="fuImage" class="col-lg-2 control-label">Додади слика</label>
                    <div class="col-lg-10">
                        <asp:FileUpload ID="fuImage" runat="server" />
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="form-group">
                    <div class="col-lg-1"></div>
                    <div class="col-lg-10">
                        <asp:Button ID="btnCancel" runat="server" class="btn btn-default " Text="Откажи" type="reset" />
                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-default" Text="Зачувај" OnClick="btnSubmit_Click" />
                    </div>
                    <div class="col-lg-1">
                        <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>