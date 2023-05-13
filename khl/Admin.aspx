<%@ Page Title="Администратор" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="khl.Admin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Администратор</h2>
    <hr />
    <div class="row">
        <div class="col-md-6">
            <h4>Добавление новости</h4>
            <hr />
            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
            <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" placeholder="Заголовок"></asp:TextBox>
            <asp:TextBox ID="txtContent" runat="server" CssClass="form-control" placeholder="Текст новости"></asp:TextBox>
            <asp:Calendar ID="calDate" runat="server" />
            <asp:FileUpload ID="fileUpload" runat="server" />
            <asp:Button ID="btnAddNews" runat="server" Text="Добавить новость" CssClass="btn btn-primary" OnClick="btnAddNews_Click" />
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <h4>Удаление пользователя</h4>
            <hr />
            <asp:Label ID="lblDeleteMessage" runat="server" Visible="false"></asp:Label>
            <asp:TextBox ID="txtDeleteId" runat="server" CssClass="form-control" placeholder="ID пользователя"></asp:TextBox>
            <asp:Button ID="btnDeleteUser" runat="server" Text="Удалить пользователя" CssClass="btn btn-danger" OnClick="btnDeleteUser_Click" />
        </div>
    </div>
</asp:Content>
