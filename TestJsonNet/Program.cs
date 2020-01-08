using System;
using Newtonsoft.Json;

namespace TestJsonNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("USING NEWTONSOFT JSON.NET");
            Console.WriteLine("*************************\n");

            MyObject objExample = new MyObject();

            objExample.intData = 13;
            objExample.stringData = "Hey JJ!";
            objExample.decimalData = 7.13m;
            objExample.doubleData = 13.7;
            objExample.datetimeData = DateTime.Now;
            objExample.boolData = true;

            string resultJson = SerializeMyObject(objExample);

            Console.WriteLine("Json string result is> \n" + resultJson);

            string JsonMock = "{\"intData\":101,\"stringData\":\"This is a Json!\",\"decimalData\":104.7,\"doubleData\":105.1,\"datetimeData\":\"2021-02-13T23:59:00.1234567-06:00\",\"boolData\":false}";

            MyObject objMock = DeserializeJsonString(JsonMock);

            Console.WriteLine("Data object result is> \nINT: " + objMock.intData + " STRING: " + objMock.stringData + " DECIMAL: " + objMock.decimalData + " DOUBLE: " + objMock.doubleData + " DATETIME: " + objMock.datetimeData + " BOOL: " + objMock.boolData + "\n\n");

            Console.ReadKey();
        }

        private static string SerializeMyObject(MyObject myObject)
        {
            string outputString = JsonConvert.SerializeObject(myObject);
            return outputString;
        }

        private static MyObject DeserializeJsonString(string Json)
        {
            MyObject resultObj = JsonConvert.DeserializeObject<MyObject>(Json);
            return resultObj;
        }
    }
}
