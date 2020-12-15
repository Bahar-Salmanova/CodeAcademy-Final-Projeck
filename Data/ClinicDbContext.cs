using CodeClinic.Models;
using CodeClinic.Models.HomePage;

using Microsoft.EntityFrameworkCore;

namespace CodeClinic.Data
{
    public class ClinicDbContext : DbContext
    {
        public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options)
        { 
        
        }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<SosialLinks> SosialLinks { get; set; }
        public DbSet<WelcomeClinic> WelcomeClinics { get; set; }
        public DbSet<Promo> Promos { get; set; }
        public DbSet<AppointmentKind> AppointmentKind { get; set; }
        public DbSet<Checkup> Checkups { get; set; }
        public DbSet<CheckupSetting> CheckupSettings { get; set; }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Departments> Departments { get; set; }

        public DbSet<DiaqnosticServis> DiaqnosticServis { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
    

        public DbSet<DoctorTeamLink> DoctorTeamLinks { get; set; }
        public DbSet<GetAppointment> GetAppointments { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<DoctorOpeningHours> DoctorsOpeningHours { get; set; }
        public DbSet<ClinicOpeningHours> ClinicOpeningHours { get; set; }

        public DbSet<OurPatients> OurPatients { get; set; }

        public DbSet<PatientSay> PatientSays { get; set; }
        public DbSet<ResearchClinic> ResearchClinics { get; set; }
        
        public DbSet<SettingLast> SettingLasts { get; set; }
        public DbSet<Spesialities> Spesialities { get; set; }
        public DbSet<AppointmentTime> AppointmentTimes { get; set; }
        public DbSet<Diseas> Diseases { get; set; }
        public DbSet<Randevu> Randevu { get; set; }
        public DbSet<AboutPasient> AboutPasients { get; set; }
        public DbSet<User> User { get; set; }







    } 
    

}
