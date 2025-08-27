namespace DesignPattern.DesignPatterns.行为型模式;

public static class 命令模式
{
    public static void Run()
    {
        // 简单命令模式演示
        Receiver receiver = new Receiver();
        ICommand command = new ConcreteCommand(receiver);
        Invoker invoker = new Invoker(command);
        invoker.ExecuteCommand();
    }
}

public interface ICommand
{
    void Execute();
}

public class ConcreteCommand(Receiver receiver) : ICommand
{
    public void Execute()
    {
        receiver.Action();
    }
}

public class Receiver
{
    public void Action()
    {
        Console.WriteLine("接收者执行操作");
    }
}

public class Invoker(ICommand command)
{
    public void ExecuteCommand()
    {
        command.Execute();
    }
}