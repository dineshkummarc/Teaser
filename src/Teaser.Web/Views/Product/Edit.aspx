<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
	Inherits="MvcContrib.FluentHtml.ModelViewPage<ProductForm>" %>
<%@ Import Namespace="Teaser.Web.Core"%>
<%@ Import Namespace="MvcContrib.FluentHtml"%>
<%@ Import Namespace="Teaser.Entities"%>
<%@ Import Namespace="Teaser.Web.Models"%>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Edit Product</h2>
    <form action="<%= Url.Action("Save") %>" method="post">
		<%= this.Hidden(form => form.Id) %>
		<p>
			<label for="Name">Name:</label>
			<%= this.TextBox(form => form.Name) %>
		</p>
		<p>
			<label for="Model">Model:</label>
			<%= this.TextBox(form => form.Model) %>
		</p>
		<p>
			<label for="Sku">Sku:</label>
			<%= this.TextBox(form => form.Sku) %>
		</p>
		<p>
			<label for="Price">Price:</label>
			<%= this.TextBox(form => form.Price) %>
		</p>
		<input type="submit" value="Save" />
    </form>
    
</asp:Content>
