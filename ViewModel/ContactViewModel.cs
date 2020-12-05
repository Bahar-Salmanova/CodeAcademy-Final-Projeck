using CodeClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.ViewModel
{
    public class ContactViewModel
    {
        public List<Clients> Clients { get; set; }
        public Settings Settings { get; set; }
        public List<SettingLast> SettingLasts { get; set; }
        public BreadCrumbViewModel BreadCrumb { get; set; }

    }
}
