using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplicatie_web.Models
{
    public class Salon
    {
  
public int ID { get; set; }
        public string NumarSalon { get; set; }
        public ICollection<Programare> Programari { get; set; }
    }
}
