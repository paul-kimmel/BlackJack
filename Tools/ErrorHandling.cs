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
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Web;
using System.IO;
using System.Configuration;
using System.Diagnostics;

namespace Tools
{
  public class ErrorHandling
  {
    private static readonly string LOG_FILE = "App_Data/ErrorLog.txt";

    public static void LogException(Exception ex, string source)
    {
      string path = HttpContext.Current.Server.MapPath(LOG_FILE);
      
      using(var writer = new StreamWriter(path, true))
      {
        writer.WriteLine(DateTime.Now);
        ex.Dump(writer);
      }
    }

    public static void MailException(Exception ex)
    {
#if DEBUG 
      MetaDumper.MyTrace("MailException");
      MetaDumper.MyTrace(ex.GetState());
#else
      string from = ConfigurationManager.AppSettings["CaseflowEmail"];
      const string subject = "CASEFLOW EXCEPTION";
          
      using(var client = new SmtpClient(ConfigurationManager.AppSettings.Get("SmtpServer")))
      {
        client.Send(from, from, subject, ex.GetState());
      }
#endif
    }



  }
}
   
