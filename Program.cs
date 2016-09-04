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

                var all = ctx.Set<MainEntity>().Where(e => e.Child.Text.Contains("hi")).ToArray();

                // also fails:
                //var all = ctx.Set<MainEntity>().Where(e => e.Child == null || e.Child.Text.Contains("hi")).ToArray();
            }
        }
    }
}
