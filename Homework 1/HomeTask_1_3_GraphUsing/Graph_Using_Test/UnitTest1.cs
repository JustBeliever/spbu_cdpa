using Microsoft.VisualStudio.TestTools.UnitTesting;
using HomeTask_1_3_GraphUsing;
using Matrix_Multiplication;
using QuickGraph;
using QuickGraph.Algorithms;
using System.Collections.Generic;
using System.IO;
using System;

namespace Graph_Using_Test
{
    [TestClass]
    public class UnitTest1
    {
        
        bool EdgeInGraph(IVertexAndEdgeListGraph<int, Edge<int>> graph, Edge<int> edge)
        {
            foreach (Edge<int> e in graph.Edges)
                if (e.Source == edge.Source && e.Target == edge.Target)
                    return true;
            return false;
        }
         TryFunc<int, IEnumerable<Edge<int>>> getTryGetPath(Matrix matrix)
        {
            (IVertexAndEdgeListGraph<int, Edge<int>> graph,
                Func<Edge<int>, double> edgeCost) = new Graph(matrix).GetResult();
            return graph.ShortestPathsDijkstra(edgeCost, 0);
        }
        [TestMethod]
        public void graphCreationTest()
        {

            
            int[,] array = new int[,] { { 1, 2, 3 }, { 0, 3, 0}, {3, 0, 1 } };
            


            Matrix matrix = new Matrix(array);
            (IVertexAndEdgeListGraph<int, Edge<int>> graph,
                      Func<Edge<int>, double> edgeCost) = new Graph(matrix).GetResult();
            for (int i = 0; i < matrix.number_of_lines; i++)
            {
                for (int j = 0; j < matrix.number_of_columns; j++)
                {
                    if (matrix.Current_Value(i,j) > 0)
                    {
                        Edge<int> edge = new Edge<int>(i, j);
                        Assert.IsTrue(EdgeInGraph(graph, edge) && edgeCost(edge) == matrix.Current_Value(i, j));
                    }
                    else
                        Assert.IsFalse(EdgeInGraph(graph, new Edge<int>(i, j)));
                }
            }
        }

        [TestMethod]
        public void PDFCreatorTest()
        {
            Matrix matrix = new Matrix(new int[,] { { 0, 1, 2, 3 },
                                                    { 1, 0, 1, 2 },
                                                    { 2, 1, 0, 4 },
                                                    { 3, 2, 4, 0 } });
            (IVertexAndEdgeListGraph<int, Edge<int>> graph,
                      Func<Edge<int>, double> edgeCost) = new Graph(matrix).GetResult();
            TryFunc<int, IEnumerable<Edge<int>>> tryGetPath = graph.ShortestPathsDijkstra(edgeCost, 0);
            DotCreator<int, Edge<int>> generator = new DotCreator<int, Edge<int>>(graph, tryGetPath);
            new PdfCreator(generator.CrateDotFile(), "test").CreatePDF();
            Assert.IsTrue(File.Exists("test.pdf"));
            File.Delete("test.pdf");
        }
        [TestMethod]
        public void OneVertexTest()
        {
            Matrix matrix = new Matrix(new int[,] { { -1 } });
            TryFunc<int, IEnumerable<Edge<int>>> tryGetPath = this.getTryGetPath(matrix);
            IEnumerable<Edge<int>> edges;
            Assert.IsFalse(tryGetPath(0, out edges));
        }
        [TestMethod]
        public void NoEdgesTest()
        {
           int[,]array = new int[,] {
                    {-1, -1, -1, -1, -1},
                     {-1, -1, -1, -1, -1},
                    {-1, -1, -1, -1, -1},
                    {-1, -1, -1, -1, -1},
                    {-1, -1, -1, -1, -1}
                };
            Matrix matrix = new Matrix(array);
               
            TryFunc<int, IEnumerable<Edge<int>>> tryGetPath = this.getTryGetPath(matrix);
            IEnumerable<Edge<int>> edges;
            for (int i = 0; i < 5; ++i)
                Assert.IsFalse(tryGetPath(i, out edges));
        }
    }
}
