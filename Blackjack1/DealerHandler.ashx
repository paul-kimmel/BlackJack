<%@ WebHandler Language="C#" Class="DealerHandler" %>

using System;
using System.Web;
using Softconcepts.BlackJackLib;
using System.Drawing;
using System.Drawing.Imaging;
using Tools;
using System.Web.SessionState;
using System.IO;

public class DealerHandler : IHttpHandler, IReadOnlySessionState {
    
    public void ProcessRequest (HttpContext context) {
      PaintDealerHand(context);
    }
  
    private void PaintDealerHand(HttpContext context)
    {
      const int WIDTH = 125;
      const int HEIGHT = 150;
      
      Softconcepts.BlackJackLib.BlackJack game = SessionBag.Current.Game;
      DealerHand hand = game.Dealer;
      
      Bitmap image = new Bitmap(hand.GetHandWidth(WIDTH), HEIGHT);
      Graphics g = Graphics.FromImage(image);
      hand.GraphicPrintHand(g, 0, 0, WIDTH, HEIGHT, game.IsGameOver);
      context.Response.ContentType = "image/png";

      using (MemoryStream stream = new MemoryStream())
      {
        image.Save(stream, ImageFormat.Png);
        stream.WriteTo(context.Response.OutputStream);
      }

      g.Dispose();
      image.Dispose(); 
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}