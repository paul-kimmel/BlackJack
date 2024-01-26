//    Copyright (c) 2004 Software Conceptions, Inc.  All rights reserved.
//    Written by Paul Kimmel. pkimmel@softconcepts.com
//   
//    You must not remove this notice, or any other, from this software.
//   

using System;
using System.Collections;
using System.Text;
using System.Drawing;

namespace Softconcepts.BlackJackLib
{
	public class Hand : CollectionBase
	{
		private bool standing = false;
		private bool surrender = false;
		private bool doubleDown = false;
		protected static Font font = new Font("Courier", 10);

		public Card this[int index]
		{
			get { return (Card)List[index]; }
			set { List[index] = value; }
		}

		public int Add(Card card)
		{
			return List.Add(card);
		}

		public void New()
		{
			Clear();
			standing = false;
			surrender = false;
			doubleDown = false;
		}

		public string GetTextHand()
		{
			StringBuilder builder = new StringBuilder();
			for (int i = 0; i < this.Count; i++)
			{
				if (i > 0) builder.Append(",");
				builder.Append(this[i].GetCardValue());
			}

			return builder.ToString();
		}

		public void TextPrintHand()
		{
			Console.WriteLine(GetTextHand());
		}

		public bool IsBlackJack()
		{
			return List.Count == 2 &&
				GetHandValueHigh() == 21;
		}

		public bool IsBust()
		{
			return GetHandValueLow() > 21;
		}

		public int BustedAtValue()
		{
			return GetHandValueLow();
		}

		public string BustedAtText()
		{
			return string.Format("Busted at: {0}", BustedAtValue());
		}

		public int GetHandValueLow()
		{
			int value = 0;
			foreach (Card c in this)
			{
				value += c.GetLowFaceValue();
			}

			return value;
		}

		public int GetHandValueHigh()
		{
			int value = 0;
			foreach (Card c in this)
			{
				value += c.GetHighFaceValue();
			}

			return value;
		}




    public int GetBestValue()
    {
      int value = 0;
      int aceCount = 0;
      for( int i=0; i<this.Count; i++)
        if( this[i] is Ace )
          aceCount++;
        else
          value += this[i].GetHighFaceValue();

			// we can add 11s as long as the value plus 11 and the remaining
			// aces as 11s doesn't exceed 21 (e.g. 9 + 11 + 1 but not 9 + 11 + 1 + 1)
      for( int i=0; i<aceCount; i++)
				if( value + aceCount - i - 1 + 11 <= 21)
          value += 11;
        else
          value += 1;
      
      return value;        
    }
    
    public int GetHandWidth(int cardWidth)
    {
      return ((Count - 1) * 20 + cardWidth + 2);
    }
    	  
	  public virtual void GraphicPrintHand(Graphics g, int x, int y, 
	    int cardWidth, int cardHeight, bool focused)
	  {
			for( int i=0; i<this.Count; i++)
			{
				((GraphicCard)this[i]).PaintFace(g, x + (20 * i), y, cardWidth, cardHeight);
			}
			
			 // draw the full width of the first card and then 20 pixels for successive cards
			if( focused && Count > 0)
			  g.DrawRectangle(Pens.White, x - 2, y - 2, GetHandWidth(cardWidth), cardHeight + 4);
	  }
	  
	  public bool Standing
	  {
	    get{ return standing; }
	    set{ standing = value; }
	  }
	  
	  public bool Doubled
	  {
			get{ return doubleDown; }
			set{ doubleDown = value; }
		}
	  
	  public bool Surrendered
	  {
			get{ return surrender; }
			set{ surrender = value; }
		}
		
		public virtual void Split()
		{
		}
		
	  public virtual void Double(Card card)
	  {
			Add(card);
			doubleDown = true;
			standing = true;
		}

    public virtual bool CanAcceptCard
    {
      get{ return !standing && !surrender; }
    }
    
    public virtual bool CanDouble
    {
      get{ return false; }
    }
    		
		public virtual void Surrender()
		{
			surrender = true;
		}
		
	  public void Stand()
	  {
	    standing = true;
	  }
	  
	  public virtual void Dump()
	  {
	    Console.WriteLine(GetTextHand());
	  }
  }
}
