<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="khl._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div class="container">
<h1>Новости</h1>
<hr />
<% foreach (var item in GetNews()) { %>
<div class="news-item">
<h3><%= item.name %></h3>
<img src="<%= item.img %>" alt="news-image" />
<p><%= item.shortdesc %></p>
<span class="date"><%= item.date.ToString("dd.MM.yyyy") %></span>
</div>
<hr />
<% } %>
</div>
</asp:Content>