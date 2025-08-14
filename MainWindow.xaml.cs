
using System.Windows;
using System.Windows.Controls;
using DesignPattern.DesignPatterns;

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
            { "工厂模式", 工厂模式.Run },
            { "观察者模式", 观察者模式.Run },
            { "责任链模式", 责任链模式.Run }
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
                Height = 40,
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