using CodeClinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeClinic.ViewModel
{
    public class AllDepartmentViewModel
    {
        public List<Departments> Departments { get; set; }
        public Departments Department { get; set; }
        public List<Clients> Clients { get; set; }
        public BreadCrumbViewModel BreadCrumb { get; set; }
    }
}
