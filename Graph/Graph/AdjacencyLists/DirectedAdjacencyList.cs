using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
	public class DirectedAdjacencyList<T> : IAdjacencyList<T>
	{
		private List<AdjacencyListNode<T>> _vertices;

		public DirectedAdjacencyList()
		{
			_vertices = new List<AdjacencyListNode<T>>();
		}

		public DirectedAdjacencyList(string[][] graph)
		{
			if (graph == null)
			{
				throw new ArgumentNullException("graph");
			}

			for (int i = 0; i < graph.Length; i++)
			{
				if (graph[i] == null)
				{
					throw new ArgumentNullException(("graph[" + i + "]"));
				}
			}

			_vertices = new List<AdjacencyListNode<T>>();
			
			for (int i = 0; i < graph.Length; i++)
			{
				AddVertex(graph[i][0]);
			}

			for (int i = 0; i < graph.Length; i++)
			{
				for (int j = 1; j < graph[i].Length; j++)
				{
					if (!HasEdge(graph[i][0], graph[i][j]))
					{
						AddEdge(graph[i][0], graph[i][j]);
					}
				}
			}
		}

		public int Count
		{
			get
			{
				return _vertices.Count();
			}
		}

		public void RemoveEdge(string sourceName, string destinationName)
		{
			if (!HasEdge(sourceName, destinationName))
			{
				throw new ArgumentException("There is no edge between source and destination");
			}

			var destinationVertex = _vertices.Find(t => t.Name.Equals(destinationName));

			GetVertexEdges(sourceName).Remove(destinationVertex);
		}

		public void AddVertex(string name)
		{
			if (HasVertex(name))
			{
				throw new ArgumentException("Such vertex already exists");
			}

			_vertices.Add(new AdjacencyListNode<T>(name));
		}

		public void RemoveVertex(string name)
		{
			if (!HasVertex(name))
			{
				throw new ArgumentException("There is no such vertex");
			}

			foreach (var vertex in _vertices)
			{
				foreach (var edge in vertex.Edges)
				{
					if (edge.Name.Equals(name))
					{
						vertex.Edges.Remove(edge);
						break;
					}
				}
			}

			_vertices.Remove(_vertices.Find(n => n.Name.Equals(name)));
		}

		public List<AdjacencyListNode<T>> GetVertexEdges(string name)
		{
			if (!HasVertex(name))
			{
				throw new ArgumentException("There is no such vertex");
			}

			return _vertices.Find(n => n.Name.Equals(name)).Edges;
		}

		public bool HasEdge(string sourceName, string destinationName)
		{
			if (!HasVertex(sourceName))
			{
				throw new ArgumentException("There is no such sourse vertex");
			}

			if (!HasVertex(destinationName))
			{
				throw new ArgumentException("There is no such destination vertex");
			}

			var destinationVertex = _vertices.Find(n => n.Name.Equals(destinationName));
			var sourceVertex = _vertices.Find(t => t.Name.Equals(sourceName));

			return sourceVertex.Edges.Contains(destinationVertex);
		}

		public void AddEdge(string source, string destination)
		{
			if (HasEdge(source, destination))
			{
				throw new ArgumentException("This edge already exists");
			}

			var destinationVertex = _vertices.Find(n => n.Name.Equals(destination));

			GetVertexEdges(source).Add(destinationVertex);
		}

		public bool HasVertex(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}

			return _vertices.Exists(n => n.Name.Equals(name));
		}

		public bool[][] GetMatrix()
		{
			string[] names = GetVertices(); 

			bool[][] matrix = new bool[Count][];

			for (int k = 0; k < Count; k++)
			{
				matrix[k] = new bool[Count];
			}

			int i = 0;
			int j = 0;

			foreach (var item in _vertices)
			{
				foreach (var edge in item.Edges)
				{
					j = 0;
					for (int z = 0; z < Count; z++)
					{
						if (names[z].Equals(edge.Name))
						{
							matrix[i][j] = true;
						}
						j++;
					}
				}
				i++;
			}

			return matrix;
		}

		public string[] GetVertices()
		{
			if (Count == 0)
			{
				throw new InvalidOperationException("List is empty");
			}

			string[] names = new string[Count];

			int i = 0;
			foreach (var item in _vertices)
			{
				names[i++] = item.Name;
			}

			return names;
		}


		public void SetVertexValue(string name, T value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}

			if (!HasVertex(name))
			{
				throw new ArgumentException("There is no such vertex");
			}

			_vertices.Find(t => t.Name.Equals(name)).Value = value;
		}

		public T GetVertexValue(string name)
		{
			if (!HasVertex(name))
			{
				throw new ArgumentException("There is no such vertex");
			}

			return _vertices.Find(t => t.Name.Equals(name)).Value;
		}
	}
}
