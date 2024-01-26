//    Copyright (c) 2004 Software Conceptions, Inc.  All rights reserved.
//    Written by Paul Kimmel. pkimmel@softconcepts.com
//   
//    You must not remove this notice, or any other, from this software.
//   

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing;


namespace Softconcepts.BlackJackLib
{
  public abstract class Card : ICard
  {
		private Face face;
    private int highFaceValue;
    private int lowFaceValue;
    private Suit cardSuit;

		#region External Methods and Related Fields
		private int width = 0;
		private int height = 0;
		
		[DllImport("cards.dll")]//, CallingConvention=CallingConvention.Cdecl)]

    static extern bool cdtInit(ref int width, ref int height);
		
		[DllImport("cards.dll")]
		public static extern bool cdtDraw (IntPtr hdc, int x, int y, int card, int type, long color);
		
		[DllImport("cards.dll")]
		public static extern bool cdtDrawExt(IntPtr hdc, int x, int y, int dx, int dy, int card, int suit, long color);
		
		[DllImport("cards.dll")]
		public static extern void cdtTerm();

		#endregion
     
    #region ICard Members
    public Card( int lowValue, int highValue, Suit suit, Face face)
    {
			cdtInit(ref width, ref height);
			
      this.highFaceValue = highValue;
      this.lowFaceValue = lowValue;
      this.cardSuit = suit;
      this.face = face;
    }

    public int GetLowFaceValue()
    {
      return lowFaceValue;
    }

    public int GetHighFaceValue()
    {
      return highFaceValue;
    }
    
    public virtual int GetFaceValue()
    {
      return lowFaceValue;
    }

    public Suit CardSuit
    {
      get
      {
        return cardSuit;
      }
    }
    
    public Face Face
    {
      get{ return face; }
    }
    
    #endregion

    #region TextCard Members

    void TextCard.PaintFace()
    {
      Console.WriteLine(GetCardValue());
    }

    #endregion
    
    #region GraphicCard Members
    
    void GraphicCard.PaintFace(Graphics g, int x, int y, int dx, int dy)
    {
			IntPtr hdc = g.GetHdc();
			try
			{
				int card = (int)this.face * 4 + (int)cardSuit;
				cdtDrawExt(hdc, x, y, dx, dy, card, 0, 0);
			}
			finally
			{
				g.ReleaseHdc(hdc);
			}
    }
    
    void GraphicCard.PaintBack(Graphics g, int x, int y, int dx, int dy)
    {
      IntPtr hdc = g.GetHdc();
      try
      {
        cdtDrawExt(hdc, x, y, dx, dy, 61, 1, 0);
      }
      finally
      {
        g.ReleaseHdc(hdc);
      }
    }
    #endregion
    
    protected virtual string GetTextValue()
    {
      return GetLowFaceValue().ToString();
    }
    
    protected string GetTextSuit()
    {
      switch(cardSuit)
      {
        case Suit.Club : return "C";
        case Suit.Spade: return "S";
        case Suit.Heart: return "H";
        case Suit.Diamond: return "D";
      }   
      
      throw new Exception("Invalid card suit");      
    }
    
    public virtual string GetCardValue()
    {
      return string.Format("{0}{1}", GetTextValue(), GetTextSuit());
    }

    public string GetPrettyCardValue()
    {
      throw new NotImplementedException();
    }
  }
  
  public class Ace : Card
  {
    public Ace(Suit suit)
      : base(1, 11, suit, Face.One){}

    protected override string GetTextValue()
    {
      return "A";
    }
  }
  
  public class Two : Card
  {
    public Two(Suit suit) : base(2, 2, suit, Face.Two){}
  }
  
  public class Three : Card
  {
    public Three(Suit suit) : base(3, 3, suit, Face.Three){}
  }
  
  public class Four : Card
  {
    public Four(Suit suit) : base(4, 4, suit, Face.Four){}
  }
  
  public class Five : Card
  {
    public Five(Suit suit) : base(5, 5, suit, Face.Five){}
  }
  
  public class Six : Card
  {
    public Six(Suit suit) : base(6, 6, suit, Face.Six){}
  }
  
  public class Seven : Card
  {
    public Seven(Suit suit) : base(7, 7, suit, Face.Seven){}
  }
  
  public class Eight : Card
  {
    public Eight(Suit suit) : base(8, 8, suit, Face.Eight){}
  }
  
  public class Nine : Card
  {
    public Nine(Suit suit) : base(9, 9, suit, Face.Nine){}
  }
  
  
  public class Ten : Card
  {
    public Ten(Suit suit) : base(10, 10, suit, Face.Ten){}
  }
  
  public class Jack : Card
  {
    public Jack(Suit suit) : base(10, 10, suit, Face.Jack){}

    protected override string GetTextValue()
    {
      return "J";
    }
  }
  
  public class Queen : Card
  {
    public Queen(Suit suit) : base(10, 10, suit, Face.Queen){}

    protected override string GetTextValue()
    {
      return "Q";
    }
  }
  
  public class King : Card
  {
    public King(Suit suit) : base(10, 10, suit, Face.King){}

    protected override string GetTextValue()
    {
      return "K";
    }
  }  
  
}
