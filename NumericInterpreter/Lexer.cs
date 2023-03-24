using System.Text;

namespace NumericInterpreter;

public class Lexer
{
    public static List<Token> Lex(string input)
    {
        var result = new List<Token>();

        for (int i = 0; i < input.Length; i++)
        {
            switch (input[i])
            {
                case '+':
                    result.Add(new Token(Token.Type.Plus, "+"));
                    break;
                case '-':
                    result.Add(new Token(Token.Type.Minus, "-"));
                    break;
                case '*':
                    result.Add(new Token(Token.Type.Multiply, "*"));
                    break;
                case '/':
                    result.Add(new Token(Token.Type.Divide, "/"));
                    break;
                case '(':
                    result.Add(new Token(Token.Type.Lparen, "("));
                    break;
                case ')':
                    result.Add(new Token(Token.Type.Rparen, ")"));
                    break;
                default:
                    var sb = new StringBuilder(input[i].ToString());
                    for (int j = i + 1; j < input.Length; j++)
                    {
                        if (char.IsDigit(input[j]))
                        {
                            sb.Append(input[j]);
                            i++;
                        }
                        else
                        {
                            result.Add(new Token(Token.Type.Number, sb.ToString()));
                            break;
                        }
                    }
                    break;
            }
        }
        return result;
    }
}