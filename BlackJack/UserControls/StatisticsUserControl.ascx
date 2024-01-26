<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StatisticsUserControl.ascx.cs" Inherits="UserControls_StatisticsUserControl" %>
<%@ Register Assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxRoundPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPanel" tagprefix="dx" %>



<dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" HeaderText="Statistics" Theme="BlackGlass" Width="100%">
  <PanelCollection>
<dx:PanelContent runat="server" SupportsDisabledAttribute="True">
  <div class="Statistics">
    <dx:ASPxLabel ID="SurrendedLabel" runat="server" Text="Surrendered: "  Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px">
    </dx:ASPxLabel>
    <dx:ASPxLabel ID="WinsLabel" runat="server" Text="Wins: "  Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px">
    </dx:ASPxLabel>
    <dx:ASPxLabel ID="LossesLabel" runat="server" Text="Losses: "  Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px">
    </dx:ASPxLabel>
    <dx:ASPxLabel ID="PushesLabel" runat="server" Text="Pushes: "  Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px">
    </dx:ASPxLabel>
    <dx:ASPxLabel ID="AverageWonLabel" runat="server" Text="Average amount won per hand: "  Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px">
    </dx:ASPxLabel>
    <dx:ASPxLabel ID="AverageLostLabel" runat="server" Text="Average amount lost per hand: "  Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px">
    </dx:ASPxLabel>
    <dx:ASPxLabel ID="NetAverageLabel" runat="server" Text="Net average won/lost per hand: "  Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px">
    </dx:ASPxLabel>
    <dx:ASPxLabel ID="TotalWonLabel" runat="server" Text="Total amount won: "  Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px">
    </dx:ASPxLabel>
    <dx:ASPxLabel ID="TotalLostLabel" runat="server" Text="Total amount lost: "  Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px">
    </dx:ASPxLabel>
    <dx:ASPxLabel ID="NetWonLossLabel" runat="server" Text="Net Won/Lost: "  Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px">
    </dx:ASPxLabel>
    <dx:ASPxLabel ID="PercentageWinLabel" runat="server" Text="Percentage of wins: "  Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px">
    </dx:ASPxLabel>
    <dx:ASPxLabel ID="PercentageLossLabel" runat="server" Text="Percentage of losses: "  Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px">
    </dx:ASPxLabel>
    <dx:ASPxLabel ID="PercentagePushLabel" runat="server" Text="Percentage of pushes:"  Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px">
    </dx:ASPxLabel>
    <dx:ASPxLabel ID="BlackJacksLabel" runat="server" Text="BlackJacks/As Percentage of: 0/0.00%"  Font-Bold="False" Font-Names="Tahoma,Geneva,sans-serif" Font-Size="14px">
    </dx:ASPxLabel>
  </div>
  </dx:PanelContent>
</PanelCollection>
</dx:ASPxRoundPanel>


