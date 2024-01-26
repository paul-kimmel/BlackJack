﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
  public static class ListExtensions
  {
    public static bool IsNullOrEmpty<T>(this IList<T> list)
    {
      return list == null || list.Count == 0;
    }

    public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
    {
      return list == null || list.Count() == 0;
    }
  }
}
