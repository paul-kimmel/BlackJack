using Softconcepts.BlackJackLib;
using System;
using Tools;

public partial class UserControls_StatisticsUserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
      BindEvents();
    }

    private void BindEvents()
    {
      if (Game == null) return;
      Game.OnDecidePlay += Game_OnDecidePlay;
    }

    private void Game_OnDecidePlay(object sender, EventArgs e)
    {
      if (sender is PlayerHand == false) return;
      UpdateStatistics(sender as PlayerHand);
    }

    private void UpdateStatistics(PlayerHand hand)
    {
      try
      {
        var statistics = hand.Player.Statistics;
        ASPxRoundPanel1.HeaderText = string.Format("{0} Statistics", hand.Player.Name);
        
        SurrendedLabel.Text = string.Format("Surrendered: {0}", statistics.Surrenders);
        WinsLabel.Text = string.Format("Wins: {0}", statistics.Wins);
        LossesLabel.Text = string.Format("Losses: {0}", statistics.Losses);
        PushesLabel.Text = string.Format("Pushes: {0}", statistics.Pushes);
        AverageWonLabel.Text = string.Format("Average amount won per hand: {0,2:c}", statistics.AverageAmountWon);
        AverageLostLabel.Text = string.Format("Net average won/lost per hand: {0,2:c}", statistics.NetAverageWinLoss);
        TotalWonLabel.Text = string.Format("Total amount won: {0,2:c}", statistics.TotalAmountWon);
        TotalLostLabel.Text = string.Format("Total amount loss: {0,2:c}", statistics.TotalAmountLost);
        NetAverageLabel.Text = string.Format("Average amount lost per hand: {0,2:c}", statistics.AverageAmountLost);
        PercentageWinLabel.Text = string.Format("Percentage of wins: {0,2:f}%", statistics.PercentageOfWins);
        PercentageLossLabel.Text = string.Format("Percentage of losses: {0,2:f}%", statistics.PercentageOfLosses);
        PercentagePushLabel.Text = string.Format("Percentage of pushes: {0,2:f}%", statistics.PercentageOfPushes);
        NetWonLossLabel.Text = string.Format("Net Won/Lost: {0,2:c}", statistics.NetWinLoss);
        BlackJacksLabel.Text = string.Format("BlackJacks/As Percentage: {0}/{1,2:f}%",
          statistics.BlackJacks, statistics.PercentageOfBlackJacks);
        
      }
      catch{
        ASPxRoundPanel1.HeaderText = "Statistics";
      }
    }

    private BlackJack Game
    {
      get { return SessionBag.Current.Game; }
    }
}