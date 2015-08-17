using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using System.Data;
using System.Data.SqlClient;

using System.IO;

using XMLReader;
using XMLconfig;

namespace Info
{
    public partial class _Default : System.Web.UI.Page
    {

        protected DataTable CreateTable(DataRow[] Row )
        {
            /*создаем таблицу *******************************************************/
            //телефонный справочник 
            DataTable A = new DataTable("Telephone_dictyonary");
            //name 
            DataColumn Col = new DataColumn()
            {
                ColumnName = "ФИО",
                DataType   = System.Type.GetType("System.String")
            };
            A.Columns.Add(Col);
            
            //title
            Col = new DataColumn()
            {
                ColumnName = "Должность",
                DataType = System.Type.GetType("System.String")
            };
            A.Columns.Add(Col);

            //mail
            Col = new DataColumn()
            {
                ColumnName = "Почта",
                DataType = System.Type.GetType("System.String")
            };
            A.Columns.Add(Col);
            
            //telephonenumber
            Col = new DataColumn()
            {
                ColumnName = "Номер телефона",
                DataType = System.Type.GetType("System.String")
            };
            A.Columns.Add(Col);
           
           
            
            /*****************************************************************************/
            //грузим данные **************************************************************
            /*****************************************************************************/
            foreach (DataRow R in Row) 
            {
                DataRow Myrow = A.NewRow();

                Myrow["ФИО"] = Convert.ToString(R["name"]);
                Myrow["Должность"] = Convert.ToString(R["title"]);
                Myrow["Почта"] = "<a href=\"mailto:" + Convert.ToString(R["mail"]) + "\">" + Convert.ToString(R["mail"]) + "</a>";
                Myrow["Номер телефона"] = Convert.ToString(R["telephonenumber"]);

                A.Rows.Add(Myrow);
            }


            /*****************************************************************************/
            //грузим данные **************************************************************
            /*****************************************************************************/
            
            return A;
        }
        protected DataGrid MyGrid = new DataGrid();
        protected void getAdInfo(string OfficeName) 
        {
            //путь до папки с дампом боевая
            //string FilePatch = @"D:\www\bin";
            //разработка 
            string FilePatch = @"d:\WWW";
            //имя таблицы
            string FileName = "AD";
            //создаем объект чтения данных 
            DBXML GetDB = new DBXML();
            //указываем путь от куда брать данные 
            GetDB.PatchDir = FilePatch;
            //читсаем содержимое в таблицу
            DataTable ReadAD = GetDB.LoadDataTablefromXML(FileName);
            if(ReadAD.Rows.Count>0)
            //проверяем смогли ли мы прочесть данные
            if (ReadAD != null) 
            {
                //если все хорошо то фильтруем данные по наличию номера телефона в поле mail
                DataRow[] Result = null;
                switch (OfficeName)
                {
                    //нет фильтров тогда все 
                    case "":
                        Result = ReadAD.Select(@"telephonenumber<>'' 
                                                and telephonenumber<>'-' 
                                                and  mail<>''"
                                                , "name ASC"
                                                );

                        break;
                    //нет фильтров тогда все 
                    case "Головной офис":
                        Result = ReadAD.Select(@"telephonenumber<>'' 
                                                and telephonenumber<>'-' 
                                                and  mail<>''
                                                and company = 'Головной офис'"
                                                , "name ASC"
                                                );

                        break;
                    //нет фильтров тогда все 
                    case "ДО Хорошевский":
                        Result = ReadAD.Select(@"telephonenumber<>'' 
                                                and telephonenumber<>'-' 
                                                and  mail<>''
                                                and company = 'ДО Хорошевский'"
                                                , "name ASC"
                                                );

                        break;
                }
                
                ReadAD = CreateTable(Result);

                Result = null;
                //очищаем содержимое таблицы
                MyGrid = new DataGrid();

                //вешаем таблицу на страницу
                DataView ShowDataInWeb = new DataView(ReadAD);

                

                //грузим всю гадость на страницу потом отсеим че не нада 
                MyGrid.DataSource = ShowDataInWeb;
                MyGrid.CssClass = "PhoneTable";
               
                //загружаем данные в таблицу
                MyGrid.DataBind();
                this.Panel1.Controls.Clear();
                this.Panel1.Controls.Add(MyGrid);
            }

        }

       

        protected void Page_Load(object sender, EventArgs e)
        {
            //выполняем загрузку данных 1 раз при заходе на страницу
            if (!IsPostBack)
            {
                //по умолчанию загружаем список всех людей 
                getAdInfo("");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //оставляем только головной офис
            getAdInfo("Головной офис");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //оставляем только доп офис 
            getAdInfo("ДО Хорошевский");
        }
    }
}