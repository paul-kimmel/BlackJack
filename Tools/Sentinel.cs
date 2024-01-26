using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
  public class Sentinel
  {

    //Sentinel.ThrowIf<Exception>(Model.ApplicationContextID< 0, "No ApplicationContext Selected");
    public static void ThrowIf<T>(bool guard, string message) where T : Exception, new()
    {
      if (guard == false) throw (Exception)typeof(T).GetConstructor(new Type[] { message.GetType() })
          .Invoke(new object[] { message });
    }
  }
}
