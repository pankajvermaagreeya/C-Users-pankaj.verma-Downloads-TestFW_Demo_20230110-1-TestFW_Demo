using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFW_Demo.Model
{
    public class TestDataModel
    {
        public DemoModel DemoModel { get; set; }
        public MainPageModel MainPageModel { get; set; }
    }
    public class TestDataStructures
    {
        public TestDataModel TestDataModel { get; set; }
    }

    public class DemoModel
    {
        public string URL { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class MainPageModel
    {
        public string SearchInputValue { get; set; }
        public string Item { get; set; }
    }
}
