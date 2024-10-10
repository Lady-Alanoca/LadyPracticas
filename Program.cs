using System;
using Microsoft.AspNetCore.Builder; // Agregar esta directiva
using Microsoft.AspNetCore.Hosting; // Asegúrate de que esta directiva esté presente
using Microsoft.AspNetCore.Http; // Agregar esta directiva
using Microsoft.Extensions.Hosting;

namespace ladyPractica
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Crear y ejecutar el host de la aplicación
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Configurar el puerto en el que la aplicación escuchará
                    webBuilder.UseStartup<Startup>()
                              .UseUrls("http://*:5000"); // Cambia el número de puerto si es necesario
                });
    }

    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async context =>
            {
                await context.Response.WriteAsync("¡Hola Mundo!... desde DOCKER...");
            });
        }
    }
}


