﻿namespace SIS
{
    using HTTP.Enums;
    using Controllers;
    using WebServer;
    using WebServer.Routing;
    using WebServer.Routing.Contracts;
    using SIS.HTTP.Requests;

    public class Launcher
    {
        public static void Main(string[] args)
        {
            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Add(HttpRequestMethod.Get, "/", request => new HomeController().Index(request));

            Server server = new Server(8080, serverRoutingTable);

            server.Run();
        }
    }
}