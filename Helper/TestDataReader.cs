using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFW_Demo.Model;

namespace TestFW_Demo.Helper
{
    public class TestDataReader
    {
        public static string GetProjectRootDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return currentDirectory.Split(new char[] { 'b', 'i', 'n' })[0];
        }

        public static TestDataStructures GetTestDataJsonObject()
        {
            string path = Path.Combine(GetProjectRootDirectory(), "byagari.kumar", "source", "repos", "TestFW_Demo", "TestData","Demo.json");
            var jObject = File.ReadAllText(path);
            var myJsonConfig = JsonConvert.DeserializeObject<TestDataStructures>(jObject);
            return myJsonConfig;
        }
    }
}
