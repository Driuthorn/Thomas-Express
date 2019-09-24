using System.Data;

namespace ThomasExpressProducer.Data.Interfaces
{
    public interface IThomasExpressContext
    {
        IDbConnection GetDbConnection();
    }
}
