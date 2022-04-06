using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pizzas.API.Models;
using System.Data.SqlClient;
using Dapper;

namespace Pizzas.API.Utils
{
    public class BD{
        
        public static string getConnection(){
            string _connectionstring=@"Server=A-CEO-12;Database=Base;Trusted_Connection=True;";
            return _connectionstring;
            //Hay que hacer lo de que conecte al helper y dsps tmb se hace los stored procedure
        }
        
    }

}