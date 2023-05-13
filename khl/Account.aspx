<%@ Page Title="Личный кабинет" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="khl.Account" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Личный кабинет</h2>
    <hr />
    <div class="row">
        <div class="col-md-6">
            <h4>Добро пожаловать, <%: this.firstName %> <%: this.lastName %>!</h4>
            <p>Здесь вы можете просмотреть информацию о своем аккаунте и совершенных покупках.</p>
            <p>Email: <%: Session["Email"] %></p>
            <br />
            <asp:Button ID="btnLogout" runat="server" Text="Выйти" CssClass="btn btn-danger" OnClick="btnLogout_Click" />
        </div>
        <div class="col-md-6">
            <h4>Редактирование профиля</h4>
            <hr />
            <asp:Label ID="lblMessage" runat="server" Visible="false"></asp:Label>
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" Text="" placeholder="Имя"></asp:TextBox>
            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" Text="" placeholder="Фамилия"></asp:TextBox>
            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" Text="" placeholder="Номер телефона"></asp:TextBox>
            <asp:Button ID="btnSave" runat="server" Text="Сохранить" CssClass="btn btn-primary" OnClick="btnSave_Click" />
        </div>
    </div>
</asp:Content>
