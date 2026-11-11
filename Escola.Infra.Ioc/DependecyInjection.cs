using Escola.Application.Interfaces;
using Escola.Application.Services;
using Escola.Domain.Interfaces;
using Escola.Infra.Data.Context;
using Escola.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Ioc
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, 
            IConfiguration configuration) 
        {
            //Aqui você pode resgistrar os serviços da camda de infraestrutura, como repositórios, serviços de email, etc

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), 
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            }
            );
            
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                   
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    //ValidIssuer, ValidAudience e IssuerSigningKey devem ser configurados no appsettings.json
                    //ValidIssuer é o emissor do token, ValidAudience é o público alvo do token e IssuerSigningKey é a chave secreta usada para assinar o token
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])),
                    ClockSkew = TimeSpan.Zero,
                };
            });

            services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<IMatriculaRepository, MatriculaRepository>();
            services.AddScoped<INotaRepository, NotaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<ICursoService, CursoService>();
            services.AddScoped<ITurmaService, TurmaService>();
            services.AddScoped<IMatriculaService, MatriculaService>();
            services.AddScoped<INotaService, NotaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();

            return services;
        }
    }
}
