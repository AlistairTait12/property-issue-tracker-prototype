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
        builder.Services
            .AddSingleton<IJsonHandler<IssueModel>, JsonHandler<IssueModel>>(factory =>
            {
                return new JsonHandler<IssueModel>(string.Empty);
            });
        builder.Services.AddTransient<IssuesListPage>();
        builder.Services.AddTransient<IssuesListViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
