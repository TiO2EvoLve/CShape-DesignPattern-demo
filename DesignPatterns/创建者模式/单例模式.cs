namespace DesignPattern.DesignPatterns.创建者模式;

public class 单例模式
{
    public static void Run()
    {
        var instance1 = Singleton.Instance;
        var instance2 = Singleton.Instance;
        Console.WriteLine($"instance1 == instance2: {instance1 == instance2}");
    }
}
public class Singleton
{
    //私有构造方法，防止外部实例化
    private Singleton() { }
    //静态只读字段，确保线程安全的单例实例
    //公共静态属性，提供全局访问点
    public static Singleton Instance { get; } = new ();
}