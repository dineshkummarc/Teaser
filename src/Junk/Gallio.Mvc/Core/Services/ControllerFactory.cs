using System;
using System.Web.Mvc;
using StructureMap;
using System.Web.Routing;

namespace Stable.Core.Services
{
	public class ControllerFactory : DefaultControllerFactory
	{ 
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			if (controllerType == null)
				return null;

			var controller = ObjectFactory.GetInstance(controllerType);

			return (IController)controller;
		}
	}
}