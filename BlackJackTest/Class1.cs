//    Copyright (c) 2004 Software Conceptions, Inc.  All rights reserved.
//    Written by Paul Kimmel. pkimmel@softconcepts.com
//   
//    You must not remove this notice, or any other, from this software.
//   

using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using NUnit.Framework;
using Softconcepts.BlackJackLib;

namespace BlackJackTest
{
  public class Listener : TraceListener
  {
    public override void Write(string message)
    {
      Console.Write(message);
    }
    
    public override void WriteLine(string message)
    {
      Console.WriteLine(message);
    }
  } 
    

  [TestFixture]
	public class Test
	{
	  private static Listener listener = new Listener();
	  private Decks decks = new Decks(6);
	  private BlackJack game = new BlackJack(1, 6);
	
	  [SetUp()]
	  public void Init()
	  {
	    Trace.Listeners.Add(listener);
    }
    
    [TearDown()]
    public void Deinit()
    {
      Trace.Listeners.Remove(listener);
    }
    
    [Test(), Ignore("This is a long test")]
    public void DealTest()
    {
      decks.Shuffle();
      
      Hand hand = new Hand();
      while(!hand.IsBust() && decks.MoreCards())
      {
        hand.Add(decks.GetNextCard());
        Console.WriteLine(hand.GetTextHand());      
      }
      
      Console.WriteLine(hand.BustedAtText());
    }
    
    private int GetDealerHand()
    {
      DealerHand hand = new DealerHand();
      
      while(!hand.WantsCard())
      {
        hand.Add(decks.GetNextCard());
        Console.WriteLine(hand.GetTextHand());
      }
      
      return hand.GetHandValueHigh();
    }
    
    [Test()]
    public void DealerHandTest()
    {
      Console.WriteLine("Dealer stopped at: {0}", GetDealerHand());
    }
    
    [Test(), Ignore("Needs some fine tuning")]
    public void GetMultipleDealerHandsTest()
    {
      Console.WriteLine( new string('*', 40));
      Console.WriteLine("Dealing 200 hands to dealer");
      for( int i=0; i<200; i++)
      {
        int hand = GetDealerHand();
        if( hand < 17 ) 
          throw new Exception("Stopped before 17");
        else
          Console.WriteLine("Dealer stopped at: {0}", hand);
      }
    }
    
    [Test()]
    public void InitialDealTest()
    {
      DealerHand dealer = new DealerHand();
      Hand hand = new Hand();
      
      for(int i=0; i<2; i++)
      {
        hand.Add(decks.GetNextCard());
        dealer.Add(decks.GetNextCard());
      }
      
      Console.WriteLine("Dealer hand={0}, value={1}", dealer.GetTextHand(), dealer.GetHandValueHigh());
      Console.WriteLine("Player hand{0}, value={1}", hand.GetTextHand(), hand.GetHandValueHigh());
    }
    
    [Test()]
    public void BlackJackInitialDealTest()
    {
      Console.WriteLine( new string('*', 40));
      Console.WriteLine("Game Test");
      BlackJack game = new BlackJack(3, 6);
      game.Dump();
    }
    
    [Test(), Ignore("Need to rewrite")]
    public void BlackJackDealThreeCardsTest()
    {
      Console.WriteLine( new string('*', 40));
      Console.WriteLine("Game Test");
      BlackJack game = new BlackJack(3, 6);
      game.Dump();
    }
    
    //TODO: Need to rewrite after revision for multi-players
    private void InternalDrawTo17Test()
    {
      Console.WriteLine( new string('*', 40));
      Console.WriteLine("Game Test");
      
      game.Dump();
      
      game.Deal();
    }
    
    [Test()]
    public void DrawTo17Test()
    {
      InternalDrawTo17Test();
    }
    
    [Test()]
    public void DrawTo17LoopTest()
    {
      // draw cards to force re-deal
      for( int i=0; i <75; i++ )
        InternalDrawTo17Test();    
    }
    
    [Test()]
    public void PlaySoundTest()
    {
      Sounds.Beep();
      Assertion.Assert(Query("Did you hear the sound?"));
    }
    
    private Ace card;
    [Test()]
    public void GraphicPaintTest()
    {
      for(Suit s=Suit.Club; s<=Suit.Spade; s++)
      {
        card = new Ace(s);
        Form f = new Form();
        f.Paint += new PaintEventHandler(OnPaint);
        f.Show();
        try
        {
          Assertion.Assert(Query(string.Format("Did you see the ace of {0}?", s)));
        }
        finally
        {
          f.Close();
          f.Dispose();
        }
      }
    }
    
