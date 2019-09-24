using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ThomasExpressProducer.Data.Interfaces;

namespace ThomasExpressProducer.Data.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IThomasExpressContext _context;

        public BaseRepository(IThomasExpressContext context)
        {
            _context = context;
        }

        public List<TEntity> GetEntities (string sql)
        {
            var dbConnection = _context.GetDbConnection();

            using(var cn = dbConnection)
            {
                if (dbConnection.State != ConnectionState.Open) dbConnection.Open();
                var response = dbConnection.Query<TEntity>(sql);

                return response.ToList();
            }
        }
    }
}
