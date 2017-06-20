using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;

namespace Console_CS2PHP
{

    class Program
    {
        static void Pause()
        {
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
        static void Main(string[] args)
        {
            string url = "http://localhost:8080/showpostdata.php";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            //request.CookieContainer = cc;

            string firstname = "晅晢"; //用戶名
            string lastname = "廖"; //密碼
            string data = "firstname=" + HttpUtility.UrlEncode(firstname) + "&lastname=" + HttpUtility.UrlEncode(lastname);
            request.ContentLength = data.Length;

            StreamWriter writer = new StreamWriter(request.GetRequestStream(), Encoding.ASCII);
            writer.Write(data);
            writer.Flush();

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string encoding = response.ContentEncoding;
            if (encoding == null || encoding.Length < 1)
            {
                encoding = "UTF-8"; //預設編碼
            }

            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encoding));
            data = reader.ReadToEnd();
            //cc = request.CookieContainer;
            response.Close();

            Console.WriteLine(data);
            Pause();
        }
    }
}
