using System;
using System.Collections.Generic;
using System.Text;

namespace Matrix_Multiplication
{
    public class File_Not_Exist_Exception:Exception
    {
        public File_Not_Exist_Exception()
        {
        }
    }
    public class File_Is_Empty_Exception : Exception
    {
        public File_Is_Empty_Exception()
        {
        }
    }

    public class It_is_not_Matrrix_Exception: Exception
    {
        public It_is_not_Matrrix_Exception()
        {
        }
    }

    public class Matrices_Can_Not_Be_Multiplied : Exception
    {
        public Matrices_Can_Not_Be_Multiplied()
        {
        }
    }
}
