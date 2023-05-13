<%@ Page Title="Авторизация" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="khl.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Авторизация</h2>
    <hr />
    <div class="row">
        <div class="col-md-6">
            <h4>Введите email и пароль для входа:</h4>
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" ValidationGroup="LoginGroup" />
            <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail">Email:</asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ValidationGroup="LoginGroup"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Email обязателен" CssClass="text-danger" ValidationGroup="LoginGroup" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Неверный формат Email" CssClass="text-danger" ValidationExpression="\w+([-+.']\w+)@\w+([-.]\w+).\w+([-.]\w+)*" ValidationGroup="LoginGroup"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword">Пароль:</asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" ValidationGroup="LoginGroup"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Пароль обязателен" CssClass="text-danger" ValidationGroup="LoginGroup" />
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Войти" CssClass="btn btn-primary" ValidationGroup="LoginGroup" OnClick="btnLogin_Click" />
        </div>
    </div>
</asp:Content>