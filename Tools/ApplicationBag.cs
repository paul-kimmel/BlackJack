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
using System.Web.Caching;
using System.Collections;
using System.Web.Hosting;

namespace Tools
{
  public class ApplicationBag : DynamicObject
  {

    private static readonly ApplicationBag current;
    static ApplicationBag()
    {
      current = new ApplicationBag();
    }

    public static dynamic Current
    {
      get { return current; }
    }

    private static Cache instance
    {
      get { return HostingEnvironment.Cache; } 
    }

    public static void Remove(string key)
    {
      instance.Remove(key);
    }

    public static void Clear()
    {
#if DEBUG
      List<string> keys = new List<string>();
      IDictionaryEnumerator enumerator = instance.GetEnumerator();

      while (enumerator.MoveNext())
        keys.Add(enumerator.Key.ToString());

      for (int i = 0; i < keys.Count; i++)
        instance.Remove(keys[i]);
#endif
    }

    public static void Add(string key, object value)
    {
      instance.Add(key, value, null, DateTime.Now.AddMinutes(15), TimeSpan.Zero, CacheItemPriority.Normal, null);        
    }


    public object this[string name]
    {
      get { 
        return instance == null ? null : instance[name]; 
      }
      set { instance[name] = value; }
    }

    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
      result = instance[binder.Name];
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
        result = instance[binder.Name];
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
      List<string> list = new List<string>();

      var e = instance.GetEnumerator();
      while (e.MoveNext())
        list.Add(e.Key.ToString());

      return list;
    }

    public override bool TryConvert(ConvertBinder binder, out object result)
    {
      return base.TryConvert(binder, out result);
    }
  }
}
