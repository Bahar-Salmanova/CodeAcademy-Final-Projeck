using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.Models
{
    public class DoctorOpeningHours
    {
        public int Id { get; set; }

        public string Date { get; set; }
        public string Time { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
       


    }
}
