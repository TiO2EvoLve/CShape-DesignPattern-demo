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

public class NumberExpression(int number) : IExpression
{
    public int Interpret(Dictionary<string, int> context) => number;
}

public class VariableExpression(string name) : IExpression
{
    public int Interpret(Dictionary<string, int> context) => context[name];
}

public class AddExpression(IExpression left, IExpression right) : IExpression
{
    public int Interpret(Dictionary<string, int> context) => left.Interpret(context) + right.Interpret(context);
}

public class SubtractExpression(IExpression left, IExpression right) : IExpression
{
    public int Interpret(Dictionary<string, int> context) => left.Interpret(context) - right.Interpret(context);
}

