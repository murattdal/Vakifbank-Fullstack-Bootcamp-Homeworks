using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;



namespace Homework2_BookStore.Attributes
{
    public class AuthorizeFakeUserAttribute : TypeFilterAttribute
    {
        public AuthorizeFakeUserAttribute() : base(typeof(AuthorizeFakeUserFilter))
        {
        }
    }

    public class AuthorizeFakeUserFilter : IAuthorizationFilter
    {


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;
            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new UnauthorizedResult(); 
            }
        }

    }
}
