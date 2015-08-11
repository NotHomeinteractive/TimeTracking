using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace V2
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label testL = new Label()
            {
                Text = "Test Param"
            };

            TextBox MyTextBox = new TextBox()
            {
                Width = 500
            };

            Button OK = new Button()
            {
                Text = "OK"
            };

        }
    }
}