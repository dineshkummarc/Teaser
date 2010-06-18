<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
    <ul>
        <li>
            <%= Html.ActionLink("Account.UserList", MVC.Account.UserList())%>
        </li>
        <li>
            <%= Html.ActionLink("Account.Welcome", MVC.Account.Welcome())%>
        </li>
        <li>
            <%= Html.ActionLink("Account.UserInfo", MVC.Account.UserInfo())%>
        </li>
        <li>
            <%= Html.ActionLink("SiteUser.Index", MVC.SiteUser.Index())%>
        </li>
    </ul>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>
