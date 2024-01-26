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
using System.Web;
using System.IO;
using System.Web.UI;

namespace Tools
{
  public class Navigate
  {

    private static string SessionName(string pageName)
    {
      return string.Format("PreviousPage{0}", pageName);
    }

    private static string PagePath(Page page)
    {
      return page.Request.Url.AbsolutePath;
    }

    private static FileInfo GetAbsolutePathFromPage(Page page)
    {
      return new FileInfo(PagePath(page));
    }

    private static string PageName(System.Web.UI.Page page)
    {
      return GetAbsolutePathFromPage(page).Name;
    }

    private static void SetSession(Page page, string newPageName)
    {
      if (SessionBag.Current[SessionName(newPageName)] == null)
        SessionBag.Add(SessionName(newPageName), PagePath(page));
    }

    private static void ClearSession(Page page)
    {
      SessionBag.Remove(SessionName(PageName(page)));
    }

    public static void GoToPage(Page page, string newPageName)
    {
      SetSession(page, newPageName);
      page.Response.Redirect(newPageName);
    }

    /// <summary>
    /// Use this function for redirects with query parameters. The fromPage is 
    /// the Page object we are coming from, toUrl is the full url with parameters, 
    /// and return page is a shortcut for stripping the parameters
    /// </summary>
    /// <param name="fromPage">Originating Page</param>
    /// <param name="toUrl">Target URL with Query Parameters</param>
    /// <param name="urlNoQueryParams">Same URL without query parameters</param>
    public static void GoToPage(Page fromPage, string toUrl, string urlNoQueryParams)
    {
      SetSession(fromPage, urlNoQueryParams);
      fromPage.Response.Redirect(toUrl);
    }

    public static string PreviousPageName(Page page)
    {
      return SessionBag.Current[SessionName(PageName(page))];
    }

    public static void ReturnToPreviousPage(Page page)
    {
      if (SessionBag.Current[SessionName(PageName(page))] == null)
        page.Server.Transfer("right.aspx");
      else
      {
        string previousPage = PreviousPageName(page);
        ClearSession(page);
        page.Response.Redirect(previousPage, true);
      }
    }
  }
}
