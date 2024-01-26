//    Copyright (c) 2004 Software Conceptions, Inc.  All rights reserved.
//    Written by Paul Kimmel. pkimmel@softconcepts.com
//   
//    You must not remove this notice, or any other, from this software.
//   

using System;

namespace Softconcepts.BlackJackLib
{
	public class Dealer
	{
	  private string name;
	  private DealerHand hand = null;
	  
		public Dealer(string name)
		{
		  this.name = name;
		  hand = new DealerHand();
		}
		
		public DealerHand Hand
		{
		  get{ return hand; }
		}
		
		public void DealCard(Card card)
		{
		  hand.Add(card);
		}
		
		public void New()
		{
		  hand.New();
		}
	}
}
