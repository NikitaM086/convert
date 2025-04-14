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
        public class CsvHandler
        {
            public static List<Course> Deserialize<T>(string filePath)
            {
                using var reader = new StreamReader(filePath);
                using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
                return csv.GetRecords<Course>().ToList();
            }

            public static void Serialize<T>(T data, string filePath)
            {
                using var writer = new StreamWriter(filePath);
                using var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture));
                csv.WriteRecords(data as IEnumerable<Course>);
            }
        }


    
}

