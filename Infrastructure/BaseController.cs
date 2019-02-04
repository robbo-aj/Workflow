using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Workflow.Infrastructure
{
    public class BaseController : Controller
    {
        internal void SetBaseUrl(HttpContext context)
        {
            var host = string.Empty;
            var pathBase = string.Empty;
            var scheme = string.Empty;
            if (context == null)
            {
                host = this.Request?.Host.ToUriComponent();
                pathBase = this.Request.PathBase.ToUriComponent();
                scheme = this.Request.Scheme;
            }
            else
            {
                host = context.Request.Host.ToUriComponent();
                pathBase = context.Request.PathBase.ToUriComponent();
                scheme = context.Request.Scheme;
            }

            var baseUrl = $"{scheme}://{host}/{pathBase}";
            ViewBag.BaseUrl = baseUrl;
        }
    }
}