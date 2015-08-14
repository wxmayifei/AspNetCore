﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNet.Builder;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Localization;

namespace LocalizationWebSite
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddViewLocalization();

            // Adding TestStringLocalizerFactory since ResourceStringLocalizerFactory uses ResourceManager. DNX does
            // not support getting non-enu resources from ResourceManager yet.
            services.AddSingleton<IStringLocalizerFactory, TestStringLocalizerFactory>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCultureReplacer();

            app.UseRequestLocalization();
            
            app.UseMvcWithDefaultRoute();
        }
    }
}
