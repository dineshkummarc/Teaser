<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Teaser.Web.Models.UserProfileModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>UserProfile</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">SiteUserName</div>
        <div class="display-field"><%= Html.Encode(Model.SiteUserName) %></div>
        
        <div class="display-label">RpxUserIdentity</div>
        <div class="display-field"><%= Html.Encode(Model.RpxUserIdentity) %></div>
        
        <div class="display-label">LeagueName</div>
        <div class="display-field"><%= Html.Encode(Model.LeagueName) %></div>
        
        <div class="display-label">TeaserTeamName</div>
        <div class="display-field"><%= Html.Encode(Model.TeaserTeamName) %></div>
        
        <div class="display-label">RoleName</div>
        <div class="display-field"><%= Html.Encode(Model.RoleName) %></div>
        
    </fieldset>
    <p> 
        <%= Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="javascript" runat="server">
</asp:Content>

