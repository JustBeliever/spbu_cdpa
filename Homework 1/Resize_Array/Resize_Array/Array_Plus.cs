using System;
using System.Collections.Generic;
using System.Text;

namespace Resize_Array
{
  public class Array_Plus
    {
        int[] array;
        int count_of_elements;

        public Array_Plus(int number_of_elements)
        {
            array = new int[number_of_elements];
            count_of_elements = number_of_elements;
        }

        public int this[int item_number]
        {
            get 
            {
                return array[item_number];
            }
            set 
            {
                if(item_number>=count_of_elements)
                {
                    Resize(item_number - count_of_elements + 1);
                }
                array[item_number] = value;
            }
        }

        private void Resize(int increase)
        {
            int[] array2 = new int[count_of_elements + increase];
            for(int i=0;i<count_of_elements;i++)
            {
                array2[i] = array[i];
            }
            array = array2;
            count_of_elements += increase;
        }

        public void Add_To_End(int Value)
        {
            Resize(1);
            array[count_of_elements - 1] = Value;
        }

        public void Print_Array()
        {
            for(int i=0;i<count_of_elements;i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
