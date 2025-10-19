global using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using CapCutTool.Core;
using CapCutTool.Service;
using CapCutTool.Service.Interface;
using CapCutTool.Service.Service;
using CapCutTool.UI.ViewModel;
using Microsoft.Extensions.Configuration;

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

        // Load appsettings.json
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        // Bind trực tiếp và đăng ký Singleton
        var config = configuration.GetSection("Configs").Get<Config>();
        services.AddSingleton(config!);

        services.AddTransient<Context>(sp =>
        {
            var cfg = sp.GetRequiredService<Config>();
            return new Context(cfg);
        });

        // Init View
        services.AddScoped<MainWindow>();

        // Init View Model
        services.AddTransient<MainViewModel>();

        // Init Service
        services.AddTransient<IDraftService, DraftService>();
        services.AddTransient<IAnimationService, AnimationService>();
        services.AddTransient<IEffectService, EffectService>();
        services.AddTransient<ITransitionService, TransitionService>();
        services.AddTransient<IVoiceService, VoiceService>();

        return services.BuildServiceProvider();
    }
}

