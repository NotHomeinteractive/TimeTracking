using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XMLconfig;
using ADGet;
using XMLReader;

using System.Data;

namespace ServiceConsole
{
    class Program
    {
        //класс работы с файлом настроек 
        static ConfigClass MyConfig = new ConfigClass();
        //класс получения данных из AD
        static ADEngine MyADinformer = new ADEngine();
        //класс сохранения данных в таблицу
        static DBXML MyXMLTable = new DBXML();

        static void Main(string[] args)
        {
            //задаем путь к директории куда будет сохраняться файл с информацией из АД
            MyXMLTable.PatchDir = ".";
            //находим все данные по пользователях 
            MyADinformer.GetAdUserInfo();
            //получаем сведения о пользователях
            DataTable AD = MyADinformer.ADSearchResult;
            //сохраняем данные в XML 
            MyXMLTable.SaveDataTableInXML(AD);

            int A = 0;
        }
    }
}
