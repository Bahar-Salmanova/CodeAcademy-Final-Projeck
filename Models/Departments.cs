using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.Models
{
    public class Departments
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(300)]
        public string Photo { get; set; }
        [NotMapped]
        public IFormFile Upload { get; set; }


        [MaxLength(300)]
        public string Icon { get; set; }

        [MaxLength(1000)]
        public string About { get; set; }
        public string ShortAbout { get; set; }

        public ICollection<Doctor> Doctors { get; set; }
        public ICollection<Randevu> Randevu { get; set; }




    }
}
