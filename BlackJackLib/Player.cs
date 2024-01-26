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
	public class Player
	{
    private double money = 0;
    private string name;
    private double currentBet = 25;
    private Statistics statistics = null;
    
    private PlayerHandCollection hands = new PlayerHandCollection();

		public Player(string name)
		  : this(name, 500, 25){}
	  
    public Player(string name, double money, double currentBet)
    {
      statistics = new Statistics();
      this.name = name;
      this.money = money;
      this.currentBet = currentBet;
      hands.Add(new PlayerHand(this, currentBet));
    }

    public Statistics Statistics
    {
      get{ return statistics; }
    }
    
    public double CurrentBet
    {
      get{ return currentBet; }
    }
    
    public bool HasSufficientFunds
    {
      get{ return GetTotalBet() <= money; }
    }
    
    public double GetTotalBet()
    {
      double total = 0;
      foreach(PlayerHand h in hands)
        total += h.CurrentBet;
      return total;  
    }

    public bool CanIncreaseMinimumBet(double additionalBet)
    {
      return currentBet + additionalBet <= money;
    }
    
    public void IncreaseMinimumBet(double additionalBet)
    {
      currentBet += additionalBet;
    }

    public bool CanIncreaseBet(double additionalBet)
    {
      return GetTotalBet() + additionalBet <= money;
    }
        
    private double GetTotalBet(double additionalBet)
    {
      return GetTotalBet() + additionalBet;
    }    
    
    public bool CanDouble(int index)
    {
      Debug.Assert( index > 0 && index < hands.Count);
      
      return hands[index].CanDouble && 
        CanIncreaseBet(hands[index].CurrentBet);
    }
    
    public bool CanSplit(int index)
    {
      return hands[index].CanSplit && 
        CanIncreaseBet(hands[index].CurrentBet);
    }
    
    public bool CanSurrender(int index)
    {
      return hands[index].CanSurrender;
    }
	  
    public void Double(int index, Card card)
    {
      Debug.Assert(CanDouble(index));
      if( CanIncreaseBet(hands[index].CurrentBet))
        hands[index].Double(card);
    }
    
    public void Split(PlayerHand handToSplit)
    {
      Debug.Assert(handToSplit.CanSplit);
      // split out the second card to seed the new hand
      Card cardToRemove = handToSplit[1];
      handToSplit.RemoveAt(1);
      hands.InsertAfter(handToSplit, 
        new PlayerHand(this, handToSplit.CurrentBet, cardToRemove));
    }
    
    public void Surrender(PlayerHand hand)
    {
      money += PlayDecisionEngine.GetChange(hand);
    }
    
    public void Surrender(int index)
    {
      Debug.Assert(IsValidIndex(index));
      Lose(hands[index]);
    }

    public bool IncreaseBet(double amount)
    {
      return IncreaseBet(0, amount);
    }
    
    public bool IncreaseBet(int index, double amount)
    { 
      if( CanIncreaseBet(amount))
      {
        hands[index].CurrentBet += amount;
        return true;
      }
      
      return false; 
    }

    public bool CanDecreaseMinimumBet(double amount)
    {
      return currentBet - amount > 0;  
    }

    public void DecreaseMinimumBet(double amount)
    {
      currentBet -= amount;
    }

    public bool CanDecreaseBet(PlayerHand hand, double amount)
    {
      return CanDecreaseBet(hands.IndexOf(hand), amount);
    }
    
    public bool CanDecreaseBet( int index, double amount )
    {
      return hands[index].CurrentBet - amount > 0;
    }
    
    public bool DecreaseBet(double amount)
    {
      return DecreaseBet(0, amount);
    }
    
    public bool DecreaseBet(int index, double amount)
    {
      if(CanDecreaseBet(index, amount))
      {
        hands[index].CurrentBet -= amount;
        return true;
      }
      
      return false;
    }
	  
	  private bool IsValidIndex(int index)
	  {
	    return index >= 0 && index < hands.Count;
	  }
	  
	  public void Win(PlayerHand hand)
	  {
	    money += PlayDecisionEngine.GetChange(hand);
	  }
	  
    public void Win(int index)
    {
      Debug.Assert(IsValidIndex(index));
      money += PlayDecisionEngine.GetChange(hands[index]);
    }

    public void Lose(PlayerHand hand)
    {
      Lose(PlayDecisionEngine.GetChange(hand));
    }
    
    private void Lose(double amount)
    {
      money += amount;
    }
        
    public void Lose(int index)
    {
      Debug.Assert(IsValidIndex(index));
      Lose(hands[index]);
    }

    public double Money
    {
      get{ return money; }
      set{ money = value; }
    }
    
    public string Name
    {
      get{ return name; }
      set{ name = value; }
    }
    
    public void DealCard(int index, Card card)
    {
      Debug.Assert(IsValidIndex(index));
      hands[index].Add(card);
    }
    
    public void DealCard(Card card)
    {
      hands[0].Add(card);
    }
    
    public void New()
    {
      hands.Clear();
      Hands.Add(new PlayerHand(this, currentBet));
    }
    
    public void Dump()
    {
      Console.WriteLine("Player name: {0}", this.name);
      foreach(PlayerHand hand in hands)
        hand.Dump();
    }
    
    public bool IsBlackJack(int index)
    {
      Debug.Assert(IsValidIndex(index));
      return hands[index].IsBlackJack();
    }
    
    public bool IsBlackJack()
    {
      return IsBlackJack(0);
    }
    
    public PlayerHandCollection Hands
    {
      get{ return hands; }
    }
    
    public PlayerHand this[int index]
    {
      get{ return (PlayerHand)hands[index]; }
    }
    
    public void GraphicPrintHand(Graphics g, int x, int y, int dx, int dy)
    {
      GraphicPrintHand(g, x, y, dx, dy, null);
    }
    
    public void GraphicPrintHand(Graphics g, int x, int y, int dx, int dy,
      PlayerHand currentHand)
    {
      const int pad = 10;
      int startX = x;
      for( int i=0; i<hands.Count; i++ )
      {
        if( i > 0)
          // previous offset + size of one card + (20 pixels multipled
          // by number of cards less one in previous hand + small pad
          startX = startX + dx + (20 * (hands[i-1].Count-1)) + pad;
          
        hands[i].GraphicPrintHand(g, startX, y, dx, dy, hands[i] == currentHand);
      }
    }
	}
}
