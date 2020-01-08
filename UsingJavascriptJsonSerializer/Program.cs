using System;
using System.Web.Script.Serialization;

namespace UsingJavascriptJsonSerializer
{
    class Program
    {
        private static JavaScriptSerializer jsSerializer = new JavaScriptSerializer();

        static void Main(string[] args)
        {
            Console.WriteLine("USING JAVASCRIPT JSON SERIALIZER");
            Console.WriteLine("********************************\n");

            MyObject objExample = new MyObject();

            objExample.intData = 13;
            objExample.stringData = "Hey JJ!";
            objExample.decimalData = 7.13m;
            objExample.doubleData = 13.7;
            objExample.datetimeData = DateTime.Now;
            objExample.boolData = true;

            Console.WriteLine("****** Serializing Object *******\n");

            string resultJson = SerializeMyObject(objExample);

            Console.WriteLine("Json string result is> \n" + resultJson + "\n");

            Console.WriteLine("***** Deserializing to Object******\n");

            string JsonMock = "{\"intData\":101,\"stringData\":\"This is a Json!\",\"decimalData\":104.7,\"doubleData\":105.1,\"datetimeData\":\"2021-02-13T23:59:00.1234567-06:00\",\"boolData\":false}";

            MyObject objMock = DeserializeJsonStringToObject(JsonMock);

            Console.WriteLine("Data object result is> \nINT: " + objMock.intData + " STRING: " + objMock.stringData + " DECIMAL: " + objMock.decimalData + " DOUBLE: " + objMock.doubleData + " DATETIME: " + objMock.datetimeData + " BOOL: " + objMock.boolData + "\n\n");

            Console.WriteLine("***** Dynamic Deserializing ******\n");

            string jsonFake = "{'intData':123,'stringData':'Json fake!','decimalData':91.3,'doubleData':95.1,'datetimeData':'2020-03-17T23:11:00.1234567-05:00','boolData':true}";

            MyObject objFake = DynamicDeserializeJsonString(jsonFake);

            Console.WriteLine("Data object result is> \nINT: " + objFake.intData + " STRING: " + objFake.stringData + " DECIMAL: " + objFake.decimalData + " DOUBLE: " + objFake.doubleData + " DATETIME: " + objFake.datetimeData + " BOOL: " + objFake.boolData + "\n\n");

            Console.ReadKey();

        }

        private static string SerializeMyObject(MyObject myObject)
        {
            // Serializing object to json data  
            string outputString = jsSerializer.Serialize(myObject);
            return outputString;
        }

        private static MyObject DeserializeJsonStringToObject(string Json)
        {
            // Deserializing json data to object
            MyObject resultObj = jsSerializer.Deserialize<MyObject>(Json);
            return resultObj;
        }

        private static MyObject DynamicDeserializeJsonString(string Json)
        {
            // Deserializing json whithout help of object class  
            MyObject mObj = new MyObject();

            dynamic jsonDeserialized = jsSerializer.Deserialize<dynamic>(Json);

            mObj.intData = Convert.ToInt32(jsonDeserialized["intData"]);
            mObj.stringData = Convert.ToString(jsonDeserialized["stringData"]);
            mObj.decimalData = Convert.ToDecimal(jsonDeserialized["decimalData"]);
            mObj.doubleData = Convert.ToDouble(jsonDeserialized["doubleData"]);
            mObj.datetimeData = Convert.ToDateTime(jsonDeserialized["datetimeData"]);
            mObj.boolData = Convert.ToBoolean(jsonDeserialized["boolData"]);

            return mObj;
        }

    }
}
