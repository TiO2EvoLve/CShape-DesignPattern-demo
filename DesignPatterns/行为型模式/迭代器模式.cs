namespace DesignPattern.DesignPatterns.行为型模式;

public class 迭代器模式
{
    public static void Run()
    {
        var aggregate = new ConcreteAggregate<string>();
        aggregate.Add("A");
        aggregate.Add("B");
        aggregate.Add("C");
        var iterator = aggregate.CreateIterator();
        while (iterator.MoveNext())
            Console.WriteLine(iterator.Current);
    }
}
public interface IIterator<T>
{
    bool MoveNext();
    T Current { get; }
    void Reset();
}

public interface IAggregate<T>
{
    IIterator<T> CreateIterator();
}

public class ConcreteAggregate<T> : IAggregate<T>
{
    private readonly List<T> _items = new();
    public void Add(T item) => _items.Add(item);
    public IIterator<T> CreateIterator() => new ConcreteIterator<T>(_items);
}

public class ConcreteIterator<T>(List<T> items) : IIterator<T>
{
    private int _index = -1;
    public bool MoveNext() => ++_index < items.Count;
    public T Current => items[_index];
    public void Reset() => _index = -1;
}

