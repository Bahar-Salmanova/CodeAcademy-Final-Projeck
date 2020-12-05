using CodeClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.ViewModel
{
    public class DepartmentDetailsViewModel
    {
        public List<Departments> Departments { get; set; }
        public List<DoctorOpeningHours> DoctorOpeningHours { get; set; }
        public DoctorOpeningHours DoctorOpeningHourses { get; set; }
        public Departments Department { get; set; }
        public List<Clients> Clients { get; set; }
        public BreadCrumbViewModel BreadCrumb { get; set; }
        public Doctor Doctor { get; set; }

    }
}
