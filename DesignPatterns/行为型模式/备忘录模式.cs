namespace DesignPattern.DesignPatterns.行为型模式;

public static class 备忘录模式
{
    public static void Run()
    {
        var originator = new Originator { State = "状态1" };
        var caretaker = new Caretaker { Memento = originator.CreateMemento() };
        originator.State = "状态2";
        originator.SetMemento(caretaker.Memento);
        Console.WriteLine(originator.State); // 输出“状态1”
    }
}

public class Originator
{
    public string State { get; set; }
    public Memento CreateMemento() => new(State);
    public void SetMemento(Memento memento) => State = memento.State;
}

public class Memento
{
    public string State { get; }
    public Memento(string state) => State = state;
}

public class Caretaker
{
    public Memento Memento { get; set; }
}