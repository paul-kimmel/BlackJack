<%@ Control Language="C#" AutoEventWireup="true" CodeFile="HandsUserControl.ascx.cs" Inherits="UserControls_HandsUserControl" %>
<%@ Register Src="~/UserControls/HandUserControl.ascx" TagPrefix="uc1" TagName="HandUserControl" %>


<%@ Register src="PlayerHandsUserControl.ascx" tagname="PlayerHandsUserControl" tagprefix="uc2" %>


<div class="Hands">
  <div class="Dealer">
    <uc1:HandUserControl runat="server" id="Dealer1"  IsDealer="true" ImageUrl="../DealerHandler.ashx" />
  </div>
  <div class="Player">
    
      <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal">
          <ItemTemplate>
              <uc2:PlayerHandsUserControl ID="PlayerHandsUserControl1" runat="server" />
          </ItemTemplate>
      </asp:DataList>
    
  </div>
</div>