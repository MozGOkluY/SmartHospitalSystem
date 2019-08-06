using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace SmartHospitalSystem.Api
{
    /// <summary>
	/// Start class
	/// </summary>
    public class Program
    {
        /// <summary>
		/// Entry point
		/// </summary>
		/// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
		/// Host builder
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
