using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;

// Prototype interface
public interface ICloneable<T>
{
    T Clone();
}

// Concrete prototype for data
[Serializable]
public class Data : ICloneable<Data>
{
    public string Name { get; set; }
    public int Value { get; set; }

    public Data Clone()
    {
        // Using deep copy for simplicity
        using (MemoryStream stream = new MemoryStream())
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Seek(0, SeekOrigin.Begin);
            return (Data)formatter.Deserialize(stream);
        }
    }
}

// Adapter interface
public interface IDataConverter
{
    string ConvertData(Data data);
}

// Adapter for CSV format
public class CsvDataConverter : IDataConverter
{
    public string ConvertData(Data data)
    {
        return $"{data.Name},{data.Value}";
    }
}

// Adapter for XML format
public class XmlDataConverter : IDataConverter
{
    public string ConvertData(Data data)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Data));
        using (StringWriter writer = new StringWriter())
        {
            serializer.Serialize(writer, data);
            return writer.ToString();
        }
    }
}

// Adapter for JSON format
public class JsonDataConverter : IDataConverter
{
    public string ConvertData(Data data)
    {
        return JsonConvert.SerializeObject(data);
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter data name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter data value:");
        int value = int.Parse(Console.ReadLine());

        Data originalData = new Data { Name = name, Value = value };

        Console.WriteLine("Enter the output format (CSV, XML, JSON):");
        string outputFormat = Console.ReadLine().ToUpper();

        IDataConverter dataConverter;
        switch (outputFormat)
        {
            case "CSV":
                dataConverter = new CsvDataConverter();
                break;
            case "XML":
                dataConverter = new XmlDataConverter();
                break;
            case "JSON":
                dataConverter = new JsonDataConverter();
                break;
            default:
                throw new ArgumentException("Invalid output format");
        }

        string convertedData = dataConverter.ConvertData(originalData);
        Console.WriteLine($"Converted data in {outputFormat} format:\n{convertedData}");

        // Prototype usage
        Data clonedData = originalData.Clone();
        Console.WriteLine($"Cloned data:\nName: {clonedData.Name}, Value: {clonedData.Value}");
    }
}
