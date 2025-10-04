global using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using CapCutTool.Service;
using CapCutTool.UI.ViewModel;

namespace CapCutTool.UI;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        this.InitializeComponent();
        Services = ConfigureServices();
    }

    public IServiceProvider Services { get; }
    public new static App Current => (App)Application.Current;
    private static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Init View
        services.AddScoped<MainWindow>();

        // Init View Model
        services.AddTransient<MainViewModel>();

        // Init Service
        services.AddTransient<IPersonService, PersonService>();

        return services.BuildServiceProvider();
    }
}

