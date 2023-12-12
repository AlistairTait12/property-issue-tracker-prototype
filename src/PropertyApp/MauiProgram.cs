using Microsoft.Extensions.Logging;
using PropertyApp.JsonReadWrite;
using PropertyApp.Model;
using PropertyApp.ModelHandling;
using PropertyApp.View;
using PropertyApp.ViewModel;

namespace PropertyApp;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<IModelHandler, ModelHandler>();
        builder.Services.AddSingleton<IJsonHandler<IssueModel>>(new JsonHandler<IssueModel>(FileSystem.Current.CacheDirectory));
        builder.Services.AddTransient<IssuesListPage>();
        builder.Services.AddTransient<IssuesListViewModel>();
        builder.Services.AddTransient<IssueDetailsPage>();
        builder.Services.AddTransient<IssueDetailsViewModel>();
        builder.Services.AddTransient<SetTitleAndDescriptionPage>();
        builder.Services.AddTransient<SetTitleAndDescriptionViewModel>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MainViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
