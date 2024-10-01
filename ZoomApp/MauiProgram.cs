using ZoomApp.Interfaces;
using ZoomApp.Services;

namespace ZoomApp;

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

		#if windows
				 builder.Services.AddTransient<IZoomService, WindowsZoomService>();
			builder.ConfigureMauiHandlers(handlers =>
			{
				handlers.AddHandler<ZoomMeetingView, ZoomMeetingViewHandler>();
			});
		#endif

        return builder.Build();
	}
}
