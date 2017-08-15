using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestsQA
{
   public class XUnitTestCases
    {

        [Theory]
        //[InlineData("Hello",true)]
        //[InlineData("Test1",false)]
        //[InlineData("Test2",false)]
       
        public void SampleTestStrings(string strparam,bool expectedVal)
        {
            var strTocompare = new StringComparer("Hello");
            var actualVal = strTocompare.StringCompTest(strparam);
            Assert.Equal(expectedVal, actualVal);
        }

        [Fact]
        public void SampleTest2()
        {

        }
    }
}
