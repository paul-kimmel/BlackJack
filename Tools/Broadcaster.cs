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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.Hosting;

namespace Tools
{
  public class Broadcaster 
  {
    public static void WriteLine(string format, params object[] args)
    {
      WriteLine(string.Format(format, args));
    }

    public static void WriteLine(string text)
    {
      if (HostingEnvironment.IsHosted)
      {
        if (SessionBag.Current.Debug == null)
          SessionBag.Current.Debug = new StringBuilder();

        StringBuilder o = SessionBag.Current.Debug;
        try
        {
          StackFrame frame = new StackTrace().GetFrame(1);
          var s = string.Format("{0}.{1}[{2}]({3})", frame.GetMethod().DeclaringType.FullName, frame.GetMethod().Name, frame.GetFileName(), text);
          o.Append(s);
        }
        catch
        {
          o.Append(text);
        }

        o.AppendLine();
      }
    }

    public static void Clear()
    {
      if (HostingEnvironment.IsHosted)
      {
        if (SessionBag.Current.Debug == null)
          SessionBag.Current.Debug = new StringBuilder();

        StringBuilder o = SessionBag.Current.Debug;
        o.Clear();
      }
    }

    public static string GetDebugText()
    {
      try
      {
        return SessionBag.Current.Debug.ToString().Replace("\r\n", "\n");
      }
      catch
      {
        return "";
      }
    }
  }
}
