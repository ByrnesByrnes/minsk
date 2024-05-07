// See https://aka.ms/new-console-template for more information

namespace mc.CodeAnalysis
{
    public enum SyntaxKind
    {
        // Tokens
        BadToken,
        EndOfFileToken,
        WhiteSpaceToken,
        NumberToken,
        PlusToken,
        MinusToken,
        StarToken,
        SlashToken,
        OpenParenthesisToken,
        CloseParenthesisToken,

        // Expression
        NumberExpression,
        BinaryExpression,
        ParenthesizedExpression
    }
}