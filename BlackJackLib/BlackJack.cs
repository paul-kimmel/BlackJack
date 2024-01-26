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
  [Serializable()]
	public class BlackJack
	{
	  private bool isGameOver = false;
	  private bool isNewGame = true;
	  private int numberOfPlayers;
	  private Decks decks = null;
	  private Dealer dealer = null;
	  private PlayerCollection players = null;
	  private PlayerHand currentHand = null;
	  private Options options = null;
    private Recorder recorder = null;

    public BlackJack()
    {
      Initialize(1, options.DeckCount);
    }
	  
		public BlackJack(int numberOfPlayers, int deckCount)
		{
		  Initialize(numberOfPlayers, deckCount);
		}
		
		private void Initialize(int numberOfPlayers, int deckCount)
		{
      Debug.Assert(numberOfPlayers >= 1);
      if( numberOfPlayers < 1)
        throw new ArgumentOutOfRangeException("numberOfPlayers", 1, "You must specify at least 1 player");
   
      options = new Options(this);
      this.numberOfPlayers = numberOfPlayers;
      if( deckCount != options.DeckCount)
        deckCount = options.DeckCount;

      CheckRecording();
      decks = new Decks(options.DeckCount);
      players = new PlayerCollection(numberOfPlayers);
      players[0].Name = options.Name;
      players[0].Money = options.StartupCashAmount;
      currentHand = players[0][0];
      
      dealer = new Dealer("Doug");
      Record();
		}
		
		public void CheckRecording()
		{
      if( options.RecordPlay )
        StartRecording();
		}
		
		public void StartRecording()
		{
		  if( recorder == null )
		    recorder = new Recorder();
		}
		
		public void StopRecording()
		{
		  if( recorder != null )
		  {
		    recorder.WriteToFile("game.txt");
		    recorder = null;
      }
		}
		
		public void Record()
		{
      if( recorder != null )
        recorder.Record(this);		  
		}
		
		public Options Options
		{
		  get{ return options; }
		}

		public void Deal()
		{
		  ClearHands();
		  for( int i=0; i<2; i++)
		  {
		    foreach(Player player in players)
		      player.DealCard(decks.GetNextCard());
		      
		    dealer.DealCard(decks.GetNextCard());
		  }
		}
		
		public void DealToDealer()
		{
		  dealer.DealCard(decks.GetNextCard());
		}
		
		private void ClearHands()
		{
		  dealer.New();
		  foreach(Player player in players)
		    player.New();
		}

    
    public PlayState GetPlayState(PlayerHand hand)
    {
      return PlayDecisionEngine.GetPlayState(dealer.Hand, hand);
    }
    
    public DealerHand Dealer
    {
      get{ return dealer.Hand; }
    }
    
    public PlayerHand CurrentHand
    {
      get{ return currentHand; }
    }
    
    public bool NextHand()
    {
      for( int i=0; i<players.Count; i++)
      {
        int index = players[i].Hands.IndexOf(currentHand);
        // we found the current hand
        if( index > -1 )
        {
          // its either the current players next hand
          if( index < players[i].Hands.Count - 1 )
          {
            currentHand = players[i][index+1];
            return true;
          }
          // or the next players first hand
          else if (players[i+1] != null)
          {
            currentHand = players[i+1][0];
            return true;
          }
          //or that last player's last hand
          else
            break;
        }
      }
      
      currentHand = null;
      return false;
    }
    
    public bool IsNewGame 
    {
      get{ return isNewGame; }
    }
    
    public bool IsGameOver
    {
      get{ return isGameOver; }
    }
    
    public bool CanDealToCurrentHand
    {
      get{ return !isGameOver && currentHand != null 
        && !currentHand.Standing && !currentHand.IsBust()
        && currentHand.Player.HasSufficientFunds 
        && !currentHand.IsBlackJack() && !currentHand.Surrendered; }
    }
    
    
    public bool CanSplitCurrentHand
    {
      get{ return !isGameOver && currentHand != null && currentHand.CanSplit; }
    }

    public bool CanDoubleCurrentHand
    {
      get{ return !isGameOver && currentHand != null && currentHand.CanDouble; }
    }
    
    public bool CanSurrenderCurrentHand
    {
      get{ return !isGameOver && currentHand != null && currentHand.CanSurrender; }
    }
    
    public void SurrenderCurrentHand()
    {
      if( CanSurrenderCurrentHand )
      {
        CurrentHand.Surrender();
        DoSurrenderCurrentHand();
        NextSteps();
      }
    }
    
		public void DoubleCurrentHand()
		{
		  if( CanDoubleCurrentHand )
		  {
		    CurrentHand.Double(decks.GetNextCard());
		    DoDoubleCurrentHand();
        NextSteps();
      }		    
		}
  
    public bool Double()
    {
      if( CanDoubleCurrentHand )
      {
        DoubleCurrentHand();
        Record();
        return true;
      }
      
      return false;
    }

    public void Surrender()
    {
      if( this.CanSurrenderCurrentHand )
      {
        SurrenderCurrentHand();
        Record();
      }
    }

    public bool DecreaseBet()
    {
      if( IsGameOver && GetPlayer(0).CanDecreaseMinimumBet(options.ChangeBetAmount))
      {
        Players[0].DecreaseMinimumBet(options.ChangeBetAmount);
        Record();
        return true;
      }
      
      return false;
    }  
    
    public bool IncreaseBet()
    {
      if( IsGameOver && GetPlayer(0).CanIncreaseMinimumBet(options.ChangeBetAmount))
      {
        Players[0].IncreaseMinimumBet(options.ChangeBetAmount);
        Record();
        return true;
      }
      return false;
    }
    
    public bool Hit()
    {
      if( CanDealToCurrentHand )
      {
        HitCurrentHand();
        Record();
        return true;
      }
      return false;
    }
    
    public void Stand()
    {
      StandCurrentHand();
      Record();
    }

    public bool Split()
    {
      if( CanSplitCurrentHand )
      {
        SplitCurrentHand();
        Record();
        return true;
      }
      return false;
    }

    public string GetHint()
    {
      const string mask = "Hint: {0}";
      if( options.HintsEnabled )
        return string.Format(mask, Hints.GetHintText(Dealer, CurrentHand));
      else
        return string.Format(mask, "Off");            
    }        

    public PlayerCollection Players
    {
      get{ return this.players; }
    }
    
    public Player GetPlayer(int index)
    {
      Debug.Assert(index >= 0 && index < players.Count);
      return players[index];
    }
      
    public void Dump()
    {
      Console.WriteLine("Dealer={0}, value={1}", 
        Dealer.GetTextHand(), Dealer.GetBestValue());
     
      foreach(Player player in players)
        player.Dump();
    }
    
    public bool CanPlayNewGame()
    {
      return Players[0].Money >= Players[0].CurrentBet;
    }
    
    public bool NewGame()
    {
      if( CanPlayNewGame())
      {
        isNewGame = false;
        isGameOver = false;
        Deal();
        currentHand = Players[0][0];
        Record();
        DoNewGame();
        return true;
      }
      
      return false;
    }
 
    public void CheckEndGame()
    {
      if( Dealer.IsBlackJack() || GetPlayer(0).IsBlackJack())
        EndGame();
    }
  
    public void EndGame()
    {
      isGameOver = true;
      PlayDealerHand();
      DecidePlay();
      DoEndGame();
    }

    private bool NeedToDraw()
    {
      foreach(Player player in players)    
        foreach(PlayerHand hand in player.Hands)
          if(!hand.IsBust() && !hand.Surrendered && !hand.IsBlackJack())
            return true;
            
      return false;
    }
    
    private void PlayDealerHand()
    {
      if(NeedToDraw())
      {
        DoBeforePlayDealerHand();
      
        while(!Dealer.IsBust() && Dealer.GetBestValue() < 17)
        {
          DealToDealer();
          DoDealerHandChanged();
        }
      }
    }
    
    private void DoBeforePlayDealerHand()
    {
      if(BeforePlayDealerHand != null)
        BeforePlayDealerHand(dealer.Hand, EventArgs.Empty);
    }
    
    private void DoDealerHandChanged()
    {
      if(OnDealerHandChanged != null )
        OnDealerHandChanged(dealer.Hand, EventArgs.Empty);
    }

    private void DecidePlay()
    {
      foreach(Player player in Players)
        foreach(PlayerHand hand in player.Hands)
        {
          DoDecidePlay(hand);
          hand.SetPlayState(GetPlayState(hand));
          player.Statistics.Add( new Statistic(
            hand, dealer.Hand, GetPlayState(hand), PlayDecisionEngine.GetChange(hand)));
        }
    }
    
    public void HitCurrentHand()
    {
      if(CanDealToCurrentHand)
      {
        currentHand.Add(decks.GetNextCard());
        DoHitCurrentHand();
        if( CurrentHand.IsBust() )
          NextSteps();
      }
    }
 
    public void StandCurrentHand()
    {
      if( CurrentHand == null ) return;
      CurrentHand.Stand();
      DoStandCurrentHand();
      NextSteps();
    }
    
    public void SplitCurrentHand()
    {
      if( CanSplitCurrentHand )
      {
        CurrentHand.Split();
        DoSplitCurrentHand();
      }
    }

    private void DoDoubleCurrentHand()
    {
      if( OnDoubleCurrentHand != null )
        OnDoubleCurrentHand(CurrentHand, EventArgs.Empty);
    }
    
    private void DoStandCurrentHand()
    {
      if( OnStandCurrentHand != null )
        OnStandCurrentHand(CurrentHand, EventArgs.Empty);
    }
    
    private void NextSteps()
    {
      if(NextHand())
        DoNextHand();
      else
        EndGame();
    }
    
    protected void DoHitCurrentHand()
    {
      if( OnHitCurrentHand != null )
        OnHitCurrentHand(CurrentHand, EventArgs.Empty);
    }
    
    protected void DoNewGame()
    {
      if(OnNewGame != null)
        OnNewGame(this, EventArgs.Empty);
    }
    
    protected void DoEndGame()
    {
      if(OnEndGame != null)
        OnEndGame(this, EventArgs.Empty);
    }
    
    protected void DoNextHand()
    {
      if( OnNextHand != null )
        OnNextHand(CurrentHand, EventArgs.Empty);
    } 
 
    protected void DoSurrenderCurrentHand()
    {
      if( OnSurrenderCurrentHand != null )
        OnSurrenderCurrentHand(CurrentHand, EventArgs.Empty);
    }
    
    protected void DoSplitCurrentHand()
    {
      if( OnSplitCurrentHand != null )
        OnSplitCurrentHand(CurrentHand, EventArgs.Empty);
    }
    
    protected void DoDecidePlay(PlayerHand hand)
    {
      if( OnDecidePlay != null )
        OnDecidePlay(hand, EventArgs.Empty);
    }

    public void DealSplitGame()
    {
      throw new NotImplementedException();
    }

    public event EventHandler OnChangeBet;
    public event EventHandler OnSplitCurrentHand;
    public event EventHandler OnSurrenderCurrentHand;
    public event EventHandler OnDoubleCurrentHand;          
    public event EventHandler OnStandCurrentHand;
    public event EventHandler OnNewGame;
    public event EventHandler OnEndGame;
    public event EventHandler OnHitCurrentHand;
    public event EventHandler OnNextHand;    
    public event EventHandler BeforePlayDealerHand;
    public event EventHandler OnDealerHandChanged;
    public event EventHandler OnDecidePlay;
	}
}