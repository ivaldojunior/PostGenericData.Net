using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PostGenericData.Net
{
    public class PostGenericClass
    {

        public void Post()
        {
            string URI = "http://localhost:10108";
            string myParameters = "param1=value1&param2=value2&param3=value3";

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                string HtmlResult = wc.UploadString(URI, myParameters);
                HtmlResult = HtmlResult.Replace(System.Environment.NewLine, string.Empty).Trim();
            }

        }
    }
}
