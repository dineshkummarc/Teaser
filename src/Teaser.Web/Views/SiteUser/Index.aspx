<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SiteUserModel[]>" %>
<%@ Import Namespace="Teaser.Web.Core" %>
<%@ Import Namespace="Teaser.Web.Models" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Name
            </th>
            <th>
                Email
            </th>
        </tr>

		<% var i = 0; %>
		<% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new {   id=item.Id  }) %> |
                <%= Html.ActionLink("Details", "Details", new { id = item.Id })%> |
                <%= Html.ActionLink("Delete", "Delete", new { id = item.Id })%>
            </td> 
		    <td><%= Html.Span(m => m[i].Id)%></td> 
		    <td><%= Html.Span(m => m[i].Name) %></td> 
		    <td><%= Html.Span(m => m[i].Email) %></td> 
        </tr>
    
    <% 
        i++;
     } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>

