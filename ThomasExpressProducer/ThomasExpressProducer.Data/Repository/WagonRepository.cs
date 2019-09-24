using System.Collections.Generic;
using ThomasExpressProducer.Data.Entity;
using ThomasExpressProducer.Data.Interfaces;

namespace ThomasExpressProducer.Data.Repository
{
    public class WagonRepository : BaseRepository<Wagon>, IWagonRepository
    {
        public WagonRepository(IThomasExpressContext context) : base(context) { }

        public List<Wagon> GetWagons()
        {
            var sql = "SELECT * FROM Wagon";

            var wagons = GetEntities(sql);

            return wagons;
        }
    }
}
