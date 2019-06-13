using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phonebook.Common.Commands;
using Phonebook.Common.Events;
using Phonebook.Common.Mongo;
using Phonebook.Common.RabbitMq;
using Phonebook.Services.Entry.Domain.Repositories;
using Phonebook.Services.Entry.Domain.Services;
using Phonebook.Services.Entry.Handlers;
using Phonebook.Services.Entry.Repositories;
using Phonebook.Services.Entry.Services;

namespace Phonebook.Services.Entry
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMongoDb(Configuration);
            services.AddRabbitMq(Configuration);
            services.AddScoped<ICommandHandler<xEntry>, InsertEntryHandler>();
            services.AddScoped<IEntryRepository, EntryRepository>();
            services.AddScoped<IEntryService, EntryService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
