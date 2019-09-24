using System.Collections.Generic;
using ThomasExpressProducer.Data.Entity;
using ThomasExpressProducer.Data.Interfaces;

namespace ThomasExpressProducer.Data.Repository
{
    public class LocomotivaRepository : BaseRepository<Locomotive>, ILocomotivaRepository
    {
        public LocomotivaRepository(IThomasExpressContext context) : base(context) { }

        public List<Locomotive> GetLocomotives()
        {
            var sql = " SELECT * FROM LOCOMOTIVE";

            var response = GetEntities(sql);

            return response;
        }
    }
}
