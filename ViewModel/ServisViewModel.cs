using CodeClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.ViewModel
{
    public class ServisViewModel
    {
        public List<DiaqnosticServis> DiaqnosticServis { get; set; }
        public GetAppointment GetAppointment { get; set; }
        public List<Spesialities> Spesialities { get; set; }
        public List<PatientSay> PatientSays { get; set; }
        public List<Clients> Clients { get; set; }
        public BreadCrumbViewModel BreadCrumb { get; set; }

    }
}
