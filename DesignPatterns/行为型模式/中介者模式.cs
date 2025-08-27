namespace DesignPattern.DesignPatterns.行为型模式;

public static class 中介者模式
{
    public static void Run()
    {
        var mediator = new ConcreteMediator();
        var c1 = new ConcreteColleague1(mediator);
        var c2 = new ConcreteColleague2(mediator);
        mediator.Colleague1 = c1;
        mediator.Colleague2 = c2;
        c1.Send("你好，c2");
        c2.Send("你好，c1");
    }
}
public abstract class Mediator
{
    public abstract void Send(string message, Colleague colleague);
}

public abstract class Colleague
{
    protected Mediator mediator;

    public Colleague(Mediator mediator)
    {
        this.mediator = mediator;
    }
}

public class ConcreteColleague1 : Colleague
{
    public ConcreteColleague1(Mediator mediator) : base(mediator)
    {
    }

    public void Send(string message) => mediator.Send(message, this);
    public void Notify(string message) => Console.WriteLine($"同事1收到消息：{message}");
}

public class ConcreteColleague2 : Colleague
{
    public ConcreteColleague2(Mediator mediator) : base(mediator)
    {
    }

    public void Send(string message) => mediator.Send(message, this);
    public void Notify(string message) => Console.WriteLine($"同事2收到消息：{message}");
}

public class ConcreteMediator : Mediator
{
    public ConcreteColleague1 Colleague1 { get; set; }
    public ConcreteColleague2 Colleague2 { get; set; }

    public override void Send(string message, Colleague colleague)
    {
        if (colleague == Colleague1)
            Colleague2.Notify(message);
        else
            Colleague1.Notify(message);
    }
}

