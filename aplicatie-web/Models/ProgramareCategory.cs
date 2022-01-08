using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplicatie_web.Models
{
    public class ProgramareCategory
    {
        public int ID { get; set; }
        public int ProgramareID { get; set; }
        public Programare Programare { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
