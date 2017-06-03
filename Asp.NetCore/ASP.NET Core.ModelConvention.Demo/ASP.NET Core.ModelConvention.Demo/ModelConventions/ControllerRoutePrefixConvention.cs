using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace ASP.NETCore.ModelConvention.Demo.ModelConventions
{
    public class ControllerRoutePrefixConvention : IControllerModelConvention
    {
        private readonly AttributeRouteModel _routePrefix = new AttributeRouteModel(new RouteAttribute("api/v1"));
        public void Apply(ControllerModel controller) {
            foreach (var selector in controller.Selectors) {
                if (selector.AttributeRouteModel==null) {
                    selector.AttributeRouteModel = _routePrefix;
                }
                else {
                    selector.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(_routePrefix, selector.AttributeRouteModel);
                }
            }
        }
    }
}
