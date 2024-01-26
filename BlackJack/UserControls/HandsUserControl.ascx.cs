using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Softconcepts.BlackJackLib;
using Tools;

public partial class UserControls_HandsUserControl : System.Web.UI.UserControl
{
  protected void Page_PreRender(object sender, EventArgs e)
  {
    BindData();
  }

  private void BindData()
  {
    if (Game == null) return;
    Player player = Game.Players[0];
    DataList1.DataSource = player.Hands;
    DataList1.DataBind();
  }

  private BlackJack Game
  {
    get { return SessionBag.Current.Game; }
  }

}