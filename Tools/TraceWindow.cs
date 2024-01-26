#region Copyright Notice
//Copyright 2002-2016 Software Conceptions, Inc 4103 Cornell Rd. 
//Okemos. MI 49964, U.S.A. All rights reserved.

//Software Conceptions, Inc has intellectual property rights relating to 
//technology embodied in this product. In particular, and without 
//limitation, these intellectual property rights may include one or more 
//of U.S. patents or pending patent applications in the U.S. and/or other countries.

//This product is distributed under licenses restricting its use, copying and
//distribution. No part of this product may be 
//reproduced in any form by any means without prior written authorization 
//of Software Conceptions.

//Software Conceptions is a trademarks of Software Conceptions, Inc
#endregion
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Tools
{
    public partial class TraceWindow : Form
    {
      public TraceWindow()
      {
          InitializeComponent();
            
      }

      private TextWriter oldOutput = null;
      public static TraceWindow Create()
      {
        var o = new TraceWindow();
        o.oldOutput = Console.Out;
        return o;
      }

      private TextBoxWriter writer = null;

      private void textBox1_TextChanged(object sender, EventArgs e)
      {

      }

      private Image image = null;
      public void DrawImage(Image image)
      {
        this.image = image;
        Refresh();
      }

      private void TraceWindow_Load(object sender, EventArgs e)
      {
          writer = new TextBoxWriter(textBox1, oldOutput);
          Console.SetOut(writer);
      }

      private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
      {
          textBox1.Text = "";
      }

      private void TraceWindow_Paint(object sender, PaintEventArgs e)
      {
        if (image == null) return;
        var graphics = textBox1.CreateGraphics();
        graphics.DrawImage(image, 0, 0);
      }
    }
}
