using System.Threading.Tasks;
using Microsoft.Owin;

namespace Owin.RedirectUrl
{
    public class RedirectUrl : OwinMiddleware
    {
        private readonly string _destinationPath;
        private readonly string _sourcePath;

        public RedirectUrl(OwinMiddleware next, string sourcePath, string destinationPath)
            : base(next)
        {
            _sourcePath = sourcePath;
            _destinationPath = destinationPath;
        }

        public override async Task Invoke(IOwinContext context)
        {
            var path = context.Request.Uri.AbsolutePath;
            if (path.ShouldRedirect(_sourcePath, _destinationPath))
            {
                context.Response.StatusCode = 301;
                context.Response.Headers.Set("Location", _destinationPath);
            }
            else
            {
                await Next.Invoke(context);
            }
        }
    }
}