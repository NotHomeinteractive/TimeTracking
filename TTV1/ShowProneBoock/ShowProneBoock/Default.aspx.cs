using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

namespace ShowProneBoock
{
    public partial class _Default : System.Web.UI.Page
    {
        //класс работы с файлом настроек 
        protected ConfigClass MyConfig = new ConfigClass();
        //класс сохранения данных в таблицу
        protected DBXML MyXMLTable = new DBXML();

        protected void ADDColumnsToConfig() 
        { 
            //string{} Eval={"displayname","mail","title","company","telephonenumber"};
            
            MyConfig.AddParam("displayname","ФИО");
            MyConfig.AddParam("title","Должность");
            MyConfig.AddParam("telephonenumber","Телефон");
            MyConfig.AddParam("mail","Почта");
            MyConfig.AddParam("company","Офис");

        }

        //читаем данные из таблицы
        protected void ReadTable() 
        {
            MyXMLTable.PatchDir = @"d:\WWW\";
            DataTable Dannie =  MyXMLTable.LoadDataTablefromXML("AD");
            int Y = 0;

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            ADDColumnsToConfig();
            //ReadTable();
        }
    }
}