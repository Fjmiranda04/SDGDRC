using GeneralLedger.SelfServiceCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeneralLedger.SelfService.Web.Controllers
{
    public class BaseController : Controller
    {
        private readonly IHttpContextAccessor contextAccessor;

        public BaseController(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
            ConnectionTools.SetKeyConnectionString(this.contextAccessor.HttpContext.User.Identity.Name);
        }
    }
}