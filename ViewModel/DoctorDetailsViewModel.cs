using CodeClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.ViewModel
{
    public class DoctorDetailsViewModel
    {
        public  Doctor Doctors { get; set; }
        public List<Doctor> Doctor { get; set; }
        public List<DoctorTeamLink> DoctorTeamLinks { get; set; }
        public List<DoctorOpeningHours> DoctorOpeningHours { get; set; }
        public DoctorOpeningHours DoctorOpeningHourses { get; set; }
        public AboutPasient AboutPasient { get; set; }
        public List<Clients> Clients { get; set; }
        public BreadCrumbViewModel BreadCrumb { get; set; }

    }
}
