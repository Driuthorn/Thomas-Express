using System;
using ThomasExpressProducer.Data.Enum;

namespace ThomasExpressProducer.Data.Entity
{
    public class Wagon
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public CargoType Cargo { get; set; }
        public int Capacity { get; set; }
    }
}
