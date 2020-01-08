using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
// **************** DOCUMENTATION ***************** 
//
// Serializing and Deserializing https://www.newtonsoft.com/json/help/html/SerializingJSON.htm
// LINQ to JSON https://www.newtonsoft.com/json/help/html/LINQtoJSON.htm
// Creating JSON https://www.newtonsoft.com/json/help/html/CreatingLINQtoJSON.htm
// 

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

            Console.WriteLine("****** Serializing *******\n");

            string resultJson = SerializeMyObject(objExample);

            Console.WriteLine("Json string result is> \n" + resultJson + "\n");

            Console.WriteLine("***** Deserializing ******\n");

            string JsonMock = "{\"intData\":101,\"stringData\":\"This is a Json!\",\"decimalData\":104.7,\"doubleData\":105.1,\"datetimeData\":\"2021-02-13T23:59:00.1234567-06:00\",\"boolData\":false}";

            MyObject objMock = DeserializeJsonString(JsonMock);

            Console.WriteLine("Data object result is> \nINT: " + objMock.intData + " STRING: " + objMock.stringData + " DECIMAL: " + objMock.decimalData + " DOUBLE: " + objMock.doubleData + " DATETIME: " + objMock.datetimeData + " BOOL: " + objMock.boolData + "\n\n");

            Console.WriteLine("USING NEWTONSOFT.json.linq");
            Console.WriteLine("*************************\n");

            Console.WriteLine("****** Declarative *******\n");

            string resJsonLinq = CreateJsonWithLINQandJObjectDeclarative(objExample);
            Console.WriteLine("Json created is> \n" + resJsonLinq + "\n");

            Console.WriteLine("******* FromObject *******\n");

            string resObjJsonLinq = CreateJsonWithLINQandJObjectFromObject(objExample);
            Console.WriteLine("Json created is> \n" + resObjJsonLinq + "\n");

            Console.WriteLine("***** JObject.Parse ******\n");

            string jsonFake = "{'intData':123,'stringData':'Json fake!','decimalData':101.9, 'doubleData':103.9,'datetimeData':'2023-03-07T23:11:00.1234567-06:00','boolData':false}";
            MyObject objFake = CreateObjectWithLINQandJObject(jsonFake);

            Console.WriteLine("Data object result is> \nINT: " + objFake.intData + " STRING: " + objFake.stringData + " DECIMAL: " + objFake.decimalData + " DOUBLE: " + objFake.doubleData + " DATETIME: " + objFake.datetimeData + " BOOL: " + objFake.boolData + "\n\n");

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

        private static string CreateJsonWithLINQandJObjectDeclarative(MyObject myObject)
        {
            // Using Newtonsoft.Json.Linq;
            // Declaratively creating JSON objects using LINQ is a fast way to create JSON from collections of values.

            JObject jsonObject =
                                new JObject(
                                    new JProperty("iData", myObject.intData),
                                    new JProperty("strData", myObject.stringData),
                                    new JProperty("dmData", myObject.decimalData),
                                    new JProperty("ddData", myObject.doubleData),
                                    new JProperty("dtData", myObject.datetimeData),
                                    new JProperty("bData", myObject.boolData)
                                    );

            return jsonObject.ToString();
        }

        private static string CreateJsonWithLINQandJObjectFromObject(MyObject myObject)
        {
            // Using Newtonsoft.Json.Linq;
            // Internally, FromObject will use the JsonSerializer to serialize the object to LINQ to JSON objects instead of text.

            JObject jsonObject = JObject.FromObject(new
                {
                    iData = myObject.intData,
                    strData = myObject.stringData,
                    dmData = myObject.decimalData,
                    ddData = myObject.doubleData,
                    dtData = myObject.datetimeData,
                    bData = myObject.boolData
                });

            return jsonObject.ToString();
        }

        private static MyObject CreateObjectWithLINQandJObject(string myJson)
        {
            // Using Newtonsoft.Json.Linq;
            // LINQ to JSON is an API for working with JSON objects. It has been designed with LINQ in mind to enable quick querying and creation of JSON objects.

            MyObject mObj = new MyObject();

            JObject jsonParsed = JObject.Parse(myJson);
            
            mObj.intData = Convert.ToInt32(jsonParsed["intData"]);
            mObj.stringData = Convert.ToString(jsonParsed["stringData"]);
            mObj.decimalData = Convert.ToDecimal(jsonParsed["decimalData"]);
            mObj.doubleData = Convert.ToDouble(jsonParsed["doubleData"]);
            mObj.datetimeData = Convert.ToDateTime(jsonParsed["datetimeData"]);
            mObj.boolData = Convert.ToBoolean(jsonParsed["boolData"]);

            return mObj;
        }
    }
}
