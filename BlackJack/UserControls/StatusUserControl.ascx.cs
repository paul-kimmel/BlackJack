using Softconcepts.BlackJackLib;
using System;
using Tools;

public partial class UserControls_StatusUserControl : System.Web.UI.UserControl, IStatusable
{
    protected void Page_Load(object sender, EventArgs e)
    {
      //UpdateStatus();
      BindEvents();
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
      UpdateStatus();
    }

    private void BindEvents()
    {
      if (Game == null) return;
      Game.OnChangeBet += (o, e) => UpdateBetStatus(o as Player);
      Game.OnHitCurrentHand += (o, e) => UpdateStatus(o as PlayerHand);
      Game.OnNewGame += (o, e) => UpdateStatus(Game.CurrentHand);
      Game.OnEndGame += (o, e) => UpdateEndStatus();
      Game.OnNextHand += (o, e) => UpdateStatus(o as PlayerHand);
      Game.OnDealerHandChanged += (o,e) => SetDealerStatus(o as DealerHand);
      Game.OnDoubleCurrentHand += (o, e) => UpdateStatus(o as PlayerHand);
      Game.OnSurrenderCurrentHand += (o, e) => UpdateStatus(o as PlayerHand);
      Game.OnSplitCurrentHand += (o, e) => UpdateStatus(o as PlayerHand);
      Game.OnDecidePlay += (o, e) => UpdateStatus(o as PlayerHand);
    }
  
    private BlackJack Game
    {
      get { return SessionBag.Current.Game; }
    }

    private bool IsPlaying()
    {
      return Game != null && Game.Players != null && Game.Players[0] != null;
    }

    private void UpdateBetStatus(Player player)
    {
      try
      {
        SetPlayerBet(player.CurrentBet);
      }
      catch 
      { }
    }

    private void UpdatePlayerStatus()
    {
      PlayerHand hand = Game.CurrentHand;
      if (hand == null) return;
      UpdateStatus(hand);
    }

    private void UpdateStatus(PlayerHand hand)
    {
      SetPlayerStatus(hand.GetBestValue());
      SetPlayerBet(hand.CurrentBet);
      SetPlayerBalance(hand.Money);
      SetDealerStatus(Game.Dealer);
      SetHintStatus(Game);
    }

    private void UpdateEndStatus()
    {
      if (IsPlaying() == false) return;
      SetPlayerBalance(Game.Players[0].Money);
      SetDealerStatus(Game.Dealer);
      SetHintStatus(Game);
    }

    private void UpdateStatus()
    {
      if (IsPlaying() == false) return;
      UpdatePlayerStatus();
      SetDealerStatus(Game.Dealer);
      SetHintStatus(Game);
    }

    private void SetPlayerStatus(int bestValue)
    {
      PlayerLabel.Text = string.Format("Player: {0}", bestValue);
    }

    private void SetPlayerBet(double currentBet)
    {
      BetLabel.Text = string.Format("Bet: {0:C}", currentBet);
    }

    private void SetPlayerBalance(double money)
    {
      BalanceLabel.Text = string.Format("Balance: {0:C}", money);
    }

    private void SetDealerStatus(DealerHand dealer)
    {
      if (Game.IsGameOver)
        DealerLabel.Text = string.Format("Dealer: {0}", dealer.GetBestValue());
      else
        DealerLabel.Text = string.Format("Dealer: {0}", dealer[1].GetPrettyCardValue());
    }

    private void ClearHintStatus()
    {
      HintLabel.Text = "Hint: (none)";
    }

    private void SetHintStatus(BlackJack game)
    {
      if (game.IsGameOver == false)
      {
        HintLabel.Text = game.GetHint();
        HintLabel.ToolTip = game.GetHint();
      }
      else
        ClearHintStatus();
    }

    public void ResetStatus()
    {

    }
}


