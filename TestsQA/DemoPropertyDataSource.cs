using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsQA
{
    public static class DemoPropertyDataSource
    {
        private static readonly List<Dictionary<string, object>> _data =
            new ExcelToDataTableHelper().GetDataByProperty("property1");           

        public static IEnumerable<Dictionary<string, object>> TestData
        {
            get { return _data; }
        }
    }
}
