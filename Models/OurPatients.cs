using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.Models
{
    public class OurPatients
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Icon { get; set; }

        [MaxLength(300)]
        public string Title { get; set; }
        [MaxLength(500)]
        public string Decs { get; set; }
    }
}
