<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HintsUserControl.ascx.cs" Inherits="UserControls_HintsUserControl" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>


<dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="100%" HeaderText="Hints" Theme="BlackGlass">
  <PanelCollection>
<dx:PanelContent runat="server" SupportsDisabledAttribute="True">
  <div class="Hints">
  <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Hit - Space"  Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px">
  </dx:ASPxLabel>
  <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Double - D"  Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px">
  </dx:ASPxLabel>
  <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Split - S"  Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px">
  </dx:ASPxLabel>
  <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Surrender - X"  Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px">
  </dx:ASPxLabel>
  <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Stand - Return"  Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px">
  </dx:ASPxLabel>
  <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Increase Bet - Arrow Up"  Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px">
  </dx:ASPxLabel>
  <dx:ASPxLabel ID="ASPxLabel7" runat="server" Text="Decrease Bet - Arrow Down"  Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px">
  </dx:ASPxLabel>
  </div>
</dx:PanelContent>
</PanelCollection>
</dx:ASPxRoundPanel>

  