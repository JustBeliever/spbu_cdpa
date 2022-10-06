using System;
using System.Collections.Generic;
using System.Text;
using Matrix_Multiplication;
using QuickGraph;



namespace HomeTask_1_3_GraphUsing
{
    public class Graph
    {
        private ArrayAdjacencyGraph<int, Edge<int>> graph;
        private Func<Edge<int>, double> edgeCost;
        Matrix matrix = new Matrix();


        
        
        
        public Graph(string filename)
        {
            matrix.GetFileName(filename);
            matrix.ReadFile();
        }
        public Graph(Matrix matrix)
        {
            if (matrix.number_of_columns != matrix.number_of_lines)
                throw new ArgumentException("Матрица должна быть квадратной");
            this.matrix = matrix;
            graph = null;
            edgeCost = null;
        }
        public (IVertexAndEdgeListGraph<int, Edge<int>>, Func<Edge<int>, double>) GetResult()
        {
           
            if (this.graph != null)
                return (this.graph, this.edgeCost);
            AdjacencyGraph<int, Edge<int>> graph = new AdjacencyGraph<int, Edge<int>>();
            
            for (int i = 0; i < this.matrix.number_of_lines; i++)
                for (int j = 0; j < this.matrix.number_of_columns;j++)
                    if (matrix.Current_Value(i,j) > 0)
                        graph.AddVerticesAndEdge(new Edge<int>(i, j));
            
            this.edgeCost = edge => matrix.Current_Value(edge.Source,edge.Target);
            this.graph = new ArrayAdjacencyGraph<int, Edge<int>>(graph);
            return this.GetResult();
        }
        
       
    }
}
