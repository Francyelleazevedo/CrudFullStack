using Dominio.Interfaces;
using Infra.Conexao;
using Infra.Repositorio;
using Api.Dto;
using CadastroCliente.Classes;
using CadastroCliente.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Api
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
            services.AddCors();
            var server = Configuration["database:mysql:server"];
            var port = Configuration["database:mysql:port"];
            var database = Configuration["database:mysql:database"];
            var username = Configuration["database:mysql:username"];
            var password = Configuration["database:mysql:password"];
            services.AddControllers();
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(@"data source=DESKTOP-F3DQKQC;initial catalog=DEV-FULLSTACK;TrustServerCertificate=True;Integrated Security=SSPI", opt =>
                {
                    opt.MigrationsAssembly("Api");
                    opt.CommandTimeout(180);
                    opt.EnableRetryOnFailure(5); //testar 5 vezes
                });
            });

            services.AddScoped<IRepository<Cliente>, Repository<Cliente>>();
            services.AddScoped<IService<Cliente>, BaseServiceCliente<Cliente>>();

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<CreateClienteDto, Cliente>();
                config.CreateMap<Cliente, ClienteDto>();
                config.CreateMap<ClienteDto, Cliente>();
            }).CreateMapper());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
            builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
