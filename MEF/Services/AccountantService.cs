using MEFApp.Interfaces;
using MEFBaseLibrary;
using Microsoft.AspNetCore.Hosting;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Runtime.Loader;

namespace MEFApp.Services
{
    public class AccountantService : IAccountantService
    {
        [System.Composition.Import("ICalculateVAT")]
        public ICalculateVAT CalculateVAT { get; set; }

        private readonly IWebHostEnvironment _env;

        public AccountantService(IWebHostEnvironment env)
        {
            _env = env;
            Compose();
        }

        private void Compose()
        {
            var pluginAssemblies = Directory.GetFiles(Path.Combine(_env.ContentRootPath, "plugins"), "*.dll", SearchOption.TopDirectoryOnly)
                .Select(AssemblyLoadContext.Default.LoadFromAssemblyPath)
                .Where(s => s.GetTypes().Any(p => typeof(ICalculateVAT).IsAssignableFrom(p)));

            var configuration = new ContainerConfiguration().WithAssemblies(pluginAssemblies);

            using (var container = configuration.CreateContainer())
            {
                CalculateVAT = container.GetExports<ICalculateVAT>().FirstOrDefault();
            }
        }


        public decimal CalcVat(decimal amount)
        {
            return CalculateVAT.CalcVAT(amount);
        }
    }
}
