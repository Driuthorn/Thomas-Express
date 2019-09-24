using System;

namespace ThomasExpressProducer.Data.Entity
{
    public class TrainWagon
    {
        public Guid TrainId { get; set; }
        public Guid WagonId { get; set; }
        public int Quantity { get; set; }
    }
}
