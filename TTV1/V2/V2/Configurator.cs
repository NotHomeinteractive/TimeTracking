using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
//класс для работы с файлом конфигурации
namespace V2
{
    public class Configurator
    {
        //класс получает значение параметра для настройки
        public string GetAppSeting(string Name) 
        {
            return ConfigurationManager.AppSettings[Name];
        }

        //класс задает указанному параметру указанную настройку 
        public void SetAppSetting(string ParamName, string ValueParam)
        {
            ConfigurationManager.AppSettings.Set(ParamName, ValueParam);
        }

    }
}