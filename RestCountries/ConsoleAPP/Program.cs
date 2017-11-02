using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
namespace ConsoleAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader oSr = new StreamReader("countries.json");
            string sJson = "";
            using (oSr)
            {
                sJson = oSr.ReadToEnd();
            }
            JObject oJson = JObject.Parse(sJson);
            var oCountries = oJson["countries"].ToList();
            List<countries> lCountries = new List<countries>();
            for(int i = 0;i < oCountries.Count; i++)
            {
                lCountries.Add(new countries
                {
                    sCode = (string)oCountries[i]["alpha2code"],
                    sName = (string)oCountries[i]["name"],
                    sCapital = (string)oCountries[i]["capital"],
                    Population = (int)oCountries[i]["population"],
                    fArea = (float)oCountries[i]["area"]
                });
                /*Console.WriteLine(lCountries[i].sCode + ' ' + lCountries[i].sName + ' ' + lCountries[i].sCapital + ' ' + lCountries[i].Population + ' ' + lCountries[i].fArea);*/              
            }
            var EqualQuery = from c in lCountries.OrderBy(o => o.sName) where c.sName == "Afghanistan" select c;
            List<countries> lFilteredCountries = EqualQuery.ToList();
            for(int i = 0; i < oCountries.Count; i++)
            {
                Console.WriteLine(lFilteredCountries[i].sCode + ' ' + lFilteredCountries[i].sName + ' ' + lFilteredCountries[i].sCapital + ' ' + lFilteredCountries[i].Population + ' ' + lFilteredCountries[i].fArea);
            }
            Console.ReadKey();
        }
    }  
}
