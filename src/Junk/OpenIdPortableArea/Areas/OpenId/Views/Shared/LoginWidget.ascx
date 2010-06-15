﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<OpenIdPortableArea.Areas.OpenId.Models.LoginInput>" %>

<% using (Html.BeginRouteForm(new { action = "Login", controller = "OpenId", area = "OpenId" }))
   { %>    
    <div class="openIdLoginForm">
        <div class="loginControls">
            <input id="openIdUrl" name="openIdUrl" class="openIdUrlInput" />
            <%= Html.HiddenFor(m => m.ReturnUrl) %>
            <input id="loginButton" type="submit" value="Login" />
        </div>
    </div>
<% } %>