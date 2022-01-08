using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aplicatie_web.Models
{
    public class Programare
    {
        public int ID { get; set; }

        [Required, StringLength(150, MinimumLength = 3)]
        [Display(Name = "Nume Client")]
        
        public string NumeClient { get; set; }
        public string PrenumeClient { get; set; }
        public string Animal { get; set; }

        [Range(1, 300)]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }

        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public string SalonID { get; set; }
        public Salon Salon { get; set; }
        public ICollection<ProgramareCategory> ProgramareCategories { get; set; }
    }
}
