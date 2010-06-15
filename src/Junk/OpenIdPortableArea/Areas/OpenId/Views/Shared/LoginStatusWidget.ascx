<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Welcome <b><%= Html.Encode(Page.User.Identity.Name) %></b>!
        [ <%= Html.ActionLink("Logout", "Logout", "OpenId", new { area = "OpenId" }, null) %> ]
<%
    }
    else {
%> 
        [ <%= Html.ActionLink("Login", "Login", "OpenId", new { area = "OpenId" }, null)%> ]
<%
    }
%>
