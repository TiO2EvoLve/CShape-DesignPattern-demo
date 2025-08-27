namespace DesignPattern.DesignPatterns.结构型模式;

public class 外观模式
{
    public static void Run()
    {
        var facade = new Facade();
        facade.OperationAll();
    } 
}
public class SubSystemA
{
    public void OperationA() => Console.WriteLine("子系统A的操作");
}

public class SubSystemB
{
    public void OperationB() => Console.WriteLine("子系统B的操作");
}

public class SubSystemC
{
    public void OperationC() => Console.WriteLine("子系统C的操作");
}

public class Facade
{
    private readonly SubSystemA _a = new();
    private readonly SubSystemB _b = new();
    private readonly SubSystemC _c = new();

    public void OperationAll()
    {
        _a.OperationA();
        _b.OperationB();
        _c.OperationC();
    }
}



