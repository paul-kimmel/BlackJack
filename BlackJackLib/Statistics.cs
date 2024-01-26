//    Copyright (c) 2004 Software Conceptions, Inc.  All rights reserved.
//    Written by Paul Kimmel. pkimmel@softconcepts.com
//   
//    You must not remove this notice, or any other, from this software.
//   

using System;
using System.Collections;

namespace Softconcepts.BlackJackLib
{
  public class Statistics : CollectionBase
  {
    public Statistic this[int index]
    {
      get{ return (Statistic)List[index]; }
      set{ List[index] = value; }
    }
    
    public int Add(Statistic value)
    {
      return List.Add(value);
    }
    
    public int Surrenders
    {
      get{ return GetSurrenderCount(); }
    }
    
    public int Wins
    {
      get{ return GetWinCount(); }
    }
    
    public int Losses
    {
      get{ return GetLossCount(); }
    }
    
    public int Pushes
    {
      get{ return GetPushCount(); }
    }    
    
    public double AverageAmountWon
    {
      get{ return GetAverageAmountWon(); }
    }
    
    public double TotalAmountWon
    {
      get{ return GetTotalAmountWon(); }
    }
    
    public double TotalAmountLost
    {
      get{ return GetTotalAmountLost(); }
    }
    
    public double AverageAmountLost
    {
      get{ return GetAverageAmountLost(); }
    }
    
    public double PercentageOfWins
    {
      get{ return GetPercentageOfWins(); }
    }
    
    public double PercentageOfLosses
    {
      get{ return GetPercentageOfLosses(); }
    }
    
    public double PercentageOfPushes
    {
      get{ return GetPercentageOfPushes(); }
    }
    
    public double NetAverageWinLoss
    {
      get{ return GetNetAverageWinLoss(); }
    }
    
    public double NetWinLoss
    {
      get{ return GetNetWinLoss(); }
    }
    
    public double GetNetAverageWinLoss()
    {
      return Wins + Losses == 0 ? 0 : ((AverageAmountWon * Wins) + (AverageAmountLost * Losses)) 
        / (Wins + Losses);
    }
    
    public int BlackJacks
    {
      get{ return GetBlackJacks(); }
    }
    
    public int GetBlackJacks()
    {
      int count = 0;
      foreach(Statistic s in this)
        if( s.Player.IsBlackJack())
          count++;
      return count;
    }
    
    public double PercentageOfBlackJacks
    {
      get{ return GetPercentageOfBlackJacks(); }
    }
    
    public double GetPercentageOfBlackJacks()
    {
      return Count == 0 ? 0 : (double)BlackJacks / Count;
    }
    
    public double GetNetWinLoss()
    {
      return TotalAmountWon + TotalAmountLost;
    }
    
    private int GetCount(PlayState state)
    {
      int count = 0;
      foreach(Statistic s in this)
        if( s.State == state)
          count++;
      
      return count;
    }
    
    private double GetSum(PlayState state)
    {
      double sum = 0;
      foreach(Statistic s in this)
        if( s.State == state )
          sum += s.Change;
      
      return sum;
    }
    
    private int GetSurrenderCount()
    {
      return GetCount(PlayState.Surrender); 
    }
    
    private int GetWinCount()
    {
      return GetCount(PlayState.Win);
    }
    
    public int GetLossCount()
    {
      return GetCount(PlayState.Lose);
    }
    
    public int GetPushCount()
    {
      return GetCount(PlayState.Push);
    }
    
    
    public double GetAverageAmountWon()
    {
      return GetWinCount() == 0 ? 0 : GetTotalAmountWon() / GetWinCount();  
    }
    
    public double GetTotalAmountWon()
    {
      return GetSum(PlayState.Win);
    }
    
    public double GetAverageAmountLost()
    {
      return GetLossCount() == 0 ?  0 : GetTotalAmountLost() / GetLossCount();
    }
    
    public double GetTotalAmountLost()
    {
      return GetSum(PlayState.Lose);
    }
    
    public double GetPercentageOfWins()
    {
      return Count == 0 ? 0 : (double)GetWinCount() / this.Count * 100;
    }
    
    public double GetPercentageOfLosses()
    {
      return Count == 0 ? 0 : (double)GetLossCount() / this.Count * 100;
    }
    
    public double GetPercentageOfPushes()
    {
      return Count == 0 ? 0 : (double)GetPushCount() / this.Count * 100; 
    }
  }

	public class Statistic
	{
	  private PlayerHand player = null;
	  private DealerHand dealer = null;
	  private PlayState state = PlayState.None;
	  private double bet = 0;
	  private double money = 0; 
	  private double change = 0;
	  
		public Statistic(PlayerHand player, DealerHand dealer, 
		  PlayState state, double change)
		{
		  this.player = player;
		  this.dealer = dealer;
		  this.state = state;
		  this.bet = player.CurrentBet;
		  this.money = player.Money;
		  this.change = PlayDecisionEngine.GetChange(player);
		}

		public PlayerHand Player
		{
		  get{ return player; }
		}
		
		public DealerHand Dealer
		{
		  get{ return dealer; }
		}
		
		public PlayState State 
		{
		  get{ return state; }
		}
		
		public double Bet
		{
		  get{ return bet; }
		}
		
		public double Money
		{
		  get{ return money; }
		}
		
		public double Change
		{
		  get{ return change; }
		}
	}
}
