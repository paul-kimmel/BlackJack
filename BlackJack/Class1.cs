//    Copyright (c) 2004 Software Conceptions, Inc.  All rights reserved.
//    Written by Paul Kimmel. pkimmel@softconcepts.com
//   
//    You must not remove this notice, or any other, from this software.
//   

using System;
using Softconcepts.BlackJackLib;

namespace Softconcepts.BlackJack
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1
	{
		[STAThread]
		static void Main(string[] args)
		{
		  Decks decks = new Decks(6);
		  decks.Shuffle();
		  decks.Dump();
		  Console.ReadLine();
		}
	}
}
