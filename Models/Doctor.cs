using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string FullName { get; set; }

        [MaxLength(400)]
        public string Education { get; set; }

        [MaxLength(300)]
        public string Speciality { get; set; }

        [MaxLength(300)]
        public string Experience { get; set; }

        [MaxLength(300)]
        public string Address { get; set; }

        [MaxLength(400)]
        public String Timing { get; set; }

        [MaxLength(300)]
        public string Phone { get; set; }

        [MaxLength(300)]
        public string Email { get; set; }

        [MaxLength(400)]
        public string Website { get; set; }

        [MaxLength(700)]
        public string About { get; set; }

        [MaxLength(200)]
        public string Photo { get; set; }
        [NotMapped]
        public IFormFile Upload { get; set; }

        [MaxLength(200)]
        public string Position { get; set; }

        public ICollection<DoctorTeamLink> DoctorTeamLinks { get; set; }
       


        public int DepartmentsId{ get; set; }

        public Departments Departments { get; set; }


        public ICollection<DoctorOpeningHours> DoctorOpeningHours { get; set; }




        public bool IsHome { get; set; } = false;
    }
}
