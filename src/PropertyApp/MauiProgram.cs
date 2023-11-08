using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PropertyApp.JsonReadWrite;
using PropertyApp.Model;
using PropertyApp.ModelHandling;
using PropertyApp.View;
using PropertyApp.ViewModel;
using System.Reflection;

namespace PropertyApp;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        var assembly = Assembly.GetExecutingAssembly();
        using var stream = FileSystem.OpenAppPackageFileAsync("appsettings.json");
        var config = new ConfigurationBuilder()
            .AddJsonStream(stream.Result)
            .Build();

        builder.Configuration.AddConfiguration(config);

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddTransient<IOptions<StorageOptions>>(services =>
        {
            var storageOptions = new StorageOptions();
            builder.Configuration.GetSection("StorageOptions").Bind(storageOptions);
            return Options.Create(storageOptions);
        });

        builder.Services.AddSingleton<IModelHandler, ModelHandler>();
        builder.Services.AddSingleton<IJsonHandler<IssueModel>, JsonHandler<IssueModel>>();
        builder.Services.AddTransient<IssuesListPage>();
        builder.Services.AddTransient<IssuesListViewModel>();
        builder.Services.AddTransient<IssueDetailsPage>();
        builder.Services.AddTransient<IssueDetailsViewModel>();
        builder.Services.AddTransient<SetTitleAndDescriptionPage>();
        builder.Services.AddTransient<SetTitleAndDescriptionViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
