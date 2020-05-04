using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using IdentityServer4.AccessTokenValidation;
using MultCo_ISD_API.Models;
using MultCo_ISD_API.Swagger;
using FluentValidation;
using FluentValidation.AspNetCore;

namespace MultCo_ISD_API
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
			services.AddMvc()
				.AddFluentValidation(); // Add Fluent Validation 

			var connection = @"Server = localhost; Database = InternalServicesDirectoryV1; Trusted_Connection = True;";
			services.AddDbContext<InternalServicesDirectoryV1Context>(options => options.UseSqlServer(connection));
			services.AddControllers();

			// register validator(s):
			services.AddTransient<IValidator<Contact>, V1.Validators.ContactValidator>(); 
			services.AddTransient<IValidator<Community>, V1.Validators.CommunityValidator>(); 
			services.AddTransient<IValidator<Division>, V1.Validators.DivisionValidator>(); 
			services.AddTransient<IValidator<Language>, V1.Validators.LanguageValidator>(); 
			services.AddTransient<IValidator<LocationType>, V1.Validators.LocationTypeValidator>(); 
			services.AddTransient<IValidator<Location>, V1.Validators.LocationValidator>(); 
			services.AddTransient<IValidator<ServiceCommunityAssociation>, V1.Validators.ServiceCommunityAssociationValidator>(); 
			services.AddTransient<IValidator<Program>, V1.Validators.ProgramValidator>(); 
			services.AddTransient<IValidator<ServiceLanguageAssociation>, V1.Validators.ServiceLanguageAssociationValidator>(); 
			services.AddTransient<IValidator<Department>, V1.Validators.DepartmentValidator>(); 
			services.AddTransient<IValidator<ServiceLocationAssociation>, V1.Validators.ServiceLocationAssociationValidator>(); 
			services.AddTransient<IValidator<Service>, V1.Validators.ServiceValidator>(); 


			services.AddSwaggerService();

#if AUTH
			// JWT Token Auth with IdentityServer4
			services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
				.AddIdentityServerAuthentication(o =>
				{
					o.Authority = Configuration["IdentityServerSettings:Uri"];
					o.ApiName = Configuration["IdentityServerSettings:Scope"];
					o.RequireHttpsMetadata = true;
					o.EnableCaching = true;
					o.CacheDuration = TimeSpan.FromMinutes(30);
				});


			// Example Scope Policies with a simple read or write
			services.AddAuthorization(o =>
			{
				o.AddPolicy("Writer", p =>
				{
					p.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
					p.RequireAuthenticatedUser();
					p.RequireScope("mult-co-isd-api.write");
				});
				o.AddPolicy("Reader", p =>
				{
					p.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
					p.RequireAuthenticatedUser();
					p.RequireScope("mult-co-isd-api.read");
				});
			});
#endif

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseSwaggerService();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
