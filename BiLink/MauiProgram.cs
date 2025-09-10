using BiLink.ViewModels;
using BiLink.Views;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace BiLink
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiCommunityToolkit(opt =>
                {
                    opt.SetShouldEnableSnackbarOnWindows(true);
                })
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                    fonts.AddFont("Poppins-Semibold.ttf", "PoppinsSemibold");
                    fonts.AddFont("Font-Awesome.otf", "FontAwesome");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            // Registrar SQLiteAsyncConnection como serviço singleton
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BiLink.db3");
            var db = new SQLite.SQLiteAsyncConnection(dbPath);

            db.CreateTableAsync<Models.Link>().Wait();
            db.CreateTableAsync<Models.Categorias>().Wait();

            builder.Services.AddSingleton(db);
            builder.Services.AddSingleton<Models.Service.ILinkService, Models.Service.LinkService>();
            builder.Services.AddSingleton<Models.Service.ICategoriaService, Models.Service.CategoriaService>();

            builder.Services.AddSingleton<MainPageViewModel>();

            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
}
