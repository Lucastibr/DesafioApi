using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using src.Services;


namespace src
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // services.AddCors();
            services.AddMemoryCache();
            //Aqui adicionamos a injeção de dependência, pois senão daria conflito nas requisições.
            services.AddScoped<IPessoaService, PessoaService>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseRouting();
            app.UseHttpsRedirection();
            // app.UseCors( builder => builder.AllowAnyMethod()
            //                         .AllowAnyOrigin()
            //                         // .AllowCredentials()
            //                         // .AllowAnyHeader()

            app.UseAuthorization();
            app.UseCors(option => option.AllowAnyOrigin());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
