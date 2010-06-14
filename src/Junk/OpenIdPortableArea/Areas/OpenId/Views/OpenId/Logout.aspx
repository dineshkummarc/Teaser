<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Logout
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Logout</h2>
    <% using(Html.BeginRouteForm("OpenId")) { %>
    <p>You are about to logout.  Remember that you can always login with your OpenID account.</p>
    <input type="submit" value="Logout" />
    <% } %>
</asp:Content>