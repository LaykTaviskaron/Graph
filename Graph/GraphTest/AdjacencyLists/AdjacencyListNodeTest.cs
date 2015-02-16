using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Graph;

namespace GraphTest
{
	[TestClass]
	public class AdjacencyListNodeTest
	{
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void AdjacencyListNode_NullGiven_ArgumentNullExceptionThrown()
		{
			AdjacencyListNode<string> node = new AdjacencyListNode<string>(null);
		}

		[TestMethod]
		public void AdjacencyListNode_ValidStringGiven_NoExceptionThrown()
		{
			string name = "1";
			AdjacencyListNode<string> node = new AdjacencyListNode<string>(name);
			Assert.AreEqual(node.Name, name);
			Assert.IsNotNull(node.Edges);
		}

		[TestMethod]
		public void AdjacencyListNode_NoDataGiven_NoExceptionThrown()
		{
			AdjacencyListNode<string> node = new AdjacencyListNode<string>();
			Assert.IsNotNull(node.Edges);
		}
	}
}
