using FluentAssertions;
using NumericInterpreter;

namespace NumericInterpreterTests;

public class UnitTest1
{
    private class LexWrapper
    {
        public List<Token> Lex(string input) => Lexer.Lex(input);
    }

    private LexWrapper _sut = new();
    
    [Theory]
    [InlineData("1+(2+3)")]
    [InlineData(" 1 + ( 2 + 3)")]
    [InlineData(" 1 + (2+3)")]
    public void Lex_ShouldReturnExpectedValue_WhenDataIsValid(string input)
    {
        List<Token> expected = new()
        {
            new Token(Token.Type.Number, "1"),
            new Token(Token.Type.Plus, "+"),
            new Token(Token.Type.Lparen, "("),
            new Token(Token.Type.Number, "2"),
            new Token(Token.Type.Plus, "+"),
            new Token(Token.Type.Number, "3"),
            new Token(Token.Type.Rparen, ")"),
        };

        var result = _sut.Lex(input);

        result.Should().Equal(expected, (c1, c2) => c1.ThisType == c2.ThisType && c1.Text == c2.Text);
    }
}