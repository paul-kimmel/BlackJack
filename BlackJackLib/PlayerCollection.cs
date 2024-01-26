//    Copyright (c) 2004 Software Conceptions, Inc.  All rights reserved.
//    Written by Paul Kimmel. pkimmel@softconcepts.com
//   
//    You must not remove this notice, or any other, from this software.
//   

using System;
using System.Collections;

namespace Softconcepts.BlackJackLib
{
	public class PlayerCollection : CollectionBase
	{
	  public PlayerCollection( int numberOfPlayers )
	  {
	    for( int i=0; i<numberOfPlayers; i++)
	      Add(new Player("player " + i.ToString()));
	  }
	  
	  public PlayerCollection(string[] players )
	  {
	    foreach(string name in players)
	      Add(new Player(name));
	  }
	  
	  private bool IsValidIndex(int index)
	  {
	    return index >= 0 && index < List.Count;
	  }
	  
	  public Player this[int index]
	  {
	    get
	    { 
	      if(IsValidIndex(index))
	        return (Player)List[index]; 
	      else
	        return null;
	    }
	    set{ List[index] = value; }
	  }
	  
	  public int Add(Player value)
	  {
	    return List.Add(value);
	  }
	  
	  public void Remove(Player value)
	  {
	    List.Remove(value);
	  }
	}
}
