<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<OpenIdPortableArea.Areas.OpenId.Models.LoginInput>" %>
<%@ Import Namespace="OpenIdPortableArea.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Success!
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Login Successful</h2>

    <p>Your login was successful.</p>
</asp:Content>