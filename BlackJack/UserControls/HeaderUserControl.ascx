<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HeaderUserControl.ascx.cs" Inherits="UserControls_HeaderUserControl" %>

<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxMenu" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v13.1, Version=13.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxDocking" tagprefix="dx" %>

<div class="TopHeader">
<span class="Logo">Guided BlackJack</span>
</div>
<div class="BottomHeader" >
  
<script>
  $(function () {
    $(window).keydown(function (e) {
      var index = -1;
      switch (e.keyCode) {
        case 68: /* D - double */
          index = 1;
          break;
        case 83: /* S - split */
          index = 2;
          break;
        case 32: /* space - hit or deal  */
          index = 0;
          break;
        case 13: /* return = stand  */
          index = 4;
          break;
        case 88: /* X - surrender */
          index = 3;
          break;
        case 38:  /* up arrow - increment bet */
        case 107: /* plus - ncrement bet */
          index = 6;
          break;
        case 40: /* down arrow - decrement bet */
        case 109: /* - - decrement */
          index = 7;
          break;
      }

      if (index > -1) {
        var item = Menu.GetItem(2).GetItem(index);
        Menu.DoItemClick(item.indexPath, false, null);
      }
    });
  });
</script>

<dx:ASPxMenu ID="ASPxMenu1" runat="server" Font-Size="14px" OnItemClick="ASPxMenu1_ItemClick" Theme="BlackGlass" Width="100%" RenderMode="Lightweight" ClientInstanceName="Menu">
    <Items>
      <dx:MenuItem Text="Home" NavigateUrl="http://www.softconcepts.com"></dx:MenuItem>
      <dx:MenuItem Text="Game">
        <Items>
          <dx:MenuItem Text="New Game"></dx:MenuItem>
          <dx:MenuItem Text="Deal" ToolTip="Deal">
          </dx:MenuItem>
        </Items>
      </dx:MenuItem>
      <dx:MenuItem Text="Choices">
        <Items>
          <dx:MenuItem Text="Hit">
          </dx:MenuItem>
          <dx:MenuItem Text="Double">
          </dx:MenuItem>
          <dx:MenuItem Text="Split">
          </dx:MenuItem>
          <dx:MenuItem Text="Surrender">
          </dx:MenuItem>
          <dx:MenuItem Text="Stand">
          </dx:MenuItem>
          <dx:MenuItem Text="Insurance" Enabled="False">
          </dx:MenuItem>
          <dx:MenuItem BeginGroup="True" Text="Increase Bet">
          </dx:MenuItem>
          <dx:MenuItem Text="Decrease Bet">
          </dx:MenuItem>
          <dx:MenuItem BeginGroup="True" Text="Deal">
          </dx:MenuItem>
          <dx:MenuItem Text="Deal Split">
          </dx:MenuItem>

        </Items>
      </dx:MenuItem>
      <dx:MenuItem Text="Help">
        <Items>
          <dx:MenuItem Text="About">
          </dx:MenuItem>
        </Items>
      </dx:MenuItem>
    </Items>
  </dx:ASPxMenu>


</div>

 