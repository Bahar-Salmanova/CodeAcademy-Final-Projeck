using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.Models
{
    public class Diseas
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string ShortAbout { get; set; }
        [NotMapped]
        public IFormFile Upload { get; set; }
        public string Photo { get; set; }


    }
}
