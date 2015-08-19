using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace PhoneBookConfigurator
{
    public struct Params
    {
        public string NameParams;
        public string ValueParams;
    };


    public class configFilds
    {
        [XmlElement()]
        public List<Params> Parametrs = new List<Params>();

        public void DeleteParam(string NameParams)
        {
            //сохраняем значение во временном буфере
            List<Params> tmpParametrs = Parametrs;
            //очищаем все параметры 
            Parametrs.Clear();
            //перебираем параметры по 1 
            foreach (Params A in tmpParametrs)
                //если параметр не равен то добавляем его в список 
                if (!string.Equals(A.NameParams, NameParams))
                {
                    Parametrs.Add(A);
                }
        }

        //находим есть ли такой параметр в конфигурации
        public bool FindParam(string NameParams)
        {
            //считаем что параметр не найден 
            bool Find = false;
            foreach (Params SelectParam in Parametrs)
            {
                //сравниваем строки на равенство
                if (string.Equals(SelectParam.NameParams, NameParams))
                {
                    //если нашли строки то возвращаем правду
                    Find = true;
                    //останавливаем цикл поиска все найдено 
                    break;
                }

            }
            return Find;
        }

        //находим номер параметра по номеру
        public int GetIndex(string NameParams)
        {
            int index = -1;
            //если параметр существет ищем его номер 
            if (FindParam(NameParams))
            {
                foreach (Params SelectParam in Parametrs)
                {
                    index++;
                    //сравниваем строки на равенство
                    if (string.Equals(SelectParam.NameParams, NameParams)) break;

                }
            }
            return index;
        }
    }

    public class ConfigClass
    {
        //путь сохранения файла настроек
        public string DirPatchFile = ".",
                      ConfigFileName = "config.xml";

        //класс хранящий список параметров
        configFilds MyParams = new configFilds();

        //создаем класс сохранения данных
        XmlSerializer s = new XmlSerializer(typeof(configFilds));

        public void DelParam(string NameParams)
        {
            //перед добавлением проверим что там уже что то есть 
            loadParam();
            //удаляем значение
            MyParams.DeleteParam(NameParams);
            //сохраняем результат 
            SaveParam();
        }

        //получаем список названий параметров которые храняться в файле
        public string[] GetParamList()
        {
            //перед добавлением проверим что там уже что то есть 
            loadParam();
            //загружаем список параметров в виде строки
            int Len = MyParams.Parametrs.Count;
            //создаем текстовый массив
            string[] Result = new string[Len];
            //загружаем в него значения
            for (int I = 0; I < Len; I++) Result[I] = MyParams.Parametrs[I].NameParams;
            //возвращаем все что нашли 
            return Result;
        }

        public string GetParam(string NameParams)
        {
            //перед добавлением проверим что там уже что то есть 
            loadParam();
            //получаем номер параметра 
            int Index_ = MyParams.GetIndex(NameParams);
            //сохранять будем значения тут 
            string Result = "";
            //если параметр найден заполняем значение
            if (Index_ != -1)
            {
                Result = MyParams.Parametrs[Index_].ValueParams;
            }
            //возвращаем значение 
            return Result;
        }


        public void AddParam(string NameParams, string ValueParams)
        {
            //создаем структуру
            Params buf;
            //заполняем структуру значениями 
            buf.NameParams = NameParams;
            buf.ValueParams = ValueParams;
            //перед добавлением проверим что там уже что то есть 
            loadParam();
            //если параметр найден то просто меняем в нем значение
            if (MyParams.FindParam(NameParams))
            {
                int Index_ = MyParams.GetIndex(NameParams);
                //переписываем параметр 
                MyParams.Parametrs[Index_] = buf;

            }
            else
            {
                //если параметра нет добавляем его к списку 
                MyParams.Parametrs.Add(buf);
            }


            //сохраняем значение
            SaveParam();
        }

        void loadParam()
        {
            if (File.Exists(DirPatchFile + "\\" + ConfigFileName))
            {
                //если файла настройки нет то создаем его заново
                var stringReader = new StringReader(File.ReadAllText(DirPatchFile + "\\" + ConfigFileName));
                MyParams = s.Deserialize(stringReader) as configFilds;
            }
        }


        //добавляем параметр в файл
        void SaveParam()
        {
            //создаем поток записи в файл
            StringWriter stringWriter = new StringWriter();
            //записываем данные 
            s.Serialize(stringWriter, MyParams);
            //сохраняем данные в виде строки текста
            string xml = stringWriter.ToString();
            //записываем данные в файл
            File.WriteAllText(DirPatchFile + "\\" + ConfigFileName, xml);

        }
    }
}
