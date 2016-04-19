using System.Web.Mvc;

namespace Match.Areas.Match
{
    public class MatchAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Match";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Match_default",
                "Match/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
