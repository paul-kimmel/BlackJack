<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StatusUserControl.ascx.cs" Inherits="UserControls_StatusUserControl" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<div>
  <table style="width:100%"> 
    <tr>
      <td style="width:20%">
        <dx:ASPxLabel ID="PlayerLabel" runat="server" Text="Player: 0" ForeColor="White" Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px"></dx:ASPxLabel>
      </td>
      <td style="width:20%">
        <dx:ASPxLabel ID="BetLabel" runat="server" Text="Bet: $25.00"  ForeColor="White" Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px"></dx:ASPxLabel>
      </td>
      <td style="width:20%">
        <dx:ASPxLabel ID="BalanceLabel" runat="server" Text="Balance: $0.00"  ForeColor="White" Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px"></dx:ASPxLabel>
      </td>
      <td style="width:20%">
        <dx:ASPxLabel ID="DealerLabel" runat="server" Text="Dealer: Joker"  ForeColor="White" Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px"></dx:ASPxLabel>
      </td>
      <td style="width:20%">
        <dx:ASPxLabel ID="HintLabel" runat="server" Text="Hint: PLay to win" ToolTip="Play to win"  ForeColor="White" Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px"></dx:ASPxLabel>
      </td>
    </tr>
  </table>
</div>