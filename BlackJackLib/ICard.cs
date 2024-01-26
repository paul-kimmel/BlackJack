//    Copyright (c) 2004 Software Conceptions, Inc.  All rights reserved.
//    Written by Paul Kimmel. pkimmel@softconcepts.com
//   
//    You must not remove this notice, or any other, from this software.
//   

using System;
using System.Drawing;

namespace Softconcepts.BlackJackLib
{
  public interface TextCard
  {
    void PaintFace();
  }
  
  public interface GraphicCard
  {
    void PaintBack(Graphics g, int x, int y, int dx, int dy);
    void PaintFace(Graphics g, int x, int y, int dx, int dy);
  }
  
	public interface ICard : TextCard, GraphicCard
	{
	  int GetLowFaceValue();
	  int GetHighFaceValue();
	  int GetFaceValue();
	  Suit CardSuit{ get; }
	}
}
