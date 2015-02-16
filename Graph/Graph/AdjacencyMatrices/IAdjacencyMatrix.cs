
namespace Graph
{
	public interface IAdjacencyMatrix
	{
		int VerticesCount { get; }

		bool[][] Matrix { get; }

		void AddEdge(int rowIndex, int columnIndex);

		void RemoveEdge(int rowIndex, int columnIndex);
	}
}
