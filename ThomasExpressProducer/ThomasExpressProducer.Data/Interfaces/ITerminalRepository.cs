using System.Collections.Generic;
using ThomasExpressProducer.Data.Entity;

namespace ThomasExpressProducer.Data.Interfaces
{
    public interface ITerminalRepository
    {
        List<Terminal> GetTerminals();
    }
}
