using AutoMapper;
using AutoglassTest.Application.Models;
using AutoglassTest.Domain.Entities;
using AutoglassTest.Domain.Interfaces;
using AutoglassTest.Infra.Data.Context;
using AutoglassTest.Infra.Data.Repository;
using AutoglassTest.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Logging;

namespace AutoglassTest.Application
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

            var connection = Configuration["ConexaoSqlite:SqliteConnectionString"];
            services.AddDbContext<SqliteContext>(options =>
                options.UseSqlite(connection)
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
            );

            services.AddScoped<IBaseRepository<Produto>, ProdutoRepository<Produto>>();
            services.AddScoped<IBaseService<Produto>, BaseService<Produto>>();
            services.AddScoped<IBaseRepository<Fornecedor>, BaseRepository<Fornecedor>>();
            services.AddScoped<IBaseService<Fornecedor>, BaseService<Fornecedor>>();

            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<ProdutoViewModel, Produto>();
                config.CreateMap<Produto, ProdutoViewModel>()
                    .ForMember(dest => dest.DescricaoFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Descricao))
                    .ForMember(dest => dest.CNPJFornecedor, opt => opt.MapFrom(src => src.Fornecedor.CNPJ)
                );
            }).CreateMapper());


            services.AddSwaggerGen();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Autoglass Swagger Test",
                    Description = "My Autoglass Test! By Raphael Bandeira",
                });
            });

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Autoglass Swagger Test");
            });
        }
    }
}
