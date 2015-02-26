using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Graph
{
	class Program
	{
		static void Main(string[] args)
		{
			DirectedAdjacencyMatrix directedMatrix = new DirectedAdjacencyMatrix(5);

			directedMatrix.AddEdge(0, 2);
			directedMatrix.AddEdge(2, 2);
			directedMatrix.AddEdge(2, 4);
			directedMatrix.AddEdge(1, 3);

			ShowMatrix(directedMatrix.Matrix);

			UndirectedAdjacencyMatrix undirectedMatrix = new UndirectedAdjacencyMatrix(5);

			undirectedMatrix.AddEdge(0, 2);
			undirectedMatrix.AddEdge(2, 2);
			undirectedMatrix.AddEdge(2, 4);
			undirectedMatrix.AddEdge(1, 3);

			ShowMatrix(undirectedMatrix.Matrix);

			DirectedAdjacencyList<string> directedAdjacencyList = new DirectedAdjacencyList<string>();

			directedAdjacencyList.AddVertex("1");
			directedAdjacencyList.AddVertex("2");
			directedAdjacencyList.AddVertex("3");
			directedAdjacencyList.AddVertex("4");
			directedAdjacencyList.AddVertex("5");
			
			directedAdjacencyList.AddEdge("1", "1");
			directedAdjacencyList.AddEdge("2", "2");
			directedAdjacencyList.AddEdge("3", "3");
			directedAdjacencyList.AddEdge("4", "4");
			directedAdjacencyList.AddEdge("5", "5");

			ShowMatrix(directedAdjacencyList.GetMatrix());
			 
			UndirectedAdjacencyList<string> undirectedAdjacencyList = new UndirectedAdjacencyList<string>();

			undirectedAdjacencyList.AddVertex("1");
			undirectedAdjacencyList.AddVertex("2");
			undirectedAdjacencyList.AddVertex("3");
			undirectedAdjacencyList.AddVertex("4");
			undirectedAdjacencyList.AddVertex("5");
			undirectedAdjacencyList.AddVertex("6");
			undirectedAdjacencyList.AddVertex("7");
			undirectedAdjacencyList.AddVertex("8");
			undirectedAdjacencyList.AddVertex("9");
			undirectedAdjacencyList.AddVertex("10");
			
			undirectedAdjacencyList.AddEdge("1", "2");
			undirectedAdjacencyList.AddEdge("1", "3");
			undirectedAdjacencyList.AddEdge("1", "4");

			undirectedAdjacencyList.AddEdge("2", "5");

			undirectedAdjacencyList.AddEdge("3", "6");
			undirectedAdjacencyList.AddEdge("3", "7");

			undirectedAdjacencyList.AddEdge("4", "8");

			undirectedAdjacencyList.AddEdge("5", "9");

			undirectedAdjacencyList.AddEdge("6", "10");

			undirectedAdjacencyList.SetVertexValue("10", "A");

			undirectedAdjacencyList.SetVertexValue("5", "B");

			ShowMatrix(undirectedAdjacencyList.GetMatrix());

			Console.WriteLine();
			
			BFS bfs = new BFS();
			var resultBFS = bfs.Find<string>(undirectedAdjacencyList, "1", "A");
			Console.WriteLine("Result of BFS search is vertice " + resultBFS);

			DFS dfs = new DFS();
			var resultDFS = dfs.Find<string>(undirectedAdjacencyList, "1", "B");
			Console.WriteLine("Result of DFS search is vertice " + resultDFS);

			Console.ReadLine();
		}

		static void ShowMatrix(bool[][] matrix)
		{
			int count = matrix.Count();
			
			Console.ReadLine();

			Console.Write("  ");

			for (int i = 0; i < count; i++)
			{
				Console.Write(i + " ");
			}

			Console.WriteLine();

			for (int i = 0; i < count; i++)
			{
				Console.Write(i + " ");

				for (int j = 0; j < count; j++)
				{
					if (matrix[i][j] == true)
					{
						Console.Write(1 + " ");
					}
					else
					{
						Console.Write(0 + " ");
					}
				}

				Console.WriteLine();
			}
		}

	}
}
