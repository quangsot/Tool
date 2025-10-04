using CapCutTool.UI.ViewModel;
using System.Windows;

namespace CapCutTool.UI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        DataContext = App.Current.Services.GetService<MainViewModel>();
        InitializeComponent();
    }
}