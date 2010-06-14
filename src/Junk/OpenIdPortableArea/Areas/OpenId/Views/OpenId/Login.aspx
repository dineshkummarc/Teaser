<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<OpenIdPortableArea.Areas.OpenId.Models.LoginInput>" %>
<%@ Import Namespace="OpenIdPortableArea.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Login
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <img src="/OpenId/Images/logo_openid.png" width="120" height="41" alt="OpenID" class="openIdLogo" />
    <h2>Login</h2>

    <p>Please login using an OpenId account.</p>
    
    <%= Html.ValidationSummary("There was a problem with the OpenID URL provided.")%>
    <% Html.EnableClientValidation(); %>
    <%= Html.LoginWidget(Model) %>
    <%= Html.ProvidersWidget() %>
    
    <div style="clear:both;" />
</asp:Content>