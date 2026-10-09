namespace MoviesAdmin.Routes
{
    public static class catlogsRoute
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapControllerRoute(
                name: "Default",
                template: "catlogs/{action=Index}/{id?}",
                defaults: new { controller = "catlogs" }
            );
        }
    }
}