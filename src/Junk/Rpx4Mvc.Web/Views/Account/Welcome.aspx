<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Welcome
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div>token: <%= Html.Encode(ViewData["token"]) %></div>
    <h2>Welcome</h2>


    <div><%= Html.ActionLink("Login", "Login", "Account")%></div>

    <table>
    <tr><td>Request.ApplicationPath</td><td><%= Request.ApplicationPath %></td></tr>
    <tr><td>Request.CurrentExecutionFilePath</td><td><%= Request.CurrentExecutionFilePath%></td></tr>
    <tr><td>Request.FilePath</td><td><%= Request.FilePath%></td></tr>
    <tr><td>Request.Path</td><td><%= Request.Path%></td></tr>
    <tr><td>Request.PhysicalApplicationPath</td><td><%= Request.PhysicalApplicationPath%></td></tr>
    <tr><td>Request.QueryString</td><td><%= Request.QueryString%></td></tr>
    <tr><td>Request.Url.AbsolutePath</td><td><%= Request.Url.AbsolutePath%></td></tr>
    <tr><td>Request.Url.AbsoluteUri</td><td><%= Request.Url.AbsoluteUri%></td></tr>
    <tr><td>Request.Url.Fragment</td><td><%= Request.Url.Fragment%></td></tr>
    <tr><td>Request.Url.Host</td><td><%= Request.Url.Host%></td></tr>
    <tr><td>Request.Url.Authority</td><td><%= Request.Url.Authority%></td></tr>
    <tr><td>Request.Url.LocalPath</td><td><%= Request.Url.LocalPath%></td></tr>
    <tr><td>Request.Url.PathAndQuery</td><td><%= Request.Url.PathAndQuery%></td></tr>
    <tr><td>Request.Url.Port</td><td><%= Request.Url.Port%></td></tr>
    <tr><td>Request.Url.Query</td><td><%= Request.Url.Query %></td></tr>
    <tr><td>Request.Url.Scheme</td><td><%= Request.Url.Scheme%></td></tr>
    <tr><td>Request.Url.Segments</td><td><%= Request.Url.Segments%></td></tr>
    <tr><td>Request.Url</td><td><%= Request.Url%></td></tr>
   
    </table>
   
   

</asp:Content>
