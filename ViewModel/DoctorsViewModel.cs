using CodeClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.ViewModel
{
    public class DoctorsViewModel
    {
        public List<Doctor> Doctors { get; set; }
        public List<DoctorTeamLink> DoctorTeamLinks { get; set; }

        public List<DoctorOpeningHours> DoctorOpeningHours { get; set; }
        public List<ClinicOpeningHours> ClinicOpeningHours { get; set; }
        public List<AppointmentTime> AppointmentTimes { get; set; }


        public List<PatientSay> PatientSay { get; set; }
        
        public List<AppointmentKind >AppointmentKind { get; set; }
        public List< Clients > Clients { get; set; }
        public BreadCrumbViewModel BreadCrumb { get; set; }
        public List< Randevu >Randevu { get; set; }
        public Randevu Randevus { get; set; }
        public AboutPasient AboutPasient { get; set; }








    }
}
