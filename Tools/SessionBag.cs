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
using System.Dynamic;

namespace Tools
{
  public class SessionBag : DynamicObject
  {
    private static SessionBag current;
    static SessionBag()
    {
      current = new SessionBag();
    }

    public static dynamic Current
    {
      get { return current; }
      internal set { current = value; }
    }

    private static HttpSessionStateBase Session
    {
      get { return new HttpSessionStateWrapper(HttpContext.Current.Session); }
    }

    public static void Remove(string key)
    {
      Session.Remove(key);
    }

    public static void Add(string key, object value)
    {
      Session.Add(key, value);
    }


    public object this[string name]
    {
      get { return Session[name]; }
      set { Session[name] = value; }
    }

    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
      result = Session[binder.Name];
      return true;
    }

    public override bool TrySetMember(SetMemberBinder binder, object value)
    {
      this[binder.Name] = value;
      return true;
    }

    public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
    {
      try
      {
        result = Session[binder.Name];
        if (result == null) result = args[0];
        return true;
      }
      catch
      {
        return base.TryInvokeMember(binder, args, out result);
      }
    }

    public override IEnumerable<string> GetDynamicMemberNames()
    {
      List<string> keys = new List<string>();
      foreach (var key in Session.Keys)
        keys.Add(key.ToString());

      return keys;
    }

    public override bool TryConvert(ConvertBinder binder, out object result)
    {
      return base.TryConvert(binder, out result);
    }
  }
}
