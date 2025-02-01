using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

var constructor = WebApplication.CreateBuilder(args);

constructor.Services.AddControllers();

var webApp = constructor.Build();

webApp.UseRouting();

webApp.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

webApp.Run();
