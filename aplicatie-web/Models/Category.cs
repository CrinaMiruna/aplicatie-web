using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aplicatie_web.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<ProgramareCategory> ProgramareCategories { get; set; }
    }
}
