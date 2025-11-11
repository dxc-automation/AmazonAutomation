using AmazonAutomation.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonAutomation.Tests.Data
{
    public class Constants
    {
        public string BaseUrl { get; set; }
        public string TestDetails {  get; set; }
        public string TestName { get; set; }
        public string ProductTile {  get; set; }


        public void ReadTestData()
        {
            BaseUrl = ConfigReader.GetString("BaseUrl");
            ProductTile = ConfigReader.GetString("ProductTitle");
        }
     
    }
}
