﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nop.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Reflection;
using Nop.Plugin.InstantSearch.ActionFilters;
using Nop.Plugin.InstantSearch.Helpers;
using Nop.Plugin.InstantSearch.Services.Catalog;
using Nop.Plugin.InstantSearch.Services.Helpers;
using Nop.Plugin.InstantSearch.Theme;
using Nop.Plugin.InstantSearch.ViewLocations;
using Nop.Services.Media;
using Nop.Services.Configuration;

namespace Nop.Plugin.InstantSearch.Infrastructure
{
    public class NopStartup : INopStartup
    {
        public int Order => 3000;
        public void Configure(IApplicationBuilder application)
        {
           
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IInstallHelper, InstallHelper>();
            services.AddScoped<IViewLocationsManager, ViewLocationsManager>();
            services.AddScoped<IAccessControlHelper, AccessControlHelper>();
            services.AddScoped<GlobalActionFiltersProvider>();
            services.AddScoped<ICategoryService7Spikes, CategoryService7Spikes>();
            services.AddScoped<IAclHelper, AclHelper>();
            services.AddScoped<IThemeService, ThemeService>();
            services.AddScoped<IPictureService, PictureService>();
            services.AddScoped<ISettingService, SettingService>();
            // services.AddControllersWithViews().AddRazorRuntimeCompilation();
            //services.AddControllersWithViews();




        }

            private T GetServiceFromCollection<T>(IServiceCollection services) => (T)services.LastOrDefault<ServiceDescriptor>((Func<ServiceDescriptor, bool>)(d => d.ServiceType == typeof(T)))?.ImplementationInstance;
        
    
    }
}
