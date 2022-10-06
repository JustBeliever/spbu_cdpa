using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Matrix_Multiplication
{
  public  class Matrix
    {
        int[,] matrix;
       public int number_of_lines, number_of_columns;
        string[] textfromfile;
        string file_name;

        public Matrix()
        {

        }
        public Matrix(int[,] array)
        {
            this.matrix = array;
            number_of_lines = array.GetUpperBound(0);
            number_of_columns = array.GetUpperBound(1);
        }
        public void GetFileName(string name)
        {
            file_name = name;
        }
        public void ReadFile()
        {
            
            var path = Directory.GetCurrentDirectory() + "\\"+ file_name;
            
            
            if (!File.Exists(path))
            {
                throw new File_Not_Exist_Exception();
            }
            textfromfile = File.ReadAllLines(path);
            number_of_lines = textfromfile.Length;
            if (number_of_lines == 0)
            {
                throw new File_Is_Empty_Exception();
                
            }
            //Проверка одинаковое ли количество элементов в каждой строке
            for(int i=0;i<textfromfile.Length;i++)
            {
                string[] textfromline = textfromfile[i].Split(" ");
                int count_elements = textfromline.Length;
                if (i == 0)
                {
                    number_of_columns = count_elements;
                }
                if(i>0)
                {
                    if(count_elements!=number_of_columns)
                    {
                        throw new It_is_not_Matrrix_Exception();
                    }
                }
            }

            Create_Matrix();
        }

        private void Create_Matrix()
        {
            matrix = new int[number_of_lines,number_of_columns];
            for(int i=0;i<number_of_lines;i++)
            {
                string[] textfromline = textfromfile[i].Split(" ");
                for(int j=0;j<number_of_columns;j++)
                {
                    matrix[i,j] = Convert.ToInt32(textfromline[j]);
                }
            }
        }

        public Matrix Multiply(Matrix matrix2)
        { Matrix final_matrix = new Matrix();
            if(number_of_columns!=matrix2.number_of_lines)
            {
                throw new Matrices_Can_Not_Be_Multiplied();
            }
            final_matrix.matrix = new int[number_of_lines, matrix2.number_of_columns];
            final_matrix.number_of_lines = number_of_lines;
            final_matrix.number_of_columns = matrix2.number_of_columns;
            for (int i=0;i<number_of_lines;i++)
            {
                for(int k=0;k<matrix2.number_of_columns;k++)
                {
                    int current_item = 0;
                    for(int j=0;j<number_of_columns;j++)
                    {
                        current_item += matrix[i, j] * matrix2.matrix[j, k];
                    }
                    final_matrix.matrix[i, k] = current_item;
                }
            }
            return final_matrix;
        }

       

        public void Write_File(string file_name)
        {
            var path = Directory.GetCurrentDirectory() + "\\" + file_name;
            string text_to_file="";
            for (int i=0;i<number_of_lines;i++)
            {
                for(int j=0;j<number_of_columns;j++)
                {
                    if (j != 0) { text_to_file += " "; }
                    text_to_file += matrix[i, j];
                }
                if (i != (number_of_lines - 1))
                {
                    text_to_file += '\n';
                }
            }
            File.WriteAllText(path, text_to_file);
        }

       
        public int Current_Value(int i,int j)
        {
            return matrix[i,j];
        }



    }
}
