using Phonebook.Common.Commands;
using Phonebook.Common.Events;
using Phonebook.Common.RabbitMq;
using Phonebook.Common.Services;
using System.Threading.Tasks;

namespace Phonebook.Services.Entry
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }
        public async static Task MainAsync(string[] args)
        {
            await ServiceHost.Create<Startup>(args)
                .UseRabbitMq()
                .SubscribeToCommand<xEntry>()
                .Build()
                .Run();
        }
    }
}
