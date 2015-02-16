using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graph;

namespace GraphTest
{
	[TestClass]
	public class BFSTest
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Find_NullAdjacencyListGiven_ArgumentNullExceptionThrown()
		{
			BFS BFS = new BFS();
			BFS.Find<string>(null, "anyVertex", "anyData");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Find_NullVertexGiven_ArgumentNullExceptionThrown()
		{
			BFS BFS = new BFS();
			BFS.Find<string>(new DirectedAdjacencyList<string>(), null, "anyData");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void Find_NullValueGiven_ArgumentNullExceptionThrown()
		{
			BFS BFS = new BFS();
			BFS.Find<string>(new DirectedAdjacencyList<string>(), "anyVertex", null);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void Find_InvalidVertexGiven_ArgumentExceptionThrown()
		{
			BFS BFS = new BFS();
			BFS.Find<string>(new DirectedAdjacencyList<string>(), "anyVertex", "anyData");
		}

		[TestMethod]
		public void Find_ValueIsInAStartVertex_NoExceptionThrown()
		{
			string startVertex = "1";
			string value = "anyData";

			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();

			adj.AddVertex(startVertex);

			adj.AddVertex("anyOther");

			adj.AddEdge(startVertex, "anyOther");

			adj.SetVertexValue("anyOther", value);

			adj.SetVertexValue(startVertex, value);

			BFS BFS = new BFS();
			Assert.AreEqual(startVertex, BFS.Find<string>(adj, startVertex, value));
		}

		[TestMethod]
		public void Find_ValidDataGiven_NoExceptionThrown()
		{
			UndirectedAdjacencyList<string> dir = new UndirectedAdjacencyList<string>();

			dir.AddVertex("1");
			dir.AddVertex("2");
			dir.AddVertex("3");
			dir.AddVertex("4");
			dir.AddVertex("5");
			dir.AddVertex("6");
			dir.AddVertex("7");
			dir.AddVertex("8");
			dir.AddVertex("9");
			dir.AddVertex("10");

			dir.AddEdge("1", "2");
			dir.AddEdge("1", "3");
			dir.AddEdge("1", "4");

			dir.AddEdge("2", "5");

			dir.AddEdge("3", "6");
			dir.AddEdge("3", "7");

			dir.AddEdge("4", "8");

			dir.AddEdge("5", "9");

			dir.AddEdge("6", "10");

			dir.SetVertexValue("10", "ololosh");


			BFS bfs = new BFS();
			var result = bfs.Find<string>(dir, "1", "ololosh");

			Assert.AreEqual(result, "10");
		}

		[TestMethod]
		public void Find_InvalidValueGiven_NoExceptionThrown()
		{
			UndirectedAdjacencyList<string> dir = new UndirectedAdjacencyList<string>();

			dir.AddVertex("1");
			dir.AddVertex("2");
			dir.AddVertex("3");
			dir.AddVertex("4");
			dir.AddVertex("5");
			dir.AddVertex("6");
			dir.AddVertex("7");
			dir.AddVertex("8");
			dir.AddVertex("9");
			dir.AddVertex("10");

			dir.AddEdge("1", "2");
			dir.AddEdge("1", "3");
			dir.AddEdge("1", "4");

			dir.AddEdge("2", "5");

			dir.AddEdge("3", "6");
			dir.AddEdge("3", "7");

			dir.AddEdge("4", "8");

			dir.AddEdge("5", "9");

			dir.AddEdge("6", "10");

			dir.SetVertexValue("10", "ololosh");


			BFS bfs = new BFS();
			var result = bfs.Find<string>(dir, "1", "NEOLOLOSHAHAHHA");

			Assert.AreEqual(result, null);
		}
	}
}
