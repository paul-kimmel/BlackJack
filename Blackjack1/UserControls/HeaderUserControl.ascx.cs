using Softconcepts.BlackJackLib;
using System;

public partial class UserControls_HeaderUserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ASPxMenu1_ItemClick(object source, DevExpress.Web.ASPxMenu.MenuItemEventArgs e)
    {
      Perform(e.Item.Text);
    }

    private void Perform(string command)
    {
      switch (command)
      {
        case "Hit":
          Hit();
          break;
        case "Stand":
          Stand();
          break;
        case "New Game":
          NewGame();
          break;
        case "Deal":
          Deal();
          break;
        case "Double":
          Double();
          break;
        case "Split":
          Split();
          break;
        case "Surrender":
          Surrender();
          break;
        case "Decrease Bet":
          Decrease();
          break;
        case "Increase Bet":
          Increase();
          break;
        case "Deal Split":
          DealSplit();
          break;
        case "About":
          About();
          break;
      }
    }

    private void Surrender()
    {
      if (Page is IActionable)
        ((IActionable)Page).Surrender();
    }

    private void Decrease()
    {
      if (Page is IActionable)
        ((IActionable)Page).Decrease();
    }

    private void Increase()
    {
      if (Page is IActionable)
        ((IActionable)Page).Increase();
    }

    private void Split()
    {
      if (Page is IActionable)
        ((IActionable)Page).Split();
    }

    private void Double()
    {
      if (Page is IActionable)
        ((IActionable)Page).Double();
    }

    private void Stand()
    {
      if (Page is IActionable)
        ((IActionable)Page).Stand();
    }

    private void Hit()
    {
      if (Page is IActionable)
        ((IActionable)Page).Hit();
    }

    private void NewGame()
    {
      if (Page is IActionable)
        ((IActionable)Page).NewGame();
    }
  
    private void Deal()
    {
      if (Page is IActionable)
        ((IActionable)Page).Deal();
    }

    private void DealSplit()
    {
      if (Page is IActionable)
        ((IActionable)Page).DealSplit();
    }

    private void About()
    {
      if (Page is IActionable)
        ((IActionable)Page).About();
    }
}