<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OptionsUserControl.ascx.cs" Inherits="UserControls_OptionsUserControl" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>
<style type="text/css">
  .auto-style1
  {
    height: 25px;
  }
</style>
<div style="width:400px;height:100%">
  <table style="width:100%;height:100%;border-spacing: 4px;">
    <tr>
      <td>
        <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Player Name:">
        </dx:ASPxLabel>
      </td>
      <td>
        <dx:ASPxTextBox ID="PlayerNameTextBox" runat="server" Width="170px" Text="Player 1">
        </dx:ASPxTextBox>
      </td>
    </tr>
    <tr>
      <td><dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Increase/Decrease Bet By:">
        </dx:ASPxLabel></td>
      <td>

        <dx:ASPxSpinEdit ID="BetSpinEdit" runat="server" Height="21px" MaxValue="500" MinValue="5" Number="0" />

      </td>
    </tr>
    <tr>
      <td><dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Player Funds:">
        </dx:ASPxLabel></td>
      <td>

        <dx:ASPxSpinEdit ID="FundsSpinEdit" runat="server" Height="21px" MaxValue="10000" MinValue="100" Number="500" />

      </td>
    </tr>
    <tr>
      <td>
        <dx:ASPxCheckBox ID="ASPxCheckBox1" runat="server" Enabled="False" Text="Record Play" ToolTip="Record play statistics">
        </dx:ASPxCheckBox>
      </td>
      <td>
        <dx:ASPxCheckBox ID="ASPxCheckBox2" runat="server" Enabled="False" Text="Enforce Hints" ToolTip="Play must follow hints">
        </dx:ASPxCheckBox>
      </td>
    </tr>
    <tr>
      <td class="auto-style1">
        <dx:ASPxCheckBox ID="HintsCheckBox" runat="server" Checked="True" CheckState="Checked" Text="Hints Enabled" ToolTip="Show hints">
        </dx:ASPxCheckBox>
      </td>
      <td class="auto-style1">
        <dx:ASPxCheckBox ID="ASPxCheckBox4" runat="server" Enabled="False" Text="Prohibit Surrender" ToolTip="Disallow surrender">
        </dx:ASPxCheckBox>
      </td>
    </tr>
    <tr>
      <td> 
        <div style="float:right;">
        <dx:ASPxButton ID="ASPxButton1"  runat="server" Text="Save" Width="100px" OnClick="ASPxButton1_Click">
          <ClientSideEvents Click="function(s, e) {
	OptionsPopupHide();
}" />
        </dx:ASPxButton>
        </div>
      </td>
      <td>
        <dx:ASPxButton ID="ASPxButton2" runat="server" Text="Cancel" Width="100px">
          <ClientSideEvents Click="function(s, e) {
	OptionsPopup.Hide();
}" />
        </dx:ASPxButton>
      </td>
    </tr>
  </table>
</div>