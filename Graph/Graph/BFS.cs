using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
	public class BFS
	{
		private List<string> visitedVertices;

		private Queue<string> detectedVertices;

		public string Find<T>(IAdjacencyList<T> adjacencyList, string startVertex, T value)
		{
			if (adjacencyList == null)
			{
				throw new ArgumentNullException("adjacencyList");
			}

			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			if (!adjacencyList.HasVertex(startVertex))
			{
				throw new ArgumentException("There is no such vertex in the list");
			}

			if (value.Equals(adjacencyList.GetVertexValue(startVertex)))
			{
				return startVertex;
			}

			detectedVertices = new Queue<string>();
			visitedVertices = new List<string>();

			detectedVertices.Enqueue(startVertex);

			while (detectedVertices.Count != 0)
			{
				string vertexName = detectedVertices.Dequeue();

				visitedVertices.Add(vertexName);

				if (value.Equals(adjacencyList.GetVertexValue(vertexName)))
				{
					return vertexName;
				}

				foreach (var edge in adjacencyList.GetVertexEdges(vertexName))
				{
					if (!visitedVertices.Contains(edge.Name) && !detectedVertices.Contains(edge.Name))
					{
						detectedVertices.Enqueue(edge.Name);
					}
				}
			}

			return null;
		}
	}
}
