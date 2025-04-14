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
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Instructor { get; set; }
        public int StudentCount { get; set; }
        public double Rating { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Title: {Title}, Instructor: {Instructor}, Students: {StudentCount}, Rating: {Rating}";
        }
    }


}

