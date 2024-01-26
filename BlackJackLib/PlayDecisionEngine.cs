//    Copyright (c) 2004 Software Conceptions, Inc.  All rights reserved.
//    Written by Paul Kimmel. pkimmel@softconcepts.com
//   
//    You must not remove this notice, or any other, from this software.
//   

using System;

namespace Softconcepts.BlackJackLib
{
	public class PlayDecisionEngine
	{
	  public static PlayState GetPlayState(DealerHand dealerHand, 
	    PlayerHand playerHand)
	  {
      if( playerHand.Surrendered )
        return PlayState.Surrender;
      
      if( IsPush(dealerHand, playerHand))
        return PlayState.Push; 
      
      if(IsWin(dealerHand, playerHand))
        return PlayState.Win; 
     
      return PlayState.Lose;
    }
    
    public static bool IsPush(DealerHand dealerHand, 
      PlayerHand playerHand )
    {
      return !playerHand.IsBust() && !dealerHand.IsBust() 
        && playerHand.GetBestValue() == dealerHand.GetBestValue()
        && !playerHand.IsBlackJack();
    }
    
    public static bool IsWin(DealerHand dealerHand, 
      PlayerHand playerHand)
    {
      return (playerHand.IsBlackJack() 
        || (!playerHand.IsBust() 
        && (playerHand.GetBestValue() > dealerHand.GetBestValue() 
        || dealerHand.IsBust())));
    }
    
    
    
    
    public static double GetChange(PlayerHand hand)
    {
      switch(hand.GetPlayState())
      {
        case PlayState.Lose:
          if( hand.Doubled ) 
            return -2 * hand.CurrentBet;		    
          else
            return -1 * hand.CurrentBet;
        case PlayState.Push:
          return 0;
        case PlayState.Win:
          if( hand.IsBlackJack() ) 
            return 1.5 * hand.CurrentBet;
          else if( hand.Doubled )
            return 2 * hand.CurrentBet;
          else
            return hand.CurrentBet;
        case PlayState.Surrender:
          return -0.5 * hand.CurrentBet;
      }
      return 0;
    }
  }
}
