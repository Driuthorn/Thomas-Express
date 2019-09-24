using System.Collections.Generic;
using ThomasExpressProducer.Data.Entity;
using ThomasExpressProducer.Data.Interfaces;

namespace ThomasExpressProducer.Data.Repository
{
    public class TrainRepository : BaseRepository<Train>, ITrainRepository
    {
        public TrainRepository(IThomasExpressContext context) : base(context) { }

        public List<Train> GetTrains()
        {
            var sql = "SELECT * FROM Trains";

            var trains = GetEntities(sql);

            return trains;
        }
    }
}
