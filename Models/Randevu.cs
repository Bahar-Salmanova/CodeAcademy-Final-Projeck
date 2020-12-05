using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.Models
{
    public class Randevu
    {
        public int Id { get; set; }
        public string PasientName { get; set; }
        public string Time { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(2000)]
        public string Message { get; set; }
        public int DepartmentsId { get; set; }
        public Departments Departments { get; set; }

    }
}
