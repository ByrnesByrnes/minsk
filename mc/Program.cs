﻿// See https://aka.ms/new-console-template for more information

using mc.CodeAnalysis;

namespace mc
{
	internal static class Program
	{
		private static void Main()
		{
			var showTree = false;

			while (true)
			{
				Console.Write("> ");
				var line = Console.ReadLine();

				if (string.IsNullOrEmpty(line))
					return;

				if (line == "#showTree")
				{
					showTree = !showTree;
					Console.WriteLine(showTree ? "Showing parse trees." : "Not showing parse trees");
					continue;
				}
				else if (line == "#cls")
				{
					Console.Clear();
					continue;
				}

				var syntaxTree = SyntaxTree.Parse(line);

				if (showTree)
				{
					var color = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.DarkGray;
					PrettyPrint(syntaxTree.Root);
					Console.ResetColor();
				}

				if (syntaxTree.Diagnostics.Any())
				{
					var color = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.DarkRed;

					foreach (var diagnostic in syntaxTree.Diagnostics)
					{
						Console.WriteLine(diagnostic);
					}

					Console.ResetColor();
				}
				else
				{
					var e = new Evaluator(syntaxTree.Root);
					var result = e.Evaluate();
					Console.WriteLine(result);
				}
			}
		}

		static void PrettyPrint(SyntaxNode node, string indent = "", bool isLast = true)
		{

			// └──
			// │
			// ├──

			var marker = isLast ? "└── " : "├── ";

			Console.Write(indent);
			Console.Write(marker);
			Console.Write(node.Kind);

			if (node is SyntaxToken t && t.Value != null)
			{
				Console.Write(" ");
				Console.Write(t.Value);
			}

			Console.WriteLine();

			indent += isLast ? "     " : "│    ";

			var lastChild = node.GetChildren().LastOrDefault();

			foreach (var child in node.GetChildren())
			{
				PrettyPrint(child, indent, child == lastChild);
			}
		}
	}
}