    private bool Query(string format, params object[] args)
    {
      return Query(string.Format(format, args));
    }
    
    private bool Query(string message)
    {
      return MessageBox.Show(message, "Query", MessageBoxButtons.YesNo,
        MessageBoxIcon.Question) == DialogResult.Yes;
    }
    
    private void OnPaint(object sender, PaintEventArgs e)
    {
      if( card == null) return;
      ((GraphicCard)card).PaintFace(e.Graphics, 0, 0, 75, 100);
    }

    [Test()]
    public void ShuffleTimingTest()
    {
      //TODO: See about speed here; maybe make this asynchronous
      DateTime start = DateTime.Now;
      Decks deck = new Decks(6);
      deck.Shuffle();
      TimeSpan stop = DateTime.Now.Subtract(start);
      Console.WriteLine("Shuffle time: {0} milliseconds", stop.TotalMilliseconds);
    }    
    
    private Hand GetTestHand()
    {
      Hand hand = new Hand();
      hand.Add(new Five(Suit.Club));
      hand.Add(new Ace(Suit.Heart));
      hand.Add(new Five(Suit.Club));
      hand.Add(new Ace(Suit.Spade));
      return hand;
    }
    
    [Test()]
    public void GetBestValueTest()
    {
      Hand hand = GetTestHand();      
      Console.WriteLine("Hand: {0} should equal 12; equals {1}", 
        hand.GetTextHand(), hand.GetBestValue());       
      Assertion.Assert(hand.GetBestValue() == 12);
    
    }

    [Test()]
    public void DrawHandTest()
    {
      PlayerHand hand = new PlayerHand(game.Players[0], 25);
      hand.Add(new Five(Suit.Club));
      hand.Add(new Ace(Suit.Heart));
      hand.Add(new Five(Suit.Spade));
      hand.Add(new Ace(Suit.Diamond));
      game.Players[0].Hands.Clear();
      game.Players[0].Hands.Add(hand);
      
      Form f = new Form();
      f.Paint += new PaintEventHandler(OnPaintHand);
      try
      {
        f.Show();
        Assertion.Assert(Query("Did you see the {0} hand?", hand.GetTextHand()));
      }
      finally
      {
        f.Dispose();
      }
    }
    
    private void OnPaintHand(object sender, PaintEventArgs e)
    {
      game.Players[0].GraphicPrintHand(e.Graphics, 0, 0, 75, 100, game.Players[0].Hands[0]);
    }

    [Test()]
    public void MoneyAfterDoubleWinTest()
    {
      Console.WriteLine(new String('*', 40));
      BlackJack b = new BlackJack(1, 6);
      Assertion.Assert(b.Players[0].CurrentBet == 25);
      b.Players[0].Money = 100;
      b.Players[0].Hands[0].Add(new Ten(Suit.Heart));
      b.Players[0].Hands[0].Add(new Three(Suit.Heart));
      b.Players[0].Hands[0].Double(new Eight(Suit.Heart));
      b.Dealer.Add(new Ten(Suit.Spade));
      b.Dealer.Add(new Seven(Suit.Spade));
      b.EndGame();
      b.Dump();
      Console.WriteLine("Player total bet: {0}", b.Players[0].GetTotalBet());
      Console.WriteLine("Player should have: {0}; does have {1}", 150, b.Players[0].Money);
      Assertion.AssertEquals("player's hand: {0}, dealer's hand: {1}", 
        true, b.Players[0].Money == 150);
      Console.WriteLine(new String('*', 40));
    }
    
    [Test()]
    public void MoneyAfterDoubleLossTest()
    {
      Console.WriteLine(new String('*', 40));
      BlackJack b = new BlackJack(1, 6);
      Assertion.Assert(b.Players[0].CurrentBet == 25);
      b.Players[0].Money = 100;
      b.Players[0].Hands[0].Add(new Ten(Suit.Heart));
      b.Players[0].Hands[0].Add(new Three(Suit.Heart));
      b.Players[0].Hands[0].Double(new Ace(Suit.Heart));
      b.Dealer.Add(new Ten(Suit.Spade));
      b.Dealer.Add(new Seven(Suit.Spade));
      b.EndGame();
      b.Dump();
      Console.WriteLine("Player total bet: {0}", b.Players[0].GetTotalBet());
      Console.WriteLine("Player should have: {0}; does have {1}", 50, b.Players[0].Money);
      Assertion.AssertEquals("player's hand: {0}, dealer's hand: {1}", 
        true, b.Players[0].Money == 50);
      Console.WriteLine(new String('*', 40));
    }
    
