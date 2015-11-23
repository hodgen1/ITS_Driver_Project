using System.Web;
using System.Web.Routing;

namespace ITSDriverApplication
{
    public class IncomingRequestConstraint : IRouteConstraint  
    {  
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {  
            return routeDirection==RouteDirection.IncomingRequest;  
        }  
    }  
}
