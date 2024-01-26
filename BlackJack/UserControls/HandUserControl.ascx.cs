using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_HandUserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public string ImageUrl{
      get{
        return Image1.ImageUrl;
      }
      set{
        Image1.ImageUrl = value;
      }
    }
    public bool IsDealer{ get; set; }
}