using CodeClinic.Models;
using CodeClinic.Models.HomePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.ViewModel
{
    public class HomeViewModel
    {
        public List<WelcomeClinic> WelcomeClinic { get; set; }
        public List<Promo> Promo { get; set; }
        public ResearchClinic ResearchClinic { get; set; }
        public List<DiaqnosticServis> DiaqnosticServis { get; set; }
        public List<Doctor> Doctors { get; set; }
        public GetAppointment GetAppointment { get; set; }
        public List<Spesialities> Spesialities { get; set; }
        public List<PatientSay> PatientSays { get; set; }
        public List<Checkup> Checkups { get; set; }
        public List<CheckupSetting> CheckupSettings { get; set; }
        public List<News> News { get; set; }
        public List<Clients> Clients { get; set; }
        public List<DoctorTeamLink> DoctorTeamLinks { get; set; }
        public Settings Settings { get; set; }
        public SettingLast SettingLast { get; set; }
        


    }
}
