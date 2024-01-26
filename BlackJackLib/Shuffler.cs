//    Copyright (c) 2004 Software Conceptions, Inc.  All rights reserved.
//    Written by Paul Kimmel. pkimmel@softconcepts.com
//   
//    You must not remove this notice, or any other, from this software.
//   

using System;
using System.Collections;

namespace Softconcepts.BlackJackLib
{
  public struct Shuffler
  {
    public int random;
    public int key;

    public static Shuffler[] GetArray()
    {
      return GetArray(52);
    }
    
    public static Shuffler[] GetArray(int size)
    {
      Shuffler[] shuffler = new Shuffler[size];
      Random r = new Random();
      for( int i=0; i<shuffler.GetLength(0); i++)
      {
        shuffler[i].key = i;
        shuffler[i].random = r.Next();
      }

      Array.Sort(shuffler, new Comparer());
      return shuffler;
    }

    private class Comparer : IComparer 
    {
      public int Compare(object x, object y)
      {
        return Compare((Shuffler)x, (Shuffler)y);
      }
      
      private int Compare(Shuffler lhs, Shuffler rhs)
      {
        if( lhs.random > rhs.random )
          return 1;
        else if( lhs.random < rhs.random )
          return -1;
        else
          return 0;        
      }
    }
  }
}
