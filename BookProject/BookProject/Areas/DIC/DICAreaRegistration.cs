using System.Web.Mvc;

namespace Class2.Areas.DIC
{
    public class DICAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "DIC";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "DIC_default",
                "DIC/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
