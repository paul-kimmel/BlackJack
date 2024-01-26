<%@ WebHandler Language="C#" Class="ImageHandler" %>

using System;
using System.Web;
using Softconcepts.BlackJackLib;
using System.Drawing;
using System.Drawing.Imaging;

public class ImageHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
      GraphicCard ace = new Ace(Suit.Heart);
      Bitmap image = new Bitmap(105, 100);
      Graphics g = Graphics.FromImage(image);
      ace.PaintFace(g, 0, 0, 75, 100);

      GraphicCard jack = new Jack(Suit.Spade);
      jack.PaintFace(g, 30, 0, 75, 100);
      context.Response.ContentType = "image/png";

      image.Save(context.Response.OutputStream, ImageFormat.Png);

      g.Dispose();
      image.Dispose();      
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}