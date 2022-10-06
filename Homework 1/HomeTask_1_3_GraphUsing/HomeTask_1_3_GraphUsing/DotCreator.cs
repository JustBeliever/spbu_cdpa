using System;
using System.Collections.Generic;
using System.Text;
using QuickGraph;
using QuickGraph.Algorithms;

namespace HomeTask_1_3_GraphUsing
{
    public class DotCreator<TVertex, TEdge> where TEdge : IEdge<TVertex>
    {
         IVertexAndEdgeListGraph<TVertex, TEdge> graph;
         TryFunc<TVertex, IEnumerable<TEdge>> tryGetPath;
         string dotfile;
        public DotCreator(IVertexAndEdgeListGraph<TVertex, TEdge> graph, TryFunc<TVertex, IEnumerable<TEdge>> tryGetPath)
        {
            this.graph = graph;
            this.tryGetPath = tryGetPath;
            this.dotfile = null;
        }

        public string CrateDotFile()
        {
            if (this.dotfile != null)
                return this.dotfile;
            HashSet<TEdge> shortestTree = new HashSet<TEdge>();
            IEnumerable<TEdge> edges;
            foreach (TVertex vertex in this.graph.Vertices)
                if (this.tryGetPath(vertex, out edges))
                    shortestTree.UnionWith(edges);
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("digraph G {");
            foreach (TVertex vertex in this.graph.Vertices)
            {
                builder.Append(vertex.ToString());
                builder.AppendLine(";");
            }
            foreach (TEdge edge in this.graph.Edges)
            {
                builder.Append(edge.ToString());
                if (shortestTree.Contains(edge))
                    builder.AppendLine(" [color = red];");
                else
                    builder.AppendLine(" [];");
            }
            builder.AppendLine("}");
            this.dotfile = builder.ToString();
            return this.CrateDotFile();
        }
    }
}
