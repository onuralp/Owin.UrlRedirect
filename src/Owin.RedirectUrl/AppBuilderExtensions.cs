namespace Owin.RedirectUrl
{
    public static class AppBuilderExtensions
    {
        public static void UseWelcomePage(
            this IAppBuilder app, string url)
        {
            app.Use<WelcomePage>(url);
        }

        public static void UseRedirectUrl(
            this IAppBuilder app, string sourcePath, string destinationPath)
        {
            app.Use<RedirectUrl>(sourcePath, destinationPath);
        }
    }
}