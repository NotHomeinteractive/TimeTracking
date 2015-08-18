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

        protected string CreateTable(DataRow[] Row )
        {
            string HTML_TABLES = "";
            string Head = " <table width='100%'  border='1' cellspacing='0' cellpadding='0'> <tbody>@Content </tbody></table>";
            string TableHead = @"<tr>
                                    <th>N п.</th>
                                    <th>ФИО</th>
                                    <th>Должность</th>
                                    <th>Почта</th>
                                    <th>Номер телефона</th>
                                 </tr>";
            string TableRow = @"<tr><td>@number</td>
                                    <td>@name</td>
                                    <td>@title</td>
                                    <td>@mail</td>
                                    <td>@telephonenumber</td>
                                </tr>";
            //собераем данные в таблицу
            string ContentBuffer = TableHead;

            string tmp = TableRow;
            int RowList = 0;
            foreach (DataRow R in Row)
            {
                RowList++;
                //создаем данные для записи
                tmp = TableRow;
                //заменяем теги на данные 
                tmp = tmp.Replace("@number", Convert.ToString(RowList));
               tmp= tmp.Replace("@name", Convert.ToString(R["name"]));
               tmp = tmp.Replace("@title", Convert.ToString(R["title"]));
               tmp = tmp.Replace("@mail", "<a href=\"mailto:" + Convert.ToString(R["mail"]) + "\">" + Convert.ToString(R["mail"]) + "</a>");
               tmp = tmp.Replace("@telephonenumber", Convert.ToString(R["telephonenumber"]));
                //сохраняем данные в буфер
               ContentBuffer += tmp;
            }
            //загружаем данные в таблицу
            HTML_TABLES = Head.Replace("@Content", ContentBuffer);

            return HTML_TABLES;
        }
        protected DataGrid MyGrid = new DataGrid();
        protected DataTable LoadData() 
        {
            //получение ифнормаци из файла настроек
            ConfigClass cfg = new ConfigClass();
            //задаем путь где лежат настройки 
            cfg.DirPatchFile = @"c:\Windows\SysWOW64";
            //получаем данные из файла 
            //разработка 
            string FilePatch = cfg.GetParam("ConfigFilePutch");
            //имя таблицы
            string FileName = "AD";
            //создаем объект чтения данных 
            DBXML GetDB = new DBXML();
            //указываем путь от куда брать данные 
            GetDB.PatchDir = FilePatch;
            //читсаем содержимое в таблицу
            return GetDB.LoadDataTablefromXML(FileName);
        }

        protected void getAdInfo(string OfficeName) 
        {
            DataTable ReadAD = LoadData();
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
                
              

               

                tableContent.InnerHtml = CreateTable(Result);
                Result = null;
             
            }

        }

        protected void SearchData() 
        {
            if (TextBox1.Text != "")
            {

                string Phone = "", FIO = "", TITLE = "", MAIL = "";
                DataRow[] Result = null;
                //загружаем таблицу с даннми
                DataTable ReadAD = LoadData();
                //собираем значение для поиска данных 
                string Expression = "LIKE '%" + TextBox1.Text + "%'";
                //пробуем найти данные
                Result = ReadAD.Select(@"telephonenumber<>'' 
                                                and telephonenumber<>'-' 
                                                and  mail<>'' and " + "name " + Expression
                                               , "name ASC"
                                               );
                
                //собераем табличку по сотрудникам
                if (Result.Length > 0) FIO = CreateTable(Result);   
                //собераем табличку по должности 
                Result = ReadAD.Select(@"telephonenumber<>'' 
                                                and telephonenumber<>'-' 
                                                and  mail<>'' and " + "title " + Expression
                                              , "name ASC"
                                              );
                if (Result.Length > 0) TITLE = CreateTable(Result); 
                //собераем таблчку по почте 
                Result = ReadAD.Select(@"telephonenumber<>'' 
                                                and telephonenumber<>'-' 
                                                and  mail<>'' and " + "mail " + Expression
                                              , "name ASC"
                                              );
                if (Result.Length > 0) MAIL = CreateTable(Result); 

                //собераем таблицу по номеру телефона 
                //собераем таблчку по почте 
                Result = ReadAD.Select(@"telephonenumber<>'' 
                                                and telephonenumber<>'-' 
                                                and  mail<>'' and " + "telephonenumber " + Expression
                                              , "name ASC"
                                              );
                if (Result.Length > 0) Phone = CreateTable(Result);
                

                tableContent.InnerHtml = FIO + TITLE + MAIL + Phone;
            }
            else 
            {
                //по умолчанию загружаем список всех людей 
                getAdInfo("");
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //выполняем загрузку данных 1 раз при заходе на страницу
            if (!IsPostBack)
            {
                ImageButton1.ImageUrl = "~/img/GO.png";
                ImageButton2.ImageUrl = "~/img/DO1.png";
                ImageButton3.ImageUrl = "~/img/ALL_on.png";
                //по умолчанию загружаем список всех людей 
                getAdInfo("");
            }
        }

        //protected void Button1_Click(object sender, EventArgs e)
        //{
            
        //}

        //protected void Button2_Click(object sender, EventArgs e)
        //{
           
        //}

        //protected void Button4_Click(object sender, EventArgs e)
        //{
           
        //    //по умолчанию загружаем список всех людей 
        //    getAdInfo("");
        //}

        protected void Button3_Click(object sender, EventArgs e)
        {
            ImageButton1.ImageUrl = "~/img/GO.png";
            ImageButton2.ImageUrl = "~/img/DO1.png";
            ImageButton3.ImageUrl = "~/img/ALL.png";
            SearchData();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton1.ImageUrl = "~/img/GO_on.png";
            ImageButton2.ImageUrl = "~/img/DO1.png";
            ImageButton3.ImageUrl = "~/img/ALL.png";

            //оставляем только головной офис
            getAdInfo("Головной офис");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton1.ImageUrl = "~/img/GO.png";
            ImageButton2.ImageUrl = "~/img/DO1_on.png";
            ImageButton3.ImageUrl = "~/img/ALL.png";
            //оставляем только доп офис 
            getAdInfo("ДО Хорошевский");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton1.ImageUrl = "~/img/GO.png";
            ImageButton2.ImageUrl = "~/img/DO1.png";
            ImageButton3.ImageUrl = "~/img/ALL_on.png";
            //по умолчанию загружаем список всех людей 
            getAdInfo("");
        }
    }
}