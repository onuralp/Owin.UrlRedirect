using System.Threading.Tasks;
using Microsoft.Owin;

namespace Owin.RedirectUrl
{
    public class WelcomePage : OwinMiddleware
    {
        private readonly string _destinationUrl;

        public WelcomePage(OwinMiddleware next, string destinationUrl)
            : base(next)
        {
            _destinationUrl = destinationUrl;
        }

        public override async Task Invoke(IOwinContext context)
        {
            var path = context.Request.Uri.AbsolutePath;
            if (path.ShouldRedirect("/", _destinationUrl))
            {
                context.Response.StatusCode = 301;
                context.Response.Headers.Set("Location", _destinationUrl);
            }
            else
            {
                await Next.Invoke(context);
            }
        }
    }
}