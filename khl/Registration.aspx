<%@ Page Title="Регистрация" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="khl.Registration" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Регистрация нового пользователя</h2>
    <hr />
    <div class="row">
        <div class="col-md-6">
            <h4>Для регистрации заполните следующие поля:</h4>
            <br />
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" ValidationGroup="RegistrationGroup" />
            <asp:Label ID="lblFirstName" runat="server" AssociatedControlID="txtFirstName">Имя:</asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" ValidationGroup="RegistrationGroup"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName" Display="Dynamic" ErrorMessage="Имя обязательно" CssClass="text-danger" ValidationGroup="RegistrationGroup" />
            <br />
            <asp:Label ID="lblLastName" runat="server" AssociatedControlID="txtLastName">Фамилия:</asp:Label>
            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" ValidationGroup="RegistrationGroup"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName" Display="Dynamic" ErrorMessage="Фамилия обязательна" CssClass="text-danger" ValidationGroup="RegistrationGroup" />
            <br />
            <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail">Email:</asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ValidationGroup="RegistrationGroup"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Email обязателен" CssClass="text-danger" ValidationGroup="RegistrationGroup" />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Неверный формат Email" CssClass="text-danger" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="RegistrationGroup"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword">Пароль:</asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" ValidationGroup="RegistrationGroup"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Пароль обязателен" CssClass="text-danger" ValidationGroup="RegistrationGroup" />
            <br />
            <asp:Label ID="lblConfirmPassword" runat="server" AssociatedControlID="txtConfirmPassword">Подтвердите пароль:</asp:Label>
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-control" ValidationGroup="RegistrationGroup"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtConfirmPassword" Display="Dynamic" ErrorMessage="Подтверждение пароля обязательно" CssClass="text-danger" ValidationGroup="RegistrationGroup" />
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" Display="Dynamic" ErrorMessage="Пароли не совпадают" CssClass="text-danger" ValidationGroup="RegistrationGroup" />
            <br />
            <asp:Button ID="btnRegister" runat="server" Text="Зарегистрироваться" CssClass="btn btn-primary" ValidationGroup="RegistrationGroup" OnClick="btnRegister_Click" />
            </div>
            </div>
            </asp:Content>
