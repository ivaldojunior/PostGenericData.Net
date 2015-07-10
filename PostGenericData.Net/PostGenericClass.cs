using Newtonsoft.Json;
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
        string _URI { get; set; }

        public PostGenericClass(string URI)
        {
            _URI = URI;
        }

        private static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        public void Post<T>(object obj,ref string resul)
        {
            if (obj == null)
                return;

            var prop = obj.GetType().GetProperties();

            string param = "soft=postgenericClass.net";

            for (int i = 0; i < prop.Count(); i++)
            {
                param += "&" + prop[i].Name + "=" + GetPropValue(obj, prop[i].Name);
            }

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                resul = wc.UploadString(_URI, param);
                
            }

        }

        public async Task PostAsync<T>(object obj)
        {

            var prop = obj.GetType().GetProperties();
            string param = "soft=postgenericClass.net";

            for (int i = 0; i < prop.Count(); i++)
            {
                param += "&" + prop[i].Name + "=" + GetPropValue(obj, prop[i].Name);
            }

            using (WebClient wc = new WebClient())
            {
                Uri u = new Uri(_URI);
                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                wc.UploadStringAsync(u, param);
            }

        }

        public void PostJson<T>(object obj, ref string resul)
        {
            if (obj == null)
                return;

            var json = JsonConvert.SerializeObject(obj);

            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                resul = wc.UploadString(_URI, "POST", json);
            }
       }

        public void PostJsonAsync<T>(object obj)
        {
            if (obj == null)
                return;

            var json = JsonConvert.SerializeObject(obj);
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                Uri u = new Uri(_URI);
                wc.UploadStringAsync(u, "POST", json);
            }
        }

        public void PostJsonAndGetObject<T>(object obj, ref T resul)
        {
            if (obj == null)
                return;

            var json = JsonConvert.SerializeObject(obj);
            using (WebClient wc = new WebClient())
            {
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                var resul_tmp = wc.UploadString(_URI, "POST", json);
                resul = JsonConvert.DeserializeObject<T>(resul_tmp);
            }

        }

    }
}
