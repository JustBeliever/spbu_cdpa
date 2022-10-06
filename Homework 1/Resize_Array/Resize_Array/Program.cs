using System;

namespace Resize_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Array_Plus massiv = new Array_Plus(3);
            massiv[0] = 0;
            massiv[1] = 1;
            massiv[2] = 2;
            massiv.Add_To_End(3);
            massiv[5] = 5;
            massiv.Print_Array();
        }
    }
}
