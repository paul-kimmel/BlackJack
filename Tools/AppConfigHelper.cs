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
using System.Configuration;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
  public class AppConfigHelper
  {
    public static string GetPickupFolder()
    {
      var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
      var settings = config.GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;

      return settings.Smtp.SpecifiedPickupDirectory.PickupDirectoryLocation;
    }

  }
}
