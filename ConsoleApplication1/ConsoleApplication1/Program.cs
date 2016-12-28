using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

           // Console.WriteLine("Hello world!");

            var doc = new HtmlDocument();

            doc.Load("test for now");


            Console.ReadLine();

        }
    }
}