    [Test()]
    public void SplitWinTest()
    {
      Console.WriteLine(new String('*', 40));
      BlackJack b = new BlackJack(1, 6);
      Assertion.Assert(b.Players[0].CurrentBet == 25);
      b.Players[0].Money = 100;
      b.Players[0].Hands[0].Add(new Ace(Suit.Heart));
      b.Players[0].Hands[0].Add(new Ace(Suit.Heart));
      b.Players[0].Hands[0].Split();
      Assertion.Assert(b.Players[0].Hands.Count == 2);
      
      b.Players[0].Hands[0].Add(new Seven(Suit.Heart));
      b.Players[0].Hands[1].Add(new Eight(Suit.Heart));
      
      b.Dealer.Add(new Ten(Suit.Spade));
      b.Dealer.Add(new Seven(Suit.Spade));
      b.EndGame();
      b.Dump();
      Console.WriteLine("Player total bet: {0}", b.Players[0].GetTotalBet());
      Console.WriteLine("Player should have: {0}; does have {1}", 150, b.Players[0].Money);
      Assertion.AssertEquals("player's hand: {0}, dealer's hand: {1}", 
        true, b.Players[0].Money == 150);
      Console.WriteLine(new String('*', 40));
    }
    
    [Test()]
    public void SplitLossTest()
    {
      Console.WriteLine(new String('*', 40));
      BlackJack b = new BlackJack(1, 6);
      Assertion.Assert(b.Players[0].CurrentBet == 25);
      b.Players[0].Money = 100;
      b.Players[0].Hands[0].Add(new Ace(Suit.Heart));
      b.Players[0].Hands[0].Add(new Ace(Suit.Heart));
      b.Players[0].Hands[0].Split();
      Assertion.Assert(b.Players[0].Hands.Count == 2);
      
      b.Players[0].Hands[0].Add(new Six(Suit.Heart));
      b.Players[0].Hands[1].Add(new Six(Suit.Heart));
      
      b.Dealer.Add(new Ten(Suit.Spade));
      b.Dealer.Add(new Eight(Suit.Spade));
      b.EndGame();
      b.Dump();
      Console.WriteLine("Player total bet: {0}", b.Players[0].GetTotalBet());
      Console.WriteLine("Player should have: {0}; does have {1}", 50, b.Players[0].Money);
      Assertion.AssertEquals("player's hand: {0}, dealer's hand: {1}", 
        true, b.Players[0].Money == 50);
      Console.WriteLine(new String('*', 40));
    }
    
    [Test()]
    public void SplitWinLossTest()
    {
      Console.WriteLine(new String('*', 40));
      BlackJack b = new BlackJack(1, 6);
      Assertion.Assert(b.Players[0].CurrentBet == 25);
      b.Players[0].Money = 100;
      b.Players[0].Hands[0].Add(new Ace(Suit.Heart));
      b.Players[0].Hands[0].Add(new Ace(Suit.Heart));
      b.Players[0].Hands[0].Split();
      Assertion.Assert(b.Players[0].Hands.Count == 2);
      
      b.Players[0].Hands[0].Add(new Six(Suit.Heart));
      b.Players[0].Hands[1].Add(new Eight(Suit.Heart));
      
      b.Dealer.Add(new Ten(Suit.Spade));
      b.Dealer.Add(new Eight(Suit.Spade));
      b.EndGame();
      b.Dump();
      Console.WriteLine("Player total bet: {0}", b.Players[0].GetTotalBet());
      Console.WriteLine("Player should have: {0}; does have {1}", 100, b.Players[0].Money);
      Assertion.AssertEquals("player's hand: {0}, dealer's hand: {1}", 
        true, b.Players[0].Money == 100);
      Console.WriteLine(new String('*', 40));
    }
    
