using ServiceParcela;

namespace ServiceParcela
{
    /// <summary>
    /// Program
    /// </summary>
    ///
    public class Program
    {
        /// <summary>
        /// Program
        /// </summary>
        ///
        protected Program()
        {

        }
        /// <summary>
        /// Main
        /// </summary>
        ///
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        /// <summary>
        /// CreateHostBuilder
        /// </summary>
        ///
        public static IHostBuilder CreateHostBuilder(string[] args) =>
              Host.CreateDefaultBuilder(args)
                  .ConfigureWebHostDefaults(webBuilder =>
                  {
                      webBuilder.UseStartup<Startup>();
                  });
    }
}



