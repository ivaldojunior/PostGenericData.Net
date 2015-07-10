using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostGenericData.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TestPostGenericData.Net
{
    [TestClass]
    public class TestPost
    {
        string uri = "http://localhost:10108/";
        [TestMethod]
        public void Test1()
        {
            Example c = new Example() { name = "Jack", age = 26 };
            PostGenericClass p = new PostGenericClass(uri);
            string resul = string.Empty;
            p.Post<Example>(c,ref resul);
            resul = resul.Replace(System.Environment.NewLine, string.Empty).Trim();
        }


        [TestMethod]
        public void TestAsync1()
        {
            Example c = new Example() { name = "Jack", age = 26 };
            PostGenericClass p = new PostGenericClass(uri);
            List<Task> tasks = new List<Task>();
            tasks.Add(Task.Run(() => p.PostAsync<Example>(c)));
 
        }

        [TestMethod]
        public void TestJson1()
        {
            Example c = new Example() { name = "Jack", age = 26 };
            PostGenericClass p = new PostGenericClass(uri);
            string resul = string.Empty;
            p.PostJson<Example>(c, ref resul);
            resul = resul.Replace(System.Environment.NewLine, string.Empty).Trim();
        }


    }


    public class Example
    {
        public string name { get; set; }
        public int age { get; set; }
    }


}
