//    Copyright (c) 2004 Software Conceptions, Inc.  All rights reserved.
//    Written by Paul Kimmel. pkimmel@softconcepts.com
//   
//    You must not remove this notice, or any other, from this software.
//   

using System;
using System.Drawing;

namespace Softconcepts.BlackJackLib
{
	public class DealerHand : Hand
	{
	  public DealerHand(){}
	  
		public bool WantsCard()
		{
		  return base.Count >= 2 &&
		    (base.GetBestValue() < 17);
		}
		
    public override void GraphicPrintHand(Graphics g, int x, int y, 
      int cardWidth, int cardHeight, bool showAllCards)
    {
      if( showAllCards )
        base.GraphicPrintHand(g, x, y, cardWidth, cardHeight, false);
      else
        GraphicPrintConcealedHand(g, x, y, cardWidth, cardHeight);
    }
    
		private void GraphicPrintConcealedHand(Graphics g, int x, int y, int cardWidth, int cardHeight)
		{
			if( this.Count == 0 ) return;
		  ((GraphicCard)this[0]).PaintBack(g, x, y, cardWidth, cardHeight);
		  
			// paint all cards except first!
			for( int i=1; i<this.Count; i++)
			{
				((GraphicCard)this[i]).PaintFace(g, x + (20* i), y, cardWidth, cardHeight);
			}
		}



  }
}
