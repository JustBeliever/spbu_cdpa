using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matrix_Multiplication;
using System.IO;
using System;
namespace Matrix_Multiplication_Tests
{
    [TestClass]
    public class Matrix_Multiplication_Tests
    {
        [TestMethod]
        public void Is_Matrix_Exist_Test()
        {
            Matrix matrix1 = new Matrix();
            matrix1.GetFileName("Input_F_Matrix.txt");
            Assert.ThrowsException<File_Not_Exist_Exception>(matrix1.ReadFile);
        }
        [TestMethod]
        public void Is_Matrix_Not_Empty_Test()
        {
            Matrix matrix1 = new Matrix();
            matrix1.GetFileName("Empty_Matrix_Test.txt");
            Assert.ThrowsException<File_Is_Empty_Exception>(matrix1.ReadFile);
        }
        [TestMethod]
        public void Is_It_Matrix_Test()
        {
            Matrix matrix1 = new Matrix();
            matrix1.GetFileName("It_Is_Not_Matrix_Test.txt");
            Assert.ThrowsException<It_is_not_Matrrix_Exception>(matrix1.ReadFile);
        }
        [TestMethod()]
        [ExpectedException (typeof(Matrices_Can_Not_Be_Multiplied))]
        public void Could_They_Been_Multiplied_Test()
        {
            
            Matrix matrix1 = new Matrix();
            Matrix matrix2 = new Matrix();
            matrix1.GetFileName("Matrix_Can_Not_Be_Multiplied_Test_1.txt");
            matrix2.GetFileName("Matrix_Can_Not_Be_Multiplied_Test_2.txt");
            matrix1.ReadFile();
            matrix2.ReadFile();
            matrix1.Multiply(matrix2);
        }
        [TestMethod]
        public void Multiplying_Test()
        {
            Matrix matrix1 = new Matrix();
            Matrix matrix2 = new Matrix();
            matrix1.GetFileName("Input_First_Matrix.txt");
            matrix1.ReadFile();
            matrix2.GetFileName("Input_Second_Matrix.txt");
            matrix2.ReadFile();
            Matrix final = matrix1.Multiply(matrix2);
            final.Write_File("Outpit_Final_Matrix.txt");
            string expected = "1 0" +'\n' +"0 1";
            string actual = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Matrix_Using\\" + "Outpit_Final_Matrix.txt");
            
            Assert.AreEqual(expected, actual);
        }
    }
}
