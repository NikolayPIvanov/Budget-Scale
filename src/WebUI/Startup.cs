using AutoMapper;
using BudgetScale.Application.Accounts.Commands;
using BudgetScale.Application.Accounts.Models.Output;
using BudgetScale.Application.Categories.Commands.CreateCommand;
using BudgetScale.Application.Categories.Models.Output;
using BudgetScale.Application.Groups.Commands.CreateCommand;
using BudgetScale.Application.Groups.Models.Output;
using BudgetScale.Application.Groups.Queries.GetGroup;
using BudgetScale.Application.Infrastructure;
using BudgetScale.Application.Requests.Models.Output;
using BudgetScale.Domain.Entities;
using BudgetScale.Infrastructure.Extensions;
using BudgetScale.Infrastructure.Filters;
using BudgetScale.Infrastructure.Middlewares.Authentication;
using BudgetScale.Persistence;
using BudgetScale.Persistence.Infrastructure;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using BudgetScale.Application.Accounts.Commands.CreateCommand;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(action =>
                {
                    action.ReturnHttpNotAcceptable = true;
                    action.Filters.Add(new ValidationFilter());
                })
                .AddFluentValidation(fv =>
                {
                    fv.RegisterValidatorsFromAssemblyContaining<CreateGroupCommandValidator>();
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Configuration["JwtTokenValidation:Secret"]));

            services.Configure<TokenProviderOptions>(options =>
            {
                options.Audience = this.Configuration["JwtTokenValidation:Audience"];
                options.Issuer = this.Configuration["JwtTokenValidation:Issuer"];
                options.Path = "/api/users/login";
                options.Expiration = TimeSpan.FromDays(15);
                options.SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            });

            //services.AddTransient(typeof(IRequestAbstraction<Group,GroupViewModel>),typeof(MapEntityRequest<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(GetGroupQueryHandler).GetTypeInfo().Assembly);

            services
               .AddAuthentication()
               .AddJwtBearer(opts =>
               {
                   opts.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = signingKey,
                       ValidateIssuer = true,
                       ValidIssuer = this.Configuration["JwtTokenValidation:Issuer"],
                       ValidateAudience = true,
                       ValidAudience = this.Configuration["JwtTokenValidation:Audience"],
                       ValidateLifetime = true,
                   };
               });

            services
             .AddIdentity<ApplicationUser, IdentityRole>(options =>
             {
                 options.Password.RequiredLength = 6;
                 options.Password.RequireDigit = false;
                 options.Password.RequireLowercase = false;
                 options.Password.RequireNonAlphanumeric = false;
                 options.Password.RequireUppercase = false;
             })
             .AddDefaultUI()
                .AddRoles<IdentityRole>()
                .AddUserManager<UserManager<ApplicationUser>>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddSingleton(this.Configuration);

            services.AddAuthorization(
                options =>
                {
                    options.AddPolicy("Administrator",
                        policy => policy
                            .RequireClaim(ClaimTypes.Role, "Administrator"));
                });

            services.AddAutoMapper(config =>
            {

                config.CreateMap<Category, CategoryViewModel>()
                    .ForMember(p => p.CategoryId, src => src.MapFrom(d => d.CategoryId))
                    .ForMember(p => p.CategoryName, src => src.MapFrom(d => d.CategoryName));

                config.CreateMap<CreateCategoryCommand, Category>();

                config.CreateMap<LongRequest, RequestViewModel>()
                    .ForMember(p => p.Time, src => src.MapFrom(d => d.Time.ToShortDateString()));

                config.CreateMap<Account, AccountsViewModel>()
                    .ForMember(e => e.AccountType, src => src.MapFrom(d => d.AccountType.ToString("G")));

                config.CreateMap<Category, CategoryViewModel>();
                config.CreateMap<CreateGroupCommand, Group>();
                config.CreateMap<Group, GroupViewModel>();
                config.CreateMap<CreateAccountCommand, Account>()
                    .ForMember(dest => dest.AccountType,
                        src => src.MapFrom(d => (AccountType)(Enum.Parse(typeof(AccountType), d.AccountType))));
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                dbContext.Database.EnsureCreated();

                ApplicationDbContextSeeder.Seed(dbContext, serviceScope.ServiceProvider);
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            context.Response.AddApplicationError(error.Error.Message);
                            await context.Response.WriteAsync(error.Error.Message);
                        }
                    });
                });

                //app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            //Disable this
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            //GDPR middleware
            app.UseFeaturePolicy();

            app.UseJwtBearerTokens(app.ApplicationServices
                .GetRequiredService<IOptions<TokenProviderOptions>>(), PrincipalResolver);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.UseDefaultFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501
                spa.Options.SourcePath = "ClientApp";
                spa.UseAngularCliServer(npmScript: "start");
            });
        }

        private static async Task<GenericPrincipal> PrincipalResolver(HttpContext context)
        {
            var email = context.Request.Form["email"];

            var userManager = context.RequestServices.GetRequiredService<UserManager<ApplicationUser>>();

            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return null;
            }

            var password = context.Request.Form["password"];

            var isValidPassword = await userManager.CheckPasswordAsync(user, password);
            if (!isValidPassword)
            {
                return null;
            }

            var roles = await userManager.GetRolesAsync(user);

            var identity = new GenericIdentity(email, "Token");
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));

            return new GenericPrincipal(identity, roles.ToArray());
        }
    }
}
