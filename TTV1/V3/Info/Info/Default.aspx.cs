using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Data;
using System.Data.SqlClient;

using XMLReader;
using XMLconfig;

namespace Info
{
    public partial class _Default : System.Web.UI.Page
    {

        protected void getAdInfo() 
        {
            
        }

       

        protected void Page_Load(object sender, EventArgs e)
        {
            //выполняем загрузку данных 1 раз при заходе на страницу
            if (!IsPostBack)
            {
               
            }
        }
    }
}