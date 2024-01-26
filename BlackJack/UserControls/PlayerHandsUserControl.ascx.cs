using Softconcepts.BlackJackLib;
using System;

public partial class UserControls_PlayerHandsUserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected string GetImageUrl(object item)
    {
      try
      {
        PlayerHand hand = (PlayerHand)item;
        int index = hand.Player.Hands.IndexOf(hand);
        return string.Format("../PlayerHandler.ashx?handposition={0}", index);
      }
      catch
      {
        return "";
      }
    }

}