using System;
using System.Collections.Generic;

namespace Graph
{
	public class AdjacencyListNode<T>
	{
		public AdjacencyListNode()
		{
			Edges = new List<AdjacencyListNode<T>>();
		}

		public AdjacencyListNode(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}

			Edges = new List<AdjacencyListNode<T>>();
			Name = name;
		}

		public string Name { get; private set; }

		public List<AdjacencyListNode<T>> Edges { get; private set; }

		public T Value { get; set; }
	}
}
