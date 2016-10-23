
namespace Entegra.Common.Pages
{
    using Administration.Entities;
    using Serenity;
    using System;
    using System.Web.Mvc;

    [RoutePrefix("Dashboard"), Route("{action=index}")]
    public class DashboardController : Controller
    {
        [Authorize, HttpGet, Route("~/")]
        public ActionResult Index()
        {
            var cachedModel = TwoLevelCache.GetLocalStoreOnly("DashboardPageModel", TimeSpan.FromMinutes(5),
                UserRow.Fields.GenerationKey, () =>
                {
                    return new DashboardPageModel();
                });

            return View(MVC.Views.Common.Dashboard.DashboardIndex, cachedModel);
        }
    }
}