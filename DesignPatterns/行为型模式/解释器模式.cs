namespace DesignPattern.DesignPatterns.行为型模式;

public class 解释器模式
{
    public static void Run()
    {
        // 解释器模式简单示例：(a + b) - c
        var context = new Dictionary<string, int> { ["a"] = 5, ["b"] = 3, ["c"] = 2 };
        IExpression expression = new SubtractExpression(
            new AddExpression(new VariableExpression("a"), new VariableExpression("b")),
            new VariableExpression("c")
        );
        int result = expression.Interpret(context);
        Console.WriteLine($"(a + b) - c = {result}");
    }
}
public interface IExpression
{
    int Interpret(Dictionary<string, int> context);
}

public class NumberExpression : IExpression
{
    private readonly int _number;
    public NumberExpression(int number) => _number = number;
    public int Interpret(Dictionary<string, int> context) => _number;
}

public class VariableExpression : IExpression
{
    private readonly string _name;
    public VariableExpression(string name) => _name = name;
    public int Interpret(Dictionary<string, int> context) => context[_name];
}

public class AddExpression : IExpression
{
    private readonly IExpression _left, _right;
    public AddExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }
    public int Interpret(Dictionary<string, int> context) => _left.Interpret(context) + _right.Interpret(context);
}

public class SubtractExpression : IExpression
{
    private readonly IExpression _left, _right;
    public SubtractExpression(IExpression left, IExpression right)
    {
        _left = left;
        _right = right;
    }
    public int Interpret(Dictionary<string, int> context) => _left.Interpret(context) - _right.Interpret(context);
}

