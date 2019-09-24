using System;

namespace ThomasExpressProducer.Data.Entity
{
    public class Locomotive
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Power { get; set; }
        public int TopSpeed { get; set; }
        public int TractiveEffort { get; set; }
        public int Weight { get; set; }
    }
}
