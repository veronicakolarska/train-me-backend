namespace TrainMe.Common.Extensions
{
    using System.Security.Principal;

    public static class IdentityExtensions
    {
        public static bool IsAuthenticated(this IPrincipal principal)
        {
            return principal.Identity.IsAuthenticated;
        }

        public static string GetExternalId(this IPrincipal principal)
        {
            return principal.Identity.Name;
        }
    }
}
