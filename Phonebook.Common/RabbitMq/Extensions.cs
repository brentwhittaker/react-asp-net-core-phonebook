using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phonebook.Common.Commands;
using Phonebook.Common.Events;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.Configuration.Exchange;
using RawRabbit.Instantiation;
using RawRabbit.Pipe.Middleware;
using RawRabbit.Subscription;
using System.Reflection;
using System.Threading.Tasks;

namespace Phonebook.Common.RabbitMq
{
    public static class Extensions
    {
        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus,
            ICommandHandler<TCommand> handler) where TCommand : ICommand
            => bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
                context => context.UseConsumeConfiguration(
                    config => config.FromQueue(GetQueueName<TCommand>())
                ));

        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus,
            IEventHandler<TEvent> handler) where TEvent : IEvent
            => bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
                context => context.UseConsumeConfiguration(
                    config => config.FromQueue(GetQueueName<TEvent>())
                ));

        private static string GetQueueName<T>()
            => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";

        public static void AddRabbitMq(this IServiceCollection services, IConfiguration config)
        {
            var options = new RawRabbitConfiguration();
            var section = config.GetSection("rabbitmq");
            section.Bind(options);
            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            {
                ClientConfiguration = options
            });
            services.AddSingleton<IBusClient>(_ => client);
        }
    }
}