    [Test()]
    public void ThreeWaySplitTest()
    {
      Console.WriteLine(new String('*', 40));
      BlackJack b = new BlackJack(1, 6);
      Assertion.Assert(b.Players[0].CurrentBet == 25);
      b.Players[0].Money = 100;
      b.Players[0].Hands[0].Add(new Ace(Suit.Heart));
      b.Players[0].Hands[0].Add(new Ace(Suit.Heart));
      b.Players[0].Hands[0].Split();
      Assertion.Assert(b.Players[0].Hands.Count == 2);
      b.Players[0].Hands[0].Add(new Nine(Suit.Heart));
      b.Players[0].Hands[1].Add(new Ace(Suit.Heart));
      b.Players[0].Hands[1].Split();
      b.Players[0].Hands[1].Add(new Eight(Suit.Heart));
      Assertion.Assert(b.Players[0].Hands.Count == 3);
      b.Players[0].Hands[2].Add(new Eight(Suit.Heart));
      
      b.Dealer.Add(new Ten(Suit.Spade));
      b.Dealer.Add(new Eight(Suit.Spade));
      b.EndGame();
      b.Dump();
      Console.WriteLine("Player total bet: {0}", b.Players[0].GetTotalBet());
      Console.WriteLine("Player should have: {0}; does have {1}", 175, b.Players[0].Money);
      Assertion.AssertEquals("player's hand: {0}, dealer's hand: {1}", 
        true, b.Players[0].Money == 175);
      Console.WriteLine(new String('*', 40));
    }
    
    [Test()]
    public void ThreeWaySplitLossTest()
    {
      Console.WriteLine(new String('*', 40));
      BlackJack b = new BlackJack(1, 6);
      Assertion.Assert(b.Players[0].CurrentBet == 25);
      b.Players[0].Money = 100;
      b.Players[0].Hands[0].Add(new Ace(Suit.Heart));
      b.Players[0].Hands[0].Add(new Ace(Suit.Heart));
      b.Players[0].Hands[0].Split();
      Assertion.Assert(b.Players[0].Hands.Count == 2);
      b.Players[0].Hands[0].Add(new Six(Suit.Heart));
      b.Players[0].Hands[1].Add(new Ace(Suit.Heart));
      b.Players[0].Hands[1].Split();
      b.Players[0].Hands[1].Add(new Seven(Suit.Heart));
      Assertion.Assert(b.Players[0].Hands.Count == 3);
      b.Players[0].Hands[2].Add(new Seven(Suit.Heart));
      
      b.Dealer.Add(new Ten(Suit.Spade));
      b.Dealer.Add(new Nine(Suit.Spade));
      b.EndGame();
      b.Dump();
      Console.WriteLine("Player total bet: {0}", b.Players[0].GetTotalBet());
      Console.WriteLine("Player should have: {0}; does have {1}", 25, b.Players[0].Money);
      Assertion.AssertEquals("player's hand: {0}, dealer's hand: {1}", 
        true, b.Players[0].Money == 25);
      Console.WriteLine(new String('*', 40));
    }
    
    [Test()]
    public void ThreeSplitWinLossTest()
    {
      Console.WriteLine(new String('*', 40));
      BlackJack b = new BlackJack(1, 6);
      Assertion.Assert(b.Players[0].CurrentBet == 25);
      b.Players[0].Money = 100;
      b.Players[0].Hands[0].Add(new Ace(Suit.Heart));
      b.Players[0].Hands[0].Add(new Ace(Suit.Heart));
      b.Players[0].Hands[0].Split();
      Assertion.Assert(b.Players[0].Hands.Count == 2);
      b.Players[0].Hands[0].Add(new Six(Suit.Heart));
      b.Players[0].Hands[1].Add(new Ace(Suit.Heart));
      b.Players[0].Hands[1].Split();
      b.Players[0].Hands[1].Add(new Seven(Suit.Heart));
      Assertion.Assert(b.Players[0].Hands.Count == 3);
      b.Players[0].Hands[2].Add(new Eight(Suit.Heart));
      
      b.Dealer.Add(new Ten(Suit.Spade));
      b.Dealer.Add(new Eight(Suit.Spade));
      b.EndGame();
      b.Dump();
      Console.WriteLine("Player total bet: {0}", b.Players[0].GetTotalBet());
      Console.WriteLine("Player should have: {0}; does have {1}", 100, b.Players[0].Money);
      Assertion.AssertEquals("player's hand: {0}, dealer's hand: {1}", 
        true, b.Players[0].Money == 100);
      Console.WriteLine(new String('*', 40));
    
    }
    
