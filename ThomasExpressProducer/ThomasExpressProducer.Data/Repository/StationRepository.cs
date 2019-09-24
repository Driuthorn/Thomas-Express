using System.Collections.Generic;
using ThomasExpressProducer.Data.Entity;
using ThomasExpressProducer.Data.Interfaces;

namespace ThomasExpressProducer.Data.Repository
{
    public class StationRepository : BaseRepository<Station>, IStationRepository
    {
        public StationRepository(IThomasExpressContext context) : base(context) { }

        public List<Station> GetStations()
        {
            var sql = "SELECT * FROM Station";

            var stations = GetEntities(sql);

            return stations;
        }
    }
}
