<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<link rel="stylesheet" type="text/css" href="/OpenId/Styles/providers.css" />
<p>Choose your OpenID Provider below, or manually enter your OpenID Url.</p>
<ul class="openIdProviders">
    <li><div id="Google" title="Google" class="hoverButton" onclick="OpenIdHandler('google', true)">&nbsp;</div></li>
    <li><div id="Yahoo" title="Yahoo" class="hoverButton" onclick="OpenIdHandler('yahoo', true)">&nbsp;</div></li>
    <li><div id="myOpenId" title="myOpenId" class="hoverButton" onclick="OpenIdHandler('myOpenId', false)">&nbsp;</div></li>
    <li><div id="AOL" title="AOL" class="hoverButton" onclick="OpenIdHandler('AOL', false)">&nbsp;</div></li>
</ul>
<script src="/OpenId/Scripts/providers.js" type="text/javascript"></script>