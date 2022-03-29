
using ConsoleApp;

try
{
    string path = @"TestData.json";
    if (!File.Exists(path))
    {
        Console.WriteLine("TestData.json is NOT FOUND.");
        return;
    }
    string jsonText = File.ReadAllText(path);

    Console.WriteLine("<<<<< DataContractJsonSerializor >>>>>");

    var dcjs = new UseDataContractJsonSerializor();
    var dcjsJsonData = dcjs.Read(jsonText);
    Console.WriteLine("Read Data =>");
    Console.WriteLine(dcjsJsonData?.ToString());
    var dcjsSerialize = dcjs.Serialize(dcjsJsonData ?? new UseDataContractJsonSerializor.JsonData());
    Console.WriteLine($"Serialize => ");
    Console.WriteLine(dcjsSerialize);

    Console.WriteLine();

    Console.WriteLine("<<<<< Newtonsoft.Json >>>>>");

    var jsnt = new UseJsonNet();
    var jsntJsonData = jsnt.Read(jsonText);
    Console.WriteLine("Read Data =>");
    Console.WriteLine(jsntJsonData?.ToString());
    var jsntSerialize = jsnt.Serialize(jsntJsonData ?? new UseJsonNet.JsonData());
    Console.WriteLine($"Serialize => ");
    Console.WriteLine(jsntSerialize);

    Console.WriteLine();

    Console.WriteLine("<<<<< System.Text.Json >>>>>");

    var stj = new UseSystemTextJson();
    var stjJsonData = stj.Read(jsonText);
    Console.WriteLine("Read Data =>");
    Console.WriteLine(stjJsonData?.ToString());
    var stjSerialize = stj.Serialize(stjJsonData ?? new UseSystemTextJson.JsonData());
    Console.WriteLine($"Serialize => ");
    Console.WriteLine(stjSerialize);

}
finally
{
    Console.WriteLine();
    Console.WriteLine("Press Any Key...");
    Console.ReadLine();
}

