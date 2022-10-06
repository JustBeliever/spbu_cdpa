using System;
using System.Data;
using QuickGraph;
using QuickGraph.Algorithms;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using Matrix_Multiplication;



namespace HomeTask_1_3_GraphUsing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Начало работы");
           
            string path = Directory.GetCurrentDirectory();
            string filename = "matrix.txt";
            
            try
            {
                
                (IVertexAndEdgeListGraph<int, Edge<int>> graph,
                    Func<Edge<int>, double> edgeCost) = new Graph(filename).GetResult();

                TryFunc<int, IEnumerable<Edge<int>>> tryGetPath = graph.ShortestPathsDijkstra(edgeCost, 0);

                DotCreator<int, Edge<int>> generator = new DotCreator<int, Edge<int>>(graph, tryGetPath);
                new PdfCreator(generator.CrateDotFile(),"graph").CreatePDF();
            }
            catch (IndexOutOfRangeException exn)
            {
                Console.Error.WriteLine("Укажите путь к матрице смежности");
            }
            catch (Exception exn)
            {
                Console.Error.WriteLine(exn.Message);
            }
        }

        
    }
}
