using Business.Services.BoeReading;
using Business.Services.CompanyServ;
using Business.Services.DocumentBorme;
using Entities.DTOS;
using Microsoft.Extensions.DependencyInjection;
using Repository.BoeReadRep;
using Repository.CompanyRep;
using Repository.DocumentDBRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaGrupo10
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var services = new ServiceCollection();
            ConfigureServices(services);
            using (var serviveProvider = services.BuildServiceProvider())
            {
                var principalMDI = serviveProvider.GetRequiredService<PrincipalMDI>();
                Application.Run(principalMDI);
            }
         
        }
       
        //creamos la inyeccion de dependencias
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IBoeReadingServices, BoeReadingServices>()
                .AddScoped<IDocumentBormeServices,DocumentBormeServices>()
                .AddScoped<ICompanyServices, CompanyServices>()
                .AddScoped<ICompanyRepository, CompanyRepository>()
                .AddScoped<IBoeReadingRepository, BoeReadingRepository>()
                .AddScoped<IDocumentDBRepository<BOEReading>, DocumentDBRepository<BOEReading>>()
                .AddScoped<IDocumentDBRepository<Company>, DocumentDBRepository<Company>>()
                .AddScoped<PrincipalMDI>();

         
        }
    }
}
