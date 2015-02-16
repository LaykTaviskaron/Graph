using System;
using System.IO;

namespace Graph
{
	public static class GraphReader
	{
		public static string[][] TextFileAsAdjacencyModel(string filePath)
		{
			string[] lines = File.ReadAllLines(filePath);

			if (lines.Length == 0)
			{
				throw new InvalidOperationException("File content is not valid");
			}

			string[][] model = new string[lines.Length][];

			for (int i = 0; i < lines.Length; i++)
			{
				model[i] = new string[lines.Length];

				string[] separator = new string[] { "\t" };
				model[i] = lines[i].Split(separator, StringSplitOptions.RemoveEmptyEntries);
			}

			return model;
		}

		public static bool[][] GenerateAdjacencyMatrix(string[][] graph)
		{
			return (new DirectedAdjacencyList<int>(graph)).GetMatrix();
		}
	}
}
