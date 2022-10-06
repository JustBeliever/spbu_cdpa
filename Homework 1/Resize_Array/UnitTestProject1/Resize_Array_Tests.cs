using Microsoft.VisualStudio.TestTools.UnitTesting;
using Resize_Array;

namespace Resize_Array_Tests
{
    [TestClass]
    public class Resize_Array_Tests
    {
        [TestMethod]
        


        public void Write_Ana_Read_Index_Test()
        {
            var array = new Array_Plus(5);
            array[3] = 12;
            int expected = 12;
            int actual = array[3];
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Add_To_End_Test()
        {
            var array = new Array_Plus(5);
            array.Add_To_End(3);
            int expected = 3;
            Assert.AreEqual(expected, array[5]);
        }
        [TestMethod]
        public void Write_Index_More_Array_Size_Test()
        {
            var array = new Array_Plus(5);
            array[8] = 4;
            int expected = 4;
            Assert.AreEqual(expected, array[8]);
        }
         
        
    }
}
