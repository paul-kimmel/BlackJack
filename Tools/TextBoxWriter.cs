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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tools
{
    public class TextBoxWriter : TextWriter
    {
        private TextBoxBase control;
        private StringBuilder builder;
        private TextWriter oldWriter;

        public TextBoxWriter(TextBox control)
        {
            this.control = control;
            control.HandleCreated += new EventHandler(control_HandleCreated);
        }

        public TextBoxWriter(TextBox control, TextWriter writer)
        {
          this.control = control;
          control.HandleCreated += new EventHandler(control_HandleCreated);
        }


        public override void Write(char ch)
        {
            Write(ch.ToString());
            if (oldWriter != null)
              oldWriter.Write(ch);
        }

        public override void Write(string s)
        {
            if (control.IsHandleCreated)
                AppendText(s);
            else
                BufferText(s);

            if (oldWriter != null)
              oldWriter.Write(s);
        }

        public override void WriteLine(string s)
        {
            Write(s + Environment.NewLine);
            if (oldWriter != null)
              oldWriter.WriteLine(s);
        }

        private void BufferText(string s)
        {
            if (builder == null)
                builder = new StringBuilder();
            builder.Append(s);
        }

        private delegate void AppendTextInvoker(string s);
        private void AppendText(string s)
        {
            if (control.InvokeRequired)
                control.Invoke(new AppendTextInvoker(InternalAppendText), s);
            else
                InternalAppendText(s);
        }

        private void InternalAppendText(string s)
        {
            if (builder != null)
            {
                control.AppendText(builder.ToString());
                builder = null;
            }

            control.AppendText(s);
        }


        private void control_HandleCreated(object sender, EventArgs e)
        {
            if(builder != null)
            {
                AppendText(builder.ToString());
                builder = null;
            }
        }

        public override Encoding Encoding
        {
            get { return Encoding.Default; }
        }
    }
}
