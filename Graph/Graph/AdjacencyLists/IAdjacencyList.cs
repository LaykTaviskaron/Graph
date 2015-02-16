using System.Collections.Generic;

namespace Graph
{
	public interface IAdjacencyList<T>
	{
		int Count { get; }

		void AddEdge(string source, string destination);

		void RemoveEdge(string source, string destination);

		void AddVertex(string name);

		void RemoveVertex(string name);

		List<AdjacencyListNode<T>> GetVertexEdges(string name);

		bool HasEdge(string source, string destination);

		bool HasVertex(string name);

		void SetVertexValue(string name, T value);

		T GetVertexValue(string name);

		bool[][] GetMatrix();

		string[] GetVertices();
	}
}
