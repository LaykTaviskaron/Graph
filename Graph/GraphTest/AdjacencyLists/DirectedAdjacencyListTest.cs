using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graph;

namespace GraphTest
{
	[TestClass]
	public class DirectedAdjacencyListTest
	{
		[TestMethod]
		public void DirectedAdjacencyList_NoDataGiven_NoExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();
			Assert.AreEqual(adj.Count, 0);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void HasVertex_NullGiven_ArgumentNullExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();
			adj.HasVertex(null);
		}

		[TestMethod]
		public void HasVertex_ValidDataGiven_NoExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();
			adj.AddVertex("any");
			Assert.IsTrue(adj.HasVertex("any"));
		}

		[TestMethod]
		public void HasVertex_InvalidDataGiven_NoExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();
			Assert.IsTrue(!adj.HasVertex("any"));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void HasEdge_NullGiven_ArgumentNullExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();
			adj.HasEdge(null,null);
		}

		[TestMethod]
		public void HasEdge_ValidDataGiven_NoExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();
			adj.AddVertex("1");
			adj.AddVertex("2");

			adj.AddEdge("1", "2");
			
			Assert.IsTrue(adj.HasEdge("1","2"));
		}

		[TestMethod]
		public void HasEdge_InvalidDataGiven_NoExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();
			adj.AddVertex("1");
			adj.AddVertex("2");

			Assert.IsTrue(!adj.HasEdge("1", "2"));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void HasEdge_InvalidSourceItemGiven_ArgumentExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();
			adj.AddVertex("1");
			adj.AddVertex("2");

			adj.HasEdge("100", "2");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void HasEdge_InvalidDestinationItemGiven_ArgumentExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();
			adj.AddVertex("1");
			adj.AddVertex("2");

			adj.HasEdge("1", "100");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void AddEdge_InvalidDataGiven_ArgumentExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();
			adj.AddVertex("1");
			adj.AddVertex("2");

			adj.AddEdge("1", "2");
			adj.AddEdge("1", "2");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void RemoveVertex_InvalidDataGiven_ArgumentExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();
			adj.AddVertex("1");
			adj.AddVertex("2");

			adj.RemoveVertex("100");
		}

		[TestMethod]
		public void RemoveVertex_ValidDataGiven_NoExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();
			adj.AddVertex("1");
			adj.AddVertex("2");

			adj.AddEdge("1", "2");
			adj.AddEdge("2", "1");

			adj.RemoveVertex("1");

			Assert.IsTrue(!adj.HasVertex("1"));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void RemoveEdge_InvalidDataGiven_ArgumentExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();
			adj.AddVertex("1");
			adj.AddVertex("2");

			adj.AddEdge("1", "2");

			adj.RemoveEdge("2","1");
		}

		[TestMethod]
		public void RemoveEdge_ValidDataGiven_NoExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();
			adj.AddVertex("1");
			adj.AddVertex("2");

			adj.AddEdge("1", "2");
			adj.AddEdge("2", "1");

			adj.RemoveEdge("2", "1");

			Assert.IsTrue(!adj.HasEdge("2","1"));
			Assert.IsTrue(adj.HasEdge("1", "2"));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void AddVertex_AddingExistingVertex_ArgumentExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();
			adj.AddVertex("1");
			adj.AddVertex("1");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void GetVertexEdges_InvalidDataGiven_ArgumentExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();

			adj.GetVertexEdges("any");
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidOperationException))]
		public void GetVertices_InvalidDataGiven_InvalidOperationExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();

			adj.GetVertices();
		}

		[TestMethod]
		public void GetVertices_ValidDataGiven_NoExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();

			adj.AddVertex("1");
			adj.AddVertex("2");
			adj.AddVertex("3");

			adj.AddEdge("1", "1");
			adj.AddEdge("2", "2");
			adj.AddEdge("3", "3");

			var result = adj.GetMatrix();

			Assert.IsTrue(result[0][0]);
			Assert.IsTrue(result[1][1]);
			Assert.IsTrue(result[2][2]);
		}

		[TestMethod]
		public void GetVertexEdges_InvalidDataGiven_NoExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();

			adj.AddVertex("1");
			adj.AddVertex("2");
			adj.AddVertex("3");

			string[] names = adj.GetVertices();

			Assert.AreEqual(names[0], "1");
			Assert.AreEqual(names[1], "2");
			Assert.AreEqual(names[2], "3");
		}

		[TestMethod]
		public void DirectedAdjacencyList_ValidDataGiven_NoExceptionThrown()
		{
			string[][] input = new string[4][];

			input[0] = new string[3] { "1", "2", "3" };
			input[1] = new string[2] { "2", "1" };
			input[2] = new string[2] { "3", "2" };
			input[3] = new string[1] { "4" };

			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>(input);

			Assert.AreEqual(adj.Count, 4);
			Assert.AreEqual(adj.GetVertexEdges("1").Count, 2);
			Assert.AreEqual(adj.GetVertexEdges("2").Count, 1);
			Assert.AreEqual(adj.GetVertexEdges("3").Count, 1);
			Assert.AreEqual(adj.GetVertexEdges("4").Count, 0);

			Assert.IsTrue(adj.HasEdge("1", "2"));
			Assert.IsTrue(adj.HasEdge("1", "3"));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void DirectedAdjacencyList_EmptyArrayGiven_ArgumentExceptionThrown()
		{
			string[][] input = new string[4][];

			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>(input);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void DirectedAdjacencyList_NullGiven_ArgumentNullExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>(null);
		}

		[TestMethod]
		public void SetVertexValue_ValidDataGiven_NoExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();

			adj.AddVertex("1");
			adj.AddVertex("2");
			adj.AddVertex("3");

			adj.SetVertexValue("1", "AAAAA");
			adj.SetVertexValue("2", "BBBBB");
			adj.SetVertexValue("3", "CCCCC");

			Assert.AreEqual(adj.GetVertexValue("1"), "AAAAA");
			Assert.AreEqual(adj.GetVertexValue("2"), "BBBBB");
			Assert.AreEqual(adj.GetVertexValue("3"), "CCCCC");
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void SerVertexValue_NullGiven_ArgumentNullExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();

			adj.AddVertex("1");

			adj.SetVertexValue("1", null);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void SerVertexValue_NotExistingVertexGiven_ArgumentExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();

			adj.AddVertex("1");

			adj.SetVertexValue("2", "AAAAA");
		}


		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void GetVertexValue_NotExistingVertexGiven_ArgumentExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();

			adj.AddVertex("1");

			adj.GetVertexValue("2");
		}

		[TestMethod]
		public void GetVertexValue_ValidDataGiven_NoExceptionThrown()
		{
			DirectedAdjacencyList<string> adj = new DirectedAdjacencyList<string>();

			adj.AddVertex("1");
			adj.SetVertexValue("1", "AAAAA");

			Assert.AreEqual(adj.GetVertexValue("1"), "AAAAA");
		}
	}
}
