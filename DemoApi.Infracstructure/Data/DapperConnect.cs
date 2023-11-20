using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApi.Infracstructure.Data
{
    public class DapperConnect
    {
        private readonly IConfiguration _configuration;

        protected DapperConnect(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection()
        {
            var _connectString = _configuration.GetConnectionString("Connect");
            return new MySqlConnection(_connectString);
        }
    }
}
