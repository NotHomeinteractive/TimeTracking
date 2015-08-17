﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading;

namespace Stroybank_service
{
    public class Sniffer
    {
        //класс работы с файлом настроек 
        static ConfigClass MyConfig = new ConfigClass();
        //класс получения данных из AD
        static ADEngine MyADinformer = new ADEngine();
        //класс сохранения данных в таблицу
        static DBXML MyXMLTable = new DBXML();
        static int StrToInt(string T)
        {
            //по умолчанию время задержки раз в минуту 
            int DeltaTime = 6000;
            //если данные есть то преобразуем их в число 
            if (T != "")
                try
                {
                    DeltaTime = Convert.ToInt32(T);
                    DeltaTime *= 1000;
                }
                catch
                {
                }
            return DeltaTime;
        }
        static void GetInfo()
        {
            //время запуска сервиса 
            DateTime N = new DateTime();

            MyConfig.AddParam("TimeStart", N.ToString());
            string Dir, times;
            
            while (true)
            {
                times = MyConfig.GetParam("Period_V_minutah");
                Dir = MyConfig.GetParam("ConfigFilePutch");
                if (Dir == "")
                    //ругаемся в лог потом 
                    Dir = ".";
                //путь к файлу конфигурации 
                MyConfig.DirPatchFile = Dir;
                //находим все данные по пользователях 
                MyADinformer.GetAdUserInfo();
                //получаем сведения о пользователях
                DataTable AD = MyADinformer.ADSearchResult;

                Console.WriteLine("записано " + AD.Rows.Count);
                //куда сохраняеться информация об АД 
                Dir = MyConfig.GetParam("FilePutch");
                if (Dir == "")
                    //ругаемся в лог потом 
                    Dir = ".";
                //задаем путь к директории куда будет сохраняться файл с информацией из АД
                MyXMLTable.PatchDir = Dir;
                //сохраняем данные в XML 
                MyXMLTable.SaveDataTableInXML(AD);
                //спим
                Thread.Sleep(StrToInt(times));
            }
        }
        public Thread MyPotok = new Thread(GetInfo);
    }
}