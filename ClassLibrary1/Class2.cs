using System.Text.Json;
using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using System;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Linq;
using System.Formats.Asn1;

namespace cs
{
    public class FileManager
    {
        public static T ReadFromFile<T>(string filePath)
        {
            try
            {
                if (!File.Exists(filePath)) throw new FileNotFoundException("Файл не найден.");

                string extension = Path.GetExtension(filePath).ToLower();
                string content = File.ReadAllText(filePath);

                switch (extension)
                {
                    case ".json":
                        return JsonSerializer.Deserialize<T>(content);
                    case ".xml":
                        using (var reader = new StringReader(content))
                            return (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                    case ".yaml":
                    case ".yml":
                        var deserializer = new DeserializerBuilder()
                            .WithNamingConvention(CamelCaseNamingConvention.Instance)
                            .Build();
                        return deserializer.Deserialize<T>(content);
                    case ".csv":
                        return (T)(object)CsvHandler.Deserialize<List<Course>>(filePath);
                    default:
                        throw new NotSupportedException("Неподдерживаемый формат файла.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения файла: {ex.Message}");
                return default;
            }
        }




        public static void WriteToFile<T>(T data, string filePath)
        {
            try
            {
                string extension = Path.GetExtension(filePath).ToLower();
                string content = "";

                switch (extension)
                {
                    case ".json":
                        content = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                        break;
                    case ".xml":
                        using (var writer = new StringWriter())
                        {
                            new XmlSerializer(typeof(T)).Serialize(writer, data);
                            content = writer.ToString();
                        }
                        break;
                    case ".yaml":
                    case ".yml":
                        var serializer = new SerializerBuilder()
                            .WithNamingConvention(CamelCaseNamingConvention.Instance)
                            .Build();
                        content = serializer.Serialize(data);
                        break;
                    case ".csv":
                        CsvHandler.Serialize(data, filePath);
                        return;
                    default:
                        throw new NotSupportedException("Неподдерживаемый формат файла.");
                }

                File.WriteAllText(filePath, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка записи файла: {ex.Message}");
            }
        }
    }


}

