using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.Models
{
    public class GetAppointment
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string About { get; set; }

        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Call { get; set; }

        //[MaxLength(200)]
        //public string Phone { get; set; }

        [MaxLength(200)]
        public string Photo { get; set; }
    }
}
