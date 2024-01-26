//    Copyright (c) 2004 Software Conceptions, Inc.  All rights reserved.
//    Written by Paul Kimmel. pkimmel@softconcepts.com
//   
//    You must not remove this notice, or any other, from this software.
//   

using System;
using System.Collections;

namespace Softconcepts.BlackJackLib
{
	public class Decks : ReadOnlyCollectionBase
	{
	  private int decks = 0;
	  
		public Decks(int decks)
		{
		  this.decks = decks;
		  Initialize();
		}
		
		private void Initialize()
		{
		  Console.WriteLine("Initalizing deck");
		  InnerList.Clear();
		  for( int i=0; i<decks; i++)
		    InnerList.AddRange(new Deck());
		  Shuffle();
		  Console.WriteLine("Done initializing");
		}
		
		public Card this[int index]
		{
		  get{ return (Card)InnerList[index]; }
		}
		
		public void RemoveAt(int index)
		{
		  InnerList.RemoveAt(index);
		}
		
		public void Remove(Card card)
		{
		  InnerList.Remove(card);
		}
		
		public bool MoreCards()
		{
		  return InnerList.Count > 0;
		}

    public Card GetNextCard()
    {
      Console.WriteLine("GetNextCard called, remaining cards={0}", this.Count);
      if( this.Count == 0) Initialize();
      Card card = this[0];
      RemoveAt(0);
      return card;
    }

    public void Shuffle()
    {
      Shuffler[] shuffler = Shuffler.GetArray(decks * 52);
      for( int i=0; i<shuffler.GetLength(0); i++)
      {
        Card temp = (Card)InnerList[i];
        InnerList[i] = InnerList[shuffler[i].key];
        InnerList[shuffler[i].key] = temp;
      }
    }
		
		public void Dump()
		{
		  foreach(Card card in this)
		  {
		    Console.WriteLine(card.GetCardValue());
		  }
		  Console.WriteLine("There are {0} cards in the pile", this.Count);
		  Console.ReadLine();
		}
	}
}
