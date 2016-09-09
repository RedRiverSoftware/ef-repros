using System;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var ctx = new DemoContext())
            {
                var sp = ctx.GetInfrastructure<IServiceProvider>();
                var lf = sp.GetService<ILoggerFactory>();
                lf.AddConsole();

                var list = ctx.Set<Widget>()
                    .Select(m => new { Manufacturer = m.ManufacturedIdentity.Manufacturer.Name, GeoArea = m.GeoArea.Name })
                    .ToList();
            }
        }
    }
}
