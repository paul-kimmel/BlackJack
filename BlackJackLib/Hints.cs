//    Copyright (c) 2004 Software Conceptions, Inc.  All rights reserved.
//    Written by Paul Kimmel. pkimmel@softconcepts.com
//   
//    You must not remove this notice, or any other, from this software.
//   

using System;
using System.Diagnostics;
using System.Reflection;
using System.Resources;

namespace Softconcepts.BlackJackLib
{
	public enum Hint{ Hit, Stand, DoubleHit, DoubleStand, Surrender, Split, DontKnow, BlackJack }
		
	public class Hints
	{
    private static ResourceManager manager = null;
    
    static Hints()
    {
      manager = new ResourceManager(typeof(Hints).Namespace + ".Hints", Assembly.GetExecutingAssembly());
    }
    	
		private Hints(){}
		
		private static Hint GetMultiCardHint(DealerHand dealer, PlayerHand player)
		{
		  int sum = player.GetBestValue();
		  int dealerCard = dealer[1].GetLowFaceValue();
		  
		  switch(sum)
		  {
				case 0:
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
					return Hit();
				case 9:
					switch(dealerCard)
					{
						case 2:
							return Hit();
						case 3:
						case 4:
						case 5:
						case 6:
							return DoubleHit();
						case 7:
						case 8:
						case 9:
						case 10:
						case 1:
							return Hit();
					}
					break;
				case 10:
					switch(dealerCard)
					{
						case 2:
						case 3:
						case 4:
						case 5:
						case 6:
						case 7:
						case 8:
						case 9:
							if( player.Count == 2 )
								return DoubleHit();
							else
								return Hit();
						case 10:
						case 1:
							return Hit();
					}
					break;
				case 11:
					switch(dealerCard)
					{
						case 2:
						case 3:
						case 4:
						case 5:
						case 6:
						case 7:
						case 8:
						case 9:
						case 10:
							if( player.Count == 2 )
								return DoubleHit();
							else
								return Hit();
						case 1:
							return Hit();
					}
					break;
				case 12:
					switch(dealerCard)
					{
						case 2:
						case 3:
							return Hit();
						case 4:
						case 5:
						case 6:
							return Stand();
						case 7:
						case 8:
						case 9:
						case 10:
						case 1:
							return Hit();
					}
					break;
				case 13:
				case 14:
					switch(dealerCard)
					{
						case 2:
						case 3:
						case 4:
						case 5:
						case 6:
							return Stand();
						case 7:
						case 8:
						case 9:
						case 10:
						case 1:
							return Hit();
					}
					break;
				case 15:
					switch(dealerCard)
					{
						case 2:
						case 3:
						case 4:
						case 5:
						case 6:
							return Stand();
						case 7:
						case 8:
						case 9:
							return Hit();
						case 10:
							if( player.Count == 2 )
								return Surrender();
							else
								return Hit();
						case 1:
							return Hit();
					}
					break;
				case 16:
					switch(dealerCard)
					{
						case 2:
						case 3:
						case 4:
						case 5:
						case 6:
							return Stand();
						case 7:
						case 8:
							return Hit();
						case 9:
						case 10:
						case 1:
							if( player.Count == 2)
								return Surrender();
							else
								return Hit();
					}
					break;
				case 17:
				case 18:
				case 19:
				case 20:
				case 21:
					return Stand();
		  }
		  
		  return DontKnow();
		}
		
		private static Hint GetTwoCardHint(DealerHand dealer, PlayerHand player)
		{
			Debug.Assert(player != null);
			Debug.Assert(player.Count == 2);
			Debug.Assert(dealer != null);
			Debug.Assert(dealer.Count >= 2);
			
			int playerCard1 = player[0].GetFaceValue();
			int playerCard2 = player[1].GetFaceValue();
			int dealerCard = dealer[1].GetFaceValue();
			int playerBestValue = player.GetBestValue();
			
			// if the player does not have a pair or an ace then
			// the rules for two cards is the same for vaues less than 17
			if(playerCard1 != 1 && playerCard2 != 1 &&
				playerCard1 != playerCard2 )
				return GetMultiCardHint(dealer, player);
				
			// if player has matching cards then get those hints
			if( playerCard1 == playerCard2 )
				return GetMatchingCardHint(dealerCard, playerCard1);
		
			// if player has an ace then get those hints
			if( playerCard1 == 1 ) 
				return GetAceCardHint(dealerCard, playerCard2);
			else if( playerCard2 == 1)
				return GetAceCardHint(dealerCard, playerCard1);
				
			return DontKnow();
		
		}
		
