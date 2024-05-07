// See https://aka.ms/new-console-template for more information

namespace mc.CodeAnalysis
{
	public sealed class SyntaxTree
	{
		public SyntaxTree(IEnumerable<string> diagnostics, ExpressionSyntax root, SyntaxToken EndOfFileToken)
		{
			Diagnostics = diagnostics.ToArray();
			Root = root;
			this.EndOfFileToken = EndOfFileToken;
		}

		public IReadOnlyList<string> Diagnostics { get; }
		public ExpressionSyntax Root { get; }
		public SyntaxToken EndOfFileToken { get; }

		public static SyntaxTree Parse(string text)
		{
			var parser = new Parser(text);
			return parser.Parse();
		}
	}
}