    [Test()]
    public void ThreeSplitBlackJackTest()
    {
      Console.WriteLine(new String('*', 40));
      BlackJack b = new BlackJack(1, 6);
      Assertion.Assert(b.Players[0].CurrentBet == 25);
      b.Players[0].Money = 100;
      b.Players[0].Hands[0].Add(new Ace(Suit.Heart));
      b.Players[0].Hands[0].Add(new Ace(Suit.Heart));
      b.Players[0].Hands[0].Split();
      Assertion.Assert(b.Players[0].Hands.Count == 2);
      b.Players[0].Hands[0].Add(new King(Suit.Heart));
      b.Players[0].Hands[1].Add(new Ace(Suit.Heart));
      b.Players[0].Hands[1].Split();
      b.Players[0].Hands[1].Add(new Queen(Suit.Heart));
      Assertion.Assert(b.Players[0].Hands.Count == 3);
      b.Players[0].Hands[2].Add(new Jack(Suit.Heart));
      
      b.Dealer.Add(new Ten(Suit.Spade));
      b.Dealer.Add(new Eight(Suit.Spade));
      b.EndGame();
      b.Dump();
      Console.WriteLine("Player total bet: {0}", b.Players[0].GetTotalBet());
      Console.WriteLine("Player should have: {0}; does have {1}", 212.5, b.Players[0].Money);
      Assertion.AssertEquals("player's hand: {0}, dealer's hand: {1}", 
        true, b.Players[0].Money == 212.5);
      Console.WriteLine(new String('*', 40));
    }
    
    [Test()]
    public void SurrenderTest()
    {
      Console.WriteLine(new String('*', 40));
      BlackJack b = new BlackJack(1, 6);
      Assertion.Assert(b.Players[0].CurrentBet == 25);
      b.Players[0].Money = 100;
      b.Players[0].Hands[0].Add(new Seven(Suit.Heart));
      b.Players[0].Hands[0].Add(new Nine(Suit.Heart));
      b.Players[0].Hands[0].Surrender();
      
      b.Dealer.Add(new Ten(Suit.Spade));
      b.Dealer.Add(new Eight(Suit.Spade));
      b.EndGame();
      b.Dump();
      Console.WriteLine("Player total bet: {0}", b.Players[0].GetTotalBet());
      Console.WriteLine("Player should have: {0}; does have {1}", 87.5, b.Players[0].Money);
      Assertion.AssertEquals("player's hand: {0}, dealer's hand: {1}", 
        true, b.Players[0].Money == 87.5);
      Console.WriteLine(new String('*', 40));
    }
    
    [Test()]
    public void SplitWinSurrenderTest()
    {
      Console.WriteLine(new String('*', 40));
      BlackJack b = new BlackJack(1, 6);
      Assertion.Assert(b.Players[0].CurrentBet == 25);
      b.Players[0].Money = 100;
      b.Players[0].Hands[0].Add(new Seven(Suit.Heart));
      b.Players[0].Hands[0].Add(new Seven(Suit.Heart));
      b.Players[0].Hands[0].Split();
      Assertion.Assert(b.Players[0].Hands.Count == 2);
      
      b.Players[0].Hands[0].Add(new Nine(Suit.Heart));
      b.Players[0].Hands[0].Surrender();
      b.Players[0].Hands[1].Add(new Ace(Suit.Heart));
      
      b.Dealer.Add(new Ten(Suit.Spade));
      b.Dealer.Add(new Seven(Suit.Spade));
      b.EndGame();
      b.Dump();
      Console.WriteLine("Player total bet: {0}", b.Players[0].GetTotalBet());
      Console.WriteLine("Player should have: {0}; does have {1}", 112.5, b.Players[0].Money);
      Assertion.AssertEquals("player's hand: {0}, dealer's hand: {1}", 
        true, b.Players[0].Money == 112.5);
      Console.WriteLine(new String('*', 40));
    }

    [Test(), Ignore("Test to ensure no bets are permitted below $0")]
    public void NoBetBelowBrokeTest()
    {
      // no bet
      // no split
      // no double
    }    

    [Test()]
    public void AnimateCardBackTest()
    {
    
    }
        
    [Test()]
    public void PrettyPrintTest()
    {
    
    }

    [Test(), Ignore("Statistics test not finished")]
    public void StatisticsTest()
    {
      //TODO: Implement wins, losses, hands played, cards played, bets made
    }
    
    [Test(), Ignore("Not implemented")]
    public void ShufflingNotificationTest()
    {
    }
    
    [Test(), Ignore("Not implemented")]
    public void SaveTest()
    {
    }   

    [Test(), Ignore("Not implemented")]
    public void LoadTest()
    {
    }
	}
}
