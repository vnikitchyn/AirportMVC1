﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AirportMVC1.Startup))]
namespace AirportMVC1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
