using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.Models
{
    public class DoctorTeamLink
    {
        public int Id { get; set; }
        [MaxLength(300)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Icon { get; set; }

        [MaxLength(300)]
        public string Url { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

    }
}
