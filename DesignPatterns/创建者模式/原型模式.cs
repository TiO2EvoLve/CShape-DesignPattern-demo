namespace DesignPattern.DesignPatterns;

public class 原型模式
{
    public static void Run()
    {
        // 创建原始角色
        GameCharacter warrior = new GameCharacter("战士A", 10, "长剑");
        warrior.ShowInfo();

        // 克隆一个角色，并修改部分属性
        GameCharacter warriorClone = warrior.Clone("战士B",12,"战斧");
        warriorClone.ShowInfo();

        // 再克隆
        GameCharacter warriorClone2 = warrior.Clone("战士C",13,"战斧");
        warriorClone2.ShowInfo();
        
    }
}
public interface IPrototype<out T>
{
    T Clone(string name, int level, string weapon);
}
//游戏角色类，实现原型接口
public class GameCharacter(string name, int level, string weapon) : IPrototype<GameCharacter>
{
    public string Name { get; set; } = name;
    public int Level { get; set; } = level;
    public string Weapon { get; set; } = weapon;

    // 克隆方法（浅拷贝）
    public GameCharacter Clone(string name, int level, string weapon)
    {
        GameCharacter gameCharacter = (GameCharacter)this.MemberwiseClone();
        gameCharacter.Name = name;
        gameCharacter.Level = level;
        gameCharacter.Weapon = weapon;
        return gameCharacter;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"角色：{Name} | 等级：{Level} | 武器：{Weapon}");
    }
}