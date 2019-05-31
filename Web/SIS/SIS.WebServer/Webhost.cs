﻿namespace SIS.WebServer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using SIS.HTTP.Enums;
    using SIS.HTTP.Responses;
    using SIS.HTTP.Responses.Contracts;
    using SIS.WebServer.Attributes;
    using SIS.WebServer.Routing;
    using SIS.WebServer.Routing.Contracts;

    public static class Webhost
    {
        public static void Start(IMvcApplication application)
        {
            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();
            AutoRegisterRoutes(application, serverRoutingTable);
            application.ConfigureServices();
            application.Configure(serverRoutingTable);
            Server server = new Server(8000, serverRoutingTable);
            server.Run();
        }

        private static void AutoRegisterRoutes(IMvcApplication application, IServerRoutingTable serverRoutingTable)
        {
            var controllers = application.GetType().Assembly
                                .GetTypes()
                                .Where(type => type.IsClass 
                                        && !type.IsAbstract 
                                        && type.IsSubclassOf(typeof(Controller)));

            foreach (var controller in controllers)
            {
                var actions = controller
                    .GetMethods(BindingFlags.Public
                    | BindingFlags.DeclaredOnly
                    | BindingFlags.Instance)
                    .Where(m => !m.IsSpecialName
                    && m.DeclaringType == controller);

                foreach (var action in actions)
                {
                    var path = $"/{controller.Name.Replace("Controller", string.Empty)}/{action.Name}";
                    var attribute = action.GetCustomAttributes()
                        .Where(a => a.GetType().IsSubclassOf(typeof(BaseHttpAttribute))).LastOrDefault() as BaseHttpAttribute;

                    var httpMethod = HttpRequestMethod.Get;

                    if(attribute != null)
                    {
                        httpMethod = attribute.Method;
                    }

                    if(attribute?.Url != null)
                    {
                        path = attribute.Url;
                    }

                    if(attribute?.ActionName != null)
                    {
                        path = $"/{controller.Name.Replace("Controller", string.Empty)}/{attribute.ActionName}";
                    }

                    serverRoutingTable.Add(httpMethod, path, request =>
                    {
                        var controllerInstance = Activator.CreateInstance(controller);
                        var response = action.Invoke(controllerInstance, new[] { request }) as IHttpResponse;
                        return response;
                    });
                }

            }
        }
    }
}
