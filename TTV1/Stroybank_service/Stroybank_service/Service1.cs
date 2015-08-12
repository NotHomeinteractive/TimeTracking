using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace Stroybank_service
{
    public partial class Service1 : ServiceBase
    {
        //класс отслеживания изменений в АД 
        Sniffer S = new Sniffer();

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            //при старте запускаем поток отслеживания 
            S.MyPotok.Start();

        }

        protected override void OnStop()
        {
            //останавливаем поток 
            S.MyPotok.Abort();

        }
    }
}
