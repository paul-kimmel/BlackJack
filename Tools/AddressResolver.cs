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
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
  public class AddressResolver
  {
    public string StreetAddress { get; set; }
    public string StreetNumber { get; set; }
    public string Route { get; set; }
    public string City { get; set; }
    public string Neighborhood { get; set; }
    public string Locality { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string PostalCode { get; set; }
    public string FormattedAddress { get; set; }
    public double Latitude{ get; set; }
    public double Longitude{ get; set; }

    public static AddressResolver Resolve(YahooAddress o)
    {
      var result = new AddressResolver();
      result.FormattedAddress = o.GetFormattedAddress();
      result.StreetNumber = o.Street;

      result.StreetAddress = $"{o.House} {o.Street}";
      result.City = o.City;
      result.State = o.State;
      result.PostalCode = o.PostalCode;
      result.Country = o.Country;
      result.Latitude = o.Coordinates.Latitude;
      result.Longitude = o.Coordinates.Longitude;

      return result;
    }


    public static AddressResolver Resolve(GoogleAddress o)
    {
      var result = new AddressResolver();
      result.FormattedAddress = o.GetFormattedAddress();
      result.StreetNumber = o.GetComponentString(GoogleAddressType.StreetNumber);
      result.Route = o.GetComponentString(GoogleAddressType.Route);

      result.ResolveAddress(o);
      result.ResolveCity(o);
      result.State = o.GetComponentString(GoogleAddressType.AdministrativeAreaLevel1);
      result.PostalCode = o.GetComponentString(GoogleAddressType.PostalCode);
      result.Country = o.GetComponentString(GoogleAddressType.Country);
      result.Latitude = o.GetLatitude();
      result.Longitude = o.GetLongitude();

      return result;
    }

    private void ResolveAddress(GoogleAddress o)
    {
      StreetAddress = string.Format("{0} {1}", o.GetComponentString(GoogleAddressType.StreetNumber), o.GetComponentString(GoogleAddressType.Route));
    }

    private void ResolveCity(GoogleAddress o)
    {
      Neighborhood = o.GetComponentString(GoogleAddressType.Neighborhood);
      Locality = o.GetComponentString(GoogleAddressType.Locality);
      City = ChooseCity(o.FormattedAddress, Locality, Neighborhood);
    }

    private string ChooseCity(string address, string Locality, string Neighborhood)
    {
      if (UseThisComponent(address, Neighborhood))
        return Neighborhood;
      else if (UseThisComponent(address, Locality))
        return Locality;
      else
        return string.IsNullOrEmpty(Locality) ? Neighborhood : Locality;
    }


    private bool UseThisComponent(string address, string value)
    {
      return string.IsNullOrEmpty(value) == false && address.Contains(value);
    }

  }
}
