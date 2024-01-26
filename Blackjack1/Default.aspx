<%@ Page Title="BlackJack" Language="C#" MasterPageFile="~/BlackJack.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="~/UserControls/HandsUserControl.ascx" TagPrefix="uc1" TagName="HandsUserControl" %>
<%@ Register Src="~/UserControls/StatusUserControl.ascx" TagPrefix="uc1" TagName="StatusUserControl" %>
<%@ Register Src="~/UserControls/NavigatorUserControl.ascx" TagPrefix="uc1" TagName="NavigatorUserControl" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
<%@ Register src="UserControls/AboutUserControl.ascx" tagname="AboutUserControl" tagprefix="uc2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
  <uc1:navigatorusercontrol runat="server" id="NavigatorUserControl" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <uc1:HandsUserControl runat="server" ID="HandsUserControl" />
  <dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" RenderMode="Lightweight" AllowDragging="True" AutoUpdatePosition="True" HeaderText="About Guided BlackJack" Height="300px" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="400px" BackColor="Gainsboro" ClientInstanceName="AboutPopup" CssClass="AboutPopup">
      
      <ContentStyle CssClass="AboutContent">
      </ContentStyle>
      
      <ContentCollection>
<dx:PopupControlContentControl runat="server" SupportsDisabledAttribute="True"><uc2:AboutUserControl ID="AboutUserControl1" runat="server" /></dx:PopupControlContentControl>
</ContentCollection>
  </dx:ASPxPopupControl>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
  <uc1:StatusUserControl runat="server" ID="StatusUserControl" />
</asp:Content>


