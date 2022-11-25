using CsvHelper;
using System.Linq;
using System.Globalization;
using System;
using System.IO;

using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using System.Xml.Serialization;
using Xml2CSharp;


//   "C:\Users\cameront\source\repos\readCSV\MOR (1).object"


namespace CSVReaderDemo2
{

    class program
    {
        static void Main(string[] args)
        {
            // this is the reader for the csv file 
            using (var streamReader = new StreamReader(@"C:\Users\cameront\source\repos\readCSV\Mobile App_Android2.csv"))
            {
                using (var csvReader = new CsvReader(streamReader,CultureInfo.InvariantCulture))
                {
                    // this references the classes in ordder to map the CSV to objects 
                    csvReader.Context.RegisterClassMap<CsvClassMap>();
                    var records = csvReader.GetRecords<AndrioidApp>().ToList();

                    // simple print to see 1st record description is working 
                    Console.WriteLine(records[1].Description);


                    // Please continue this if ststament for the final part of the project. if input is not null split the coloum ... then add the rest of code 
                    char[] spearator = { ':' };

                    if (records[1].Input != null)
                    {
                        Console.WriteLine("record not null");
                    }

                    var filepath = @"C:\Users\cameront\source\repos\readCSV\MOR.object";
                    XmlSerializer serializer = new XmlSerializer(typeof(Root));

                    using (FileStream fs = new FileStream(filepath,FileMode.Open))
                    {
                        var obj = (Root)serializer.Deserialize(fs);
                       // Console.WriteLine(obj.Page[1].);
                    }


                    string jsonformat = (
                      "{\r\n    " +
                       "\"testScriptName\": \"*AddThis*\"," +"\r\n" +
                       "\"moduleName\": \"*AddThis*\",\r\n" +
           "            \"objective\": \"*AddThis*\",\r\n" +
           "            \"testSteps\": [\r\n        {\r\n" +
           "            \"stepDescription\":"+ records[0].Description +"\r\n"+ // get from csv coloumn Description
           "            \"userAction\"" + records[0].Action +"\r\n"+           // get from csv coulun Action 
           "            \"isParameterized\": false,\r\n" +
           "            \"identifier\": \"*GetFromXML - ref (Use whichever one where 'value' is not empty)*\",\r\n" +
           "            \"identifierValue\": \"*GetFromXML - value (Use whichever one is not empty)*\",\r\n" +
           "            \"dataValue\": null,\r\n" +
           "            \"dataColumn\": \"\",\r\n" +
           "            \"isScreenshot\": true,\r\n" +
           "            \"index\": \"\",\r\n" +
           "            \"imageName\": \"\",\r\n" +
           "            \"isConditional\": false,\r\n" +
           "            \"stepNum\":" + records[0].Step +"\r\n" + // csv coloun steps 
           "            \"property\": \"text\" /*Depends on which attribute of the element you want*/,\r\n" +
           "            \"controlType\": \"WebElement\",\r\n" +
           "            \"dataViewAttribute\": \"text\",\r\n" +
           "            \"isDataColumn\": true\r\n        }\r\n    ]\r\n}");

                    System.IO.File.WriteAllText("JSONTemplate.json", jsonformat);
                     Console.WriteLine(jsonformat);

                }   

            }
            
        }

    }
    public class CsvClassMap : ClassMap<AndrioidApp>
    {
        public CsvClassMap()
        {
            Map(m => m.Step).Name("Step");
            Map(m => m.ObjectName).Name("ObjectName");
            Map(m => m.Description).Name("Description");
            Map(m => m.Action).Name("Action");
            Map(m => m.Input).Name("Input");
            Map(m => m.Condition).Name("Condition");
            Map(m => m.Reference).Name("Reference");

        }
    }

    public class AndrioidApp
    {
        
        public int Step { get; set; }
       
        public string ObjectName { get; set; }
         
        public string Description { get; set; }
       
        public string Action { get; set; }
        
        public string Input  { get; set; }
       
        public string Condition { get; set; }
       
        public string Reference { get; set; }
    }
}

