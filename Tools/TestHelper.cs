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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tools
{
  public static class TestHelper
  {
    private static readonly Hashtable hash = new Hashtable();
    public static void Given(this Object o, object value)
    {
      Console.WriteLine("Given: {0}", value);
      hash.Add(o.GetHashCode(), value);
    }

    public static void Expect(this Object o)
    {
      o.Expect(true);
    }

    public static void Expect(this Object o, object expected)
    {
      Console.WriteLine("Expect: {0}", expected);

      object _actual = hash[o.GetHashCode()];
      hash.Remove(o.GetHashCode());

      Assert.IsTrue((_actual == null && expected == null) || (_actual != null && _actual.Equals(expected)), String.Format("Given: {0}, Expect: {1}", _actual, expected));
    }

    public static void SetControllerContext(this Controller controller,HttpContext httpContext, string controllerName, string actionName)
    {
      var baseContext = new HttpContextWrapper(httpContext);
      var routeData = new RouteData();
      routeData.Values.Add("controller", controllerName);
      routeData.Values.Add("action", actionName);
      controller.ControllerContext = new ControllerContext(baseContext, routeData, controller);
    }

    public static void CreateViewMocks(List<string> viewPaths)
    {
      var engine = new Mock<IViewEngine>();
      ViewEngineResult engineResult;

      ViewEngines.Engines.Clear();
      
      foreach (string viewPath in viewPaths)
      {
        engineResult = new ViewEngineResult(new MyView(viewPath), engine.Object);

        engine.Setup(e => e.FindPartialView(It.IsAny<ControllerContext>(),
          It.IsAny<String>(), It.IsAny<bool>())).Returns(engineResult);

        ViewEngines.Engines.Add(engine.Object);
      }
    }

    public static object InvokeInstance(object o, string name, object[] args)
    {
      return o.GetType().GetMethod(name, BindingFlags.NonPublic | BindingFlags.Instance).Invoke(o, args);
    }

    public static object InvokeStatic(object o, string name, object[] args)
    {
      return o.GetType().GetMethod(name, BindingFlags.NonPublic | BindingFlags.Static).Invoke(o, args);
    }
  }

  public class MyView : IView
  {
    public MyView(string viewPath)
    {
      this.ViewPath = viewPath;
    }

    public string ViewPath { get; private set; }

    public void Render(ViewContext viewContext, TextWriter writer)
    {
      writer.Write(File.ReadAllText(ViewPath));
    }
  }
}
