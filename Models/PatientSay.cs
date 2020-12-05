using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.Models
{
    public class PatientSay
    {
        public int Id { get; set; }

        [MaxLength(500)]
        public string Desc { get; set; }

        [MaxLength(200)]
        public string Photo { get; set; }
        [NotMapped]
        public IFormFile Upload { get; set; }

        [MaxLength(200)]
        public string FullName { get; set; }

        [MaxLength(200)]
        public string Position { get; set; }
    }
}
