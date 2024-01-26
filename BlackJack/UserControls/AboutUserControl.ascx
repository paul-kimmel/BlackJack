<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AboutUserControl.ascx.cs" Inherits="UserControls_AboutUserControl" %>
<%--<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>--%>
<div class="About">
  <%--<dx:ASPxImage ID="ASPxImage1" runat="server" ImageUrl="~/BlackJack/Images/Information.png" IsPng="True" ></dx:ASPxImage>
  <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Guided BlackJack v2.0" Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="12px"></dx:ASPxLabel>
  <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Copyright © 2014. All Rights Reserved." Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="12px"></dx:ASPxLabel>
  <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="By Software Conceptions, Inc" Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="12px"></dx:ASPxLabel>
  <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Written by Paul Kimmel" Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="12px"></dx:ASPxLabel>--%>
</div>
<div style="float:right;padding-top:10px;">
  <%--<dx:ASPxButton ID="ASPxButton1" runat="server" Text="Close">--%>
    <ClientSideEvents Click="function(s, e) {
	AboutPopup.Hide();
}" />
  </dx:ASPxButton>
</div>