using Microsoft.Extensions.Logging;
using CrudBTG.Services;
using CrudBTG.ViewModels;
using CrudBTG.Views;

namespace CrudBTG
{
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

            builder.Services.AddSingleton<ClienteService>();
            builder.Services.AddTransient<ClientesViewModel>();
            builder.Services.AddTransient<ClientesPage>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
