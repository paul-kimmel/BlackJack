<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PlayerHandsUserControl.ascx.cs" Inherits="UserControls_PlayerHandsUserControl" %>
<%@ Register src="HandUserControl.ascx" tagname="HandUserControl" tagprefix="uc1" %>
<div class="PlayerHand">

    <uc1:HandUserControl ID="HandUserControl1" runat="server" ImageUrl='<%# GetImageUrl(DataBinder.Eval(Container, "DataItem")) %>' />

</div>