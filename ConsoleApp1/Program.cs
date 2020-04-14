using Newtonsoft.Json;
using zfjz.mft.v.Code.player;
using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader r = new StreamReader(@"C:\temp\dev\Native.Framework\ConsoleApp1\1.json");
            Player p = JsonConvert.DeserializeObject<Player>(r.ReadToEnd());
            //p.Package.AddOne("你好");
            //Console.WriteLine(JsonConvert.SerializeObject(p));
           
        }

      
    }
}
