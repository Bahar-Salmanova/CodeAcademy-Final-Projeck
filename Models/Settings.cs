using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.Models
{
    public class Settings
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Logo { get; set; }
        [NotMapped]
        public IFormFile Upload { get; set; }

        [MaxLength(200)]
        public string Adress { get; set; }

        //public string Icon { get; set; }

        public string OpenDate { get; set; }

        public string ClosedDate { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Phone { get; set; }
       
    }
}
