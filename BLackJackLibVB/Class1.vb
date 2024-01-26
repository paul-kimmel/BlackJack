Imports System

Public MustOverride Class Card

End Class


public abstract class Card : ICard
  {
		private Face face;
    private int highFaceValue;
    private int lowFaceValue;
    private Suit cardSuit;

		#region External Methods and Related Fields
		private int width = 0;
		private int height = 0;

		[DllImport("cards.dll")]
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
