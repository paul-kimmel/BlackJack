<%@ WebHandler Language="C#" Class="PlayerHandler" %>

using System;
using System.Web;
using Softconcepts.BlackJackLib;
using System.Drawing;
using System.Drawing.Imaging;
using Tools;
using System.Web.SessionState;
using System.IO;

public class PlayerHandler : IHttpHandler, IReadOnlySessionState {
    
  public void ProcessRequest (HttpContext context) 
  {
    try
    {
        int hand = Convert.ToInt32(context.Request.QueryString["handposition"]);
        PaintPlayerHand(context, hand);
    }
    catch{}
  }
    
  public void PaintPlayerHand(HttpContext context, int index)
  {
    const int WIDTH = 125;
    const int HEIGHT = 150;
    
    try
    {
      Softconcepts.BlackJackLib.BlackJack game = SessionBag.Current.Game;
      Player player = game.Players[0];
      PlayerHand hand = player.Hands[index];

      bool current = hand == game.CurrentHand;

      Bitmap image = new Bitmap(hand.GetHandWidth(WIDTH), HEIGHT+20);

      Graphics g = Graphics.FromImage(image);

      hand.GraphicPrintHand(g, 0, 0, WIDTH, HEIGHT, false/*, current*/);
      context.Response.ContentType = "image/png";

      using (MemoryStream stream = new MemoryStream())
      {
        image.Save(stream, ImageFormat.Png);
        stream.WriteTo(context.Response.OutputStream);
      }

      g.Dispose();
      image.Dispose(); 

    }
    catch { }
    
  }
 
  public bool IsReusable {
      get {
          return false;
      }
  }
}