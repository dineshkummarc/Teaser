<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Teaser.Web.Models.RpxUserModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>UserInfo</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">Id</div>
        <div class="display-field"><%= Html.Encode(Model.Id) %></div>
        
        <div class="display-label">SiteUserId</div>
        <div class="display-field"><%= Html.Encode(Model.SiteUserId) %></div>
        
        <div class="display-label">Identifier</div>
        <div class="display-field"><%= Html.Encode(Model.Identifier) %></div>
        
        <div class="display-label">ProviderName</div>
        <div class="display-field"><%= Html.Encode(Model.ProviderName) %></div>
        
        <div class="display-label">DisplayName</div>
        <div class="display-field"><%= Html.Encode(Model.DisplayName) %></div>
        
        <div class="display-label">JsonData</div>
        <div class="display-field"><%= Html.Encode(Model.JsonData) %></div>
        
    </fieldset>
    <p>
        <%= Html.ActionLink("Edit", "Edit", new { id=Model.Id }) %> |
        <%= Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>

