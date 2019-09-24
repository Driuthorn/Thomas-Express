using System;

namespace ThomasExpressProducer.Data.Entity
{
    public class Terminal
    {
        public Guid Id { get; set; }
        public Guid StationId { get; set; }
        public string Name { get; set; }
    }
}
