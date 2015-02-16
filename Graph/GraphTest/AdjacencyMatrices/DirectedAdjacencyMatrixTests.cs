using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graph;

namespace GraphTest
{
	[TestClass]
	public class DirectedAdjacencyMatrixTest
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void UndirectedAdjacencyList_InvalidCountGiven_ArgumentExceptionThrown()
		{
			DirectedAdjacencyMatrix adj = new DirectedAdjacencyMatrix(-5);
		}

		[TestMethod]
		public void UndirectedAdjacencyList_InvalidCountGiven_NoExceptionThrown()
		{
			DirectedAdjacencyMatrix adj = new DirectedAdjacencyMatrix(5);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void AddEdge_InvalidRowIndexGiven_ArgumentExceptionThrown()
		{
			DirectedAdjacencyMatrix adj = new DirectedAdjacencyMatrix(5);
			adj.AddEdge(100, 1);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void AddEdge_InvalidColIndexGiven_ArgumentExceptionThrown()
		{
			DirectedAdjacencyMatrix adj = new DirectedAdjacencyMatrix(5);
			adj.AddEdge(1, 100);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void AddEdge_AddingExistingEdge_ArgumentExceptionThrown()
		{
			DirectedAdjacencyMatrix adj = new DirectedAdjacencyMatrix(5);
			adj.AddEdge(1, 2);
			adj.AddEdge(1, 2);
		}

		[TestMethod]
		public void AddEdge_ValidIndexGiven_NoExceptionThrown()
		{
			DirectedAdjacencyMatrix adj = new DirectedAdjacencyMatrix(5);
			adj.AddEdge(0, 2);

			Assert.IsTrue(adj.Matrix[0][2]);
			Assert.IsTrue(!adj.Matrix[2][0]);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void RemoveEdge_InvalidRowIndexGiven_ArgumentExceptionThrown()
		{
			DirectedAdjacencyMatrix adj = new DirectedAdjacencyMatrix(5);
			adj.RemoveEdge(100, 1);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void RemoveEdge_InvalidColIndexGiven_ArgumentExceptionThrown()
		{
			DirectedAdjacencyMatrix adj = new DirectedAdjacencyMatrix(5);
			adj.RemoveEdge(1, 100);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void RemoveEdge_RemovingUnexistingRow_ArgumentExceptionThrown()
		{
			DirectedAdjacencyMatrix adj = new DirectedAdjacencyMatrix(5);
			adj.RemoveEdge(1, 2);
		}

		[TestMethod]
		public void RemoveEdge_ValidIndexGiven_NoExceptionThrown()
		{
			DirectedAdjacencyMatrix adj = new DirectedAdjacencyMatrix(5);
			adj.AddEdge(0, 2);
			adj.AddEdge(2, 0);

			adj.RemoveEdge(0, 2);

			Assert.IsTrue(!adj.Matrix[0][2]);
			Assert.IsTrue(adj.Matrix[2][0]);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void DirectedAdjacencyMatrix_NotAMatrixGiven_ArgumentExceptionThrown()
		{
			bool[][] input = new bool[3][];

			input[0] = new bool[3];
			input[1] = new bool[20];
			input[2] = new bool[3];

			DirectedAdjacencyMatrix adj = new DirectedAdjacencyMatrix(3, input);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void DirectedAdjacencyMatrix_InvalidMatrixSizeGiven_ArgumentExceptionThrown()
		{
			bool[][] input = new bool[3][];

			input[0] = new bool[3];
			input[1] = new bool[3];
			input[2] = new bool[3];

			DirectedAdjacencyMatrix adj = new DirectedAdjacencyMatrix(10, input);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void DirectedAdjacencyMatrix_InvalidVerticesNumberGiven_ArgumentExceptionThrown()
		{
			bool[][] input = new bool[3][];

			input[0] = new bool[3];
			input[1] = new bool[3];
			input[2] = new bool[3];

			DirectedAdjacencyMatrix adj = new DirectedAdjacencyMatrix(-2, input);
		}

		[TestMethod]
		public void DirectedAdjacencyMatrix_ValidDataGiven_NoExceptionThrown()
		{
			bool[][] input = new bool[3][];

			input[0] = new bool[3];
			input[1] = new bool[3];
			input[2] = new bool[3];

			DirectedAdjacencyMatrix adj = new DirectedAdjacencyMatrix(3, input);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void DirectedAdjacencyMatrix_NullSubArrayGiven_ArgumentNullExceptionThrown()
		{
			bool[][] input = new bool[3][];

			input[0] = new bool[3];
			input[1] = null;
			input[2] = new bool[3];

			DirectedAdjacencyMatrix adj = new DirectedAdjacencyMatrix(3, input);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void DirectedAdjacencyMatrix_NullyGiven_ArgumentNullExceptionThrown()
		{
			DirectedAdjacencyMatrix adj = new DirectedAdjacencyMatrix(5, null);
		}
	}
}
