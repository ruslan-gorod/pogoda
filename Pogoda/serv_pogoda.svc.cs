using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using System.Text.RegularExpressions;
using System.Net;
using System.IO;
using System.Xml;



namespace Pogoda
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "serv_pogoda" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select serv_pogoda.svc or serv_pogoda.svc.cs at the Solution Explorer and start debugging.
    public class serv_pogoda : IServ
    {
        public string GetData(string value)
        {
            Regex r = new Regex(@"...&deg;");
            HttpWebRequest hwr = (HttpWebRequest)HttpWebRequest.Create(@"http://meteo.ua/ua/archive/44/lvov/" + value);

            var resp = hwr.GetResponse();

            StreamReader sr = new StreamReader(resp.GetResponseStream(), Encoding.UTF8);

            string rez_reg = String.Empty;

            while (!sr.EndOfStream)
            {
                rez_reg += sr.ReadLine();
            }

            MatchCollection matCol = r.Matches(rez_reg);

            string s = String.Empty;
            for (int i = 0; i < 48; i++)
            {
                string test = matCol[i].ToString().Substring(0, matCol[i].ToString().Length - 5);
                s += test.Substring(test.IndexOf(">") + 1) + " ";
                //s += matCol[i].ToString().Substring(matCol[i].ToString().IndexOf(">")+1, matCol[i].ToString().Length - 5) + " ";
            }
                return s;
        }

    }
}
