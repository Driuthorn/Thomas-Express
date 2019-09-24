using System.Collections.Generic;
using ThomasExpressProducer.Data.Entity;

namespace ThomasExpressProducer.Data.Interfaces
{
    public interface ITrainRepository
    {
        List<Train> GetTrains();
    }
}
