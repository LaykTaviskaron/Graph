using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
	public class UndirectedAdjacencyMatrix : IAdjacencyMatrix
	{
		private bool[][] _matrix;

		public UndirectedAdjacencyMatrix(int verticesNumber)
		{
			if (verticesNumber < 1)
			{
				throw new ArgumentException("Invalid vertices number");
			}

			VerticesCount = verticesNumber;
			_matrix = new bool[verticesNumber][];

			for (int i = 0; i < verticesNumber; i++)
			{
				_matrix[i] = new bool[verticesNumber];
			}
		}
		
		public UndirectedAdjacencyMatrix(int verticesNumber, bool[][] edges)
		{
			if (edges == null)
			{
				throw new ArgumentNullException("edges");
			}

			for (int i = 0; i < edges.Length; i++)
			{
				if (edges[i] == null)
				{
					throw new ArgumentNullException("edges[" + i + "]");
				}
			}

			if (verticesNumber < 1)
			{
				throw new ArgumentException("Invalid vertices number");
			}

			if (edges.Count() != verticesNumber)
			{
				throw new ArgumentException("Invalid matrix size");
			}

			for (int i = 0; i < verticesNumber; i++)
			{
				if (edges[i].Count() != verticesNumber)
				{
					throw new ArgumentException("Invalid matrix size");
				}

				for (int j = 0; j < verticesNumber; j++)
				{
					if (edges[i][j] != edges[j][i])
					{
						throw new ArgumentException("Invalid matrix: "
							+ "this is not a model of an undirected graph");
					}
				}
			}

			VerticesCount = verticesNumber;
			_matrix = edges;
		}


		public int VerticesCount { get; private set; }

		public bool[][] Matrix
		{
			get 
			{
				return _matrix; 
			}
		}

		private bool IsIndexValid(int index)
		{
			if (index >= VerticesCount || index < 0)
			{
				return false;
			}

			return true;
		}

		public void AddEdge(int rowIndex, int columnIndex)
		{
			if (!IsIndexValid(rowIndex))
			{
				throw new ArgumentException("Invalid row index");
			}

			if (!IsIndexValid(columnIndex))
			{
				throw new ArgumentException("Invalid coloumn index");
			}

			if (_matrix[rowIndex][columnIndex] == true)
			{
				throw new ArgumentException("The edge between such vertices already exists");
			}

			_matrix[rowIndex][columnIndex] = true;
			_matrix[columnIndex][rowIndex] = true;
		}

		public void RemoveEdge(int rowIndex, int columnIndex)
		{
			if (!IsIndexValid(rowIndex))
			{
				throw new ArgumentException("Invalid row index");
			}

			if (!IsIndexValid(columnIndex))
			{
				throw new ArgumentException("Invalid col index");
			}

			if (_matrix[rowIndex][columnIndex] == false)
			{
				throw new ArgumentException("There is no edge between such vertices");
			}

			_matrix[rowIndex][columnIndex] = false;
			_matrix[columnIndex][rowIndex] = false;
		}
	}
}
