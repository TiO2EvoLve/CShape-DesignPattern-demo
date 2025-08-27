using System.Windows;
using System.Windows.Controls;

using DesignPattern.DesignPatterns.创建者模式;
using DesignPattern.DesignPatterns.结构型模式;
using DesignPattern.DesignPatterns.行为型模式;

namespace DesignPattern;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly Dictionary<string, Action> _patternActions;

    public MainWindow()
    {
        InitializeComponent();

        // 映射：按钮名称 → 对应执行方法
        _patternActions = new Dictionary<string, Action>
        {
            { "单例模式", 单例模式.Run },
            { "原型模式", 原型模式.Run },
            { "工厂模式", 工厂模式.Run },
            { "建造者模式", 建造者模式.Run },
            { "抽象工厂模式", 抽象工厂模式.Run },
            { "享元模式", 享元模式.Run },
            { "代理模式", 代理模式.Run },
            { "外观模式", 外观模式.Run },
            { "桥接模式", 桥接模式.Run },
            { "组合模式", 组合模式.Run },
            { "装饰器模式", 装饰器模式.Run },
            { "适配器模式", 适配器模式.Run },
            { "中介者模式", 中介者模式.Run },
            { "命令模式", 命令模式.Run },
            { "备忘录模式", 备忘录模式.Run },
            { "模板方法模式", 模板方法模式.Run },
            { "状态模式", 状态模式.Run },
            { "策略模式", 策略模式.Run },
            { "观察者模式", 观察者模式.Run },
            { "解释器模式", 解释器模式.Run },
            { "访问者模式", 访问者模式.Run },
            { "责任链模式", 责任链模式.Run },
            { "迭代器模式", 迭代器模式.Run }
        };

        CreateButtons();
    }

    private void CreateButtons()
    {
        foreach (var kvp in _patternActions)
        {
            var btn = new Button
            {
                Content = kvp.Key,
                Tag = kvp.Key,
                Height = 50,
                Width = 120,
                Margin = new Thickness(5)
            };
            btn.Click += PatternButton_Click;
            ButtonGrid.Children.Add(btn);
        }
    }

    private void PatternButton_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.Tag is string key && _patternActions.TryGetValue(key, out var action))
        {
            Console.WriteLine($"\n--- {key} ---");
            action();
        }
    }
}