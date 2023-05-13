<%@ Page Title="Югра" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Team.aspx.cs" Inherits="khl.Team" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<section class="team-info">
<h1>Хоккейный клуб "Югра"</h1>
<p>Хоккейный клуб "Югра" является профессиональной хоккейной командой из города Ханты-Мансийска. Он был основан в 2006 году и выступает в Восточной конференции Континентальной хоккейной лиги (КХЛ).</p>
<p>Клуб имеет многочисленных болельщиков и является гордостью Ханты-Мансийского автономного округа – Югры.</p>
</section>
<h2>Фото команды</h2>
<img src="/img/team.jpg" />
<section class="team-stats">
<h2>Статистика команды</h2>
<table class="team-stats__table">
  <thead>
    <tr>
      <th>Сезон</th>
      <th>Игры</th>
      <th>Победы</th>
      <th>Ничьи</th>
      <th>Поражения</th>
      <th>Заброшенные шайбы</th>
      <th>Пропущенные шайбы</th>
      <th>Очки</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>2020/2021</td>
      <td>60</td>
      <td>30</td>
      <td>10</td>
      <td>20</td>
      <td>150</td>
      <td>130</td>
      <td>70</td>
    </tr>
    <tr>
      <td>2019/2020</td>
      <td>62</td>
      <td>32</td>
      <td>8</td>
      <td>22</td>
      <td>180</td>
      <td>140</td>
      <td>72</td>
    </tr>
    <tr>
      <td>2018/2019</td>
      <td>56</td>
      <td>28</td>
      <td>12</td>
      <td>16</td>
      <td>120</td>
      <td>100</td>
      <td>68</td>
    </tr>
  </tbody>
</table>
</section>
</asp:Content>