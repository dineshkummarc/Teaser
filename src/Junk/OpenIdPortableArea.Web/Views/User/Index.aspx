<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.UserListViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">




    <table>
        <tr>
            <th>Email</th>
            <th>Name</th>
            <th>ClaimId</th> 
        </tr>
        
    <% using (Html.BeginForm()) {%>

    <% foreach (var item in Model.List)
       { %>
    
        <tr> 
            <td> <%= Html.Encode(item.Email)%> </td>
            <td> <%= Html.Encode(item.Name)%> </td>
            <td> <%= Html.Encode(item.OpenId)%> </td>
        </tr>
    
    <% } %>
            
    </table>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
