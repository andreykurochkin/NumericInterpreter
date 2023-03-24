namespace NumericInterpreter;

public class Token
{
    private readonly Type _type;
    private readonly string _text;

    public enum Type
    {
        Number,
        Plus,
        Minus,
        Multiply,
        Divide,
        Lparen,
        Rparen
    }

    public Token(Type type, string text) => (_type, _text) = (type, text);
    public override string ToString() => $"{_text}";
}

}