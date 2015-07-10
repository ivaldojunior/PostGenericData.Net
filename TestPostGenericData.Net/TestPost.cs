using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostGenericData.Net;

namespace TestPostGenericData.Net
{
    [TestClass]
    public class TestPost
    {
        [TestMethod]
        public void Test1()
        {
            Example c = new Example() { name = "Jack", age = 26 };
            PostGenericClass p = new PostGenericClass("http://localhost:10108/");
            string resul = string.Empty;
            p.Post<Example>(c,ref resul);

            resul = resul.Replace(System.Environment.NewLine, string.Empty).Trim();

        }

    }


    public class Example
    {
        public string name { get; set; }
        public int age { get; set; }
    }


}
