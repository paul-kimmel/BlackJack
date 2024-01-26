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
using Geocoding.Google;
using Geocoding.Yahoo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
  public static class GoogleExtensions
  {
    public static string GetAddressLine1(this GoogleAddress o)
    {
      return string.Format("{0} {1}", o.GetStreetNumber(), o.GetRoute());
    }

    public static string GetAddressLine2(this GoogleAddress o)
    {
      return o.GetSubpremise();
    }

    public static string GetFormattedAddress(this GoogleAddress o)
    {
      return o.FormattedAddress;
    }

    public static string GetFormattedAddress(this YahooAddress o)
    {
      return o.FormattedAddress;
    }

    public static string GetStreetNumber(this GoogleAddress o)
    {
      return o.GetComponentString(GoogleAddressType.StreetNumber);
    }

    public static string GetRoute(this GoogleAddress o)
    {
      return o.GetComponentString(GoogleAddressType.Route);
    }

    public static string GetSubpremise(this GoogleAddress o)
    {
      return o.GetComponentString(GoogleAddressType.Subpremise);
    }

    public static string GetCity(this GoogleAddress o)
    {
      var s = o.GetComponentString(GoogleAddressType.Neighborhood);
      return string.IsNullOrEmpty(s) ? o.GetComponentString(GoogleAddressType.Locality) : s;
    }

    public static string GetCounty(this GoogleAddress o)
    {
      return o.GetComponentString(GoogleAddressType.AdministrativeAreaLevel2);
    }

    public static string GetState(this GoogleAddress o)
    {
      return o.GetComponentString(GoogleAddressType.AdministrativeAreaLevel1);
    }

    public static string GetPostalCode(this GoogleAddress o)
    {
      return o.GetComponentString(GoogleAddressType.PostalCode);
    }

    public static string GetComponentString(this GoogleAddress o, GoogleAddressType type)
    {
      try
      {
        switch (type)
        {
          case GoogleAddressType.AdministrativeAreaLevel2:
          case GoogleAddressType.AdministrativeAreaLevel1:
            return o.Components.First(x => x.Types.Length > 0 ? x.Types[0] == type : false).ShortName;

          default:
            return o.Components.First(x => x.Types.Length > 0 ? x.Types[0] == type : false).LongName;
        }

      }
      catch
      {
        return "";
      }
    }

    public static double GetLatitude(this GoogleAddress o)
    {
      return o.Coordinates.Latitude;
    }

    public static double GetLongitude(this GoogleAddress o)
    {
      return o.Coordinates.Longitude;
    }

  }
}

