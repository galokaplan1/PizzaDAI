using System.Data.SqlClient;
using Microsft.Extensions.Configuration;
using System.IO;
using System;

namespace Pizzas.API.Helpers{

    public class ConfigurationHelp{

        public static Iconfiguration GetConfiguration(){
            Iconfiguration config;
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJson("appsettings.json",optional : true , reloadOnCharge:true);
                config=builder.Build();
                return config;
           
            } 

        }

    }