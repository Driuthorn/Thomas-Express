using System.Collections.Generic;
using ThomasExpressProducer.Data.Entity;
using ThomasExpressProducer.Data.Interfaces;

namespace ThomasExpressProducer.Data.Repository
{
    public class TerminalRepository : BaseRepository<Terminal>, ITerminalRepository
    {
        public TerminalRepository(IThomasExpressContext context) : base(context) { }

        public List<Terminal> GetTerminals()
        {
            var sql = "SELECT * FROM Terminal";

            var terminals = GetEntities(sql);

            return terminals;
        }
    }
}
