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
        protected TextBox MyTextBox;
        protected void Page_Load(object sender, EventArgs e)
        {

            ADEngine AD = new ADEngine();
            AD.GetAdUserInfo();
        }

       
    }
}
/*
 protected void Button1_Click(object sender, EventArgs e)
        {

 Label testL = new Label()
            {
                Text = "Test Param"
            };

            TextBox MyTextBox = new TextBox()
            {
                Width = 500,
                ID = "Param1"
            };

            Button OK = new Button()
            {
                Text = "OK"
               
            };

            OK.Click += _Click;

            form1.Controls.Add(testL); form1.Controls.Add(MyTextBox); form1.Controls.Add(OK);
 *  protected void _Click(object sender, EventArgs e)
        {
            //находим на странице текстовое поле 
            TextBox StringSearch = (TextBox)form1.FindControl("Param1");


            //пробуем сохранить значения в файл конфигурации
            Configurator S = new Configurator();

          

           
        }
 * 
 * 
 * 
        }*/