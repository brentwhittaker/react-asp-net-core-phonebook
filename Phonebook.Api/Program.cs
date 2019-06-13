using Phonebook.Common.Events;
using Phonebook.Common.Services;
using System.Threading.Tasks;

namespace Phonebook.Api
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
                .SubscribeToEvent<EntryCreated>()
                .Build()
                .Run();
        }


    }
}
