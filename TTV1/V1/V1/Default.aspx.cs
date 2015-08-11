using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.DirectoryServices;
using System.Data;
using System.Data.SqlClient;
using System.Collections;


namespace V1
{

    public partial class _Default : System.Web.UI.Page
    {
        
        //данные о пользователе
        protected DataTable UsersInfo = new DataTable("Users");
        protected DataGrid MyGrid = new DataGrid();

        protected void CreateCollumns(string Name)
        {
            DataColumn column = new DataColumn();
            //числовое поле
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = Name;
            //добавляем столбцец в таблицу
            UsersInfo.Columns.Add(column);


            
        }

        //буфер списка стобцов
        List<string> columnslist = new List<string>();
        protected void ADD(string name) 
        {
            //думаем что у нас нет такого столбца
            bool find = true;
            //ищем стобцец в списке 
            foreach (string col in columnslist) 
            {
                if (col == name)
                {
                    find = false;
                    break;
                }
            }
            //если не нашли добавляем 
            if (find) 
            {
                //сохраняем в буферс списка стобцов 
                columnslist.Add(name);
                //добавляем новый столбец
                CreateCollumns(name);

                
            }
            
        }

       

        protected void GetADInfo()
        {
            /*ссылка на АД в котороу будем искать */
            DirectoryEntry AD = new DirectoryEntry();
            /*запрос в АД */
            string QWRY = @"(&(objectCategory=person)(objectClass=user)(!userAccountControl:1.2.840.113556.1.4.803:=2))";
            //ищем все пользователе
            DirectorySearcher searchInAD = new DirectorySearcher(AD, QWRY);
            /*задаем нестандартный размер для страницы памяти куда будут выгружены результаты*/
            searchInAD.PageSize = 1001;
            //находим всех пользователей
            SearchResultCollection results = searchInAD.FindAll();

            /*читаем результат запроса */
            foreach (SearchResult searchResult in results)
            {
                //A= searchResult.Properties["name"][0] as string;
                ResultPropertyCollection S = searchResult.Properties;
                //заполняем колонки если таких нет в таблице
                foreach (DictionaryEntry PropertyNames in S) ADD(PropertyNames.Key.ToString());
                //заполняем значениями стобцы
                
            }

            foreach (SearchResult searchResult in results)
            {
                //A= searchResult.Properties["name"][0] as string;
                ResultPropertyCollection S = searchResult.Properties;
                //заполняем колонки если таких нет в таблице
                DataRow MyRow = UsersInfo.NewRow();
                foreach (DictionaryEntry PropertyNames in S)
                    MyRow[PropertyNames.Key.ToString()] = Convert.ToString(searchResult.Properties[PropertyNames.Key.ToString()][0]);
                UsersInfo.Rows.Add(MyRow);
            }

        
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //выполняем загрузку данных 1 раз 
            if (!IsPostBack)
            {
                GetADInfo();

                DataView ShowDataInWeb = new DataView(UsersInfo);
                //грузим всю гадость на страницу потом отсеим че не нада 
                MyGrid.DataSource = ShowDataInWeb;
                //загружаем данные в таблицу
                MyGrid.DataBind();
                //добавляем таблицу на экран 
                this.Controls.Add(MyGrid);
            }

            

            int a = 0;
        }
    }
}