//    Copyright (c) 2004 Software Conceptions, Inc.  All rights reserved.
//    Written by Paul Kimmel. pkimmel@softconcepts.com
//   
//    You must not remove this notice, or any other, from this software.
//   

using System;
using System.Diagnostics;
using System.Drawing;

namespace Softconcepts.BlackJackLib
{
  public enum PlayState{ None, Surrender, Push, Lose, Win };
  
	public class PlayerHand : Hand
	{
	  private Player player = null;
    private double currentBet = 0;
    private PlayState playState = PlayState.None;
    
    public PlayerHand(Player player, double currentBet)
    {
      Debug.Assert(player != null);
      this.player = player;
      this.currentBet = currentBet; 
    }
    
    public PlayerHand(Player player, double currentBet, Card card)
    {
      Debug.Assert(player != null);
      this.player = player;
      this.currentBet = currentBet;
      Add(card);
    }

    public Player Player
    {
      get{ return player; }
    }
    
    public override bool CanDouble
    {
			get{ return this.Count == 2 && player.CanIncreaseBet(this.currentBet); }
    }
    
    public bool CanSplit
    {
			get{ return this.Count == 2 && 
				this[0].GetFaceValue() == this[1].GetFaceValue() 
				&& player.CanIncreaseBet(this.currentBet); }
    }
    
    public bool CanSurrender
    {
			get{ return this.Count == 2; }    
    }
    
	  
    public double CurrentBet
    {
      get{ return currentBet; }
      set{ currentBet = value; }
    }

    public override void Dump()
    {
      Console.WriteLine("Hand: {0}, Current Bet: {1}, Value: {2}", 
        this.GetTextHand(), this.CurrentBet, this.GetBestValue());
    }
    
    public double Money
    {
      get{ return player.Money; }
    }

    public override void Surrender()
    {
      base.Surrender();
      playState = PlayState.Surrender;
    }
  
    private void DoSurrender()
    {
      player.Surrender(this);
    }

    public void Win()
    {
      playState = PlayState.Win;
      player.Win(this);
    }
        
    public void Lose()
    {
      playState = PlayState.Lose;
      player.Lose(this);
    }
    
    public void Push()
    {
      playState = PlayState.Push;
    }
    
    public PlayState GetPlayState()
    {
      return playState;
    }
    
    public void SetPlayState(PlayState state)
    {
      switch(state)
      {
        case PlayState.Surrender:
          DoSurrender();
          break;
        case PlayState.Push:
          Push();
          break;
        case PlayState.Win:
          Win();
          break;
        case PlayState.Lose:
          Lose();
          break;
        default:
          throw new Exception("Invalid play result");
      }
    }
    
    public bool CanIncreaseBet(double amount)
    {
      return player.CanIncreaseBet(amount);
    }
    
    public bool CanDecreaseBet(double amount)
    {
      return player.CanDecreaseBet(this, amount);
    }
    
    public bool IncreaseBet(double amount)
    {
      return player.IncreaseBet(amount);
    }
    
    public bool DecreaseBet(double amount)
    {
      return player.DecreaseBet(amount);
    }
    
    public override void Split()
    {
      Debug.Assert(this.CanSplit);
      player.Split(this);
    }
    
    public override void GraphicPrintHand(Graphics g, int x, int y, 
      int cardWidth, int cardHeight, bool focused)
    {
      base.GraphicPrintHand(g, x, y, cardWidth, cardHeight, focused);
      if( playState != PlayState.None )
        // font from base class
        g.DrawString(playState.ToString(), font, Brushes.White, x, y + cardHeight);
    }
	}
}
