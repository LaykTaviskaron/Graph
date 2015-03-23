using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
	public class DFS
	{
		private List<string> visitedVertices;

		private string FindValue<T>(IAdjacencyList<T> adjacencyList, string startVertex, T value)
		{
			foreach (var child in adjacencyList.GetVertexEdges(startVertex))
			{
				if (visitedVertices.Contains(child.Name))
				{
					continue;
				}

				visitedVertices.Add(child.Name);

				if (value.Equals(child.Value))
				{
					return child.Name;
				}
				
				var result = FindValue<T>(adjacencyList, child.Name, value);
				
				if (result != null)
				{
					return result;
				}
			}

			return null;
		}

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

			visitedVertices = new List<string>();
			visitedVertices.Add(startVertex);

			return FindValue<T>(adjacencyList, startVertex, value);
		}
	}
}
