<%@ Control Language="C#" AutoEventWireup="true" CodeFile="NavigatorUserControl.ascx.cs" Inherits="UserControls_NavigatorUserControl" %>
<%@ Register src="StatisticsUserControl.ascx" tagname="StatisticsUserControl" tagprefix="uc1" %>
<%@ Register src="HintsUserControl.ascx" tagname="HintsUserControl" tagprefix="uc2" %>

<uc1:StatisticsUserControl ID="StatisticsUserControl1" runat="server" />
<uc2:HintsUserControl ID="HintsUserControl1" runat="server" />

