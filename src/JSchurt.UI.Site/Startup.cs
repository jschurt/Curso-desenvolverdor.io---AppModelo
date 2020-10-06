using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JSchurt.UI.Site.Data;
using JSchurt.UI.Site.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace JSchurt.UI.Site
{
    public class Startup
    {

        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Setando MVC - .NetCore 3.1
            services.AddControllersWithViews();

            //Setando DbContext (EnityFramework)
            services.AddDbContext<MeuDbContext>(option => {
                option.UseSqlServer(_configuration.GetConnectionString("MeuDbContext"));
            });


            services.AddTransient<IPedidoRepository, PedidoRepository>();

            //Criando injecoes dependencia teste
            
            //Scoped. Mantem o mesmo valor para todo o request
            //NA WEB, COM .NET MVC, .NET CORE, USE SCOPED! (MELHOR OPCAO PARA UMA APLICACAO WEB)
            services.AddScoped<IOperacaoScoped, Operacao>();

            //Singleton. Uma vez criado, vai ser o mesmo para toda a aplicacao, isto eh, para todos os usuarios enquanto a aplicacao
            //estiver rodando. (MAIS PERFORMATICA MAS ARRISCADO COMPARTILHAR O MESMO OBJETO EM TODA A APLICACAOA)
            services.AddSingleton<IOperacaoSingleton, Operacao>();
            services.AddSingleton<IOperacaoSingletonInstance>(new Operacao(Guid.Empty));

            //Transient. Sempre que houver uma injecao, uma nova instancia eh criada.
            //SE NAO SOUBER O QUE USAR, USE TRANSIENTE! (POREM USA MAIS MEMORIA, NAO EH PERFORMATICO)
            services.AddTransient<IOperacaoTransient, Operacao>();
            services.AddTransient<OperacaoService>();


        } //ConfigureServices

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            //Config for .Net 3.1
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

            });


            //Config for .Net 2.1
            /*
            app.UseMvc(routes => {

                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            
            });
            */


        }
    }
}
