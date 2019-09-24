using System.Collections.Generic;
using ThomasExpressProducer.Data.Entity;

namespace ThomasExpressProducer.Data.Interfaces
{
    public interface IWagonRepository
    {
        List<Wagon> GetWagons();
    }
}
