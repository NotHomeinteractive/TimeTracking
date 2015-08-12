using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.DirectoryServices;
using System.Data;
using System.Collections;


namespace ADGet
{
    public class ADEngine
    {
        //сохраняем данные в этой таблице 
        public DataTable ADSearchResult = new DataTable();
        public bool BeginSerch = false;
        //получаем данные о всех пользователях 
        public void GetAdUserInfo()
        {
            BeginSerch = true;
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
            //находим все столбцы и создаем из них таблицу
            foreach (SearchResult searchResult in results)
            {
                //перебираем список столбцов
                ResultPropertyCollection Collumns = searchResult.Properties;
                foreach (DictionaryEntry PropertyNames in Collumns)
                {
                    //получаем имя столбца
                    string collumnName = PropertyNames.Key.ToString();
                    //заполняем колонки если таких нет в таблице
                    int FindColumns = ADSearchResult.Columns.IndexOf(collumnName);
                    //значит нет столбца добавляем его в таблицу 
                    if (FindColumns == -1)
                    {
                        //создаем новый столбец
                        DataColumn column = new DataColumn();
                        //в идеале получать типы данных но пока стринг ( 
                        column.DataType = System.Type.GetType("System.String");
                        //присваиваем столбцу имя
                        column.ColumnName = collumnName;
                        //записываем столбец в таблицу 
                        ADSearchResult.Columns.Add(column);
                    }
                }
            }

            //сохраняем все данные в потоке 
            foreach (SearchResult searchResult in results)
            {
                //добавляем запись в таблицу
                DataRow MyRow = ADSearchResult.NewRow();
                //пробегаемся по столцам таблицы
                foreach (DataColumn col in ADSearchResult.Columns)
                {
                    string getData = "";
                    //пробуем получить данные по столбцу
                    try
                    {
                        getData = Convert.ToString(searchResult.Properties[col.ColumnName][0]);
                    }
                    catch
                    {
                    }
                    finally
                    {
                        MyRow[col.ColumnName] = getData;
                    }
                }
                ADSearchResult.Rows.Add(MyRow);
            }


            BeginSerch = false;


        }
    }
}
