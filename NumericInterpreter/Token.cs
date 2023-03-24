namespace NumericInterpreter;



public class Token
{
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
    
    public readonly Type ThisType;
    public readonly string Text;
    public Token(Type type, string text) => (ThisType, Text) = (type, text);
    public override string ToString() => $"`{Text}`";
}