//    Copyright (c) 2004 Software Conceptions, Inc.  All rights reserved.
//    Written by Paul Kimmel. pkimmel@softconcepts.com
//   
//    You must not remove this notice, or any other, from this software.
//   

using System;
using System.Collections;

namespace Softconcepts.BlackJackLib
{
	public class Deck : ReadOnlyCollectionBase
 	{
		public Deck()
		{
		  Card[] cards = new Card[]{ 
		    /* add diamonds */
		    new Ace(Suit.Diamond), new Two(Suit.Diamond), new Three(Suit.Diamond), new Four(Suit.Diamond),
		    new Five(Suit.Diamond), new Six(Suit.Diamond), new Seven(Suit.Diamond), new Eight(Suit.Diamond),
		    new Nine(Suit.Diamond), new Ten(Suit.Diamond), new Jack(Suit.Diamond), new Queen(Suit.Diamond), new King(Suit.Diamond),
		    /* Add Clubs */
		    new Ace(Suit.Club), new Two(Suit.Club), new Three(Suit.Club), new Four(Suit.Club),
		    new Five(Suit.Club), new Six(Suit.Club), new Seven(Suit.Club), new Eight(Suit.Club),
		    new Nine(Suit.Club), new Ten(Suit.Club), new Jack(Suit.Club), new Queen(Suit.Club), new King(Suit.Club),
		    /* Add Hearts */
		    new Ace(Suit.Heart), new Two(Suit.Heart), new Three(Suit.Heart), new Four(Suit.Heart),
		    new Five(Suit.Heart), new Six(Suit.Heart), new Seven(Suit.Heart), new Eight(Suit.Heart),
		    new Nine(Suit.Heart), new Ten(Suit.Heart), new Jack(Suit.Heart), new Queen(Suit.Heart), new King(Suit.Heart),
		    /* Add Spades */
		    new Ace(Suit.Spade), new Two(Suit.Spade), new Three(Suit.Spade), new Four(Suit.Spade),
		    new Five(Suit.Spade), new Six(Suit.Spade), new Seven(Suit.Spade), new Eight(Suit.Spade),
		    new Nine(Suit.Spade), new Ten(Suit.Spade), new Jack(Suit.Spade), new Queen(Suit.Spade), new King(Suit.Spade)
		  };
		  
		  InnerList.AddRange(cards);
		}
		
		public Card this[int index]
		{
		  get{ return (Card)InnerList[index]; }
		}

    public Card GetNextCard()
    {
      if( this.Count > 0)
      {
        Card card = this[0];
        RemoveAt(0);
        return card;
      }
      
      return null;
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
		
		public void Shuffle()
		{
		  Shuffler[] shuffler = Shuffler.GetArray();
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
    }		
	}
}
