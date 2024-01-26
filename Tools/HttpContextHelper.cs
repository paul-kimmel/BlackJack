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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Security;
using System.Web.SessionState;

namespace Tools
{
  public class HttpContextHelper
  {
    public static void SetupFakeContext(string url = "http://redhawk/")
    {
      SetupFakeContext("username", url);
    }

    public static void SetupFakeContext(string username, string url = "http://redhawk/")
    {
      var request = new HttpRequest("", url, "");
      var writer = new StringWriter();
      var response = new HttpResponse(writer);
      var context = new HttpContext(request, response);

      var sessionContainer = new HttpSessionStateContainer("id", new SessionStateItemCollection(),
                                                           new HttpStaticObjectsCollection(), 10, true,
                                                           //HttpCookieMode.AutoDetect,
                                                           HttpCookieMode.UseCookies,
                                                           SessionStateMode.InProc, false);

      context.Items["AspSession"] = typeof(HttpSessionState).GetConstructor(
                                               BindingFlags.NonPublic | BindingFlags.Instance,
                                               null, CallingConventions.Standard,
                                               new[] { typeof(HttpSessionStateContainer) },
                                               null)
                                          .Invoke(new object[] { sessionContainer });
      context.User = new GenericPrincipal(new GenericIdentity(username), new string[0]);


      context.Request.Browser = new HttpBrowserCapabilities()
      {
        Capabilities =
          new Dictionary<string, string> { { "supportsEmptyStringInCookieValue", "false" }, { "cookies", "false" } }
      };


      //SetHostingEnvironment(); // this goofs up the membership provider
      HttpContext.Current = context;
    }

    private static void SetHostingEnvironment()
    {
      if (HostingEnvironment.IsHosted) return;

      FieldInfo info = typeof(HostingEnvironment).GetField("_theHostingEnvironment", BindingFlags.Static | BindingFlags.NonPublic);
      var o = new HostingEnvironment();

      SetField(o, "_appPhysicalPath", @"D:\Redhawk\Redhawk\Redhawk");
      SetField(o, "_siteName", "Redhawk");

      info.SetValue(null, o);
    }

    private static void SetField(HostingEnvironment o, string fieldname, object value)
    {
      try
      {
        FieldInfo info = o.GetType().GetField(fieldname);
        info.SetValue(o, value);
      }
      catch (Exception ex)
      {
        Debug.WriteLine(ex.Message);
      }
    }
  }
}
