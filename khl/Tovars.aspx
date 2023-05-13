<%@ Page Title="Tovars" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tovars.aspx.cs" Inherits="khl.Tovars" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <h1>Товары</h1>
        <asp:DropDownList ID="CategoryDropDownList" runat="server" AutoPostBack="true" OnSelectedIndexChanged="CategoryDropDownList_SelectedIndexChanged">
            <asp:ListItem Text="Все категории" Value="0"></asp:ListItem>
            <asp:ListItem Text="Билеты" Value="1"></asp:ListItem>
            <asp:ListItem Text="Головные уборы" Value="2"></asp:ListItem>
            <%--<asp:ListItem Text="Категория 3" Value="3"></asp:ListItem>--%>
        </asp:DropDownList>
        <br />
        <br />
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="tovar">
                    <h2><%# Eval("name") %></h2>
                    <img src='<%# Eval("img") %>' alt='<%# Eval("name") %>' Height="200px" Width="200px"/>
                    <p><%# Eval("shortdesc") %></p>
                    <p><%# Eval("price") %> руб.</p>
                    <asp:Button ID="Button1" runat="server" Text="Добавить в корзину" OnClick="Button1_Click" CommandArgument='<%# Eval("id") %>' />
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>
