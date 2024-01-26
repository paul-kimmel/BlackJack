//    Copyright (c) 2004 Software Conceptions, Inc.  All rights reserved.
//    Written by Paul Kimmel. pkimmel@softconcepts.com
//   
//    You must not remove this notice, or any other, from this software.
//   

using System;
using System.Collections;

namespace Softconcepts.BlackJackLib
{
	public class PlayerHandCollection : CollectionBase
	{
		public PlayerHandCollection(){}
		
		public PlayerHand this[int index]
		{
		  get{ return (PlayerHand)List[index]; }
		  set{ List[index] = value; }
		}
		
    public int Add(PlayerHand value)
    {
      return List.Add(value);
    }
    
    public void Remove(PlayerHand value)
    {
      List.Remove(value);
    }
    
    public int IndexOf(PlayerHand value)
    {
      return List.IndexOf(value);
    }
    
    public void InsertAfter(PlayerHand hand, PlayerHand newHand)
    {
      InsertAfter(IndexOf(hand), newHand);
    }

    public void InsertAfter(int index, PlayerHand hand)
    {
      List.Insert(index + 1, hand);
    }
    
    public void Insert(int index, PlayerHand value)
    {
      List.Insert(index, value);
    }
	}
}
