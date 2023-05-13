<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="khl.Cart" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<h2>Ваша корзина:</h2>
<asp:GridView ID="CartGridView" runat="server" AutoGenerateColumns="False">
<Columns>
<asp:BoundField DataField="ItemName" HeaderText="Название" />
<asp:BoundField DataField="ItemPrice" HeaderText="Цена" />
<asp:TemplateField HeaderText="Remove">
<ItemTemplate>
<asp:Button ID="RemoveButton" runat="server" Text="Remove" OnClick="RemoveButton_Click" CommandArgument='<%# Eval("ItemName") %>' />
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>
<br />
<asp:Label ID="TotalLabel" runat="server" Text="Общая сумма: ₽0" />
</asp:Content>
