using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace WebApplication1.Filtros
{
    public class AutorizacaoFilterAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var usu = context.HttpContext.Session.GetString("usuario");
            if (usu == null)
            {
                //redirecionar para /Usuario/Login
                var routeValues = new RouteValueDictionary(new
                {
                    area = "",
                    controller = "Usuario",
                    action = "Login"
                });
                context.Result = new RedirectToRouteResult(routeValues);
            }
        }
    }
}
