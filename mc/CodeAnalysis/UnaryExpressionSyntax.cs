// See https://aka.ms/new-console-template for more information

namespace mc.CodeAnalysis
{
	public sealed class UnaryExpressionSyntax : ExpressionSyntax
	{
		public UnaryExpressionSyntax(SyntaxToken operatorToken, ExpressionSyntax operand)
		{			
			OperatorToken = operatorToken;
			Operand = operand;
		}

		public override SyntaxKind Kind => SyntaxKind.UnaryExpression;		
		public SyntaxToken OperatorToken { get; }
		public ExpressionSyntax Operand { get; }		

		public override IEnumerable<SyntaxNode> GetChildren()
		{			
			yield return OperatorToken;
			yield return Operand;
		}
	}
}