namespace DesignPattern.DesignPatterns.结构型模式;
public class 组合模式
{
    public static void Run()
    {
        var root = new Composite("根节点");
        root.Add(new Leaf("叶A"));
        var comp = new Composite("分支");
        comp.Add(new Leaf("叶B"));
        root.Add(comp);
        root.Display(1);
    }
}

public abstract class Component
{
    protected string name;

    public Component(string name)
    {
        this.name = name;
    }

    public abstract void Add(Component c);
    public abstract void Remove(Component c);
    public abstract void Display(int depth);
}

public class Leaf : Component
{
    public Leaf(string name) : base(name)
    {
    }

    public override void Add(Component c)
    {
    }

    public override void Remove(Component c)
    {
    }

    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + name);
    }
}

public class Composite : Component
{
    private readonly List<Component> children = new();

    public Composite(string name) : base(name)
    {
    }

    public override void Add(Component c) => children.Add(c);
    public override void Remove(Component c) => children.Remove(c);

    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + name);
        foreach (var child in children)
            child.Display(depth + 2);
    }
}