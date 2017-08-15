using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsQA
{
    public class StringComparer
    {
        public string InitialVal { get; set; }
        public StringComparer(string initialStr)
        {
            InitialVal = initialStr;
        }
        public bool StringCompTest(string val)
        {
            return string.Equals(InitialVal, val, StringComparison.OrdinalIgnoreCase);
        }
    }
}
