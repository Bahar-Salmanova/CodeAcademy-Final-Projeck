using CodeClinic.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.Filters
{
    public class Auth : ActionFilterAttribute
    {
        private readonly ClinicDbContext _context;

        public Auth(ClinicDbContext context)
        {
            _context = context;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            bool hasToken = context.HttpContext.Request.Cookies.TryGetValue("token", out string token);

            if (!hasToken)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "login", controller = "user" }));
            }

            var user = _context.User.FirstOrDefault(u => u.Token == token);

            if (user == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "login", controller = "user" }));
            }

            context.RouteData.Values["User"] = user;

            base.OnActionExecuting(context);
        }
    }
}
