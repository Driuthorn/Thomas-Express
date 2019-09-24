using Serilog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ThomasExpressProducer.Data.Interfaces;

namespace ThomasExpressProducer.Data.Context
{
    public class ThomasExpressContext : IThomasExpressContext
    {
        private readonly ILogger _log;
        private IDbConnection _dbConnection;

        public ThomasExpressContext(ILogger log, string connectionString)
        {
            _log = log;
            OpenDatabaseConnection(connectionString);
        }

        public IDbConnection GetDbConnection() => _dbConnection;

        private void OpenDatabaseConnection(string connectionString)
        {
            try
            {
                _log.Information("Establishing database connection.");
                _dbConnection = new SqlConnection(connectionString);
                _log.Information("Database connection established.");
            }
            catch (Exception ex)
            {
                _log.Error($"Error at opening database connection. Exception: {ex}");
            }
        }
    }
}
