using Microsoft.Extensions.DependencyInjection;

namespace CachingSystem.CachingInMemory
{
    internal class InMemoryExample
    {
        internal void CacheExample()
        {
            var services = new ServiceCollection();

            services.AddMemoryCache();
            services.AddTransient<IMyService, MyService>();
            services.AddTransient<IMyService, MySecondService>();

            var sp = services.BuildServiceProvider();

            var myService = sp.GetServices<IMyService>().First(f => f.GetType().Equals(typeof(MyService)));
            var mySecondService = sp.GetServices<IMyService>().First(f => f.GetType().Equals(typeof(MySecondService)));

            var key = "MY_KEY";
            myService.StoreSomeData(key, "THIS IS A KEY");
            Console.WriteLine(mySecondService.RetrieveData<string>(key));
            myService.DeleteData(key);
            
            myService.StoreSomeData(key, new Key("THIS IS AN OBJECT KEY"));
            Console.WriteLine(mySecondService.RetrieveData<Key>(key));
        }
    }
}
