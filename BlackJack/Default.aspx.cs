using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Softconcepts.BlackJackLib;
using Tools;

public partial class _Default : System.Web.UI.Page, IActionable
{
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Page.IsPostBack == false)
        if(SessionBag.Current.Game == null)
          Deal();
    }

    public Softconcepts.BlackJackLib.BlackJack Game
    {
      get
      {
        if (SessionBag.Current.Game == null)
          SessionBag.Current.Game = new Softconcepts.BlackJackLib.BlackJack(1, 6);
        return SessionBag.Current.Game;
      }
    }

    public void Hit()
    {
      if (Game.IsGameOver)
        Deal();
      else
        Game.Hit();
    }

    public void NewGame()
    {
      //Game.Options
      SessionBag.Current.Game = new Softconcepts.BlackJackLib.BlackJack(1, 6);
      Deal();
    }

    public void Deal()
    {
      Game.NewGame();
      Game.CheckEndGame();
    }

    public void DealSplitGame()
    {
    Game.DealSplitGame();
    }

    public void DealSplit()
    {
      Game.DealSplitGame();
    }

    public void Stand()
    {
      if (Game.IsGameOver) return;
      Game.Stand();
    }

    public void Double()
    {
      if (Game.IsGameOver) return;
      Game.Double();
    }

    public void Increase()
    {
      Game.IncreaseBet();
    }

    public void Decrease()
    {
      Game.DecreaseBet();
    }

    public void Split()
    {
      if (Game.IsGameOver) return;
      Game.Split();
    }

    public void Surrender()
    {
      if (Game.IsGameOver) return;
      Game.Surrender();
    }

    public void About()
    {
      ASPxPopupControl1.ShowOnPageLoad = true;
    }
}