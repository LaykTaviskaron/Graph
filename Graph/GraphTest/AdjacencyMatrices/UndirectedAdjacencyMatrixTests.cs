using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graph;

namespace GraphTest
{
	[TestClass]
	public class UndirectedAdjacencyMatrixTest
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void UndirectedAdjacencyList_InvalidCountGiven_ArgumentExceptionThrown()
		{
			UndirectedAdjacencyMatrix adj = new UndirectedAdjacencyMatrix(-5);
		}

		[TestMethod]
		public void UndirectedAdjacencyList_InvalidCountGiven_NoExceptionThrown()
		{
			UndirectedAdjacencyMatrix adj = new UndirectedAdjacencyMatrix(5);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void AddEdge_InvalidRowIndexGiven_ArgumentExceptionThrown()
		{
			UndirectedAdjacencyMatrix adj = new UndirectedAdjacencyMatrix(5);
			adj.AddEdge(100, 1);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void AddEdge_InvalidColIndexGiven_ArgumentExceptionThrown()
		{
			UndirectedAdjacencyMatrix adj = new UndirectedAdjacencyMatrix(5);
			adj.AddEdge(1, 100);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void AddEdge_AddingExistingEdge_ArgumentExceptionThrown()
		{
			UndirectedAdjacencyMatrix adj = new UndirectedAdjacencyMatrix(5);
			adj.AddEdge(1, 2);
			adj.AddEdge(1, 2);
		}

		[TestMethod]
		public void AddEdge_ValidIndexGiven_NoExceptionThrown()
		{
			UndirectedAdjacencyMatrix adj = new UndirectedAdjacencyMatrix(5);
			adj.AddEdge(0, 2);

			Assert.IsTrue(adj.Matrix[0][2]);
			Assert.IsTrue(adj.Matrix[2][0]);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void RemoveEdge_InvalidRowIndexGiven_ArgumentExceptionThrown()
		{
			UndirectedAdjacencyMatrix adj = new UndirectedAdjacencyMatrix(5);
			adj.RemoveEdge(100, 1);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void RemoveEdge_InvalidColIndexGiven_ArgumentExceptionThrown()
		{
			UndirectedAdjacencyMatrix adj = new UndirectedAdjacencyMatrix(5);
			adj.RemoveEdge(1, 100);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void RemoveEdge_RemovingUnexistingRow_ArgumentExceptionThrown()
		{
			UndirectedAdjacencyMatrix adj = new UndirectedAdjacencyMatrix(5);
			adj.RemoveEdge(1, 2);
		}

		[TestMethod]
		public void RemoveEdge_ValidIndexGiven_NoExceptionThrown()
		{
			UndirectedAdjacencyMatrix adj = new UndirectedAdjacencyMatrix(5);
			adj.AddEdge(0, 2);
			adj.RemoveEdge(0, 2);

			Assert.IsTrue(!adj.Matrix[0][2]);
			Assert.IsTrue(!adj.Matrix[2][0]);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void UndirectedAdjacencyMatrix_NotAMatrixGiven_ArgumentExceptionThrown()
		{
			bool[][] input = new bool[3][];

			input[0] = new bool[3];
			input[1] = new bool[20];
			input[2] = new bool[3];

			UndirectedAdjacencyMatrix adj = new UndirectedAdjacencyMatrix(3, input);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void UndirectedAdjacencyMatrix_InvalidMatrixSizeGiven_ArgumentExceptionThrown()
		{
			bool[][] input = new bool[3][];

			input[0] = new bool[3];
			input[1] = new bool[3];
			input[2] = new bool[3];

			UndirectedAdjacencyMatrix adj = new UndirectedAdjacencyMatrix(10, input);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void UndirectedAdjacencyMatrix_NotAnUndirectedGraphMatrixGiven_ArgumentExceptionThrown()
		{
			bool[][] input = new bool[3][];

			input[0] = new bool[3];
			input[1] = new bool[3];
			input[2] = new bool[3];

			input[0][2] = true;
			input[2][0] = false;

			UndirectedAdjacencyMatrix adj = new UndirectedAdjacencyMatrix(3, input);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentException))]
		public void UndirectedAdjacencyMatrix_InvalidVerticesNumberGiven_ArgumentExceptionThrown()
		{
			bool[][] input = new bool[3][];

			input[0] = new bool[3];
			input[1] = new bool[3];
			input[2] = new bool[3];

			UndirectedAdjacencyMatrix adj = new UndirectedAdjacencyMatrix(-2, input);
		}

		[TestMethod]
		public void UndirectedAdjacencyMatrix_ValidDataGiven_NoExceptionThrown()
		{
			bool[][] input = new bool[3][];

			input[0] = new bool[3];
			input[1] = new bool[3];
			input[2] = new bool[3];

			UndirectedAdjacencyMatrix adj = new UndirectedAdjacencyMatrix(3, input);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void UndirectedAdjacencyMatrix_NullSubArrayGiven_ArgumentNullExceptionThrown()
		{
			bool[][] input = new bool[3][];

			input[0] = new bool[3];
			input[1] = null;
			input[2] = new bool[3];

			UndirectedAdjacencyMatrix adj = new UndirectedAdjacencyMatrix(3, input);
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void UndirectedAdjacencyMatrix_NullyGiven_ArgumentNullExceptionThrown()
		{
			UndirectedAdjacencyMatrix adj = new UndirectedAdjacencyMatrix(5, null);
		}

	}
}
