using CodeClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.ViewModel
{
    public class AboutViewModel
    {
        public ResearchClinic ResearchClinic { get; set; }
        public List<Spesialities > Spesialities { get; set; }
        
        public List<ClinicOpeningHours> ClinicOpeningHours { get; set; }

        public GetAppointment GetAppointment { get; set; }

        public List<Doctor> Doctors { get; set; }
        public List<DoctorTeamLink> DoctorTeamLinks { get; set; }
        public List<PatientSay> PatientSays { get; set; }

        public List<Clients> Clients { get; set; }
        public BreadCrumbViewModel BreadCrumb { get; set; }
        public AboutPasient AboutPasient { get; set; }




    }
}
