using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CreateConfig
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigClass M = new ConfigClass();

           // M.AddParam("text1", "2");
            M.DelParam("text1");
            string[] A= M.GetParamList();

            foreach (string S in A) 
                Console.WriteLine(" key " + S +" Value " + M.GetParam(S));


            

            Console.ReadKey();
          
        }
    }
}
