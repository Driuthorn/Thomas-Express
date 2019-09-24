using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasExpressProducer.Data.Entity
{
    public class Train
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public Guid LocomotiveId { get; set; }
        public List<Wagon> Wagons { get; set; }
    }
}
