using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.Models
{
    public class Clients
    {
        public int Id { get; set; }

        [MaxLength(300)]
        public string Photo { get; set; }
        [NotMapped]
        public IFormFile Upload { get; set; }

        [MaxLength(300)]
        public string Url { get; set; }
    }
}
