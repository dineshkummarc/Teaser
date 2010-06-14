<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master"  Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Services.Entities.User>" %>


<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Register
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Register</h2>
    
    <% Html.EnableClientValidation(); %>
    <%=  Html.ValidationSummary()  %>
    
    <%  using (Html.BeginForm()) { %>
        <%= Html.EditorForModel() %> 
        <input type="submit" value="Register" />
    <% } %>
</asp:Content>