		private static Hint GetMatchingCardHint(int dealerCard, int playerCard)
		{
			switch(playerCard)
			{
				case 2:
				case 3:
					switch(dealerCard)
					{
						case 2:
						case 3:
							return Split();
						case 4:
						case 5:
						case 6:
						case 7:
							return Split();
						case 8:
						case 9:
						case 10:
						case 1:
							return Hit();
					}
					break;
				case 4:
					switch(dealerCard)
					{
						case 2:
						case 3:
						case 4:
							return Hit();
						case 5:
						case 6:
							return Split();
						case 7:
						case 8:
						case 9:
						case 10:
						case 1:
							return Hit();
					}
					break;
				case 5:
					switch(dealerCard)
					{
						case 2:
						case 3:
						case 4:
						case 5:
						case 6:
						case 7:
						case 8:
						case 9:
							return DoubleHit();
						case 10:
						case 1:
							return Hit();
					}
					break;
				case 6:
					switch(dealerCard)
					{
						case 2:
							return Split();
						case 3:
						case 4:
						case 5:
						case 6:
							return Split();
						case 7:
						case 8:
						case 9:
						case 10:
						case 1:
							return Hit();
					}
					break;
				case 7:
					switch(dealerCard)
					{
						case 2:
						case 3:
						case 4:
						case 5:
						case 6:
						case 7:
							return Split();
						case 8:
						case 9:
						case 10:
						case 1:
							return Hit();
					}
					break;
				case 8:
					switch(dealerCard)
					{
						case 2:
						case 3:
						case 4:
						case 5:
						case 6:
						case 7:
						case 8:
						case 9:
						case 10:
						case 1:
							return Split();
					}
					break;
				case 9:
					switch(dealerCard)
					{
						case 2:
						case 3:
						case 4:
						case 5:
						case 6:
							return Split();
						case 7:
							return Stand();
						case 8:
						case 9:
							return Split();
						case 10:
						case 1:
							return Stand();
					}
					break;
				case 10:
					return Stand();
				case 1:
					return Split();
			}
			
			return DontKnow();
		}
		
		private static Hint GetAceCardHint(int dealerCard, int nonAceCard)
		{
			switch(nonAceCard)
			{
				case 2:
				case 3:
					switch(dealerCard)
					{
						case 2:
						case 3:
						case 4:
							return Hit();
						case 5:
						case 6:
							return DoubleHit();
						case 7:
						case 8:
						case 9:
						case 10:
						case 1:
							return Hit();
					}	
					break;
				case 4:
				case 5:
					switch(dealerCard)
					{
						case 2:
						case 3:
							return Hit();
						case 4:
						case 5:
						case 6:
							return DoubleHit();
						case 7:
						case 8:
						case 9:
						case 10:
						case 1:
							return Hit();
					}	
					break;
				case 6:
					switch(dealerCard)
					{
						case 2:
							return Hit();
						case 3:
						case 4:
						case 5:
						case 6:
							return DoubleHit();
						case 7:
						case 8:
						case 9:
						case 10:
						case 1:
							return Hit();
					}	
					break;
				case 7:
					switch(dealerCard)
					{
						case 2:
							return Stand();
						case 3:
						case 4:
						case 5:
						case 6:
							return DoubleStand();
						case 7:
						case 8:
							return Stand();
						case 9:
						case 10:
						case 1:
							return Hit();
					}	
					break;
				case 8:
				case 9:
					return Stand();
				case 10: 
					return BlackJack();
			}
			
			return DontKnow();
		}
		
		public static Hint GetHint(DealerHand dealer, PlayerHand player)
		{
		  Debug.Assert(dealer != null);
		  Debug.Assert(player != null);
		  
		  if( player.Count == 2 )
				return GetTwoCardHint(dealer, player);
			else
				return GetMultiCardHint(dealer, player);
		}
		
		public static string GetHintText(DealerHand dealer, PlayerHand player)
		{
			Hint hint = GetHint(dealer, player);
			string result = manager.GetString(hint.ToString());
			return result == null ? Hint.DontKnow.ToString() : result;
		}

		private static Hint Hit()
		{
			return Hint.Hit;
		}
		
		private static Hint Stand()
		{
			return Hint.Stand;
		}
		
		private static Hint DoubleHit()
		{
			return Hint.DoubleHit;
		}
		
		private static Hint DoubleStand()
		{
			return Hint.DoubleStand;
		}
		
		private static Hint Surrender()
		{
			return Hint.Surrender;
		}
		
		private static Hint Split()
		{
			return Hint.Split;
		}
		
		private static Hint DontKnow()
		{
			return Hint.DontKnow;
		}
		
		private static Hint BlackJack()
		{
			return Hint.BlackJack; 
		}
	}
}
