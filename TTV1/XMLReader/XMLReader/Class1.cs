using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*наши библиотеки*/
using System.IO;
using System.Data;

namespace XMLReader
{
    public class DBXML
    {
        //директория где будут создаваться файлы таблиц
        public string PatchDir;
        //Функиця проверки существования таблици
        public bool ExistXMLTable(string NameTable)
        {
            //добавляем к имени таблицы расширение файла
            NameTable += ".xml";
            //если файл с таким именем существует значить таблица есть 
            if (File.Exists(PatchDir+"\\"+NameTable))
                return true; //таблица есть
            else
                return false; //таблицы нет 
        }
        //функция записи таблицы в XML формат
        public void SaveDataTableInXML(DataTable TableForSave)
        {
            //читаем имя таблицы
            string Name = TableForSave.TableName;

            //если имя таблицы не пустое то сохраняем данные 
            if (Name != "")
            {
                //добавляем к имени расширение xml 
                Name += ".xml";
                //собираем путь к директории
                Name = PatchDir + "\\" + Name;
                //создаем специальную переменную для преобразования данных из таблицы в XML формат 
                StringWriter writerXML = new StringWriter();
                //получаем данные о таблице и преобразуем их в XML формат 
                TableForSave.WriteXml(writerXML, XmlWriteMode.WriteSchema, true);
               //Сохраняем преобразованные в XML данные в файл
                File.WriteAllText(Name, writerXML.ToString());
            }
        }
        //Функция чтения таблицы из XML файла по ее миени
        public DataTable LoadDataTablefromXML(string NameTable)
        {
            //результат будем возвращать в виде таблицы
            DataTable ResultReadXML = null; //если не сможем загрузить ничего вернем Null
            //проверяем не пустое ли имя таблицы
            if (NameTable != "")
            {
                //создаем таблицу с указанным именем
                ResultReadXML = new DataTable(NameTable);
                //собираем имя тыблица из названия и расширения
                NameTable += ".xml";
                //собираем путь к директории
                NameTable = PatchDir + "\\" + NameTable;
                if (File.Exists(NameTable))
                {
                    //читаем данные из XML файла 
                    var stringReader = new StringReader(File.ReadAllText(NameTable));
                    //загружаем их в таблицу
                    ResultReadXML.ReadXml(stringReader);
                }
            }
            //возвращаме результат 
            return ResultReadXML;
        }
    }
}
